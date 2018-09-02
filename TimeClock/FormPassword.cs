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
    public partial class FormPassword : Form
    {

        public string Pass = null;
        public string User = null;

        public FormPassword()
        {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            Pass = maskedTextBoxPassword.Text;

            this.DialogResult = DialogResult.OK;
        }
    }
}
