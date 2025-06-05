
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TFRONT
{
    public partial class CV : Form
    {
        private DataSet1 dataSet;
        public CV(DataSet1 _dataSet11)
        {
            InitializeComponent();

            dataSet = _dataSet11;
        }

        private void CV_Load(object sender, EventArgs e)
        {
            ReportDataSource rds = new ReportDataSource("DataSet1", dataSet.Tables[0]);

            reportViewer1.LocalReport.ReportEmbeddedResource = "TFRONT.Report1.rdlc";
            reportViewer1.LocalReport.Refresh();
            reportViewer1.LocalReport.DataSources.Add(rds);
            
            reportViewer1.RefreshReport();
        }
    }
}
