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
    public partial class Form2 : DevComponents.DotNetBar.Metro.MetroForm
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Array keysArray = Enum.GetValues(typeof(Keys));
            foreach(Keys key in keysArray)
            {
                //if(key != Keys.LButton && key != Keys.MButton && key != Keys.RButton && key != Keys.Cancel)
                //    Win32.User.RegisterHotKey(Win32.User)
            }
        }
    }
}