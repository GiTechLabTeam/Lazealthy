namespace Lazealthy.Desktop
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.notifyIconLazealthy = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStripLazealthy = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startNotifierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopNotifierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerNotifier = new System.Windows.Forms.Timer(this.components);
            this.labelMessage = new System.Windows.Forms.Label();
            this.labelTimerCounter = new System.Windows.Forms.Label();
            this.contextMenuStripLazealthy.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIconLazealthy
            // 
            this.notifyIconLazealthy.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIconLazealthy.BalloonTipText = "Lazealthy (Lazy + Healthy) is a tool & App which helps lazy or busy people to be " +
    "healthy.";
            this.notifyIconLazealthy.BalloonTipTitle = "Lazealthy";
            this.notifyIconLazealthy.ContextMenuStrip = this.contextMenuStripLazealthy;
            this.notifyIconLazealthy.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconLazealthy.Icon")));
            this.notifyIconLazealthy.Text = "Lazealthy helps lazy people to be healthy people.";
            this.notifyIconLazealthy.Visible = true;
            this.notifyIconLazealthy.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIconLazealthy_MouseDoubleClick);
            // 
            // contextMenuStripLazealthy
            // 
            this.contextMenuStripLazealthy.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.startNotifierToolStripMenuItem,
            this.stopNotifierToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStripLazealthy.Name = "contextMenuStripLazealthy";
            this.contextMenuStripLazealthy.Size = new System.Drawing.Size(153, 114);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // startNotifierToolStripMenuItem
            // 
            this.startNotifierToolStripMenuItem.Name = "startNotifierToolStripMenuItem";
            this.startNotifierToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.startNotifierToolStripMenuItem.Text = "Start Notifier";
            this.startNotifierToolStripMenuItem.Click += new System.EventHandler(this.startNotifierToolStripMenuItem_Click);
            // 
            // stopNotifierToolStripMenuItem
            // 
            this.stopNotifierToolStripMenuItem.Name = "stopNotifierToolStripMenuItem";
            this.stopNotifierToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.stopNotifierToolStripMenuItem.Text = "Stop Notifier";
            this.stopNotifierToolStripMenuItem.Click += new System.EventHandler(this.stopNotifierToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // timerNotifier
            // 
            this.timerNotifier.Interval = 1000;
            this.timerNotifier.Tick += new System.EventHandler(this.timerNotifier_Tick);
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMessage.Location = new System.Drawing.Point(23, 22);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(218, 26);
            this.labelMessage.TabIndex = 1;
            this.labelMessage.Text = "Time Left for Next Break:";
            // 
            // labelTimerCounter
            // 
            this.labelTimerCounter.AutoSize = true;
            this.labelTimerCounter.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTimerCounter.Location = new System.Drawing.Point(247, 22);
            this.labelTimerCounter.Name = "labelTimerCounter";
            this.labelTimerCounter.Size = new System.Drawing.Size(86, 26);
            this.labelTimerCounter.TabIndex = 2;
            this.labelTimerCounter.Text = "00:00:00";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 167);
            this.Controls.Add(this.labelTimerCounter);
            this.Controls.Add(this.labelMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lazealthy";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormSetting_Load);
            this.Resize += new System.EventHandler(this.FormSetting_Resize);
            this.contextMenuStripLazealthy.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIconLazealthy;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripLazealthy;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startNotifierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopNotifierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Timer timerNotifier;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.Label labelTimerCounter;
    }
}

