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
    public partial class DialogSkipDays : Form
    {
        private Hourly hourly;

        public DialogSkipDays()
        {
            hourly = new Hourly();  
            InitializeComponent();
        }

        private void buttonSkip_Click(object sender, EventArgs e)
        {
            String nbDays;

            nbDays= comboBoxNbSkipDays.SelectedItem.ToString();

            hourly.skipDays(nbDays);
               
            this.Close();
        }
    }
}
