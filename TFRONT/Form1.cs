using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace TFRONT
{
    public partial class Form1 : Form
    {
        SqlDataAdapter dataAdapterTLearn;
        SqlDataAdapter dataAdapterTFront;
        SqlDataAdapter dataAdapterTHour;
        SqlDataAdapter dataAdapterTBackup;
        SqlDataAdapter dataAdapterTSTat;


        private const int cycleBonneManiere = -2;
        private const int cycleLeaderShip = -2;
        private const int cycleArazakar = -7;
        private const int cycleCVEnv = -2;
        private const int cycleCentura = -3;

        private const int cycleSP = -3;

        private const int cycleAI = -3;

        private const int cycleFinance = -2;
        private const int cycleAdmin = -2;
        private const int cycleWebSite = -7;

        private const int cycleMada = -5;
        private const int cycleMiremont = -3;

        private const int cycleJR = -5;
        private const int cycleCertificate = -14;
        private const int cycleReel = -2;

        private const int cycleVL = -7;
        private const int cycleJD = -7;
        private const int cyclePapers = -7;

        private Hourly hourly;
        private Front front;
        private Learn learn;
        private Backup backup;
        private Stat stat;


        private static readonly Color[] colorHour = { Color.Yellow, Color.Red, Color.Green, Color.Fuchsia, Color.Khaki, Color.Aquamarine, Color.LightGreen, Color.Plum, Color.Blue };
        private static readonly string[] cellTips = { "JobSearch", "Administration", "Finance", "Learn", "Le Temps", "BCIC", "Mada", "Certificate", "Strategie" };

        public Form1()
        {
            InitializeComponent();

            hourly = new Hourly();
            front = new Front();
            learn = new Learn();
            backup = new Backup();
            stat = new Stat();


            try
            {

                // TFRONT
                dataAdapterTFront = (SqlDataAdapter?)front.dataAdapterFront();
                dataAdapterTFront.Fill(dataSet11, "TFRONT");


                // TLEARN
                dataAdapterTLearn = (SqlDataAdapter?)learn.dataAdapterLearn();
                dataAdapterTLearn.Fill(dataSet11, "TLEARN");

                //Backup
                dataAdapterTBackup = (SqlDataAdapter?)backup.dataAdapterBackup();
                dataAdapterTBackup.Fill(dataSet11, "TBACKUP");


                // TSTAT
                dataAdapterTSTat = (SqlDataAdapter?)stat.dataAdapterStat();
                dataAdapterTSTat.Fill(dataSet11, "TSTAT");


                // Binding data source & refresh
                tFRONTBindingLeadership.DataSource = dataSet11.Tables[0];
                tFRONTBindingLeadership.Filter = "colid ='01'";


                tFRONTBindingLeadership.ResetBindings(false);
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

            dataSet11.Tables[4].Clear();
            dataAdapterTSTat = (SqlDataAdapter?)stat.dataAdapterStat();
            dataAdapterTSTat.Fill(dataSet11, "TSTAT");
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
            label_Color(dateTimePickerLeadership, labelLeaderShip, cycleLeaderShip);
            label_Color(dateTimePickerCentura, labelCentura, cycleCentura);



            // CV link  / français
            label_Color(dateTimePickerBonneManiere, labelBonneManiere, cycleBonneManiere);
            label_Color(dateTimePickerArazakar, labelArazakar, cycleArazakar);

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
            label_Color(dateTimePickerPapers, labelPapers, cyclePapers);

            label_Color(dateTimePickerMada, labelMada, cycleMada);
            label_Color(dateTimePickerMiremont, labelMiremont, cycleMiremont);

            label_Color(dateTimePickerJR, labelJR, cycleJR);
            label_Color(dateTimePickerCertificate, labelCertificate, cycleCertificate);

            label_Color(dateTimePickerReel, labelReel, cycleReel);

            label_Color(dateTimePickerVilla, labelVL, cycleVL);
            label_Color(dateTimePickerJardin, labelJD, cycleJD);

            label_Color(dateTimePickerWebSite, labelWebSite, cycleWebSite);


        }


        private void buttonCV_Click(object sender, EventArgs e)
        {

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

        private void dateTimePickerPapers_Validated(object sender, EventArgs e)
        {
            commandSQL(dateTimePickerPapers, tFRONTBindingPapers.Filter);
            label_Color(dateTimePickerPapers, labelPapers, cycleWebSite);
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
            commandSQL(dateTimePickerLeadership, tFRONTBindingLeadership.Filter);
            label_Color(dateTimePickerLeadership, labelLeaderShip, cycleBonneManiere);
        }

        private void dateTimePickerCVLecture_Validated(object sender, EventArgs e)
        {
            commandSQL(dateTimePickerCentura, tFRONTBindingCentura.Filter);
            label_Color(dateTimePickerCentura, labelCentura, cycleArazakar);
        }

        private void dateTimePickerBonneManiere_Validated(object sender, EventArgs e)
        {
            commandSQL(dateTimePickerBonneManiere, tFRONTBindingSourceBonneManiere.Filter);
            label_Color(dateTimePickerBonneManiere, labelBonneManiere, cycleArazakar);
        }

        private void dateTimePickerArazakar_Validated(object sender, EventArgs e)
        {
            commandSQL(dateTimePickerArazakar, tFRONTBindingArazakar.Filter);
            label_Color(dateTimePickerArazakar, labelArazakar, cycleArazakar);
        }

        private void dateTimePickerCVEnv_Validated(object sender, EventArgs e)
        {
            commandSQL(dateTimePickerCVEnv, tFRONTBindingCVEnv.Filter);
            label_Color(dateTimePickerCVEnv, labelCVEnv, cycleCVEnv);
        }

        private void dateTimePickerSP_Validated(object sender, EventArgs e)
        {
            commandSQL(dateTimePickerSP, tFRONTBindingSourceSP.Filter);
            label_Color(dateTimePickerSP, labelSP, cycleArazakar);
        }

        private void dateTimePickerHK_Validated(object sender, EventArgs e)
        {
            commandSQL(dateTimePickerHK, tFRONTBindingSourceHK.Filter);
            label_Color(dateTimePickerHK, labelHK, cycleArazakar);
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

        private void dateTimePickerCertificate_Validated(object sender, EventArgs e)
        {
            commandSQL(dateTimePickerCertificate, tFRONTBindingSourceCertficate.Filter);
            label_Color(dateTimePickerCertificate, labelCertificate, cycleCertificate);
        }

        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex > 0)
            {
                DataGridViewCell gridViewCell = dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex];

                if (gridViewCell.Value.ToString() != "")
                {
                    if (gridViewCell.Value.ToString() == "*")
                    {
                        gridViewCell.Style.BackColor = Color.Gray;
                        gridViewCell.ToolTipText = "Other activity";
                    }
                    else if (gridViewCell.Value.ToString() == "0")
                    {
                        gridViewCell.Style.BackColor = Color.Orange;
                        gridViewCell.ToolTipText = "Arazakar";
                    }
                    else if (gridViewCell.Value.ToString() == "+")
                    {
                        gridViewCell.Style.BackColor = Color.Tomato;
                        gridViewCell.ToolTipText = "Leadership activity";
                    }
                    else
                    {
                        gridViewCell.Style.BackColor = colorHour[Int32.Parse(gridViewCell.Value.ToString()) - 1];
                        gridViewCell.ToolTipText = cellTips[Int32.Parse(gridViewCell.Value.ToString()) - 1];
                    }
                }
                else
                {
                    gridViewCell.Style.BackColor = Color.White;
                }
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
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(dataAdapterTLearn);
            SqlCommand sqlCommand = sqlCommandBuilder.GetUpdateCommand();
            dataAdapterTLearn.Update(dataSet11.Tables[2]);
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

            // TFRONT
            dataAdapterTFront = (SqlDataAdapter)front.dataAdapterFront();
            dataAdapterTFront.Fill(dataSet11, "TFRONT");

            // TLEARN
            dataAdapterTLearn = (SqlDataAdapter?)learn.dataAdapterLearn();
            dataAdapterTLearn.Fill(dataSet11, "TLEARN");

            tFRONTBindingLLM.ResetBindings(false);


        }

        private void madaStripMenuItem_Click(object sender, EventArgs e)
        {
            hourly.updateHourlyMada();
            updateHourly();
        }


        private void dateTimePickerVilla_Validated(object sender, EventArgs e)
        {
            commandSQL(dateTimePickerVilla, tFRONTBindingVilla.Filter);
            label_Color(dateTimePickerVilla, labelVL, cycleVL);
        }

        private void dateTimePickerJardin_Validated(object sender, EventArgs e)
        {
            commandSQL(dateTimePickerJardin, tFRONTBindingJardin.Filter);
            label_Color(dateTimePickerJardin, labelJD, cycleJD);
        }

        private void certificateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hourly.updateHourlyCertificate();
            updateHourly();
        }

        private void StategieMenuItem_Click(object sender, EventArgs e)
        {
            hourly.updateHourlyStrategie();
            updateHourly();
        }

        private void dateTimePickerWebSite_Validated(object sender, EventArgs e)
        {
            commandSQL(dateTimePickerWebSite, tFRONTbindingSourceWebsite.Filter);
            label_Color(dateTimePickerWebSite, labelWebSite, cycleWebSite);
        }

        private void arazakarMenuItem_Click(object sender, EventArgs e)
        {
            hourly.updateHourlyArazakar();
            updateHourly();
        }

        private void leadershipStripMenu_Click(object sender, EventArgs e)
        {
            hourly.updateHourlyLeadership();
            updateHourly();
        }

        private void dataGridViewBackup_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
                if (DateTime.ParseExact(e.Value.ToString(), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture) < DateTime.UtcNow.AddDays(-7))
                {
                    e.CellStyle.BackColor = Color.Red;
                }
                else
                {
                    e.CellStyle.BackColor = Color.White;
                }
        }

        private void dataGridViewBackup_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex != 2)
            {
                return; // Ignore clicks on header or invalid cells
            }
            if (MessageBox.Show("Do you want to update the date for " + dataGridViewBackup.Rows[e.RowIndex].Cells[e.ColumnIndex - 2].Value,
                                                              "Question",
                                                                                              MessageBoxButtons.YesNo,
                                                                                                                              MessageBoxIcon.Question,
                                                                                                                                                              MessageBoxDefaultButton.Button2) != DialogResult.Yes)
            {
                return; // User chose not to update
            }
            else
            {
                dataGridViewBackup.BeginEdit(true);

                dataGridViewBackup.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value = DateTime.UtcNow.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);

                buttonTBackup.Focus();
                buttonTBackup_Click(sender, e); // Save changes to the database




            }
        }

        private void buttonTBackup_Click(object sender, EventArgs e)
        {
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(dataAdapterTBackup);
            SqlCommand sqlCommand = sqlCommandBuilder.GetUpdateCommand();
            dataAdapterTBackup.Update(dataSet11.Tables[3]);
        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Backup form_Backup = new Form_Backup();
            form_Backup.ShowDialog();

            // TBACKUP
            //dataAdapterTBackup = (SqlDataAdapter)backup.dataAdapterBackup();
            //dataAdapterTBackup.Fill(dataSet11, "TBACKUP");

            //tBACKUPBindingSource.ResetBindings(false);

        }
    }
}
