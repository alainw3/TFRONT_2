using Microsoft.Data.SqlClient;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace TFRONT
{
    public partial class Form1 : Form
    {
        SqlConnection conn;
        SqlDataAdapter dataAdapter;
        SqlDataAdapter dataAdapterTHour;

        private const int cycleFinance = -2;
        private const int cycleAdmin = -2;
        public Form1()
        {
            InitializeComponent();

            String connectionString = "Server=DESKTOP-H8VM3SA;Database=commande;User Id=sa;Password=1T2z565%ç*5çx54;;TrustServerCertificate=true";

            try
            {
                conn = new SqlConnection(connectionString);

                conn.Open();

                // TFRONT
                SqlCommand command = conn.CreateCommand();
                command.CommandText = "select colid , colDat from [winman].[dbo].[TBL_TFRONT]";

                dataAdapter = new SqlDataAdapter(command);

                dataAdapter.Fill(dataSet11.Tables[0]);


                // THOUR
                SqlCommand command1 = conn.CreateCommand();
                command1.CommandText = "select colid, colTitle, colMon, colTue, colWed, colThu, colFri, colSat, colSun  from [winman].[dbo].[TBL_THOUR]";

                dataAdapterTHour = new SqlDataAdapter(command1);

                dataAdapterTHour.Fill(dataSet11, "THOUR");


                // TLEARN
                command.CommandText = "select colid , colDat, colLang from [winman].[dbo].[TBL_TLEARN]";

                dataAdapter = new SqlDataAdapter(command);


                dataAdapter.Fill(dataSet11, "TLEARN");




                // Binding data source
                tFRONTBindingSource.DataSource = dataSet11.Tables[0];
                tFRONTBindingSource.Filter = "colid ='01'";


                tFRONTBindingSource.ResetBindings(false);
                tFRONTBindingSource1.ResetBindings(false);






            }
            catch (SqlException e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlCommand command = conn.CreateCommand();


            command.CommandText = "UPDATE  [winman].[dbo].[TBL_TFRONT]  set coldat = convert(datetime,'"
                                + dateTimePickerCV.Value.ToString() + "',103) where colid ='01'";
            command.ExecuteNonQuery();

            command.CommandText = "UPDATE  [winman].[dbo].[TBL_TFRONT]  set coldat = convert(datetime,'"
                    + dateTimePickerCVLecture.Value.ToString() + "',103) where colid ='04'";
            command.ExecuteNonQuery();


            command.CommandText = "UPDATE  [winman].[dbo].[TBL_TFRONT]  set coldat = convert(datetime,'"
                    + dateTimePickerCVFR.Value.ToString() + "',103) where colid ='05'";
            command.ExecuteNonQuery();

            command.CommandText = "UPDATE  [winman].[dbo].[TBL_TFRONT]  set coldat = convert(datetime,'"
                    + dateTimePickerCVFRLecture.Value.ToString() + "',103) where colid ='06'";
            command.ExecuteNonQuery();


            command.CommandText = "UPDATE  [winman].[dbo].[TBL_TFRONT]  set coldat = convert(datetime,'"
                    + dateTimePickerHK.Value.ToString() + "',103) where colid ='02'";
            command.ExecuteNonQuery();


            command.CommandText = "UPDATE  [winman].[dbo].[TBL_TFRONT]  set coldat = convert(datetime,'"
                    + dateTimePickerSP.Value.ToString() + "',103) where colid ='03'";
            command.ExecuteNonQuery();

            command.CommandText = "UPDATE  [winman].[dbo].[TBL_TFRONT]  set coldat = convert(datetime,'"
                    + dateTimePickerCVEnv.Value.ToString() + "',103) where colid ='07'";
            command.ExecuteNonQuery();

            //TLANG
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(dataAdapter);

            SqlCommand sqlCommand = sqlCommandBuilder.GetUpdateCommand();

            dataAdapter.Update(dataSet11.Tables[2]);

            //THOUR
            sqlCommandBuilder = new SqlCommandBuilder(dataAdapterTHour);

            sqlCommand = sqlCommandBuilder.GetUpdateCommand();

            dataAdapterTHour.Update(dataSet11.Tables[1]);



        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // HackerRank link 
            if (dateTimePickerHK.Value < DateTime.UtcNow.AddDays(-3))
            {
                labelHK.BackColor = Color.Red;
            }

            // CV link  / English
            if (dateTimePickerCV.Value < DateTime.UtcNow.AddDays(-14))
            {
                labelCV.BackColor = Color.Red;
            }
            if (dateTimePickerCVLecture.Value < DateTime.UtcNow.AddDays(-7))
            {
                labelCVLecture.BackColor = Color.Red;
            }
            if (dateTimePickerCVEnv.Value < DateTime.UtcNow.AddDays(-2))
            {
                labelCVEnv.BackColor = Color.Red;
            }


            // CV link  / français
            if (dateTimePickerCVFR.Value < DateTime.UtcNow.AddDays(-14))
            {
                labelCVFRUpdate.BackColor = Color.Red;
            }
            if (dateTimePickerCVFRLecture.Value < DateTime.UtcNow.AddDays(-7))
            {
                labelCVFRLecture.BackColor = Color.Red;
            }

            // Sport link 
            if (dateTimePickerSP.Value < DateTime.UtcNow.AddDays(-3))
            {
                labelSP.BackColor = Color.Red;
            }

            label_Color(dateTimePickerLLM, labelLLM, -3);
            label_Color(dateTimePickerMAT, labelMAT, -2);
            label_Color(dateTimePickerMIT, labelMIT, -3);
            label_Color(dateTimePickerPRO, labelPRO, -3);

            label_Color(dateTimePickerFinance, labelFinance, cycleFinance);
            label_Color(dateTimePickerAdmin, labelAdmin, cycleAdmin);


        }


        private void buttonCV_Click(object sender, EventArgs e)
        {
            var cv = new CV();
            cv.Show();
        }

        private void dateTimePickerLLM_ValueChanged(object sender, EventArgs e)
        {
        }

        private void dateTimePickerLLM_Validated(object sender, EventArgs e)
        {

            commandSQL(dateTimePickerLLM, "08");
            label_Color(dateTimePickerLLM, labelLLM, -3);
        }

        private void dateTimePickerMIT_Validated(object sender, EventArgs e)
        {
            commandSQL(dateTimePickerMIT, "09");
            label_Color(dateTimePickerMIT, labelMIT, -3);
        }

        private void dateTimePickerMAT_Validated(object sender, EventArgs e)
        {
            commandSQL(dateTimePickerMAT, "10");
            label_Color(dateTimePickerMAT, labelMAT, -2);
        }

        private void dateTimePickerPRO_Validated(object sender, EventArgs e)
        {
            commandSQL(dateTimePickerPRO, "11");
            label_Color(dateTimePickerPRO, labelPRO, -3);
        }


        private void commandSQL(DateTimePicker dateTimePicker, string colId)
        {

            SqlCommand command = conn.CreateCommand();

            command.CommandText = "UPDATE  [winman].[dbo].[TBL_TFRONT]  set coldat = convert(datetime,'"
                    + dateTimePicker.Value.ToString() + "',103) where colid ='" + colId + "'";
            command.ExecuteNonQuery();

        }


        private void label_Color(DateTimePicker dateTimePicker, Label label, int day)
        {
            if (dateTimePicker.Value < DateTime.UtcNow.AddDays(day))
            {
                label.BackColor = Color.Red;
            }
            else
            {
                label.BackColor = Color.Transparent;
            }
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
                if (
                    DateTime.ParseExact(e.Value.ToString(), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture) < DateTime.UtcNow.AddDays(-3))
                {
                    e.CellStyle.BackColor = Color.Red;
                }
                else
                {
                    e.CellStyle.BackColor = Color.White;
                }

        }

        private void dateTimePickerFinance_Validated(object sender, EventArgs e)
        {
            commandSQL(dateTimePickerFinance, "12");
            label_Color(dateTimePickerFinance, labelMAT, cycleFinance);
        }

        private void dateTimePickerAdmin_Validated(object sender, EventArgs e)
        {
            commandSQL(dateTimePickerAdmin, "12");
            label_Color(dateTimePickerAdmin, labelMAT, cycleAdmin);
        }
    }

}
