using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Linq;
using DevExpress.XtraEditors;

namespace MrSmarty.CodeProject
{
    public partial class FrmSet : DevComponents.DotNetBar.Metro.MetroForm
    {
        public FrmSet()
        {
            InitializeComponent();
        }

        List<MyCommand> cmds;
        List<StatsDef> stats;
        Settings settings;

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            settings = new Settings
            {
                RemoteHost = ipAddressInput1.Value,
                RemotePort = integerInput1.Value,
                Startup = switchButton1.Value,
                Power = hoteKeyInput1.Value,
                Mute = hoteKeyInput2.Value,
                VolUP = hoteKeyInput3.Value,
                VolDown = hoteKeyInput4.Value,
                Commands = cmds,
                VolStep = integerInput2.Value,
                ShowUndef = switchButton2.Value,
                DefStats = stats,
            };
            this.DialogResult = DialogResult.OK;
            Close();
        }

        public Settings Settings { get => settings;
            set {
                this.ipAddressInput1.Value = value.RemoteHost;
                this.integerInput1.Value = value.RemotePort;
                this.switchButton1.Value = value.Startup;
                hoteKeyInput1.Value = value.Power;
                hoteKeyInput2.Value = value.Mute;
                hoteKeyInput3.Value = value.VolUP;
                hoteKeyInput4.Value = value.VolDown;
                integerInput2.Value = value.VolStep;
                cmds = value.Commands?.ToList() ?? new List<MyCommand>();
                gridControl1.DataSource = cmds;
                stats = value.DefStats?.ToList() ?? new List<StatsDef>();
                gridControl2.DataSource = stats;
                switchButton2.Value = value.ShowUndef;
            } }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            FormAddCmd frm = new FormAddCmd();
            if(frm.ShowDialog() == DialogResult.OK)
            {
                cmds.Add(frm.Value);
                gridView1.RefreshData();
            }
        }

        private void gridView1_ShowingEditor(object sender, CancelEventArgs e)
        {
            if(gridView1.FocusedColumn == gridColumn3)
            {
                e.Cancel = true;
                FormHotkey frm = new FormHotkey();
                var rel = frm.ShowDialog();
                if(rel == DialogResult.OK)
                {
                    gridView1.SetFocusedRowCellValue(gridColumn3, frm.Value);
                }
            }
            else if(gridView1.FocusedColumn == gridColumn4)
            {
                e.Cancel = true;
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
                        gridView1.SetFocusedRowCellValue(gridColumn4, bitmap);
                        image.Dispose();
                    }
                    catch
                    {
                        MessageBox.Show("图像文件格式错误！");
                    }
                }
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if(gridView1.FocusedRowHandle != 0)
            {
                cmds.Remove(gridView1.GetFocusedRow()as MyCommand);
                gridView1.RefreshData();
            }
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            //string stat = XtraInputBox.Show("请输入状态字，空字符取消。", "输入", "");
            //if(!string.IsNullOrEmpty(stat))
            //{
            //    string cmd = XtraInputBox.Show("请输入返回命令字，空字符取消。", "输入", "");
            //    if (!string.IsNullOrEmpty(cmd)) ;
            //    {
            //        stats.Add(new StatsDef { Status = stat, Cmd = cmd });
            //        gridView2.RefreshData();
            //    }
            //}
            FrmStatus frm = new FrmStatus();
            if(frm.ShowDialog() == DialogResult.OK)
            {
                stats.Add(frm.Status);
                gridView2.RefreshData();
            }
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            if (gridView2.FocusedRowHandle != 0)
            {
                stats.Remove(gridView2.GetFocusedRow() as StatsDef);
                gridView2.RefreshData();
            }
        }

        private void gridView2_ShowingEditor(object sender, CancelEventArgs e)
        {
            //if (gridView2.FocusedColumn == gridColumn5)
            //{
            //    string stat = XtraInputBox.Show("请输入状态字，空字符取消。", "输入", gridView2.GetFocusedValue().ToString());
            //    if (!string.IsNullOrEmpty(stat))
            //        gridView2.SetFocusedValue(stat);
            //}
            //else
            //{
            //    string cmd = XtraInputBox.Show("请输入状态字，空字符取消。", "输入", gridView2.GetFocusedValue().ToString());
            //    if (!string.IsNullOrEmpty(cmd))
            //        gridView2.SetFocusedValue(cmd);
            //}
            if(gridView2.GetFocusedRow() != null)
            {
                FrmStatus frm = new FrmStatus();
                frm.Status = gridView2.GetFocusedRow() as StatsDef;
                if(frm.ShowDialog() == DialogResult.OK)
                {
                    gridView2.RefreshData();
                }
            }
            e.Cancel = true;
        }
    }
}