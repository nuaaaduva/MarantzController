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
    public partial class FormHotkey : DevComponents.DotNetBar.Metro.MetroForm
    {
        public FormHotkey()
        {
            InitializeComponent();
            hoteKeyInput1.ValueSet += HoteKeyInput1_ValueSet;
            hoteKeyInput1.ValueCancle += HoteKeyInput1_ValueCancle;
        }

        public HotKey Value;

        private void HoteKeyInput1_ValueCancle(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void HoteKeyInput1_ValueSet(object sender, EventArgs e)
        {
            Value = hoteKeyInput1.Value;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void labelX3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            hoteKeyInput1.Focus();
        }
    }

    
}