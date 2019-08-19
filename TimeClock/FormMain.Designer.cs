namespace Programlancer
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
            this.notifyIconApp = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStripApp = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemEnter = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemReport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.administratorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelNow = new System.Windows.Forms.Label();
            this.dataGridViewToday = new System.Windows.Forms.DataGridView();
            this.contextMenuStripApp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewToday)).BeginInit();
            this.SuspendLayout();
            // 
            // notifyIconApp
            // 
            this.notifyIconApp.ContextMenuStrip = this.contextMenuStripApp;
            resources.ApplyResources(this.notifyIconApp, "notifyIconApp");
            this.notifyIconApp.DoubleClick += new System.EventHandler(this.notifyIconApp_DoubleClick);
            // 
            // contextMenuStripApp
            // 
            this.contextMenuStripApp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemEnter,
            this.toolStripMenuItemExit,
            this.toolStripSeparator1,
            this.toolStripMenuItemReport,
            this.toolStripSeparator3,
            this.administratorToolStripMenuItem});
            this.contextMenuStripApp.Name = "contextMenuStripApp";
            resources.ApplyResources(this.contextMenuStripApp, "contextMenuStripApp");
            // 
            // toolStripMenuItemEnter
            // 
            this.toolStripMenuItemEnter.Name = "toolStripMenuItemEnter";
            resources.ApplyResources(this.toolStripMenuItemEnter, "toolStripMenuItemEnter");
            this.toolStripMenuItemEnter.Click += new System.EventHandler(this.toolStripMenuItemEnter_Click);
            // 
            // toolStripMenuItemExit
            // 
            this.toolStripMenuItemExit.Name = "toolStripMenuItemExit";
            resources.ApplyResources(this.toolStripMenuItemExit, "toolStripMenuItemExit");
            this.toolStripMenuItemExit.Click += new System.EventHandler(this.toolStripMenuItemExit_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // toolStripMenuItemReport
            // 
            this.toolStripMenuItemReport.Name = "toolStripMenuItemReport";
            resources.ApplyResources(this.toolStripMenuItemReport, "toolStripMenuItemReport");
            this.toolStripMenuItemReport.Click += new System.EventHandler(this.toolStripMenuItemReport_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // administratorToolStripMenuItem
            // 
            this.administratorToolStripMenuItem.Name = "administratorToolStripMenuItem";
            resources.ApplyResources(this.administratorToolStripMenuItem, "administratorToolStripMenuItem");
            this.administratorToolStripMenuItem.Click += new System.EventHandler(this.administratorToolStripMenuItem_Click);
            // 
            // labelNow
            // 
            resources.ApplyResources(this.labelNow, "labelNow");
            this.labelNow.Name = "labelNow";
            // 
            // dataGridViewToday
            // 
            this.dataGridViewToday.AllowUserToAddRows = false;
            this.dataGridViewToday.AllowUserToDeleteRows = false;
            resources.ApplyResources(this.dataGridViewToday, "dataGridViewToday");
            this.dataGridViewToday.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewToday.Name = "dataGridViewToday";
            this.dataGridViewToday.ReadOnly = true;
            // 
            // FormMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridViewToday);
            this.Controls.Add(this.labelNow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.ShowInTaskbar = false;
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Activated += new System.EventHandler(this.FormMain_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.contextMenuStripApp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewToday)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIconApp;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripApp;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEnter;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemReport;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.Label labelNow;
        private System.Windows.Forms.DataGridView dataGridViewToday;
        private System.Windows.Forms.ToolStripMenuItem administratorToolStripMenuItem;
        
    }
}

