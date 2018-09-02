using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;

namespace Programlancer
{
    public partial class FormEnterExit : Form
    {
        public string Direction
        {
            set
            {
                switch (value.ToUpper())
                {
                    case "ENTER":
                        radioButtonEnter.Checked = true;
                        break;
                    case "EXIT":
                        radioButtonExit.Checked = true;
                        break;
                    default:
                        break;
                }
            }
        }

        public FormEnterExit()
        {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string userName = null;

            if (Properties.Settings.Default.UsersAs == "Radio")
            {
                foreach (Control control in this.groupBoxUsers.Controls)
                {
                    if (control is RadioButton)
                    {
                        if ((control as RadioButton).Checked) userName = (control as RadioButton).Text;
                    }
                }
            }
            else
                if (comboBoxUser.SelectedItem == null)
                {
                    if (comboBoxUser.Text == "")
                        MessageBox.Show(
                            Program.resourceManager.GetString("strLoginPasswordIsNotExists")
                            , Program.resourceManager.GetString("strError")
                            , MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    else
                    {
                        userName = comboBoxUser.Text;
                    }
                }
                else
                {
                    userName = (comboBoxUser.SelectedItem as ComboBoxItem).Text;
                }

            User user = User.Create(
                            userName,
                            this.maskedTextBoxPassWord.Text,
                            Properties.Settings.Default.PasswordRequiredEnterExit);

            if (user == null)
            {
                MessageBox.Show(
                    Program.resourceManager.GetString("strLoginPasswordIsNotExists")
                    , Program.resourceManager.GetString("strError")
                    , MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
            else
            {
                string what = "";
                string message = "";

                if (radioButtonEnter.Checked)
                {
                    if (user.IsWorking())
                    {
                        MessageBox.Show(
                            Program.resourceManager.GetString("strAtWorkAlready") + " !"
                            , Program.resourceManager.GetString("strError")
                            , MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    }
                    else
                    {
                        what = "In";
                        message = "שלום";
                    }
                }

                if (radioButtonExit.Checked)
                {
                    if (user.IsWorking())
                    {
                        what = "Out";
                        message = "להתראות";
                    }
                    else
                    {
                        MessageBox.Show(
                            Program.resourceManager.GetString("strNotAtWork") + " !"
                            , Program.resourceManager.GetString("strError")
                            , MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    }

                }

                if (!string.IsNullOrWhiteSpace(what))
                {
                    if (Library.SaveToLog(user.Id.ToString(), what))
                    {
                        using (FormMessage formMessage = new FormMessage())
                        {
                            formMessage.Animate(message + " " + user.FirstName, this);
                        }
                    }
                    else
                    {
                        MessageBox.Show(
                            Program.resourceManager.GetString("strRecordIsNotSaved") + " !"
                            , Program.resourceManager.GetString("strError")
                            , MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    }

                    this.Close();
                }
            }
        }

        private void FormEE_Load(object sender, EventArgs e)
        {
            labelPass.Visible = Properties.Settings.Default.PasswordRequiredEnterExit;
            maskedTextBoxPassWord.Visible = Properties.Settings.Default.PasswordRequiredEnterExit;

            if (Properties.Settings.Default.UsersAs == "Radio")
            {
                labelUser.Visible = false;
                comboBoxUser.Visible = false;

                List<User> users = Library.GetUsers(0);

                groupBoxUsers.Visible = true;
                groupBoxUsers.Location = new Point(31, 140);

                int i = 0;
                //int t = 4;

                foreach (User u in users)
                {
                    System.Windows.Forms.RadioButton rb = new RadioButton() { Name = "radioButtonUser" + u.Id, TabStop = true, Text = u.FirstName, UseVisualStyleBackColor = true };
                    rb.Location = new Point(groupBoxUsers.Width / 3, 15 + i * 23);
                    groupBoxUsers.Controls.Add(rb);

                    groupBoxUsers.Size = new Size(groupBoxUsers.Size.Width, groupBoxUsers.Size.Height + 23);

                    //buttonSave.TabIndex = rb.TabIndex + 1;

                    if (i > 4)
                    {
                        buttonSave.Location = new Point(buttonSave.Location.X, buttonSave.Location.Y + 23);
                        this.Size = new Size(this.Size.Width, this.Size.Height + 23);
                    }

                    i++;
                }

                this.Controls.Add(groupBoxUsers);

            }
            else
            {
                Library.FillComboUsers(comboBoxUser);
            }

            labelTime.Text = DateTime.Now.ToShortTimeString();
            labelDate.Text = DateTime.Now.ToShortDateString();
            timerMain.Enabled = true;
        }

        private void FormEE_FormClosing(object sender, FormClosingEventArgs e)
        {
            timerMain.Enabled = false;
        }

        private void timerMain_Tick(object sender, EventArgs e)
        {
            labelTime.Text = DateTime.Now.ToShortTimeString();
            labelDate.Text = DateTime.Now.ToShortDateString();
        }

    }
}
