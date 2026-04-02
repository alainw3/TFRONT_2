using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TFRONT
{
    public partial class Form_Backup : Form
    {
        SqlDataAdapter da;

        public Form_Backup()
        {
            InitializeComponent();
            Backup backup = new Backup();

    
            da = (SqlDataAdapter)backup.dataAdapterBackup();
            da.Fill(dataSet1B, "TBACKUP");

        }

        private void buttonSaveBackUp_Click(object sender, EventArgs e)
        {
            
            if (MessageBox.Show("Are you sure to save the backup?", "Save Backup", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            
            SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(da);

            da.Update(dataSet1B, "TBACKUP");

            MessageBox.Show("Backup saved successfully!", "Save Backup", MessageBoxButtons.OK);

        }
    }
}
