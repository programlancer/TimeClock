using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Resources;

namespace Programlancer
{
    public partial class FormLogUC : Form
    {
        User activeUser;

        public FormLogUC(User activeUser)
        {
            this.activeUser = activeUser;

            InitializeComponent();
        }

        private void FormLog_Load(object sender, EventArgs e)
        {
            comboBoxUser.Items.Clear();

            if (activeUser.IsAdmin)
            {
                comboBoxUser.Items.Add(new ComboBoxItem(Program.resourceManager.GetString("strAll"), 0));
                comboBoxUser.SelectedIndex = 0;

                Library.FillComboUsers(comboBoxUser);
            }
            else
            {
                comboBoxUser.Items.Add(new ComboBoxItem(activeUser.Login, activeUser.Id));

                comboBoxUser.Text = activeUser.Login;
            }

            comboBoxUser.DisplayMember = "Text";
            comboBoxUser.ValueMember = "Value";

            //dateTimePickerFrom.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            //dateTimePickerTo.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month));
            dateTimePickerFrom.Value = DateTime.Today;
            dateTimePickerTo.Value = DateTime.Today;

            this.dateTimePickerFrom.ValueChanged += new System.EventHandler(this.dateTimePickerFrom_ValueChanged);
            this.dateTimePickerTo.ValueChanged += new System.EventHandler(this.dateTimePickerTo_ValueChanged);
            this.comboBoxUser.SelectedIndexChanged += new System.EventHandler(this.comboBoxUser_SelectedIndexChanged);

            FillDataSet();

            SetFilter();
        }

        private void comboBoxUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetFilter();
        }

        private void dateTimePickerTo_ValueChanged(object sender, EventArgs e)
        {
            SetFilter();
        }

        private void dateTimePickerFrom_ValueChanged(object sender, EventArgs e)
        {
            SetFilter();
        }

        private void FillDataSet()
        {
            // TODO: This line of code loads data into the 'shopDataSet.Log' table. You can move, or remove it, as needed.
            this.logTableAdapter.Fill(this.shopDataSet.Log);
        }

        private void SetFilter()
        {
            string filter = "";

            if ((comboBoxUser.SelectedItem as ComboBoxItem).Value != 0)
                filter = "[Id]=" + (comboBoxUser.SelectedItem as ComboBoxItem).Value.ToString() + " AND ";

            filter += string.Format(CultureInfo.InvariantCulture, "[When] >= #{0}#", dateTimePickerFrom.Value);
            filter += " AND " + string.Format(CultureInfo.InvariantCulture, "[When] < #{0}#", dateTimePickerTo.Value.AddDays(1));

            this.logBindingSource.Filter = filter;

            labelTotal.Text = logBindingSource.Count.ToString();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.logBindingSource.EndEdit();
                this.logTableAdapter.Update(this.shopDataSet.Log);

                MessageBox.Show(Program.resourceManager.GetString("strUpdateSuccessful") + " !", Program.resourceManager.GetString("strMessage"), MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
            catch (System.Exception ex)
            {
                Library.WriteTextMessage(ex.Message);
                MessageBox.Show(Program.resourceManager.GetString("strUpdateFailed") + " !", Program.resourceManager.GetString("strError"), MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
        }

        //private void dataGridViewLog_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        //{
        //    if ((comboBoxUser.SelectedItem as ComboBoxItem).Value > 0)
        //    {
        //        User u = User.CreateUserFromId((comboBoxUser.SelectedItem as ComboBoxItem).Value);
        //        e.Row.Cells[0].Value = u.Id;
        //        e.Row.Cells[1].Value = u.Login;
        //    }

        //    e.Row.Cells[2].Value = DateTime.Now;
        //    e.Row.Cells[3].Value = "In ";
        //}

        private void dataGridViewLog_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //if (e.RowIndex < 0) return;

            //if (e.ColumnIndex == 2)
            //{
            //    e.PaintBackground(e.CellBounds, true);
            //    TextRenderer.DrawText(e.Graphics, e.FormattedValue.ToString(), e.CellStyle.Font, e.CellBounds, e.CellStyle.ForeColor);

            //    e.Handled = true;
            //}
        }

        private void dataGridViewLog_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            dataGridViewLog.Rows[e.RowIndex].ErrorText = "";

            if (dataGridViewLog.Rows[e.RowIndex].IsNewRow) return;

            switch (e.ColumnIndex)
            {
                case 0:
                    int id;
                    int.TryParse(e.FormattedValue.ToString(), out id);
                    if (id > 0)
                    {
                        dataGridViewLog.Rows[e.RowIndex].Cells[1].Value = User.CreateUserFromId(id).Login;
                    }
                    else
                    {
                        //e.Cancel = true;
                        //dataGridViewLog.Rows[e.RowIndex].ErrorText = "the value must be a non-negative integer";
                        dataGridViewLog.Rows[e.RowIndex].ErrorText = "קוד עובד אינו מוגדר !";
                    }
                    break;

                case 2:

                    break;

                case 3:
                    break;

                default:
                    break;
            }
        }

        private void dataGridViewLog_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //if (e.RowIndex < 0) return;

            //if (dataGridViewLog.Rows[e.RowIndex].IsNewRow) return;

            switch (e.ColumnIndex)
            {
                case 1:
                    if (dataGridViewLog.Rows[e.RowIndex].Cells[0].Value != null)
                    {
                        int id;
                        int.TryParse(dataGridViewLog.Rows[e.RowIndex].Cells[0].Value.ToString(), out id);
                        if (id > 0)
                        {
                            e.Value = User.CreateUserFromId(id).Login;
                            e.FormattingApplied = true;
                        }
                    }

                    break;

                //case 2:
                //    if (e.Value != null)
                //    {
                //        try
                //        {
                //            DateTime theDate = DateTime.Parse(e.Value.ToString());

                //            e.Value = Library.ToShortDate(theDate);
                //            e.FormattingApplied = true;
                //        }
                //        catch (FormatException)
                //        {
                //            // Set to false in case there are other handlers interested trying to
                //            // format this DataGridViewCellFormattingEventArgs instance.
                //            e.FormattingApplied = false;
                //        }
                //    }
                //    break;

                default:
                    break;
            }
        }

        private void logBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            DataRowView drv = this.logBindingSource.Current as DataRowView;

            ShopDataSet.LogRow current = null;

            if (drv != null)
            {
                current = drv.Row as ShopDataSet.LogRow;
            }

            DataView dv = logBindingSource.List as DataView;
            drv = dv.AddNew();

            if (current == null)
            {
                drv[0] = 0;
            }
            else
            {
                drv[0] = current.Id;
            }

            drv[1] = DateTime.Now;
            drv[2] = "In ";

            e.NewObject = drv;

            logBindingSource.MoveLast();

        }

        private void dataGridViewLog_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

            if ((e.Exception) is ConstraintException)
            {
                //MessageBox.Show(/*Program.resourceManager.GetString("strUpdateFailed") + "Constraint Exception: " + */e.Exception.Message, Program.resourceManager.GetString("strError"), MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                MessageBox.Show("שורה כבר קיימת !", Program.resourceManager.GetString("strError"), MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                e.ThrowException = true;
            }
            else
            {
                MessageBox.Show(e.Exception.Message);
                e.ThrowException = true;
            }
        }

        private void dataGridViewLog_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            //if (this.dataGridViewLog.IsCurrentRowDirty)
            //{

            //}
            labelTotal.Text = logBindingSource.Count.ToString();

        }

    }
}
