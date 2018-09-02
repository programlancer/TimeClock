using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace Programlancer
{
    public partial class FormReportViewer : Form
    {
        ReportData reportData_;

        public FormReportViewer(ReportData reportData)
        {
            reportData_ = reportData;

            InitializeComponent();

            this.reportViewer1.LocalReport.DataSources.Clear();

            Microsoft.Reporting.WinForms.ReportDataSource rprtDTSource = new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", reportData_.Table);

            this.reportViewer1.LocalReport.DataSources.Add(rprtDTSource);
            this.reportViewer1.RefreshReport();
        }

        private void FormReportViewer_Load(object sender, EventArgs e)
        {
            string user;
            if (reportData_.User == null) user = "כולם";
            else user = reportData_.User.FirstName + " " + reportData_.User.LastName;

            string dates = "תאריך ";
            if (reportData_.From == reportData_.To)
            {
                dates += reportData_.From.ToShortDateString();
            }
            else
            {
                dates += "מ-" + reportData_.From.ToShortDateString() + " עד " + reportData_.To.ToShortDateString();
            }
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("UserFullName", user));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Dates", dates));
            this.reportViewer1.RefreshReport();
        }

    }
}
