using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace MrSmarty.CodeProject
{
    public partial class FrmStatus : DevComponents.DotNetBar.Metro.MetroForm
    {
        public FrmStatus()
        {
            InitializeComponent();
        }

        StatsDef stat;

        public StatsDef Status
        {
            get => stat;
            set
            {
                stat = value;
                checkBoxX1.Checked = value.IsRegex;
                textBoxX1.Text = value.Status;
                textBoxX2.Text = value.Cmd;
            }
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if(textBoxX1.Text == "" || textBoxX2.Text == "")
            {
                MessageBoxEx.Show("信息尚未填写完整，请检查一下。");
            }
            else if(checkBoxX1.Checked)
            {
                try
                {
                    Regex regex = new Regex(textBoxX2.Text);
                    this.DialogResult = DialogResult.OK;
                    if (stat == null) stat = new StatsDef();
                    stat.IsRegex = checkBoxX1.Checked;
                    stat.Status = textBoxX1.Text;
                    stat.Cmd = textBoxX2.Text;
                    this.Close();
                }
                catch
                {
                    MessageBoxEx.Show("正则表达式分析出错，请重试。");
                    textBoxX2.Focus();
                }
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                if (stat == null) stat = new StatsDef();
                stat.IsRegex = checkBoxX1.Checked;
                stat.Status = textBoxX1.Text;
                stat.Cmd = textBoxX2.Text;
                this.Close();
            }
        }
    }
}