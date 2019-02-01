namespace MrSmarty.CodeProject
{
    partial class Demo
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
            if(disposing && (components != null))
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
            this._b1 = new System.Windows.Forms.Button();
            this._b2 = new System.Windows.Forms.Button();
            this._b3 = new System.Windows.Forms.Button();
            this._groupBx = new System.Windows.Forms.GroupBox();
            this._txtText = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this._numAnimateTime = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this._cbAnimate = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this._numTextTime = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this._bFontPick = new System.Windows.Forms.Button();
            this._bColorPick = new System.Windows.Forms.Button();
            this._numAlpha = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._numY = new System.Windows.Forms.NumericUpDown();
            this._numX = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this._lbSample = new System.Windows.Forms.Label();
            this._b0 = new System.Windows.Forms.Button();
            this._dlgColor = new System.Windows.Forms.ColorDialog();
            this._dlgFont = new System.Windows.Forms.FontDialog();
            this._groupBx.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._numAnimateTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numTextTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numAlpha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numX)).BeginInit();
            this.SuspendLayout();
            // 
            // _b1
            // 
            this._b1.AutoSize = true;
            this._b1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._b1.Location = new System.Drawing.Point(10, 6);
            this._b1.Name = "_b1";
            this._b1.Size = new System.Drawing.Size(171, 25);
            this._b1.TabIndex = 0;
            this._b1.Tag = "1";
            this._b1.Text = "Show predetermined OSD 1";
            this._b1.UseVisualStyleBackColor = true;
            this._b1.Click += new System.EventHandler(this._all_Click);
            // 
            // _b2
            // 
            this._b2.AutoSize = true;
            this._b2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._b2.Location = new System.Drawing.Point(10, 37);
            this._b2.Name = "_b2";
            this._b2.Size = new System.Drawing.Size(171, 25);
            this._b2.TabIndex = 1;
            this._b2.Tag = "2";
            this._b2.Text = "Show predetermined OSD 2";
            this._b2.UseVisualStyleBackColor = true;
            this._b2.Click += new System.EventHandler(this._all_Click);
            // 
            // _b3
            // 
            this._b3.AutoSize = true;
            this._b3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._b3.Location = new System.Drawing.Point(10, 68);
            this._b3.Name = "_b3";
            this._b3.Size = new System.Drawing.Size(171, 25);
            this._b3.TabIndex = 2;
            this._b3.Tag = "3";
            this._b3.Text = "Show predetermined OSD 3";
            this._b3.UseVisualStyleBackColor = true;
            this._b3.Click += new System.EventHandler(this._all_Click);
            // 
            // _groupBx
            // 
            this._groupBx.Controls.Add(this._txtText);
            this._groupBx.Controls.Add(this.label7);
            this._groupBx.Controls.Add(this._numAnimateTime);
            this._groupBx.Controls.Add(this.label5);
            this._groupBx.Controls.Add(this._cbAnimate);
            this._groupBx.Controls.Add(this.label6);
            this._groupBx.Controls.Add(this._numTextTime);
            this._groupBx.Controls.Add(this.label4);
            this._groupBx.Controls.Add(this._bFontPick);
            this._groupBx.Controls.Add(this._bColorPick);
            this._groupBx.Controls.Add(this._numAlpha);
            this._groupBx.Controls.Add(this.label3);
            this._groupBx.Controls.Add(this.label2);
            this._groupBx.Controls.Add(this._numY);
            this._groupBx.Controls.Add(this._numX);
            this._groupBx.Controls.Add(this.label1);
            this._groupBx.Controls.Add(this.label8);
            this._groupBx.Controls.Add(this._lbSample);
            this._groupBx.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._groupBx.Location = new System.Drawing.Point(187, 6);
            this._groupBx.Name = "_groupBx";
            this._groupBx.Size = new System.Drawing.Size(471, 279);
            this._groupBx.TabIndex = 3;
            this._groupBx.TabStop = false;
            this._groupBx.Text = "Create custom OSD window";
            // 
            // _txtText
            // 
            this._txtText.Location = new System.Drawing.Point(66, 251);
            this._txtText.Name = "_txtText";
            this._txtText.Size = new System.Drawing.Size(394, 21);
            this._txtText.TabIndex = 8;
            this._txtText.Text = "This string will be displayed by OSD window...";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 254);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 15);
            this.label7.TabIndex = 18;
            this.label7.Text = "OSD text";
            // 
            // _numAnimateTime
            // 
            this._numAnimateTime.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this._numAnimateTime.Location = new System.Drawing.Point(159, 74);
            this._numAnimateTime.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this._numAnimateTime.Name = "_numAnimateTime";
            this._numAnimateTime.Size = new System.Drawing.Size(59, 21);
            this._numAnimateTime.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(153, 15);
            this.label5.TabIndex = 16;
            this.label5.Text = "Time for animate, in msec.";
            // 
            // _cbAnimate
            // 
            this._cbAnimate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cbAnimate.FormattingEnabled = true;
            this._cbAnimate.Location = new System.Drawing.Point(313, 74);
            this._cbAnimate.Name = "_cbAnimate";
            this._cbAnimate.Size = new System.Drawing.Size(147, 23);
            this._cbAnimate.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(223, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 15);
            this.label6.TabIndex = 13;
            this.label6.Text = "Animate effect";
            // 
            // _numTextTime
            // 
            this._numTextTime.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this._numTextTime.Location = new System.Drawing.Point(390, 48);
            this._numTextTime.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this._numTextTime.Name = "_numTextTime";
            this._numTextTime.Size = new System.Drawing.Size(70, 21);
            this._numTextTime.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(223, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(164, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "Time to display text, in msec.";
            // 
            // _bFontPick
            // 
            this._bFontPick.AutoSize = true;
            this._bFontPick.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._bFontPick.Location = new System.Drawing.Point(378, 222);
            this._bFontPick.Name = "_bFontPick";
            this._bFontPick.Size = new System.Drawing.Size(82, 23);
            this._bFontPick.TabIndex = 7;
            this._bFontPick.Text = "Font of text...";
            this._bFontPick.UseVisualStyleBackColor = true;
            this._bFontPick.Click += new System.EventHandler(this._bFontPick_Click);
            // 
            // _bColorPick
            // 
            this._bColorPick.AutoSize = true;
            this._bColorPick.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._bColorPick.Location = new System.Drawing.Point(146, 222);
            this._bColorPick.Name = "_bColorPick";
            this._bColorPick.Size = new System.Drawing.Size(82, 23);
            this._bColorPick.TabIndex = 6;
            this._bColorPick.Text = "Color of text...";
            this._bColorPick.UseVisualStyleBackColor = true;
            this._bColorPick.Click += new System.EventHandler(this._bColorPick_Click);
            // 
            // _numAlpha
            // 
            this._numAlpha.Location = new System.Drawing.Point(127, 48);
            this._numAlpha.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this._numAlpha.Name = "_numAlpha";
            this._numAlpha.Size = new System.Drawing.Size(49, 21);
            this._numAlpha.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Transparency of text";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(230, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "-";
            // 
            // _numY
            // 
            this._numY.Location = new System.Drawing.Point(244, 21);
            this._numY.Name = "_numY";
            this._numY.Size = new System.Drawing.Size(53, 21);
            this._numY.TabIndex = 1;
            // 
            // _numX
            // 
            this._numX.Location = new System.Drawing.Point(175, 21);
            this._numX.Name = "_numX";
            this._numX.Size = new System.Drawing.Size(53, 21);
            this._numX.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "X-Y position of top-left corner";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.ForeColor = System.Drawing.Color.Brown;
            this.label8.Location = new System.Drawing.Point(9, 92);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(130, 87);
            this.label8.TabIndex = 20;
            this.label8.Text = "If this value = 0 \"Animate effect\" will be ignored and OSD window will be display" +
                "ed at once";
            // 
            // _lbSample
            // 
            this._lbSample.AutoSize = true;
            this._lbSample.Font = new System.Drawing.Font("Verdana", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._lbSample.Location = new System.Drawing.Point(135, 101);
            this._lbSample.Margin = new System.Windows.Forms.Padding(0);
            this._lbSample.Name = "_lbSample";
            this._lbSample.Size = new System.Drawing.Size(325, 78);
            this._lbSample.TabIndex = 9;
            this._lbSample.Text = "Sample!";
            // 
            // _b0
            // 
            this._b0.AutoSize = true;
            this._b0.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._b0.Location = new System.Drawing.Point(67, 255);
            this._b0.Name = "_b0";
            this._b0.Size = new System.Drawing.Size(117, 25);
            this._b0.TabIndex = 3;
            this._b0.Tag = "0";
            this._b0.Text = "Show this OSD >>";
            this._b0.UseVisualStyleBackColor = true;
            this._b0.Click += new System.EventHandler(this._all_Click);
            // 
            // _dlgColor
            // 
            this._dlgColor.Color = System.Drawing.Color.Lime;
            // 
            // _dlgFont
            // 
            this._dlgFont.MaxSize = 72;
            this._dlgFont.MinSize = 8;
            // 
            // Demo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 292);
            this.Controls.Add(this._b0);
            this.Controls.Add(this._groupBx);
            this.Controls.Add(this._b3);
            this.Controls.Add(this._b2);
            this.Controls.Add(this._b1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Demo";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OSD demo form. Press \'Esc\' to close...";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.demo_KeyDown);
            this._groupBx.ResumeLayout(false);
            this._groupBx.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._numAnimateTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numTextTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numAlpha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numX)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _b1;
        private System.Windows.Forms.Button _b2;
        private System.Windows.Forms.Button _b3;
        private System.Windows.Forms.GroupBox _groupBx;
        private System.Windows.Forms.NumericUpDown _numAlpha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown _numY;
        private System.Windows.Forms.NumericUpDown _numX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label _lbSample;
        private System.Windows.Forms.Button _bFontPick;
        private System.Windows.Forms.Button _bColorPick;
        private System.Windows.Forms.NumericUpDown _numTextTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox _cbAnimate;
        private System.Windows.Forms.NumericUpDown _numAnimateTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox _txtText;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button _b0;
        private System.Windows.Forms.ColorDialog _dlgColor;
        private System.Windows.Forms.FontDialog _dlgFont;
        private System.Windows.Forms.Label label8;
    }
}

