using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Resources;

namespace Programlancer
{
    public partial class FormReport : Form
    {
        User activeUser_;

        public FormReport(User activeUser)
        {
            activeUser_ = activeUser;

            InitializeComponent();
        }

        private void FormReport_Load(object sender, EventArgs e)
        {
            comboBoxUser.Items.Clear();

            if (activeUser_.IsAdmin)
            {
                comboBoxUser.Items.Add(new ComboBoxItem(Program.resourceManager.GetString("strAll"), 0));
                comboBoxUser.SelectedIndex = 0;

                Library.FillComboUsers(comboBoxUser);
            }
            else
            {
                comboBoxUser.Items.Add(new ComboBoxItem(activeUser_.Login, activeUser_.Id));

                comboBoxUser.Text = activeUser_.Login;
            }

            comboBoxUser.DisplayMember = "Text";
            comboBoxUser.ValueMember = "Value";

            dateTimePickerFrom.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dateTimePickerTo.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month));

            this.dateTimePickerFrom.ValueChanged += new System.EventHandler(this.dateTimePickerFrom_ValueChanged);
            this.dateTimePickerTo.ValueChanged += new System.EventHandler(this.dateTimePickerTo_ValueChanged);
            this.comboBoxUser.SelectedIndexChanged += new System.EventHandler(this.comboBoxUser_SelectedIndexChanged);

            RefreshReport();

            dataGridViewReport.Columns["Date"].DefaultCellStyle.Format = "m";
            dataGridViewReport.Columns["In"].DefaultCellStyle.Format = "t";
            dataGridViewReport.Columns["Out"].DefaultCellStyle.Format = "t";
            dataGridViewReport.Columns["Duration"].DefaultCellStyle.Format = "hh\\:mm";

            dataGridViewReport.Columns["Date"].HeaderText = Program.resourceManager.GetString("strDate");
            dataGridViewReport.Columns["In"].HeaderText = Program.resourceManager.GetString("strIn");
            dataGridViewReport.Columns["Out"].HeaderText = Program.resourceManager.GetString("strOut");
            dataGridViewReport.Columns["Duration"].HeaderText = Program.resourceManager.GetString("strDuration");
            dataGridViewReport.Columns["User"].HeaderText = Program.resourceManager.GetString("strUser");
        }

        private void comboBoxUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshReport();

            dataGridViewReport.Columns[1].Visible = (comboBoxUser.SelectedItem as ComboBoxItem).Value == 0;
        }

        private void dateTimePickerTo_ValueChanged(object sender, EventArgs e)
        {
            RefreshReport();
        }

        private void dateTimePickerFrom_ValueChanged(object sender, EventArgs e)
        {
            RefreshReport();
        }

        private void RefreshReport()
        {
            Cursor saveCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;

            TimeSpan amount = new TimeSpan();
            DataTable table = Library.Report((comboBoxUser.SelectedItem as ComboBoxItem).Value, dateTimePickerFrom.Value, dateTimePickerTo.Value);

            foreach (DataRow row in table.Rows)
            {
                amount += (TimeSpan)row[4];
            }

            labelAmount.Text = (amount.Days * 24 + amount.Hours).ToString() + ":" + amount.Minutes.ToString("d2");

            dataGridViewReport.DataSource = table;

            this.Cursor = saveCursor;
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            Cursor saveCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;

            User user = null;

            if ((comboBoxUser.SelectedItem as ComboBoxItem).Value > 0)
            {
                user = User.CreateUserFromId((comboBoxUser.SelectedItem as ComboBoxItem).Value);
            }

            ReportData reportData = new ReportData(
                user
                , dateTimePickerFrom.Value
                , dateTimePickerTo.Value
                , Library.Report((comboBoxUser.SelectedItem as ComboBoxItem).Value, dateTimePickerFrom.Value, dateTimePickerTo.Value));

            this.Cursor = saveCursor;

            using (FormReportViewer formReportViewer = new FormReportViewer(reportData))
            {
                formReportViewer.ShowDialog();
            }

        }
    }

}
