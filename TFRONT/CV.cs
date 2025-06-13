
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
using Microsoft.Data.SqlClient;
using System.Data;
using System.Globalization;
using System.Windows.Forms;


namespace TFRONT
{
    public partial class CV : Form
    {
        SqlConnection conn;
        SqlDataAdapter dataAdapter;
 

        public CV()
        {
            InitializeComponent();
            
            String connectionString = "Server=DESKTOP-H8VM3SA;Database=commande;User Id=sa;Password=1T2z565%ç*5çx54;;TrustServerCertificate=true";

            try
            {
                conn = new SqlConnection(connectionString);

                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = "select colId , colDatFrom, colDatTo, colEmployer from [winman].[dbo].[TEXPERIENCE]";
                dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(dataSet21.Tables[0]);

                command.CommandText = "select colCategory , colLanguage, colYear , colLastUse from [cv].[dbo].[TLANGUAGE]";
                dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(dataSet21.Tables[1]);






            }
            catch (SqlException e)
            {
                MessageBox.Show(e.ToString());
            }

        }

        private void CV_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.ReportEmbeddedResource = "TFRONT.Report1.rdlc";
            reportViewer1.LocalReport.Refresh();

            ReportDataSource rdsExperience = new ReportDataSource("Experience", dataSet21.Tables[0]);
            reportViewer1.LocalReport.DataSources.Add(rdsExperience);


            ReportDataSource rdsLanguage = new ReportDataSource("Language", dataSet21.Tables[1]);
            reportViewer1.LocalReport.DataSources.Add(rdsLanguage);

            reportViewer1.RefreshReport();
        }
    }
}
