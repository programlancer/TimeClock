using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;

namespace Programlancer
{
    public partial class FormLogin : Form
    {
        public User User = null;

        public FormLogin()
        {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (comboBoxUser.SelectedItem == null)
            {
                if (comboBoxUser.Text != "")
                {
                    User = User.Create(
                        comboBoxUser.Text
                        , this.maskedTextBoxPassWord.Text
                        , true);
                }
            }
            else
            {
                User = User.Create(
                        (comboBoxUser.SelectedItem as ComboBoxItem).Text
                        , this.maskedTextBoxPassWord.Text
                        , true);
            }

            if (User == null)
            {
                MessageBox.Show(
                    Program.resourceManager.GetString("strLoginPasswordIsNotExists")
                    , Program.resourceManager.GetString("strError")
                    , MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }

        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            Library.FillComboUsers(comboBoxUser);

            if (comboBoxUser.Items.Count == 0|| System.Windows.Forms.Control.ModifierKeys == Keys.Shift)
            {
                comboBoxUser.DropDownStyle = ComboBoxStyle.Simple;
            }
        }

        private void comboBoxUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectNextControl(this.comboBoxUser, true, true, false, false);
        }
    }
}
