
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
using System.Globalization;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;


namespace TFRONT
{
    public partial class CV : Form
    {
        SqlConnection conn;
        SqlDataAdapter dataAdapter;

        private ReportParameter reportParameterIdJobTitle;

        public CV()
        {
            InitializeComponent();

            String connectionString =Properties.Settings1.Default.msSqlConnString;

            try
            {
                conn = new SqlConnection(connectionString);

                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = "SELECT     a2.colId," +
                    "                             a1.colDatFrom," +
                    "                             a1.colDatTo," +
                    "                             a1.colEmployer," +
                    "                             a2.colDesFr," +
                    "                             a3.colIdTJobtitle" +
                    "     FROM " +
                    "               cv.dbo.TEXPERIENCE a1," +
                    "               cv.dbo.TEXPERDESCRIPTION  a2," +
                    "               cv.dbo.TDESCJOB  a3," +
                    "               cv.dbo.TJOBTITLE  a4" +
                    "     WHERE" +
                    "                a1.colId = a2.colIdTExperience         and" +
                    "                a2.colId  = a3.colIdTExperdescription  and" +
                    "                a4.colId = a3.colIdTJobTitle           ";
                
                dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(dataSet23 ,"TEXPERIENCE");

                command.CommandText = "select colCategory , colLanguage, colYear , colLastUse from [cv].[dbo].[TLANGUAGE]";
                dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(dataSet23, "TLANGUAGE");

                command.CommandText = "SELECT colId   ,colJobTitle           FROM [cv].[dbo].[TJOBTITLE]";
                dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(dataSet23, "TJOBTITLE");




            }
            catch (SqlException e)
            {
                MessageBox.Show(e.ToString());
            }

        }

        public DataSet dataSet()
        {
            return dataSet23;
        }


        private void CV_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.ReportEmbeddedResource = "TFRONT.Report1.rdlc";
            reportViewer1.LocalReport.Refresh();

            reportParameterIdJobTitle = new ReportParameter("IdJobTitle","01");
            reportViewer1.LocalReport.SetParameters(reportParameterIdJobTitle);


            ReportDataSource rdsExperience = new ReportDataSource("Experience", dataSet23.Tables[0]);
            reportViewer1.LocalReport.DataSources.Add(rdsExperience);
           


            ReportDataSource rdsLanguage = new ReportDataSource("Language", dataSet23.Tables[1]);
            reportViewer1.LocalReport.DataSources.Add(rdsLanguage);



            reportViewer1.RefreshReport();
        }


        private void CV_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }

        private void comboBoxTJobTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            reportParameterIdJobTitle = new ReportParameter("IdJobTitle", comboBoxTJobTitle.SelectedValue.ToString());
            reportViewer1.LocalReport.SetParameters(reportParameterIdJobTitle);

            reportViewer1.RefreshReport();
        }
    }
}
