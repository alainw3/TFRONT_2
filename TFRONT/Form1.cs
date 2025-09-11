using Microsoft.Data.SqlClient;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace TFRONT
{
    public partial class Form1 : Form
    {
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
        private const int cycleReel = -2;

        private Hourly hourly;
        private Front front;
        private Learn learn;
        private CV cV;

        public Form1()
        {
            InitializeComponent();

            hourly = new Hourly();
            front = new Front();
            learn = new Learn();


            try
            {

                // TFRONT
                dataAdapter = (SqlDataAdapter?)front.dataAdapterFront();
                dataAdapter.Fill(dataSet11.Tables[0]);




                // TLEARN
                dataAdapter = (SqlDataAdapter?)learn.dataAdapterFront();
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
            dataAdapterTHour = (SqlDataAdapter?)hourly.dataAdapterHourly();
            dataAdapterTHour.Fill(dataSet11, "THOUR");

            // 
            updateHourlySum();

        }
        private void updateHourlySum()
        {

            textBoxTotalHour.Text = hourly.getTotalHour();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //THOUR
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(dataAdapterTHour);
            SqlCommand sqlCommand = sqlCommandBuilder.GetUpdateCommand();
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

            label_Color(dateTimePickerReel, labelReel, cycleReel);

        }


        private void buttonCV_Click(object sender, EventArgs e)
        {
            CV cV = Application.OpenForms.OfType<CV>().FirstOrDefault();
            if (cV == null)
            {
                cV = new CV();
            }
            //cV.Dispose();
            cV.Show();

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


        private void commandSQL(DateTimePicker dateTimePicker, string colIdFilter)
        {
            front.updateFront(dateTimePicker.Value.ToString("dd/MM/yyyy HH:mm:ss"), colIdFilter);
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
            label_Color(dateTimePickerCVEnv, labelCVEnv, cycleCVEnv);
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

                hourly.resetHourly();

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
            else if (gridViewCell.Value.ToString() == "5")
            {
                gridViewCell.Style.BackColor = Color.Khaki;
            }
            else if (gridViewCell.Value.ToString() == "6")
            {
                gridViewCell.Style.BackColor = Color.Aquamarine;
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

        private void dateTimePickerReel_Validated(object sender, EventArgs e)
        {
            commandSQL(dateTimePickerReel, tFRONTBindingSourceReel.Filter);
            label_Color(dateTimePickerReel, labelReel, cycleReel);
        }

        private void tabPage2_Enter(object sender, EventArgs e)
        {
            if (cV == null)
            {
                cV = new CV();
            }
            tLANGUAGEBindingSource.DataSource = cV.dataSet();
            //tLANGUAGEBindingSource.ResetBindings(true);
        }

        private void buttonTLanguageSave_Click(object sender, EventArgs e)
        {

        }

        private void leTempsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hourly.updateHourlyLeTemps();
            updateHourly();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 2)
            {
                return; // Ignore clicks on header or invalid cells
            }
            if (MessageBox.Show("Do you want to update the date for " + dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex - 2].Value,
                                               "Question",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question,
                                 MessageBoxDefaultButton.Button2) != DialogResult.Yes)
            {
                return; // User chose not to update
            }



            dataGridView1.BeginEdit(true);

            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value = DateTime.UtcNow.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);


            buttonTLANG.Focus();
            buttonTLANG_Click(sender, e); // Save changes to the database



        }

        private void buttonTLANG_Click(object sender, EventArgs e)
        {
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(dataAdapter);
            SqlCommand sqlCommand = sqlCommandBuilder.GetUpdateCommand();
            dataAdapter.Update(dataSet11.Tables[2]);
        }

        private void bCICToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hourly.updateHourlyBCIC();
            updateHourly();
        }

        private void buttonSkipDays_Click(object sender, EventArgs e)
        {
            DialogSkipDays dialogSkipDays = new DialogSkipDays();

            dialogSkipDays.ShowDialog();


        }
    }
}
