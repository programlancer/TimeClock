using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Resources;

namespace Programlancer
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void notifyIconApp_DoubleClick(object sender, EventArgs e)
        {
            ShowMainWindow();
        }

        void ShowMainWindow()
        {
            WindowState = FormWindowState.Normal;
            notifyIconApp.Visible = false;
            ShowInTaskbar = !notifyIconApp.Visible;
            this.Show();
        }

        void HideMainWindow()
        {
            WindowState = FormWindowState.Minimized;
            notifyIconApp.Visible = true;
            ShowInTaskbar = !notifyIconApp.Visible;
        }

        private void toolStripMenuItemEnter_Click(object sender, EventArgs e)
        {
            using (FormEnterExit formEE = new FormEnterExit() { Direction = "ENTER" })
            {
                formEE.ShowDialog();
            }
        }

        private void toolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            using (FormEnterExit formEE = new FormEnterExit() { Direction = "EXIT" })
            {
                formEE.ShowDialog();
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                HideMainWindow();
            }
        }

        private void toolStripMenuItemReport_Click(object sender, EventArgs e)
        {
            using (FormLogin formLogin = new FormLogin())
            {
                DialogResult dr = formLogin.ShowDialog();

                if (dr == DialogResult.OK)
                {
                    new FormReport(formLogin.User).ShowDialog();
                }
            }
        }

        //delegate DialogResult Method();

        //void ShowToAdmin(Method show)
        //{
        //}

        private void FormMain_Activated(object sender, EventArgs e)
        {
            dataGridViewToday.DataSource = Library.AtWork();

            dataGridViewToday.Columns["In"].DefaultCellStyle.Format = "t";

            dataGridViewToday.Columns["In"].HeaderText = Program.resourceManager.GetString("strIn");
            dataGridViewToday.Columns["User"].HeaderText = Program.resourceManager.GetString("strWorker");
        }

        private void administratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FormLogin formLogin = new FormLogin())
            {
                DialogResult dr = formLogin.ShowDialog();

                if (dr == DialogResult.OK)
                {
                    if (formLogin.User.IsAdmin)
                    {
                        new FormAdministrator(formLogin.User).ShowDialog();
                    }
                    else
                        MessageBox.Show(
                            Program.resourceManager.GetString("strOnlyAdminCanViewForm") + " !"
                            , Program.resourceManager.GetString("strError")
                            , MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
            }
        }

#if DEBUG
        private void exitProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
#endif

        private void FormMain_Load(object sender, EventArgs e)
        {
#if DEBUG

            System.Windows.Forms.ToolStripMenuItem exitProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripApp.Items.Add(exitProgramToolStripMenuItem);
            exitProgramToolStripMenuItem.Name = "exitProgramToolStripMenuItem";
            exitProgramToolStripMenuItem.Text = "Exit Program";
            exitProgramToolStripMenuItem.Click += new System.EventHandler(this.exitProgramToolStripMenuItem_Click);
#endif
        }

    }
}
