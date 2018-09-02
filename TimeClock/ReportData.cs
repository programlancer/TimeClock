using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Programlancer
{
    public class ReportData
    {
        public User User;
        public DateTime From;
        public DateTime To;
        public DataTable Table;

        public ReportData(User user, DateTime from, DateTime to, DataTable table)
        {
            User = user;
            From = from;
            To = to;
            Table = table;
        }
    }
}
