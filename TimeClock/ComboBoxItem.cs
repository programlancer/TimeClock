using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Programlancer
{
    public class ComboBoxItem
    {
        public String Text { get; set; }
        public int Value { get; set; }

        public ComboBoxItem(String text, int value)
        {
            this.Text = text;
            this.Value = value;
        }

        public override string ToString()
        {
            return Text;
        }

    }
}
