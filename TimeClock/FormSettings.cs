using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;

namespace Programlancer
{
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            comboBoxLanguage.SelectedItem = Properties.Settings.Default.Language;
            comboBoxLanguage.SelectedIndexChanged += new System.EventHandler(comboBoxLanguage_SelectedIndexChanged);

            comboBoxUsersAs.SelectedItem = Properties.Settings.Default.UsersAs;
            comboBoxUsersAs.SelectedIndexChanged += new System.EventHandler(comboBoxUsersAs_SelectedIndexChanged);

            checkBoxPasswordRequiredEnterExit.Checked = Properties.Settings.Default.PasswordRequiredEnterExit;

            checkBoxSendBackUp.Checked = Properties.Settings.Default.SendBackUpByEMail;
            textBoxSendBackUpEMail.Text = Properties.Settings.Default.SendBackUpToEMail;

            textBoxSendBackUpEMail.Enabled = checkBoxSendBackUp.Checked;

            comboBoxFormLog.SelectedItem = Properties.Settings.Default.FormLog;
            comboBoxFormLog.SelectedIndexChanged += comboBoxFormLog_SelectedIndexChanged;
        }

        private void comboBoxLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox language = (ComboBox)sender;

            switch (language.SelectedItem.ToString())
            {
                case "English":
                    SetAndSaveLangSettings("English", "en-US");
                    break;
                case "Hebrew":
                    SetAndSaveLangSettings("Hebrew", "he-IL");
                    break;
                default:

                    break;
            }
        }

        private void SetAndSaveLangSettings(string language, string culture)
        {
            Properties.Settings.Default.Language = language;
            Properties.Settings.Default.CultureInfo = culture;
            Properties.Settings.Default.Save();

            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Properties.Settings.Default.CultureInfo, false);
        }

        private void checkBoxPasswordRequiredEnterExit_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.PasswordRequiredEnterExit = checkBoxPasswordRequiredEnterExit.Checked;
            Properties.Settings.Default.Save();
        }

        private void checkBoxSendBackUp_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.SendBackUpByEMail = checkBoxSendBackUp.Checked;
            Properties.Settings.Default.Save();

            textBoxSendBackUpEMail.Enabled = checkBoxSendBackUp.Checked;
        }

        private void textBoxSendBackUpEMail_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.SendBackUpToEMail = textBoxSendBackUpEMail.Text;
            Properties.Settings.Default.Save();
        }

        private void comboBoxUsersAs_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.UsersAs = ((ComboBox)sender).SelectedItem.ToString();
            Properties.Settings.Default.Save();
        }

        private void comboBoxFormLog_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.FormLog = ((ComboBox)sender).SelectedItem.ToString();
            Properties.Settings.Default.Save();
        }
    }
}
