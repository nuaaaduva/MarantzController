namespace MrSmarty.CodeProject
{
    partial class FormHotkey
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.hoteKeyInput1 = new MrSmarty.CodeProject.HoteKeyInput();
            this.SuspendLayout();
            // 
            // labelX3
            // 
            this.labelX3.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.ForeColor = System.Drawing.Color.Black;
            this.labelX3.Location = new System.Drawing.Point(96, 49);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(75, 23);
            this.labelX3.TabIndex = 2;
            this.labelX3.Text = "取消";
            this.labelX3.TextAlignment = System.Drawing.StringAlignment.Center;
            this.labelX3.Click += new System.EventHandler(this.labelX3_Click);
            // 
            // hoteKeyInput1
            // 
            this.hoteKeyInput1.BackColor = System.Drawing.Color.White;
            this.hoteKeyInput1.ForeColor = System.Drawing.Color.Black;
            this.hoteKeyInput1.Location = new System.Drawing.Point(6, 12);
            this.hoteKeyInput1.Name = "hoteKeyInput1";
            this.hoteKeyInput1.ShortcutsEnabled = false;
            this.hoteKeyInput1.Size = new System.Drawing.Size(260, 22);
            this.hoteKeyInput1.TabIndex = 3;
            this.hoteKeyInput1.Value = null;
            // 
            // FormHotkey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 84);
            this.Controls.Add(this.hoteKeyInput1);
            this.Controls.Add(this.labelX3);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormHotkey";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "选择快捷键";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevComponents.DotNetBar.LabelX labelX3;
        private HoteKeyInput hoteKeyInput1;
    }
}