using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Programlancer
{
    public class ShortDateTimeConverter : System.ComponentModel.DateTimeConverter
    {
        public override object ConvertTo(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return Library.ToShortDate((DateTime)value);
            }
            else
                return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
