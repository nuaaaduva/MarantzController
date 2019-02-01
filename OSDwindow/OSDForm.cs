using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace MrSmarty.CodeProject
{
    public partial class OSDForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public OSDForm()
        {
            InitializeComponent();
        }

        public void ShowVol(int value,int maxvalue)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<int,int>(this.ShowVol), value,maxvalue);
            }
            else
            {
                timer1.Stop();
                progressBarX1.Maximum = maxvalue;
                progressBarX1.Value = value;
                progressBarX1.Visible = true;
                labelX2.Visible = false;
                labelX1.Visible = true;
                labelX1.Image = Properties.Resources.volume;
                this.Top = Screen.PrimaryScreen.Bounds.Height - 200;
                this.Width = 430;
                this.Left = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2;
                this.Show();
                timer1.Start();
            }
        }

        public void ShowMessage(Image image,string message)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<Image,string>(this.ShowMessage), image,message);
            }
            else
            {
                timer1.Stop();
                progressBarX1.Visible = false;
                labelX2.Left = 80;
                labelX1.Visible = true;
                labelX1.Image = image;
                labelX2.Visible = true;
                labelX2.Text = message;
                this.Top = Screen.PrimaryScreen.Bounds.Height - 200;
                this.Width = labelX2.Right + labelX1.Left;
                this.Left = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2;
                this.Show();
                timer1.Start();
            }
        }

        public void ShowMessage(string message)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<string>(this.ShowMessage), message);
            }
            else
            {
                timer1.Stop();
                progressBarX1.Visible = false;
                labelX2.Left = labelX1.Left;
                labelX1.Visible = false;
                labelX2.Visible = true;
                labelX2.Text = message;
                this.Top = Screen.PrimaryScreen.Bounds.Height - 200;
                this.Width = labelX2.Right + labelX1.Left;
                this.Left = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2;
                this.Show();
                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Hide();
        }

        public new void Show()
        {
            User32.AnimateWindow(this.Handle, 500, User32.AW_ACTIVATE | User32.AW_BLEND | User32.AW_CENTER);
            base.Show();
        }


        public new void Hide()
        {
            User32.AnimateWindow(this.Handle, 500, User32.AW_HIDE | User32.AW_BLEND | User32.AW_CENTER);
            base.Hide();
        }

        private void OSDForm_Load(object sender, EventArgs e)
        {
            this.Top = Screen.PrimaryScreen.Bounds.Height - 200;
            this.Left = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2;
            labelX2.BackColor = Color.Black;
            labelX2.ForeColor = Color.White;
        }
    }
}