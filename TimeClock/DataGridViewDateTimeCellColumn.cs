using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Programlancer
{
    public class DataGridViewDateTimeCellColumn : DataGridViewColumn
    {
        public DataGridViewDateTimeCellColumn() :base(new DataGridViewDateTimeCell())
        {
        }

        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                if (value != null &&
                !value.GetType().IsAssignableFrom(typeof(DataGridViewDateTimeCell)))
                {
                    throw new InvalidCastException("Must be a DataGridViewDateTimeCell");
                }
                base.CellTemplate = value;
            }
        }
    }
}
