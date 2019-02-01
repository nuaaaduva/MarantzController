namespace MrSmarty.CodeProject
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.styleController1 = new DevExpress.XtraEditors.StyleController(this.components);
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.btnSet = new DevExpress.XtraEditors.SimpleButton();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.dropCustomCmd = new DevExpress.XtraEditors.DropDownButton();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuNotify = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.显示主界面MToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnVPlus = new DevExpress.XtraEditors.SimpleButton();
            this.btnVDown = new DevExpress.XtraEditors.SimpleButton();
            this.btnPower = new MrSmarty.CodeProject.Form1.MyCheckButton();
            this.btnMute = new MrSmarty.CodeProject.Form1.MyCheckButton();
            this.popupMenuInput = new DevExpress.XtraBars.PopupMenu(this.components);
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.repositoryItemRadioGroup1 = new DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup();
            this.netClient1 = new MrSmarty.CodeProject.NetClient();
            this.checkTuner = new MrSmarty.CodeProject.Form1.MyCheckButton();
            this.checkCD = new MrSmarty.CodeProject.Form1.MyCheckButton();
            this.checkMPlayer = new MrSmarty.CodeProject.Form1.MyCheckButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.styleController1)).BeginInit();
            this.menuNotify.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRadioGroup1)).BeginInit();
            this.SuspendLayout();
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2016 Colorful";
            // 
            // btnSet
            // 
            this.btnSet.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSet.ImageOptions.Image")));
            this.btnSet.Location = new System.Drawing.Point(409, 5);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(42, 42);
            this.btnSet.TabIndex = 6;
            this.btnSet.ToolTip = "设置";
            this.btnSet.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // btnExit
            // 
            this.btnExit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.ImageOptions.Image")));
            this.btnExit.Location = new System.Drawing.Point(457, 5);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(42, 42);
            this.btnExit.TabIndex = 7;
            this.btnExit.ToolTip = "退出";
            this.btnExit.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // dropCustomCmd
            // 
            this.dropCustomCmd.DropDownArrowStyle = DevExpress.XtraEditors.DropDownArrowStyle.Show;
            this.dropCustomCmd.Enabled = false;
            this.dropCustomCmd.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("dropCustomCmd.ImageOptions.Image")));
            this.dropCustomCmd.Location = new System.Drawing.Point(351, 5);
            this.dropCustomCmd.Name = "dropCustomCmd";
            this.dropCustomCmd.Size = new System.Drawing.Size(52, 42);
            this.dropCustomCmd.TabIndex = 5;
            this.dropCustomCmd.ToolTip = "自定义命令";
            this.dropCustomCmd.Click += new System.EventHandler(this.dropCustomCmd_ArrowButtonClick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipText = "SR系列功放控制端";
            this.notifyIcon1.ContextMenuStrip = this.menuNotify;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "SR系列功放控制端";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // menuNotify
            // 
            this.menuNotify.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.显示主界面MToolStripMenuItem,
            this.设置SToolStripMenuItem,
            this.退出EToolStripMenuItem});
            this.menuNotify.Name = "contextMenuStrip1";
            this.menuNotify.Size = new System.Drawing.Size(157, 70);
            // 
            // 显示主界面MToolStripMenuItem
            // 
            this.显示主界面MToolStripMenuItem.Name = "显示主界面MToolStripMenuItem";
            this.显示主界面MToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.显示主界面MToolStripMenuItem.Text = "显示主界面(&M)";
            this.显示主界面MToolStripMenuItem.Click += new System.EventHandler(this.显示主界面MToolStripMenuItem_Click);
            // 
            // 设置SToolStripMenuItem
            // 
            this.设置SToolStripMenuItem.Name = "设置SToolStripMenuItem";
            this.设置SToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.设置SToolStripMenuItem.Text = "设置(&S)";
            this.设置SToolStripMenuItem.Click += new System.EventHandler(this.设置SToolStripMenuItem_Click);
            // 
            // 退出EToolStripMenuItem
            // 
            this.退出EToolStripMenuItem.Name = "退出EToolStripMenuItem";
            this.退出EToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.退出EToolStripMenuItem.Text = "退出(&E)";
            this.退出EToolStripMenuItem.Click += new System.EventHandler(this.退出EToolStripMenuItem_Click);
            // 
            // btnVPlus
            // 
            this.btnVPlus.Enabled = false;
            this.btnVPlus.ImageOptions.Image = global::MrSmarty.CodeProject.Properties.Resources.volume_;
            this.btnVPlus.Location = new System.Drawing.Point(63, 5);
            this.btnVPlus.Name = "btnVPlus";
            this.btnVPlus.Size = new System.Drawing.Size(42, 42);
            this.btnVPlus.TabIndex = 1;
            this.btnVPlus.ToolTip = "增大音量";
            this.btnVPlus.Click += new System.EventHandler(this.btnVPlus_Click);
            // 
            // btnVDown
            // 
            this.btnVDown.Enabled = false;
            this.btnVDown.ImageOptions.Image = global::MrSmarty.CodeProject.Properties.Resources.volume_1;
            this.btnVDown.Location = new System.Drawing.Point(111, 5);
            this.btnVDown.Name = "btnVDown";
            this.btnVDown.Size = new System.Drawing.Size(42, 42);
            this.btnVDown.TabIndex = 2;
            this.btnVDown.ToolTip = "减小音量";
            this.btnVDown.Click += new System.EventHandler(this.btnVDown_Click);
            // 
            // btnPower
            // 
            this.btnPower.Enabled = false;
            this.btnPower.ImageOptions.Image = global::MrSmarty.CodeProject.Properties.Resources.poweroff;
            this.btnPower.Location = new System.Drawing.Point(15, 5);
            this.btnPower.Name = "btnPower";
            this.btnPower.Size = new System.Drawing.Size(42, 42);
            this.btnPower.TabIndex = 0;
            this.btnPower.ToolTip = "电源";
            this.btnPower.Click += new System.EventHandler(this.btnPower_Click);
            // 
            // btnMute
            // 
            this.btnMute.Enabled = false;
            this.btnMute.ImageOptions.Image = global::MrSmarty.CodeProject.Properties.Resources.Mute;
            this.btnMute.Location = new System.Drawing.Point(159, 5);
            this.btnMute.Name = "btnMute";
            this.btnMute.Size = new System.Drawing.Size(42, 42);
            this.btnMute.TabIndex = 3;
            this.btnMute.ToolTip = "静音";
            this.btnMute.Click += new System.EventHandler(this.btnMute_Click);
            // 
            // popupMenuInput
            // 
            this.popupMenuInput.Manager = this.barManager1;
            this.popupMenuInput.Name = "popupMenuInput";
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.MaxItemId = 19;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemRadioGroup1});
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(512, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 64);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(512, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 64);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(512, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 64);
            // 
            // repositoryItemRadioGroup1
            // 
            this.repositoryItemRadioGroup1.Name = "repositoryItemRadioGroup1";
            // 
            // netClient1
            // 
            this.netClient1.ClientEncoding = ((System.Text.Encoding)(resources.GetObject("netClient1.ClientEncoding")));
            this.netClient1.TextReceived += new MrSmarty.CodeProject.NetClient.TextReceivedEventHandler(this.netClient1_TextReceived);
            this.netClient1.Connected += new System.EventHandler(this.netClient1_Connected);
            this.netClient1.LoseConnected += new System.EventHandler(this.netClient1_LoseConnected);
            this.netClient1.DisConnected += new System.EventHandler(this.netClient1_DisConnected);
            // 
            // checkTuner
            // 
            this.checkTuner.Enabled = false;
            this.checkTuner.ImageOptions.Image = global::MrSmarty.CodeProject.Properties.Resources.tuner;
            this.checkTuner.Location = new System.Drawing.Point(207, 5);
            this.checkTuner.Name = "checkTuner";
            this.checkTuner.Size = new System.Drawing.Size(42, 42);
            this.checkTuner.TabIndex = 3;
            this.checkTuner.ToolTip = "输入源：Tuner";
            this.checkTuner.Click += new System.EventHandler(this.checkTuner_Click);
            // 
            // checkCD
            // 
            this.checkCD.Enabled = false;
            this.checkCD.ImageOptions.Image = global::MrSmarty.CodeProject.Properties.Resources.CD;
            this.checkCD.Location = new System.Drawing.Point(255, 5);
            this.checkCD.Name = "checkCD";
            this.checkCD.Size = new System.Drawing.Size(42, 42);
            this.checkCD.TabIndex = 3;
            this.checkCD.ToolTip = "输入源：CD";
            this.checkCD.Click += new System.EventHandler(this.checkCD_Click);
            // 
            // checkMPlayer
            // 
            this.checkMPlayer.Enabled = false;
            this.checkMPlayer.ImageOptions.Image = global::MrSmarty.CodeProject.Properties.Resources.mplayer;
            this.checkMPlayer.Location = new System.Drawing.Point(303, 5);
            this.checkMPlayer.Name = "checkMPlayer";
            this.checkMPlayer.Size = new System.Drawing.Size(42, 42);
            this.checkMPlayer.TabIndex = 3;
            this.checkMPlayer.ToolTip = "输入源：Mplayer";
            this.checkMPlayer.Click += new System.EventHandler(this.checkMPlayer_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(512, 64);
            this.Controls.Add(this.checkMPlayer);
            this.Controls.Add(this.checkCD);
            this.Controls.Add(this.checkTuner);
            this.Controls.Add(this.btnMute);
            this.Controls.Add(this.btnPower);
            this.Controls.Add(this.btnVDown);
            this.Controls.Add(this.btnVPlus);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSet);
            this.Controls.Add(this.dropCustomCmd);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.DoubleBuffered = true;
            this.FlattenMDIBorder = false;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SR系列功放控制端";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.styleController1)).EndInit();
            this.menuNotify.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRadioGroup1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.DropDownButton dropCustomCmd;
        private DevExpress.XtraEditors.StyleController styleController1;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraEditors.SimpleButton btnSet;
        private DevExpress.XtraEditors.SimpleButton btnExit;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip menuNotify;
        private System.Windows.Forms.ToolStripMenuItem 显示主界面MToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置SToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出EToolStripMenuItem;
        private DevExpress.XtraEditors.SimpleButton btnVPlus;
        private DevExpress.XtraEditors.SimpleButton btnVDown;
        private MyCheckButton btnPower;
        private MyCheckButton btnMute;
        private DevExpress.XtraBars.PopupMenu popupMenuInput;
        private NetClient netClient1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup repositoryItemRadioGroup1;
        private MyCheckButton checkMPlayer;
        private MyCheckButton checkCD;
        private MyCheckButton checkTuner;
        private System.Windows.Forms.Timer timer1;
    }
}