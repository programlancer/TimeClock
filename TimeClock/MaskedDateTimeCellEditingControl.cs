using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Programlancer
{
    class MaskedDateTimeCellEditingControl : MaskedTextBox, IDataGridViewEditingControl
    {
        DataGridView dataGridView;
        private bool valueChanged = false;
        private string originalValue = "";
        int rowIndex;

        public MaskedDateTimeCellEditingControl()
            : base("00/00/00 00:00")
        {
        }

        #region IDataGridViewEditingControl

        public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
        {
            this.Font = dataGridViewCellStyle.Font;
            this.ForeColor = dataGridViewCellStyle.ForeColor;
            this.BackColor = dataGridViewCellStyle.BackColor;
            this.TextAlign = HorizontalAlignment.Center;
            this.RightToLeft = RightToLeft.No;
        }

        public DataGridView EditingControlDataGridView
        {
            get
            {
                return dataGridView;
            }
            set
            {
                dataGridView = value;
            }
        }

        public object EditingControlFormattedValue
        {
            get
            {
                return this.Text;
            }
            set
            {
                if (value is String)
                {
                    try
                    {
                        originalValue = value.ToString();
                    }
                    catch
                    {
                        originalValue = Library.ToShortDate(DateTime.MinValue);
                    }

                    this.Text = originalValue;
                }
                else { throw new Exception("Is not a string!"); }

            }
        }

        public int EditingControlRowIndex
        {
            get
            {
                return rowIndex;
            }
            set
            {
                rowIndex = value;
            }
        }

        public bool EditingControlValueChanged
        {
            get
            {
                return valueChanged;
            }
            set
            {
                valueChanged = value;
            }
        }

        public bool EditingControlWantsInputKey(Keys keyData, bool dataGridViewWantsInputKey)
        {
            switch (keyData & Keys.KeyCode)
            {
                case Keys.Left:
                //case Keys.Up:
                //case Keys.Down:
                case Keys.Right:
                case Keys.Home:
                case Keys.End:
                    //case Keys.PageDown:
                    //case Keys.PageUp:
                    return true;
                default:
                    return !dataGridViewWantsInputKey;
            }
        }

        public Cursor EditingPanelCursor
        {
            get { return base.Cursor; }
        }

        public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
        {
            return EditingControlFormattedValue;
        }

        public void PrepareEditingControlForEdit(bool selectAll)
        {
            this.SelectAll();
        }

        public bool RepositionEditingControlOnValueChange
        {
            get { return false; }
        }
        #endregion

        //protected override void OnValidating(System.ComponentModel.CancelEventArgs e)
        //{
        //    if (this.Modified)
        //    {
        //        valueChanged = true;
        //        this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
        //        base.OnValidating(e);
        //    }

        //}

        protected override void OnTextChanged(EventArgs e)
        {
            if (this.Text != originalValue)
            {
                valueChanged = true;
                this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
                base.OnTextChanged(e);
            }
        }
    }
}
