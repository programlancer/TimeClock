namespace Programlancer
{
    partial class FormSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettings));
            this.labelLanguage = new System.Windows.Forms.Label();
            this.comboBoxLanguage = new System.Windows.Forms.ComboBox();
            this.checkBoxPasswordRequiredEnterExit = new System.Windows.Forms.CheckBox();
            this.checkBoxSendBackUp = new System.Windows.Forms.CheckBox();
            this.labelSendBackUp = new System.Windows.Forms.Label();
            this.textBoxSendBackUpEMail = new System.Windows.Forms.TextBox();
            this.groupBoxSendBackUp = new System.Windows.Forms.GroupBox();
            this.labelUsersAs = new System.Windows.Forms.Label();
            this.comboBoxUsersAs = new System.Windows.Forms.ComboBox();
            this.labelFormLog = new System.Windows.Forms.Label();
            this.comboBoxFormLog = new System.Windows.Forms.ComboBox();
            this.groupBoxSendBackUp.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelLanguage
            // 
            resources.ApplyResources(this.labelLanguage, "labelLanguage");
            this.labelLanguage.Name = "labelLanguage";
            // 
            // comboBoxLanguage
            // 
            this.comboBoxLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLanguage.FormattingEnabled = true;
            this.comboBoxLanguage.Items.AddRange(new object[] {
            resources.GetString("comboBoxLanguage.Items"),
            resources.GetString("comboBoxLanguage.Items1")});
            resources.ApplyResources(this.comboBoxLanguage, "comboBoxLanguage");
            this.comboBoxLanguage.Name = "comboBoxLanguage";
            // 
            // checkBoxPasswordRequiredEnterExit
            // 
            resources.ApplyResources(this.checkBoxPasswordRequiredEnterExit, "checkBoxPasswordRequiredEnterExit");
            this.checkBoxPasswordRequiredEnterExit.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.checkBoxPasswordRequiredEnterExit.Name = "checkBoxPasswordRequiredEnterExit";
            this.checkBoxPasswordRequiredEnterExit.UseVisualStyleBackColor = true;
            this.checkBoxPasswordRequiredEnterExit.CheckedChanged += new System.EventHandler(this.checkBoxPasswordRequiredEnterExit_CheckedChanged);
            // 
            // checkBoxSendBackUp
            // 
            resources.ApplyResources(this.checkBoxSendBackUp, "checkBoxSendBackUp");
            this.checkBoxSendBackUp.Name = "checkBoxSendBackUp";
            this.checkBoxSendBackUp.UseVisualStyleBackColor = true;
            this.checkBoxSendBackUp.CheckedChanged += new System.EventHandler(this.checkBoxSendBackUp_CheckedChanged);
            // 
            // labelSendBackUp
            // 
            resources.ApplyResources(this.labelSendBackUp, "labelSendBackUp");
            this.labelSendBackUp.Name = "labelSendBackUp";
            // 
            // textBoxSendBackUpEMail
            // 
            resources.ApplyResources(this.textBoxSendBackUpEMail, "textBoxSendBackUpEMail");
            this.textBoxSendBackUpEMail.Name = "textBoxSendBackUpEMail";
            this.textBoxSendBackUpEMail.TextChanged += new System.EventHandler(this.textBoxSendBackUpEMail_TextChanged);
            // 
            // groupBoxSendBackUp
            // 
            this.groupBoxSendBackUp.Controls.Add(this.labelSendBackUp);
            this.groupBoxSendBackUp.Controls.Add(this.textBoxSendBackUpEMail);
            resources.ApplyResources(this.groupBoxSendBackUp, "groupBoxSendBackUp");
            this.groupBoxSendBackUp.Name = "groupBoxSendBackUp";
            this.groupBoxSendBackUp.TabStop = false;
            // 
            // labelUsersAs
            // 
            resources.ApplyResources(this.labelUsersAs, "labelUsersAs");
            this.labelUsersAs.Name = "labelUsersAs";
            // 
            // comboBoxUsersAs
            // 
            this.comboBoxUsersAs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUsersAs.FormattingEnabled = true;
            this.comboBoxUsersAs.Items.AddRange(new object[] {
            resources.GetString("comboBoxUsersAs.Items"),
            resources.GetString("comboBoxUsersAs.Items1")});
            resources.ApplyResources(this.comboBoxUsersAs, "comboBoxUsersAs");
            this.comboBoxUsersAs.Name = "comboBoxUsersAs";
            // 
            // labelFormLog
            // 
            resources.ApplyResources(this.labelFormLog, "labelFormLog");
            this.labelFormLog.Name = "labelFormLog";
            // 
            // comboBoxFormLog
            // 
            this.comboBoxFormLog.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFormLog.FormattingEnabled = true;
            this.comboBoxFormLog.Items.AddRange(new object[] {
            resources.GetString("comboBoxFormLog.Items"),
            resources.GetString("comboBoxFormLog.Items1")});
            resources.ApplyResources(this.comboBoxFormLog, "comboBoxFormLog");
            this.comboBoxFormLog.Name = "comboBoxFormLog";
            // 
            // FormSettings
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboBoxFormLog);
            this.Controls.Add(this.labelFormLog);
            this.Controls.Add(this.comboBoxUsersAs);
            this.Controls.Add(this.labelUsersAs);
            this.Controls.Add(this.groupBoxSendBackUp);
            this.Controls.Add(this.checkBoxSendBackUp);
            this.Controls.Add(this.checkBoxPasswordRequiredEnterExit);
            this.Controls.Add(this.comboBoxLanguage);
            this.Controls.Add(this.labelLanguage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSettings";
            this.Load += new System.EventHandler(this.FormSettings_Load);
            this.groupBoxSendBackUp.ResumeLayout(false);
            this.groupBoxSendBackUp.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelLanguage;
        private System.Windows.Forms.ComboBox comboBoxLanguage;
        private System.Windows.Forms.CheckBox checkBoxPasswordRequiredEnterExit;
        private System.Windows.Forms.CheckBox checkBoxSendBackUp;
        private System.Windows.Forms.Label labelSendBackUp;
        private System.Windows.Forms.TextBox textBoxSendBackUpEMail;
        private System.Windows.Forms.GroupBox groupBoxSendBackUp;
        private System.Windows.Forms.Label labelUsersAs;
        private System.Windows.Forms.ComboBox comboBoxUsersAs;
        private System.Windows.Forms.Label labelFormLog;
        private System.Windows.Forms.ComboBox comboBoxFormLog;
    }
}