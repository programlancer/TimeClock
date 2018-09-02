namespace Programlancer
{
    partial class FormEnterExit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEnterExit));
            this.labelDate = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.maskedTextBoxPassWord = new System.Windows.Forms.MaskedTextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.labelOr = new System.Windows.Forms.Label();
            this.comboBoxUser = new System.Windows.Forms.ComboBox();
            this.labelPass = new System.Windows.Forms.Label();
            this.radioButtonExit = new System.Windows.Forms.RadioButton();
            this.labelUser = new System.Windows.Forms.Label();
            this.radioButtonEnter = new System.Windows.Forms.RadioButton();
            this.timerMain = new System.Windows.Forms.Timer(this.components);
            this.groupBoxDirection = new System.Windows.Forms.GroupBox();
            this.groupBoxUsers = new System.Windows.Forms.GroupBox();
            this.groupBoxDirection.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelDate
            // 
            resources.ApplyResources(this.labelDate, "labelDate");
            this.labelDate.Name = "labelDate";
            // 
            // labelTime
            // 
            resources.ApplyResources(this.labelTime, "labelTime");
            this.labelTime.Name = "labelTime";
            // 
            // maskedTextBoxPassWord
            // 
            resources.ApplyResources(this.maskedTextBoxPassWord, "maskedTextBoxPassWord");
            this.maskedTextBoxPassWord.Name = "maskedTextBoxPassWord";
            this.maskedTextBoxPassWord.UseSystemPasswordChar = true;
            // 
            // buttonSave
            // 
            resources.ApplyResources(this.buttonSave, "buttonSave");
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // labelOr
            // 
            resources.ApplyResources(this.labelOr, "labelOr");
            this.labelOr.Name = "labelOr";
            // 
            // comboBoxUser
            // 
            this.comboBoxUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUser.FormattingEnabled = true;
            resources.ApplyResources(this.comboBoxUser, "comboBoxUser");
            this.comboBoxUser.Name = "comboBoxUser";
            // 
            // labelPass
            // 
            resources.ApplyResources(this.labelPass, "labelPass");
            this.labelPass.Name = "labelPass";
            // 
            // radioButtonExit
            // 
            resources.ApplyResources(this.radioButtonExit, "radioButtonExit");
            this.radioButtonExit.Name = "radioButtonExit";
            this.radioButtonExit.TabStop = true;
            this.radioButtonExit.UseVisualStyleBackColor = true;
            // 
            // labelUser
            // 
            resources.ApplyResources(this.labelUser, "labelUser");
            this.labelUser.Name = "labelUser";
            // 
            // radioButtonEnter
            // 
            resources.ApplyResources(this.radioButtonEnter, "radioButtonEnter");
            this.radioButtonEnter.Name = "radioButtonEnter";
            this.radioButtonEnter.TabStop = true;
            this.radioButtonEnter.UseVisualStyleBackColor = true;
            // 
            // timerMain
            // 
            this.timerMain.Interval = 1000;
            this.timerMain.Tick += new System.EventHandler(this.timerMain_Tick);
            // 
            // groupBoxDirection
            // 
            this.groupBoxDirection.Controls.Add(this.radioButtonEnter);
            this.groupBoxDirection.Controls.Add(this.labelOr);
            this.groupBoxDirection.Controls.Add(this.radioButtonExit);
            resources.ApplyResources(this.groupBoxDirection, "groupBoxDirection");
            this.groupBoxDirection.Name = "groupBoxDirection";
            this.groupBoxDirection.TabStop = false;
            // 
            // groupBoxUsers
            // 
            resources.ApplyResources(this.groupBoxUsers, "groupBoxUsers");
            this.groupBoxUsers.Name = "groupBoxUsers";
            this.groupBoxUsers.TabStop = false;
            // 
            // FormEnterExit
            // 
            this.AcceptButton = this.buttonSave;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxUsers);
            this.Controls.Add(this.groupBoxDirection);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.maskedTextBoxPassWord);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.comboBoxUser);
            this.Controls.Add(this.labelPass);
            this.Controls.Add(this.labelUser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEnterExit";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormEE_FormClosing);
            this.Load += new System.EventHandler(this.FormEE_Load);
            this.groupBoxDirection.ResumeLayout(false);
            this.groupBoxDirection.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxPassWord;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label labelOr;
        private System.Windows.Forms.ComboBox comboBoxUser;
        private System.Windows.Forms.Label labelPass;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.Timer timerMain;
        private System.Windows.Forms.RadioButton radioButtonEnter;
        private System.Windows.Forms.RadioButton radioButtonExit;
        private System.Windows.Forms.GroupBox groupBoxDirection;
        private System.Windows.Forms.GroupBox groupBoxUsers;
    }
}