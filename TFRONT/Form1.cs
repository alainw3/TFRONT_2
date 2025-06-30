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

        private const int cycleCV = -14;
        private const int cycleCVLecture = -7;
        private const int cycleCVEnv = -2;

        private const int cycleSP = -3;

        private const int cycleAI = -3;

        private const int cycleFinance = -2;
        private const int cycleAdmin = -2;
        private const int cycleWebSite = -3;

        private const int cycleMada = -5;
        private const int cycleMiremont = -3;

        private const int cycleJR = -5;
        private const int cycleCVNew = -3;

        private Hourly hourly;
        private Front front;


        public Form1()
        {
            InitializeComponent();
            hourly = new Hourly();
            front = new Front();

            String connectionString = "Server=DESKTOP-H8VM3SA;Database=commande;User Id=sa;Password=1T2z565%ç*5çx54;;TrustServerCertificate=true";

            try
            {
                conn = new SqlConnection(connectionString);

                conn.Open();

                // TFRONT
                //SqlCommand command = conn.CreateCommand();
                //command.CommandText = "select colid , colDat, colCycle from [winman].[dbo].[TBL_TFRONT]";
                //dataAdapter = new SqlDataAdapter(command);
                dataAdapter = (SqlDataAdapter?)front.dataAdapterFront();
                dataAdapter.Fill(dataSet11.Tables[0]);




                // TLEARN
                SqlCommand command = conn.CreateCommand();
                command.CommandText = "select colid , colDat, colLang from [winman].[dbo].[TBL_TLEARN]";
                dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(dataSet11, "TLEARN");



                // Binding data source & refresh
                tFRONTBindingSourceCV.DataSource = dataSet11.Tables[0];
                tFRONTBindingSourceCV.Filter = "colid ='01'";


                tFRONTBindingSourceCV.ResetBindings(false);
                tFRONTBindingSourceHK.ResetBindings(false);

                updateHourly();




            }
            catch (SqlException e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void updateHourly()
        {

            // THOUR
            SqlCommand command1 = conn.CreateCommand();
            command1.CommandText = "select colid, colTitle, colMon, colTue, colWed, colThu, colFri, colSat, colSun  from [winman].[dbo].[TBL_THOUR]";
            dataAdapterTHour = new SqlDataAdapter(command1);
            dataAdapterTHour.Fill(dataSet11, "THOUR");


            // 
            updateHourlySum();

        }
        private void updateHourlySum()
        {

            // 
            SqlCommand commandWeeklHour = conn.CreateCommand();
            commandWeeklHour.CommandText = new SQL().getSqlWeeklyHour();
            SqlDataReader rd = commandWeeklHour.ExecuteReader();
            if (rd != null)
            {
                if (rd.Read())
                {
                    textBoxTotalHour.Text = rd[0].ToString();
                }
            }
            rd.Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {



            //TLANG
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(dataAdapter);
            SqlCommand sqlCommand = sqlCommandBuilder.GetUpdateCommand();
            dataAdapter.Update(dataSet11.Tables[2]);

            //THOUR
            sqlCommandBuilder = new SqlCommandBuilder(dataAdapterTHour);
            sqlCommand = sqlCommandBuilder.GetUpdateCommand();
            dataAdapterTHour.Update(dataSet11.Tables[1]);

            updateHourlySum();


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label_Color(dateTimePickerHK, labelHK, -3);


            // CV link  / English
            label_Color(dateTimePickerCV, labelCV, cycleCV);
            label_Color(dateTimePickerCVLecture, labelCVLecture, cycleCVLecture);



            // CV link  / français
            label_Color(dateTimePickerCVFR, labelCVFR, cycleCV);
            label_Color(dateTimePickerCVFRLecture, labelCVFRLecture, cycleCVLecture);

            // Envoi candidature
            label_Color(dateTimePickerCVEnv, labelCVEnv, cycleCVEnv);


            // Sport link 
            label_Color(dateTimePickerSP, labelSP, cycleSP);


            //
            label_Color(dateTimePickerLLM, labelLLM, cycleAI);
            label_Color(dateTimePickerMAT, labelMAT, cycleAI);
            label_Color(dateTimePickerMIT, labelMIT, cycleAI);
            label_Color(dateTimePickerPRO, labelPRO, cycleAI);


            label_Color(dateTimePickerFinance, labelFinance, cycleFinance);
            label_Color(dateTimePickerAdmin, labelAdmin, cycleAdmin);
            label_Color(dateTimePickerWebSite, labelWebSite, cycleWebSite);

            label_Color(dateTimePickerMada, labelMada, cycleMada);
            label_Color(dateTimePickerMiremont, labelMiremont, cycleMiremont);

            label_Color(dateTimePickerJR, labelJR, cycleJR);
            label_Color(dateTimePickerCVNew, labelCVNew, cycleCVNew);

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

            commandSQL(dateTimePickerLLM, tFRONTBindingLLM.Filter);
            label_Color(dateTimePickerLLM, labelLLM, -3);
        }

        private void dateTimePickerMIT_Validated(object sender, EventArgs e)
        {
            commandSQL(dateTimePickerMIT, tFRINTbindingSourceMIT.Filter);
            label_Color(dateTimePickerMIT, labelMIT, -3);
        }

        private void dateTimePickerMAT_Validated(object sender, EventArgs e)
        {
            commandSQL(dateTimePickerMAT, tFRONTbindingSourceMAT.Filter);
            label_Color(dateTimePickerMAT, labelMAT, -2);
        }

        private void dateTimePickerPRO_Validated(object sender, EventArgs e)
        {
            commandSQL(dateTimePickerPRO, tFRONTbindingSourcePRO.Filter);
            label_Color(dateTimePickerPRO, labelPRO, -3);
        }


        private void commandSQL(DateTimePicker dateTimePicker, string colIdFiilder)
        {

            SqlCommand command = conn.CreateCommand();

            command.CommandText = "UPDATE  [winman].[dbo].[TBL_TFRONT]  set coldat = convert(datetime,'"
                    + dateTimePicker.Value.ToString() + "',103) where " + colIdFiilder;
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
            commandSQL(dateTimePickerFinance, tFRONTBindingFinance.Filter);
            label_Color(dateTimePickerFinance, labelFinance, cycleFinance);
        }

        private void dateTimePickerAdmin_Validated(object sender, EventArgs e)
        {
            commandSQL(dateTimePickerAdmin, tFRONTBindingAdministration.Filter);
            label_Color(dateTimePickerAdmin, labelAdmin, cycleAdmin);
        }

        private void dateTimePickerWebSite_Validated(object sender, EventArgs e)
        {
            commandSQL(dateTimePickerWebSite, tFRONTBindingWebSite.Filter);
            label_Color(dateTimePickerWebSite, labelWebSite, cycleWebSite);
        }

        private void dateTimePickerMada_Validated(object sender, EventArgs e)
        {
            commandSQL(dateTimePickerMada, tFRONTBindingMada.Filter);
            label_Color(dateTimePickerMada, labelMada, cycleMada);
        }

        private void dateTimePickerMiremont_Validated(object sender, EventArgs e)
        {
            commandSQL(dateTimePickerMiremont, tFRONTBindingMiremont.Filter);
            label_Color(dateTimePickerMiremont, labelMiremont, cycleMiremont);
        }

        private void dateTimePickerCV_Validated(object sender, EventArgs e)
        {
            commandSQL(dateTimePickerCV, tFRONTBindingSourceCV.Filter);
            label_Color(dateTimePickerCV, labelCV, cycleCV);
        }

        private void dateTimePickerCVLecture_Validated(object sender, EventArgs e)
        {
            commandSQL(dateTimePickerCVLecture, tFRONTBindingCVLecture.Filter);
            label_Color(dateTimePickerCVLecture, labelCVLecture, cycleCVLecture);
        }

        private void dateTimePickerCVFR_Validated(object sender, EventArgs e)
        {
            commandSQL(dateTimePickerCVFR, tFRONTBindingSourceCVFR.Filter);
            label_Color(dateTimePickerCVFR, labelCVFR, cycleCVLecture);
        }

        private void dateTimePickerCVFRLecture_Validated(object sender, EventArgs e)
        {
            commandSQL(dateTimePickerCVFRLecture, tFRONTBindingCVFRLecture.Filter);
            label_Color(dateTimePickerCVFRLecture, labelCVFRLecture, cycleCVLecture);
        }

        private void dateTimePickerCVEnv_Validated(object sender, EventArgs e)
        {
            commandSQL(dateTimePickerCVEnv, tFRONTBindingCVEnv.Filter);
            label_Color(dateTimePickerCVEnv, labelCVEnv, cycleCVLecture);
        }

        private void dateTimePickerSP_Validated(object sender, EventArgs e)
        {
            commandSQL(dateTimePickerSP, tFRONTBindingSourceSP.Filter);
            label_Color(dateTimePickerSP, labelSP, cycleCVLecture);
        }

        private void dateTimePickerHK_Validated(object sender, EventArgs e)
        {
            commandSQL(dateTimePickerHK, tFRONTBindingSourceHK.Filter);
            label_Color(dateTimePickerHK, labelHK, cycleCVLecture);
        }

        private void buttonResetDay_Click(object sender, EventArgs e)
        {
            if (
                MessageBox.Show("Are you sure",
                                "Question",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question,
                                 MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {

                SQL sQL = new SQL();
                SqlCommand command = conn.CreateCommand();

                command.CommandText = sQL.getSqlResetDay("FRIDAY", "colFri");
                command.ExecuteNonQuery();

                command.CommandText = sQL.getSqlResetDay("MONDAY", "colMon");
                command.ExecuteNonQuery();

                command.CommandText = sQL.getSqlResetDay("THURSDAY", "colThu");
                command.ExecuteNonQuery();

                command.CommandText = sQL.getSqlResetDay("WEDNESDAY", "colWed");
                command.ExecuteNonQuery();

                command.CommandText = sQL.getSqlResetDay("TUESDAY", "colTue");
                command.ExecuteNonQuery();

                command.CommandText = sQL.getSqlResetDay("SUNDAY", "colSun");
                command.ExecuteNonQuery();

                command.CommandText = sQL.getSqlResetDay("SATURDAY", "colSat");
                command.ExecuteNonQuery();


                updateHourly();
            }

        }

        private void jobSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hourly.updateHourlyJobSearch();
            updateHourly();


        }

        private void dataGridView2_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            //MessageBox.Show(dataGridView2.Columns[e.ColumnIndex].HeaderText);
            //MessageBox.Show(dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString());

            hourly.setDayID(dataGridView2.Columns[e.ColumnIndex].HeaderText);

            hourly.setHourID(dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString());
        }

        private void dateTimePickerJR_Validated(object sender, EventArgs e)
        {
            commandSQL(dateTimePickerJR, tFRONTBindingSourceJR.Filter);
            label_Color(dateTimePickerJR, labelJR, cycleJR);
        }

        private void dateTimePickerCVNew_Validated(object sender, EventArgs e)
        {
            commandSQL(dateTimePickerCVNew, tFRONTBindingSourceCVNew.Filter);
            label_Color(dateTimePickerCVNew, labelCVNew, cycleCVNew);
        }

        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewCell gridViewCell = dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (gridViewCell.Value.ToString() == "1")
            {
                gridViewCell.Style.BackColor = Color.Yellow;
            }
            else if (gridViewCell.Value.ToString() == "*")
            {
                gridViewCell.Style.BackColor = Color.Blue;
            }
            else if (gridViewCell.Value.ToString() == "2")
            {
                gridViewCell.Style.BackColor = Color.Red;
            }
            else if (gridViewCell.Value.ToString() == "3")
            {
                gridViewCell.Style.BackColor = Color.Green;
            }
            else if (gridViewCell.Value.ToString() == "4")
            {
                gridViewCell.Style.BackColor = Color.Fuchsia;
            }
            else
            {
                gridViewCell.Style.BackColor = Color.White;
            }
        }

        private void noneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hourly.updateHourlyNone();
            updateHourly();

        }

        private void administrationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            hourly.updateHourlyAdministration();
            updateHourly();
        }

        private void financeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hourly.updateHourlyFinance();
            updateHourly();
        }

        private void autreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hourly.updateHourlyAutre();
            updateHourly();
        }

        private void learnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hourly.updateHourlyLearn();
            updateHourly();
        }
    }
}
