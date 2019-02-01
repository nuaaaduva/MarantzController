using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MrSmarty.CodeProject
{
    public class MyHook : IDisposable
    {

        [DllImport("Hook.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern int HookKeyBoard(IntPtr hwnd);

        [DllImport("Hook.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern int HookMouse(IntPtr hwnd);

        [DllImport("Hook.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern int UnHook();

        //[StructLayout(LayoutKind.Sequential)]
        //public class Msg
        //{
        //    public IntPtr hwnd;
        //    public uint message;
        //    public IntPtr wParam;
        //    public int lParam;
        //    public int time;
        //    public POINT pt;
        //}

        public enum HookType
        {
            OnlyMouse,
            OnlyKeyboard,
            MouseAndKeyboard,
        }

        private Win32.MSG msg;

        const int WH_KEYBOARD_LL = 13;
        const int WH_MOUSE_LL = 14;
        const int WM_MYMSG = 0x400 + 101;
        const int WM_MOUSEWHEEL = 0x20A;
        const int WM_CLOSE = 0x10;
        const int WM_HOTKEY = 0x312;

        private bool disposing = false;
        private bool disposed = false;

        private Thread thread;
        private IntPtr hwnd = IntPtr.Zero;
        private HookType hookType;
        private Form frm;

        public MyHook()
        {
            thread = new Thread(Hook);
        }

        private void ProcessMsg()
        {
            try
            {
                while (Win32.User.GetMessage(ref msg, IntPtr.Zero, 0, 0) != 0)
                {
                    Win32.User.TranslateMessage(ref msg);
                    Win32.User.DispatchMessage(ref msg);
                }
            }
            catch (ThreadAbortException)
            {

            }
            catch
            {
                throw;
            }
            finally
            {
                UnHook();
            }
        }

        private void Hook()
        {
            switch (hookType)
            {
                case HookType.MouseAndKeyboard:
                    HookKeyBoard(hwnd);
                    HookMouse(hwnd);
                    break;
                case HookType.OnlyKeyboard:
                    HookKeyBoard(hwnd);
                    break;
                case HookType.OnlyMouse:
                    HookMouse(hwnd);
                    break;
            
            }
            try
            {
                //创建一个窗口以使消息能够正常循环
                frm = new Form();
                frm.ShowInTaskbar = false;
                frm.Opacity = 0;
                frm.Width = frm.Height = 0;
                frm.Left = -1;
                frm.ShowDialog();
            }
            catch(ThreadAbortException)
            { }
            catch { }
            finally
            {
                UnHook();
            }
        }

        public void SetHook(IntPtr handle,HookType hookType)
        {
            this.hwnd = handle;
            this.hookType = hookType;
            if (thread.ThreadState != ThreadState.Running)
            {
                thread.Start();
            }
        }

        public void SetUnhook()
        {
            thread.Abort();
        }
        public void Dispose()
        {
            if(!disposing && !disposed)
            {
                disposing = true;
                if (thread.ThreadState == ThreadState.Running) thread.Abort();
                if (frm!= null && !frm.IsDisposed) frm.Dispose();
                disposing = false;
                disposed = true;
            }
        }
    }
}
