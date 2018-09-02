using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Programlancer
{
    public partial class InOutControl : UserControl
    {
        public InOutControl()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

            RadioButton b = (RadioButton)sender;
            SwitchBold(b);
        }

        private static void SwitchBold(RadioButton b)
        {
            if (b.Checked)
            {
                b.Font = new Font(b.Font, FontStyle.Bold);
                //b.ForeColor = Color.Green;
            }
            else
            {
                b.Font = new Font(b.Font, FontStyle.Regular);
                //b.ForeColor = Color.Gray;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton b = (RadioButton)sender;
            SwitchBold(b);
        }



    }
}
