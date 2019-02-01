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
    public partial class FormAddCmd : DevComponents.DotNetBar.Metro.MetroForm
    {
        public FormAddCmd()
        {
            InitializeComponent();
        }

        private void buttonEdit1_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog()
            {
                Filter = "bmp位图|*.bmp|jpeg图像|*.jpg;*.jpeg|png图像|*.png|tiff图像|*.tif;*.tiff|所有图像文件|*.bmp;*.jpg;*.jpeg;*.png;*.tif;*.tiff|所有文件|*.*",
                Title = "选择图像",
                CheckFileExists = true,
                Multiselect = false,
            };
            if (dlg.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(dlg.FileName))
            {
                try
                {
                    Image image = Image.FromFile(dlg.FileName);
                    Bitmap bitmap = new Bitmap(image, 32, 32);
                    pictureBox1.Image = bitmap;
                    image.Dispose();
                    buttonEdit1.Text = dlg.FileName;
                }
                catch
                {
                    MessageBox.Show("图像文件格式错误！");
                }
            }
        }

        public MyCommand Value { get; private set; }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if(textBoxX1.Text == "")
            {
                MessageBox.Show("名称不能为空");
                textBoxX1.Focus();
            }
            else if(textBoxX2.Text == "")
            {
                MessageBox.Show("命令序列不能为空");
                textBoxX2.Focus();
            }
            else
            {
                Value = new MyCommand
                {
                    CmdBytes = textBoxX2.Text,
                    Name = textBoxX1.Text,
                    Image = pictureBox1.Image,
                    Keys = hoteKeyInput1.Value,
                };
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}