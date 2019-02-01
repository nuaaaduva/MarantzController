using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MrSmarty.CodeProject
{
    public partial class Demo : Form
    {
        private FloatingOSDWindow[] _osd = new FloatingOSDWindow[4];
        private Point[] _pnt = new Point[4];
        private byte[] _alpha = new byte[4];
        private Color[] _textColor = new Color[4];
        private Font[] _textFont = new Font[4];
        private int[] _textTime = new int[4];
        private FloatingWindow.AnimateMode[] _mode = new FloatingWindow.AnimateMode[4]; 
        private uint[] _animateTime = new uint[4];
        private string[] _text = new string[4];
        private Rectangle _rScreen = Screen.PrimaryScreen.Bounds;

        public Demo()
        {
            InitializeComponent();
            this._numX.Maximum = this._rScreen.Width;
            this._numY.Maximum = this._rScreen.Height;
            //--OSD windows
            for(int i = 0; i < this._osd.Length; i++)
                this._osd[i] = new FloatingOSDWindow();
            //--OSD start point
            this._pnt[0] = new Point(20, 45); this._pnt[1] = new Point(this._rScreen.Width / 8, this._rScreen.Height / 2);
            this._pnt[2] = new Point(this._rScreen.Width / 6, this._rScreen.Height / 2 - this._rScreen.Height / 4); this._pnt[3] = new Point(100, this._rScreen.Height / 2 - this._rScreen.Height / 8);
            //--OSD transparency
            this._alpha[0] = 120; this._alpha[1] = 231; this._alpha[2] = 90; this._alpha[3] = 122;
            //--OSD text color
            this._textColor[0] = Color.Lime; this._textColor[1] = Color.DarkCyan; this._textColor[2] = Color.RoyalBlue; this._textColor[3] = Color.DarkMagenta;
            //--OSD text font
            this._textFont[0] = new Font("Arial", 22f, FontStyle.Bold); this._textFont[1] = new Font("Microsoft Sans Serif", 28f, FontStyle.Regular);
            this._textFont[2] = new Font("Courier New", 36f, FontStyle.Bold | FontStyle.Underline); this._textFont[3] = new Font("Verdana", 26f, FontStyle.Bold | FontStyle.Italic);
            //--OSD text time
            this._textTime[0] = 3000; this._textTime[1] = 1800; this._textTime[2] = 3900; this._textTime[3] = 2400;
            //--OSD window animation effect
            this._mode[0] = FloatingWindow.AnimateMode.ExpandCollapse; this._mode[1] = FloatingWindow.AnimateMode.Blend;
            this._mode[2] = FloatingWindow.AnimateMode.SlideLeftToRight; this._mode[3] = FloatingWindow.AnimateMode.RollRightToLeft;
            //--OSD animate time
            this._animateTime[0] = 200; this._animateTime[1] = 0; this._animateTime[2] = 0; this._animateTime[3] = 370;
            //--OSD text
            this._text[0] = this._txtText.Text; this._text[1] = "Hello! I am OSD window...";
            this._text[2] = "OSD text can be semi-transparent!"; this._text[3] = "Also OSD can be animated in every way";

            //defaults for custom OSD
            this._numX.Value = this._pnt[0].X; this._numY.Value = this._pnt[0].Y;
            this._numAlpha.Value = this._alpha[0]; this._numTextTime.Value = this._textTime[0];
            this._numAnimateTime.Value = this._animateTime[0];
            this._lbSample.ForeColor = this._textColor[0]; this._lbSample.Font = this._textFont[0];
            this._cbAnimate.Items.AddRange(Enum.GetNames(typeof(FloatingWindow.AnimateMode)));
            this._cbAnimate.SelectedIndex = (int)this._mode[0];
        }

        private void demo_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void _all_Click(object sender, EventArgs e)
        {
            int idx;
            switch((sender as Button).Tag.ToString())
            {
                case "1": idx = 1; break;
                case "2": idx = 2; break;
                case "3": idx = 3; break;
                default: idx = 0; break;
            }
            if(idx == 0)
            {
                this._pnt[0] = new Point((int)this._numX.Value, (int)this._numY.Value);
                this._alpha[0] = (byte)this._numAlpha.Value;
                this._textColor[0] = this._lbSample.ForeColor;
                this._textFont[0] = this._lbSample.Font;
                this._textTime[0] = (int)this._numTextTime.Value;
                this._mode[0] = (FloatingWindow.AnimateMode)this._cbAnimate.SelectedIndex;
                this._animateTime[0] = (uint)this._numAnimateTime.Value;
                this._text[0] = this._txtText.Text;
            }
            this._osd[idx].Show(this._pnt[idx], this._alpha[idx], this._textColor[idx], this._textFont[idx], this._textTime[idx],
                this._mode[idx], this._animateTime[idx], this._text[idx]);
        }

        private void _bColorPick_Click(object sender, EventArgs e)
        {
            this._dlgColor.Color = this._lbSample.ForeColor;
            if(this._dlgColor.ShowDialog()==DialogResult.OK)
                this._lbSample.ForeColor = this._dlgColor.Color;
        }

        private void _bFontPick_Click(object sender, EventArgs e)
        {
            this._dlgFont.Font = this._lbSample.Font;
            if(this._dlgFont.ShowDialog() == DialogResult.OK)
                this._lbSample.Font = this._dlgFont.Font;
        }
    }
}