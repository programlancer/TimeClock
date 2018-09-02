using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace Programlancer
{
    //[TypeConverter(typeof(ShortDateTimeConverter))]

    public class DataGridViewDateTimeCell : DataGridViewTextBoxCell
    {
        public DataGridViewDateTimeCell()
            : base()
        {
        }

        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);

            MaskedDateTimeCellEditingControl ctl = DataGridView.EditingControl as MaskedDateTimeCellEditingControl;

            //if (this.Value == null)
            //{
            //    ctl.EditingControlFormattedValue = Library.ToShortDate((DateTime)this.DefaultNewRowValue);
            //}
            //else
            //{
            //    if (string.IsNullOrEmpty(this.Value.ToString()))
            //        ctl.EditingControlFormattedValue = Library.ToShortDate((DateTime)this.DefaultNewRowValue);
            //    else
            //        ctl.EditingControlFormattedValue = Library.ToShortDate((DateTime)this.Value);
            //}

            string val = initialFormattedValue as string;

            if (val == null)
            {
                //ctl.EditingControlFormattedValue = Library.ToShortDate((DateTime)this.DefaultNewRowValue);
                ctl.EditingControlFormattedValue = Library.ToShortDate(DateTime.Now);
            }
            else
            {
                if (string.IsNullOrEmpty(val))
                    //ctl.EditingControlFormattedValue = Library.ToShortDate((DateTime)this.DefaultNewRowValue);
                    ctl.EditingControlFormattedValue = Library.ToShortDate(DateTime.Now);
                else
                    ctl.EditingControlFormattedValue = val;
            }
        }

        public override Type ValueType
        {
            get
            {
                return typeof(DateTime);
            }
        }

        public override Type EditType
        {
            get
            {
                return typeof(MaskedDateTimeCellEditingControl);
            }
        }

        //public override object DefaultNewRowValue
        //{
        //    get
        //    {
        //        return DateTime.Now;
        //    }
        //}        

        protected override object GetFormattedValue(object value, int rowIndex, ref DataGridViewCellStyle cellStyle, System.ComponentModel.TypeConverter valueTypeConverter, System.ComponentModel.TypeConverter formattedValueTypeConverter, DataGridViewDataErrorContexts context)
        {
            if (value == null)
            {
                return base.GetFormattedValue(value, rowIndex, ref cellStyle, valueTypeConverter, formattedValueTypeConverter, context);
            }
            else
                return Library.ToShortDate((DateTime)value);
        }

        public override string ToString()
        {
            //return base.ToString();
            return Library.ToShortDate((DateTime)Value);
        }
    }
}
