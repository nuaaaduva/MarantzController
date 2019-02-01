using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace MrSmarty.CodeProject
{
    [Serializable]
    public class Settings
    {
        public static Settings CurrentSetting;

        static Settings()
        {
            CurrentSetting = new Settings();
        }


        public static Settings LoadFromXML()
        {
            try
            {
                System.IO.FileStream stream = new System.IO.FileStream(Application.StartupPath + "\\config.xml", System.IO.FileMode.Open);
                var setting = XmlUtil.Deserialize<Settings>(stream);
                stream.Close();
                return setting;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "配置文件加载失败\r\n");
                return null;
            }
        }

        public void WriteToXml()
        {
            try
            {
                System.IO.File.WriteAllText(Application.StartupPath + "\\config.xml", XmlUtil.Serializer<Settings>(this));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "配置文件保存失败");
            }
        }

        public string RemoteHost { get; set; } = "127.0.0.1";

        public int RemotePort { get; set; } = 23;

        public bool Startup { get; set; } = true;

        public HotKey Power { get; set; }

        public HotKey VolUP { get; set; }

        public HotKey VolDown { get; set; }

        public HotKey Mute { get; set; }

        public List<MyCommand> Commands { get; set; } = new List<MyCommand>();

        public int VolStep { get; set; } = 5;

        public bool ShowUndef { get; set; } = false;

        public List<StatsDef> DefStats { get; set; } = new List<StatsDef>();

    }

    [XmlInclude(typeof(System.Drawing.Image))]
    [XmlInclude(typeof(System.Drawing.Bitmap))]
    [Serializable]
    public class MyCommand 
    {
        [Required]
        public string Name { get; set; }

        public HotKey Keys { get; set; }
        [XmlIgnore]
        public Image Image
        {
            get
            {
                if (ImageBytes != null)
                    return Image.FromStream(new MemoryStream(ImageBytes));
                else
                    return null;
            }
            set
            {
                if (value == null) ImageBytes = null;
                else
                {
                    using(MemoryStream stream = new MemoryStream())
                    {
                        value.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                        ImageBytes = new byte[stream.Length];
                        stream.Seek(0, SeekOrigin.Begin);
                        stream.Read(ImageBytes, 0, ImageBytes.Length);
                    }
                }
            }
        }
        
        public byte[] ImageBytes { get; set; }

        [Required]
        public string CmdBytes { get; set; }
    }


    [Serializable]
    public class HotKey
    {
        public HotkeyModifiers Modifiers { get; set; }

        public MyKeys KeyCode { get; set; }

        public override string ToString()
        {
            return string.Format("{0}{1}{2}{3}", (Modifiers & HotkeyModifiers.Control) == HotkeyModifiers.Control ? "Ctrl + " : "",
                (Modifiers & HotkeyModifiers.Alt) == HotkeyModifiers.Alt ? "Alt + " : "",
                (Modifiers & HotkeyModifiers.Shift) == HotkeyModifiers.Shift ? "Shift + " : "",
                KeyCode);
        }

        [System.Xml.Serialization.XmlIgnore]
        public bool Alt { get => (Modifiers & HotkeyModifiers.Alt) == HotkeyModifiers.Alt; }

        [System.Xml.Serialization.XmlIgnore]
        public bool Ctrl { get => (Modifiers & HotkeyModifiers.Control) == HotkeyModifiers.Control; }

        [System.Xml.Serialization.XmlIgnore]
        public bool Shift { get => (Modifiers & HotkeyModifiers.Shift) == HotkeyModifiers.Shift; }

        [System.Xml.Serialization.XmlIgnore]
        public Keys KeyModifiers
        {
            get
            {
                return (Keys)((Shift ? 0x10000 : 0) + (Ctrl ? 0x20000 : 0) + (Alt ? 0x40000 : 0));
            }
        }
    }

    [Serializable]
    public class StatsDef
    {
        public string Cmd { get; set; }

        public string Status { get; set; }

        public bool IsRegex { get; set; }
    }

    [Flags]
    public enum HotkeyModifiers
    {
        Alt = 1,
        Control = 2,
        Shift = 4,
        Win = 8
    }

}
