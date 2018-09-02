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
    public partial class FormUsers : Form
    {
        User activeUser_;

        public FormUsers(User activeUser)
        {
            activeUser_ = activeUser;

            InitializeComponent();

            this.dataGridViewUsers.Columns[0].HeaderText = Program.resourceManager.GetString("strId");
            this.dataGridViewUsers.Columns[1].HeaderText = Program.resourceManager.GetString("strLogin");
            this.dataGridViewUsers.Columns[2].HeaderText = Program.resourceManager.GetString("strPassword");
            this.dataGridViewUsers.Columns[3].HeaderText = Program.resourceManager.GetString("strLastName");
            this.dataGridViewUsers.Columns[4].HeaderText = Program.resourceManager.GetString("strFirstName");
            this.dataGridViewUsers.Columns[5].HeaderText = Program.resourceManager.GetString("strIsAdmin");
            this.dataGridViewUsers.Columns[6].HeaderText = Program.resourceManager.GetString("strShowInList");
        }

        private void FormUsers_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'shopDataSet.Users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill(this.shopDataSet.Users);
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.usersBindingSource.EndEdit();
                this.usersTableAdapter.Update(this.shopDataSet.Users);
                MessageBox.Show(Program.resourceManager.GetString("strUpdateSuccessful"), "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Update failed: " + ex.Message, "Error");
            }
        }

        private void bindingNavigatorUsers_RefreshItems(object sender, EventArgs e)
        {

        }
    }
}
