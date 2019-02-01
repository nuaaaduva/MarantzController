using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using Microsoft.Win32;

namespace MrSmarty.CodeProject
{
    public partial class Form1 : DevComponents.DotNetBar.Metro.MetroForm
    {

        [DllImport("user32.dll")]
        static extern bool RegisterHotKey(IntPtr hWnd, int id, int modifiers, Keys vk);
        [DllImport("user32.dll")]
        static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        //[DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        //static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);

        //// 卸下钩子的函数
        //[DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        //static extern bool UnhookWindowsHookEx(int idHook);

        //// 下一个钩挂的函数
        //[DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        //static extern int CallNextHookEx(int idHook, int nCode, int wParam, IntPtr lParam);

        [DllImport("Hook.dll",CallingConvention = CallingConvention.Cdecl)]
        static extern int HookKeyBoard(IntPtr hwnd);

        [DllImport("Hook.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern int HookMouse(IntPtr hwnd);

        [DllImport("Hook.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern int UnHook();

        const int WH_KEYBOARD_LL = 13;
        const int WH_MOUSE_LL = 14;
        const int WM_MYMSG = 0x400 + 101;
        const int WM_MOUSEWHEEL = 0x20A;
        const int WM_CLOSE = 0x10;
        const int WM_HOTKEY = 0x312;

        [StructLayout(LayoutKind.Sequential)] //声明键盘钩子的封送结构类型 
        public class KeyboardHookStruct
        {
            public int vkCode; //表示一个在1到254间的虚似键盘码 
            public int scanCode; //表示硬件扫描码 
            public int flags;
            public int time;
            public int dwExtraInfo;
        }

        /// <summary>
        /// 钩子结构体
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public class MouseHookStruct
        {
            public POINT pt;
            public int hWnd;
            public int wHitTestCode;
            public int dwExtraInfo;
            public int mouseData;
        }

        [StructLayout(LayoutKind.Sequential)]
        public class MouseLLHookStruct
        {
            public POINT pt;
            public int mouseData;
            public int flags;
            public int time;
            public int dwExtraInfo;
        }

        int keyid = 10;
        Dictionary<int, MyCommand> CommandPairs = new Dictionary<int, MyCommand>();
        public void Regist(MyCommand cmd)
        {
            int id = keyid++;
            if (!RegisterHotKey(this.Handle, id, (int)cmd.Keys.Modifiers, (Keys)cmd.Keys.KeyCode))
            {
                MessageBox.Show("快捷键" + cmd.Keys.ToString() + "注册失败！\r\n" + new Win32Exception().Message);
            }
            else
            {
                CommandPairs.Add(id, cmd);
            }
        }

        public Form1()
        {
            InitializeComponent();
            //new Thread(() =>
            //{
                form = new OSDMessageWindow();
            //    form.Show();
            //}).Start();
        }

        delegate int HookProc(int nCode, int wParam, IntPtr lParam);
        //HookProc /*KeyHookProc,*/ mouseHookProc;


        //int _keyHookId;
        //int _mouseHookId;
        List<MyCommand> UpCommand = new List<MyCommand>();
        List<MyCommand> DownCommand = new List<MyCommand>();
        List<MyCommand> LButtonCommand = new List<MyCommand>();
        List<MyCommand> RButtonCommand = new List<MyCommand>();
        List<MyCommand> MButtonCommand = new List<MyCommand>();





        MyCommand PowerCmd = new MyCommand();
        MyCommand MuteCmd = new MyCommand();
        MyCommand VolUpCmd = new MyCommand();
        MyCommand VolDownCmd = new MyCommand();

        private void DoCommand(MyCommand cmd)
        {
            if(cmd != null)
            {
                if(cmd == VolUpCmd)
                {
                    string mvstr = ((volmu + Settings.CurrentSetting.VolStep) > 980 ? 980 : (volmu + Settings.CurrentSetting.VolStep)).ToString().Trim('0');
                    if (mvstr.Length == 1) mvstr += '0';
                    netClient1.Send("MV" + mvstr);
                }
                else if(cmd == VolDownCmd)
                {
                    string mvstr = ((volmu - Settings.CurrentSetting.VolStep) < 0 ? 0 : (volmu - Settings.CurrentSetting.VolStep)).ToString().Trim('0');
                    if (mvstr.Length == 1) mvstr += '0';
                    netClient1.Send("MV" + mvstr);
                }
                else if(cmd == PowerCmd)
                {
                    string status = btnPower.Checked ? "OFF" : "ON";
                    netClient1.Send("ZM" + status + "\r");
                }
                else if(cmd == MuteCmd)
                {
                    string status = btnMute.Checked ? "OFF" : "ON";
                    netClient1.Send("MU" + status + "\r");
                }
                else
                {
                    netClient1.Send(cmd.CmdBytes + "\r");
                }
            }
        }

        MyHook myHook = new MyHook();
        protected override void WndProc(ref Message m)
        {
            //if (Enum.IsDefined(typeof(MESSAGE), m.Msg))
            //{
            //    Debug.Print(((MESSAGE)m.Msg).ToString());
            //}
            if (m.Msg == Win32.User.WM_SYSCOMMAND && (int)m.WParam == Win32.User.SC_CLOSE)
            {
                this.Hide();
            }
            else
            {
                if(m.Msg == WM_HOTKEY)
                {
                    int id = m.WParam.ToInt32();
                    DoCommand(CommandPairs[id]);
                }
                else if(m.Msg == Win32.User.WM_CREATE)
                {
                    myHook.SetHook(this.Handle, MyHook.HookType.OnlyMouse);
                }
                else if(m.Msg == Win32.User.WM_DESTROY || m.Msg == Win32.User.WM_QUIT || m.Msg == Win32.User.WM_CLOSE)
                {
                    netClient1.DisConnect();
                    myHook.SetUnhook();
                    notifyIcon1.Visible = false;
                    Application.Exit();
                }
                else if(m.Msg == WM_MYMSG)
                {

                    if ((int)m.WParam == WM_MOUSEWHEEL)
                    {
                        MouseLLHookStruct mouse = (MouseLLHookStruct)Marshal.PtrToStructure(m.LParam, typeof(MouseLLHookStruct));
                        short delta = (short)(mouse.mouseData >> 16);
                        if (delta > 0)
                        {
                            foreach (var key in UpCommand)
                            {
                                if (key.Keys.KeyModifiers == Control.ModifierKeys)
                                {
                                    DoCommand(key);
                                }
                            }
                        }
                        else
                        {
                            foreach (var key in DownCommand)
                            {
                                if (key.Keys.KeyModifiers == Control.ModifierKeys)
                                {
                                    DoCommand(key);
                                }
                            }
                        }
                    }
                    else if((int)m.WParam == Win32.User.WM_LBUTTONDOWN)
                    {
                        foreach (var key in LButtonCommand)
                        {
                            if (key.Keys.KeyModifiers == Control.ModifierKeys)
                            {
                                DoCommand(key);
                            }
                        }
                    }
                    else if((int)m.WParam == Win32.User.WM_RBUTTONDOWN)
                    {
                        foreach (var key in RButtonCommand)
                        {
                            if (key.Keys.KeyModifiers == Control.ModifierKeys)
                            {
                                DoCommand(key);
                            }
                        }
                    }
                    else if((int)m.WParam == Win32.User.WM_MBUTTONDOWN)
                    {
                        foreach (var key in MButtonCommand)
                        {
                            if (key.Keys.KeyModifiers == Control.ModifierKeys)
                            {
                                DoCommand(key);
                            }
                        }
                    }
                }
                base.WndProc(ref m);
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
        }

        OSDMessageWindow form;
        private void netClient1_TextReceived(object sender, string text)
        {
            List<string> msgs = new List<string>();
            int v = -1;
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action<object, string>(netClient1_TextReceived), sender, text);
                }
                else
                {
                    foreach (string txtarg in text.Split(new char[] { '.', '\r', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        try
                        {
                            if (txtarg.StartsWith("ZMON")/* || text.Contains("PWON")*/)
                            {
                                btnPower.ImageOptions.Image = Properties.Resources.poweron;
                                btnPower.Checked = true;
                                btnVDown.Enabled = btnVPlus.Enabled = btnMute.Enabled = checkCD.Enabled = checkMPlayer.Enabled = checkTuner.Enabled = true;
                                dropCustomCmd.Enabled = Settings.CurrentSetting.Commands != null && Settings.CurrentSetting.Commands.Count > 0;
                                msgs.Add("电源开启");
                            }
                            else if (txtarg.StartsWith("ZMOFF")/* || text.Contains("PWSTANDBY")*/)
                            {
                                btnPower.ImageOptions.Image = Properties.Resources.poweroff;
                                btnPower.Checked = false;
                                btnVDown.Enabled = btnVPlus.Enabled = btnMute.Enabled = dropCustomCmd.Enabled = checkCD.Enabled = checkMPlayer.Enabled = checkTuner.Enabled = false;
                                msgs.Add("电源关闭");
                            }
                            else if (txtarg.StartsWith("MUON"))
                            {
                                btnMute.Checked = true;
                                msgs.Add("静音开启");
                            }
                            else if (txtarg.StartsWith("MUOFF"))
                            {
                                btnMute.Checked = false;
                                msgs.Add("静音关闭");
                            }
                            else if (txtarg.StartsWith("SI"))
                            {
                                checkTuner.Checked = checkCD.Checked = checkMPlayer.Checked = false;
                                if (txtarg.Contains("SITUNER"))
                                {
                                    checkTuner.Checked = true;
                                    msgs.Add("输入源：TUNER");
                                }
                                else if (txtarg.Contains("SICD"))
                                {
                                    checkCD.Checked = true;
                                    msgs.Add("输入源：CDPLayer");
                                }
                                else if (txtarg.Contains("SIMPLAY"))
                                {
                                    checkMPlayer.Checked = true;
                                    msgs.Add("输入源：MPlayer");
                                }
                                else
                                {
                                    msgs.Add("输入源：" + txtarg.Substring(2));
                                }
                            }
                            else if (txtarg.StartsWith("MV"))
                            {
                                if (txtarg.Contains("MVMAX"))
                                {

                                }
                                else
                                {
                                    StringBuilder builder = new StringBuilder();
                                    for (int i = txtarg.IndexOf("MV") + 2; i < txtarg.Length; i++)
                                    {
                                        if (txtarg[i] >= '0' && txtarg[i] <= '9')
                                        {
                                            builder.Append(txtarg[i]);
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                    v = int.Parse(builder.ToString());
                                    if (builder.Length == 2) v *= 10;
                                    volmu = v;
                                    //form.ShowMessage(Properties.Resources.volume, v, 980);
                                    //form.ShowMessage(Properties.Resources.volume, v, 980);// (v, 980);
                                }
                            }
                            else
                            {
                                bool flag = false;
                                foreach (var item in Settings.CurrentSetting.DefStats)
                                {
                                    if (item.IsRegex && Regex.IsMatch(txtarg, item.Cmd))
                                    {
                                        try
                                        {
                                            var match = Regex.Match(txtarg, item.Cmd);
                                            msgs.Add(match.Result(item.Status));
                                            flag = true;
                                        }
                                        catch
                                        {
                                            msgs.Add("正则错误" + item.Status);
                                            flag = true;
                                        }
                                    }
                                    else if (txtarg.StartsWith(item.Cmd))
                                    {
                                        msgs.Add(item.Status);
                                        flag = true;
                                    }
                                }
                                if (!flag && Settings.CurrentSetting.ShowUndef)
                                {
                                    msgs.Add("未定义：" + txtarg);
                                }
                            }
                        }
                        catch
                        { }
                    }
                }
            }
            finally
            {
                string str = null;
                if(msgs.Count > 0)
                {
                    str = msgs[0];
                    for(int i = 1; i < msgs.Count; i ++)
                    {
                        str += " " + msgs[i];
                    }
                }
                if(v != -1 && !string.IsNullOrEmpty(str))
                {
                    form.ShowMessage(str, Properties.Resources.volume, v);
                }
                else if(!string.IsNullOrEmpty(str))
                {
                    form.ShowMessage(str);
                }
                else if(v != -1)
                {
                    form.ShowMessage(Properties.Resources.volume, v);
                }
            }
        }

        int volmu = 800;
        public class MyCheckButton:CheckButton
        {
            public override void Toggle()
            {
                //Checked = !Checked;
            }
        }

        private void 退出EToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 显示主界面MToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }
        FrmSet frmset = new FrmSet();

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            frmset.Settings = Settings.CurrentSetting;
            if (frmset.ShowDialog() == DialogResult.OK)
            {
                string oriip = Settings.CurrentSetting.RemoteHost;
                int oriport = Settings.CurrentSetting.RemotePort;
                bool oristart = Settings.CurrentSetting.Startup;
                Settings.CurrentSetting = frmset.Settings;
                Settings.CurrentSetting.WriteToXml();
                if (oriip != frmset.Settings.RemoteHost || oriport != frmset.Settings.RemotePort)
                {
                    netClient1.DisConnect();
                    timer1_Tick(null, null);
                }
                else
                {
                    netClient1_DisConnected(null, null);
                    netClient1_Connected(null, null);
                }
                if (oristart != Settings.CurrentSetting.Startup)
                {
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
                            MessageBox.Show(ee.Message.ToString(), "写入启动键失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            loca.Close();
                        }
                    }
                    else
                    {
                        string starupPath = Application.ExecutablePath;
                        RegistryKey loca = Registry.LocalMachine;
                        RegistryKey run = loca.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
                        try
                        {
                            //SetValue:存储值的名称
                            run.DeleteValue("MarantzController");
                        }
                        catch(Exception ee)
                        {
                            MessageBox.Show(ee.Message.ToString(), "删除启动键失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            loca.Close();
                        }
                    }
                }
            }
        }

        private void RegestCmd(params MyCommand[] cmds)
        {
            foreach(var cmd in cmds)
            {
                RegestCmd(cmd);
            }
        }

        private void RegestCmd(IEnumerable<MyCommand> cmds)
        {
            foreach (var cmd in cmds)
            {
                RegestCmd(cmd);
            }
        }
        private void RegestCmd(MyCommand cmd)
        {
            if (cmd != null && cmd.Keys != null)
            {
                if ((int)cmd.Keys.KeyCode > 4 && (int)cmd.Keys.KeyCode < 0x101)
                {
                    Regist(cmd);
                }
                else
                {
                    switch (cmd.Keys.KeyCode)
                    {
                        case MyKeys.LButton:
                            LButtonCommand.Add(cmd);
                            break;
                        case MyKeys.RButton:
                            RButtonCommand.Add(cmd);
                            break;
                        case MyKeys.MButton:
                            MButtonCommand.Add(cmd);
                            break;
                        case MyKeys.WheelUp:
                            UpCommand.Add(cmd);
                            break;
                        case MyKeys.WheelDown:
                            DownCommand.Add(cmd);
                            break;
                    }
                }
            }
        }


        private void netClient1_LoseConnected(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<object, EventArgs>(this.netClient1_LoseConnected), sender, e);
            }
            else
            {
                foreach (Control item in this.Controls)
                {
                    item.Enabled = false;
                }
                btnSet.Enabled = btnExit.Enabled = true;
                foreach (int id in CommandPairs.Keys)
                {
                    UnregisterHotKey(this.Handle, id);
                }
                UpCommand.Clear();
                DownCommand.Clear();
                LButtonCommand.Clear();
                RButtonCommand.Clear();
                MButtonCommand.Clear();
                CommandPairs.Clear();
                barManager1.Items.Clear();
                popupMenuInput.LinksPersistInfo.Clear();
            }
        }

        private void btnPower_Click(object sender, EventArgs e)
        {
            if (!btnPower.Checked)
            {
                //netClient1.Send("PWON\r");
                netClient1.Send("ZMON\r");
            }
            else
            {
                //netClient1.Send("PWSTANDBY\r");
                netClient1.Send("ZMOFF\r");
            }
        }

        private void netClient1_DisConnected(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<object, EventArgs>(this.netClient1_DisConnected), sender, e);
            }
            else
            {
                foreach (Control item in this.Controls)
                {
                    item.Enabled = false;
                }
                btnSet.Enabled = btnExit.Enabled = true;
                foreach (int id in CommandPairs.Keys)
                {
                    UnregisterHotKey(this.Handle, id);
                }
                UpCommand.Clear();
                DownCommand.Clear();
                LButtonCommand.Clear();
                RButtonCommand.Clear();
                MButtonCommand.Clear();
                CommandPairs.Clear();
                barManager1.Items.Clear();
                popupMenuInput.LinksPersistInfo.Clear();
            }

        }

