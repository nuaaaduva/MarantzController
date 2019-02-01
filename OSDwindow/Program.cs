using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Drawing;
using Microsoft.Win32;

namespace MrSmarty.CodeProject
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            new System.Threading.Mutex(true, "Marlanz_Controller", out bool runone);
            if (runone)
            {

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);


                var set = Settings.LoadFromXML();
                if (set != null)
                {
                    Settings.CurrentSetting = set;
                }

                if (Settings.CurrentSetting.Startup)
                {
                    string starupPath = Application.ExecutablePath;
                    RegistryKey loca = Registry.LocalMachine;
                    RegistryKey run = loca.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
                    try
                    {
                        //SetValue:存储值的名称
                        run.SetValue("MarantzController", string.Format("\"{0}\" /s", starupPath));
                    }
                    catch (Exception ee)
                    {
                        MessageBox.Show(ee.Message.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        run.Close();
                        loca.Close();
                    }
                }


                //Application.Run(new Demo());
               

                Form1 frm = new Form1();
                frm.Opacity = 0.01;
                frm.Show();
                if (args.Length != 0 && (args.Contains("/s") || args.Contains("-s")))
                {
                    frm.Hide();
                }
                frm.Opacity = 1;

                Application.ThreadException += Application_ThreadException;
                Application.Run();
            }
            else
            {
                MessageBox.Show("应用程序已经启动！");
            }
        }


        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            MessageBox.Show("发生错误：" + e.Exception.Message + "\r\n" + e.Exception.Source + "\r\n" + e.Exception.StackTrace);
        }
    }
}