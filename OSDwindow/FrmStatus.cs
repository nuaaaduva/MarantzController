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
                MessageBoxEx.Show("��Ϣ��δ��д����������һ�¡�");
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
                    MessageBoxEx.Show("������ʽ�������������ԡ�");
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