        private void netClient1_Connected(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<object, EventArgs>(netClient1_Connected),sender,e);
            }
            else
            {
                btnPower.Enabled = true;
                QueryStatus();
                var settings = Settings.CurrentSetting;
                PowerCmd.Keys = settings.Power;
                MuteCmd.Keys = settings.Mute;
                VolUpCmd.Keys = settings.VolUP;
                VolDownCmd.Keys = settings.VolDown;
                RegestCmd(PowerCmd, MuteCmd, VolUpCmd, VolDownCmd);
                RegestCmd(settings.Commands);
                int id = 1;
                foreach (var cmd in settings.Commands)
                {
                    BarButtonItem item = new BarButtonItem()
                    {
                        Id = id++,
                        Caption = cmd.Name,
                        Name = cmd.Name,
                        Tag = cmd.CmdBytes,
                    };
                    item.ImageOptions.Image = cmd.Image;
                    item.ItemClick += Item_ItemClick;
                    barManager1.Items.Add(item);
                    popupMenuInput.AddItem(item);
                }
            }
        }

        private void Item_ItemClick(object sender, ItemClickEventArgs e)
        {
            string str = (e.Item as BarButtonItem).Tag as string;
            netClient1.Send(str + "\r");
        }

        /// <summary>
        /// 查询功放状态信息
        /// </summary>
        private void QueryStatus()
        {
            if (netClient1.Status == NetClient.NetStatus.Connected)
            {
                netClient1.Send("PW?\r");
                netClient1.Send("ZM?\r");
                netClient1.Send("MV?\r");
                netClient1.Send("MU?\r");
                netClient1.Send("SI?\r");
            }
        }

        private void btnVPlus_Click(object sender, EventArgs e)
        {
            string mvstr = ((volmu + Settings.CurrentSetting.VolStep) > 980 ? 980 : (volmu + Settings.CurrentSetting.VolStep)).ToString().Trim('0');
            if (mvstr.Length == 1) mvstr += '0';
            netClient1.Send("MV" + mvstr);
        }

        private void btnVDown_Click(object sender, EventArgs e)
        {
            string mvstr = ((volmu - Settings.CurrentSetting.VolStep) < 0 ? 0 : (volmu - Settings.CurrentSetting.VolStep)).ToString().Trim('0');
            if (mvstr.Length == 1) mvstr += '0';
            netClient1.Send("MV" + mvstr);
        }

        private void dropInputSwitch_Click(object sender, EventArgs e)
        {
            popupMenuInput.ShowPopup(MousePosition);
        }

        private void btnMute_Click(object sender, EventArgs e)
        {
            if (btnMute.Checked)
            {
                netClient1.Send("MUOFF\r");
            }
            else
            {
                netClient1.Send("MUON\r");
            }
        }

        private void 设置SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            simpleButton1_Click(null, null);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(Settings.CurrentSetting.RemoteHost) 
                && Settings.CurrentSetting.RemotePort != 0 
                && netClient1.Status != NetClient.NetStatus.Connected
                && netClient1.Status != NetClient.NetStatus.Connecting)
            {
                netClient1.ConnectSync(Settings.CurrentSetting.RemoteHost, Settings.CurrentSetting.RemotePort);
            }
        }

        private void dropCustomCmd_ArrowButtonClick(object sender, EventArgs e)
        {
            popupMenuInput.ShowPopup(this.PointToScreen(new Point(dropCustomCmd.Right,dropCustomCmd.Bottom)));
        }

        private void checkTuner_Click(object sender, EventArgs e)
        {
            netClient1.Send("SITUNER\r");
        }

        private void checkCD_Click(object sender, EventArgs e)
        {
            netClient1.Send("SICD\r");
        }

        private void checkMPlayer_Click(object sender, EventArgs e)
        {
            netClient1.Send("SIMPLAY\r");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            form.ShowMessage("启动成功");
        }
    }
}