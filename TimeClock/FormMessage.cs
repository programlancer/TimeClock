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
    public partial class FormMessage : Form
    {
        public FormMessage()
        {
            InitializeComponent();

            this.TopLevel = false;
            this.Dock = DockStyle.Fill;
        }

        public void Animate(string message, Form parent)
        {
            this.Parent = parent;
            this.labelMessage.Text = message;

            this.Show();
            this.BringToFront();
            this.Focus();
            Application.DoEvents();

            //this.Opacity = 0.0;

            //double[] o = { 0.1, 0.2, 0.3, 0.4, 0.5, 0.6, 0.7, 0.8, 0.9, 1.0, 1.0, 1.0, 0.9, 0.8, 0.7, 0.6, 0.5, 0.4, 0.3, 0.2, 0.1 };

            //foreach (double item in o)
            //{
            //    System.Threading.Thread.Sleep(200);
            //    this.Opacity = item;
            //}

            for (int i = 0; i < 10; i++)
            {
                System.Threading.Thread.Sleep(200);
                this.labelMessage.Text += ".";
                this.Refresh();
            }

            this.Hide();
            //this.Close();
        }
    }
}
