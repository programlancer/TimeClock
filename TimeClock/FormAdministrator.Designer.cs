namespace Programlancer
{
    partial class FormAdministrator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAdministrator));
            this.buttonExitProgram = new System.Windows.Forms.Button();
            this.buttonUsers = new System.Windows.Forms.Button();
            this.buttonLog = new System.Windows.Forms.Button();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.linkLabelEMail = new System.Windows.Forms.LinkLabel();
            this.labelVerDate = new System.Windows.Forms.Label();
            this.labelVerNum = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonReport = new System.Windows.Forms.Button();
            this.buttonBackUp = new System.Windows.Forms.Button();
            this.toolTipFormAdmin = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonExitProgram
            // 
            resources.ApplyResources(this.buttonExitProgram, "buttonExitProgram");
            this.buttonExitProgram.Name = "buttonExitProgram";
            this.toolTipFormAdmin.SetToolTip(this.buttonExitProgram, resources.GetString("buttonExitProgram.ToolTip"));
            this.buttonExitProgram.UseVisualStyleBackColor = true;
            this.buttonExitProgram.Click += new System.EventHandler(this.buttonExitProgram_Click);
            // 
            // buttonUsers
            // 
            resources.ApplyResources(this.buttonUsers, "buttonUsers");
            this.buttonUsers.Name = "buttonUsers";
            this.toolTipFormAdmin.SetToolTip(this.buttonUsers, resources.GetString("buttonUsers.ToolTip"));
            this.buttonUsers.UseVisualStyleBackColor = true;
            this.buttonUsers.Click += new System.EventHandler(this.buttonUsers_Click);
            // 
            // buttonLog
            // 
            resources.ApplyResources(this.buttonLog, "buttonLog");
            this.buttonLog.Name = "buttonLog";
            this.toolTipFormAdmin.SetToolTip(this.buttonLog, resources.GetString("buttonLog.ToolTip"));
            this.buttonLog.UseVisualStyleBackColor = true;
            this.buttonLog.Click += new System.EventHandler(this.buttonLog_Click);
            // 
            // buttonSettings
            // 
            resources.ApplyResources(this.buttonSettings, "buttonSettings");
            this.buttonSettings.Name = "buttonSettings";
            this.toolTipFormAdmin.SetToolTip(this.buttonSettings, resources.GetString("buttonSettings.ToolTip"));
            this.buttonSettings.UseVisualStyleBackColor = true;
            this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.linkLabelEMail);
            this.panel1.Controls.Add(this.labelVerDate);
            this.panel1.Controls.Add(this.labelVerNum);
            this.panel1.Name = "panel1";
            this.toolTipFormAdmin.SetToolTip(this.panel1, resources.GetString("panel1.ToolTip"));
            // 
            // linkLabelEMail
            // 
            resources.ApplyResources(this.linkLabelEMail, "linkLabelEMail");
            this.linkLabelEMail.Name = "linkLabelEMail";
            this.linkLabelEMail.TabStop = true;
            this.toolTipFormAdmin.SetToolTip(this.linkLabelEMail, resources.GetString("linkLabelEMail.ToolTip"));
            this.linkLabelEMail.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelEMail_LinkClicked);
            // 
            // labelVerDate
            // 
            resources.ApplyResources(this.labelVerDate, "labelVerDate");
            this.labelVerDate.Name = "labelVerDate";
            this.toolTipFormAdmin.SetToolTip(this.labelVerDate, resources.GetString("labelVerDate.ToolTip"));
            // 
            // labelVerNum
            // 
            resources.ApplyResources(this.labelVerNum, "labelVerNum");
            this.labelVerNum.Name = "labelVerNum";
            this.toolTipFormAdmin.SetToolTip(this.labelVerNum, resources.GetString("labelVerNum.ToolTip"));
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Name = "panel2";
            this.toolTipFormAdmin.SetToolTip(this.panel2, resources.GetString("panel2.ToolTip"));
            // 
            // buttonReport
            // 
            resources.ApplyResources(this.buttonReport, "buttonReport");
            this.buttonReport.Name = "buttonReport";
            this.toolTipFormAdmin.SetToolTip(this.buttonReport, resources.GetString("buttonReport.ToolTip"));
            this.buttonReport.UseVisualStyleBackColor = true;
            this.buttonReport.Click += new System.EventHandler(this.buttonReport_Click);
            // 
            // buttonBackUp
            // 
            resources.ApplyResources(this.buttonBackUp, "buttonBackUp");
            this.buttonBackUp.Name = "buttonBackUp";
            this.toolTipFormAdmin.SetToolTip(this.buttonBackUp, resources.GetString("buttonBackUp.ToolTip"));
            this.buttonBackUp.UseVisualStyleBackColor = true;
            this.buttonBackUp.Click += new System.EventHandler(this.buttonBackUp_Click);
            // 
            // FormAdministrator
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonBackUp);
            this.Controls.Add(this.buttonReport);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonSettings);
            this.Controls.Add(this.buttonLog);
            this.Controls.Add(this.buttonUsers);
            this.Controls.Add(this.buttonExitProgram);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAdministrator";
            this.toolTipFormAdmin.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonExitProgram;
        private System.Windows.Forms.Button buttonUsers;
        private System.Windows.Forms.Button buttonLog;
        private System.Windows.Forms.Button buttonSettings;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelVerDate;
        private System.Windows.Forms.Label labelVerNum;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonReport;
        private System.Windows.Forms.Button buttonBackUp;
        private System.Windows.Forms.LinkLabel linkLabelEMail;
        private System.Windows.Forms.ToolTip toolTipFormAdmin;
    }
}