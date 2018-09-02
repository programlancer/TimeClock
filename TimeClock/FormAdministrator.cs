using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Programlancer
{
    public partial class FormAdministrator : Form
    {
        User activeUser_;

        public FormAdministrator(User activeUser)
        {
            activeUser_ = activeUser;

            InitializeComponent();
        }

        private void buttonExitProgram_Click(object sender, EventArgs e)
        {
#if DEBUG
            Application.Exit();
#else

            DialogResult dr = MessageBox.Show(
                "האם לצאת ?"
                , "אישור יציאה"
                , MessageBoxButtons.YesNo
                , MessageBoxIcon.Hand
                , MessageBoxDefaultButton.Button2
                , MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign);

            if (dr == DialogResult.Yes) Application.Exit();

#endif
        }

        private void buttonUsers_Click(object sender, EventArgs e)
        {
            new FormUsers(activeUser_).ShowDialog();
        }

        private void buttonLog_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.FormLog == "B")
            {
                new FormLogUC(activeUser_).ShowDialog();
            }
            else
                new FormLog(activeUser_).ShowDialog();

        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            new FormSettings().ShowDialog();
        }

        private void buttonReport_Click(object sender, EventArgs e)
        {
            new FormReport(activeUser_).ShowDialog();
        }

        private void buttonBackUp_Click(object sender, EventArgs e)
        {
            Cursor saveCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;

            string message = Library.BackUp();

            this.Cursor = saveCursor;

            MessageBox.Show(message, Program.resourceManager.GetString("strBackUp"), MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
        }

        private void linkLabelEMail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel ll = (LinkLabel)sender;

            System.Diagnostics.Process.Start("mailto:" + ll.Text + "?Subject=TimeClock user question");
        }
    }
}
