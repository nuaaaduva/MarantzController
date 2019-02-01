using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MrSmarty.CodeProject
{
    public class OSDMessageWindow : Form
    {
        System.Windows.Forms.Timer _viewClock;
        readonly FloatingWindow.AnimateMode _mode = FloatingWindow.AnimateMode.Blend;
        readonly uint _time = 100;
        MyOSD osd = new MyOSD(); 
        Font font = new Font("微软雅黑", 14f,FontStyle.Bold);


        IntPtr safehandle;
        public OSDMessageWindow()
        {
            osd.Alpha = 180;
            safehandle = this.Handle;
            this.Load += OSDMessageWindow_Load;
            //this.Width = this.Height = 0;
            ////this.Opacity = 0;
            //this.Left = -100;
        }

        private void OSDMessageWindow_Load(object sender, EventArgs e)
        {
            
        }

        //public void HideWindow()
        //{
        //    ViewTimer(null,null);
        //    this.Dispose();
        //    GC.Collect();
        //}
        private class MyOSD:FloatingWindow
        {
            public Bitmap Bitmap { get; set; }

            protected override void PerformPaint(PaintEventArgs e)
            {
                if (Bitmap != null)
                {
                    e.Graphics.DrawImage(Bitmap, 0, 0);
                }
            }
        }
        
        protected void ViewTimer(object sender, System.EventArgs e)
        {
            this._viewClock.Stop();
            this._viewClock.Dispose();
            if (this._time > 0)
                osd.HideAnimate(this._mode, this._time);
            this.Close();
        }

        public void ShowMessage(String message)
        {
            
            SizeF textArea;
            using (Bitmap bb = new Bitmap(600, 200))
            {
                using (Graphics g = Graphics.FromImage(bb))
                {
                    textArea = g.MeasureString(message, font);
                }
            }
            Size baseSize = new Size((int)Math.Ceiling(textArea.Width), (int)Math.Ceiling(textArea.Height));
            osd.Bitmap = new Bitmap(baseSize.Width + 60, 60);
            using (Graphics g = Graphics.FromImage(osd.Bitmap))
            {
                g.FillRectangle(Brushes.Black, g.ClipBounds);
                g.DrawString(message, font, Brushes.White, 30, 30 - baseSize.Height / 2);
            }
            ShowWindow();
            
        }

        public void ShowMessage(String message,Image image)
        {
            SizeF textArea;
            using (Bitmap bb = new Bitmap(600, 200))
            {
                using (Graphics g = Graphics.FromImage(bb))
                {
                    textArea = g.MeasureString(message, font);
                }
            }
            Size baseSize = new Size((int)Math.Ceiling(textArea.Width), (int)Math.Ceiling(textArea.Height));
            Bitmap b = new Bitmap(image, 32, 32);
            osd.Bitmap = new Bitmap(baseSize.Width + 102, 60);
            using (Graphics g = Graphics.FromImage(osd.Bitmap))
            {
                g.FillRectangle(Brushes.Black, g.ClipBounds);
                g.DrawImage(b, 30, 14);
                g.DrawString(message, font, Brushes.White, 72, 30 - baseSize.Height / 2);
            }
            ShowWindow();
        }

        public void ShowMessage(string message,Image image, int value,int maxvalue = 980)
        {
            SizeF textArea;
            using (Bitmap bb = new Bitmap(600, 200))
            {
                using (Graphics g = Graphics.FromImage(bb))
                {
                    textArea = g.MeasureString(message, font);
                }
            }
            Size baseSize = new Size((int)Math.Ceiling(textArea.Width), (int)Math.Ceiling(textArea.Height));
            Bitmap b = new Bitmap(image, 32, 32);
            osd.Bitmap = new Bitmap(baseSize.Width + 432, 60);
            int vwidth = 320 * value / maxvalue;
            using (Graphics g = Graphics.FromImage(osd.Bitmap))
            {
                g.FillRectangle(Brushes.Black, g.ClipBounds);
                g.DrawImage(b, 30, 14);
                g.FillRectangle(Brushes.White, 72, 22, 320, 16);
                g.FillRectangle(Brushes.DodgerBlue, 72, 22, vwidth, 16);
                g.DrawString(message, font, Brushes.White, 402, 30 - baseSize.Height / 2);
            }
            ShowWindow();
        }

        public void ShowMessage(Image image,int value,int maxvalue = 980)
        {
            Bitmap b = new Bitmap(image, 32, 32);
            osd.Bitmap = new Bitmap(422,60);
            int vwidth = 320 * value / maxvalue;
            using (Graphics g = Graphics.FromImage(osd.Bitmap))
            {
                g.FillRectangle(Brushes.Black, g.ClipBounds);
                g.DrawImage(b, 30, 14);
                g.FillRectangle(Brushes.White, 72, 22, 320, 16);
                g.FillRectangle(Brushes.DodgerBlue, 72, 22, vwidth, 16);
            }
            ShowWindow();
        }

        private void ShowWindow()
        {
            if (InvokeRequired)
            {
                //Invoke(new MethodInvoker(this.ShowWindow));
                Win32.User.PostMessage(safehandle, WM_SHOWALTIME, 0, 0);
            }
            else
            {
                osd.Width = osd.Bitmap.Width;
                osd.Height = osd.Bitmap.Height;
                osd.Y = Screen.PrimaryScreen.Bounds.Height - 160;
                osd.X = (Screen.PrimaryScreen.Bounds.Width - osd.Width) / 2;

                if (this._viewClock != null)
                {
                    if (_viewClock.Enabled)
                    {
                        osd.Invalidate();
                        _viewClock.Stop();
                        _viewClock.Start();
                        return;
                    }
                    else
                    {
                        _viewClock.Stop();
                        _viewClock.Dispose();
                    }
                }

                //_viewClock.Stop();
                //new Thread(() =>
                //{
                if (_time > 0)
                    osd.ShowAnimate(_mode, _time);
                else
                    osd.Show();
                //}).Start();
                _viewClock = new System.Windows.Forms.Timer();
                _viewClock.Tick += new System.EventHandler(ViewTimer);
                _viewClock.Interval = 3000;
                _viewClock.Start();
            }
        }
        const int WM_SHOWALTIME = 0x400 + 105;
        protected override void WndProc(ref Message m)
        {
            Debug.Print("wndproc begin 0x" + m.Msg.ToString("X"));
            if (m.Msg == WM_SHOWALTIME)
            {
                ShowWindow();
            }
            else
            {
                base.WndProc(ref m);
            }
            Debug.Print("wndproc end");
        }
    }
}
