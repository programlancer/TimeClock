namespace Programlancer
{
    partial class FormReportViewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReportViewer));
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.DataTableReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSetReport = new Programlancer.DataSetReport();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.DataTableReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetReport)).BeginInit();
            this.SuspendLayout();
            // 
            // DataTableReportBindingSource
            // 
            this.DataTableReportBindingSource.DataMember = "DataTableReport";
            this.DataTableReportBindingSource.DataSource = this.DataSetReport;
            // 
            // DataSetReport
            // 
            this.DataSetReport.DataSetName = "DataSetReport";
            this.DataSetReport.Locale = new System.Globalization.CultureInfo("he-IL");
            this.DataSetReport.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            resources.ApplyResources(this.reportViewer1, "reportViewer1");
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.DataTableReportBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Programlancer.Report1.rdlc";
            this.reportViewer1.Name = "reportViewer1";
            // 
            // FormReportViewer
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.reportViewer1);
            this.Name = "FormReportViewer";
            this.Load += new System.EventHandler(this.FormReportViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataTableReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetReport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource DataTableReportBindingSource;
        private DataSetReport DataSetReport;

    }
}