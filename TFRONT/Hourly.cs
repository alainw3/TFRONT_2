using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFRONT
{
    internal class Hourly
    {
        private String? jobID;
        private string? hourID;
        private string? dayID;

        private SQL sQL;

        public Hourly() {
            sQL = new SQL();
        }

        public void setJobID(string jobID)
        { 
            this.jobID = jobID;
        }
        public void setHourID(string hourID) { 
            this.hourID = hourID;

        }
        public void setDayID(string dayID)
        {
            this.dayID = dayID;
        }

        public void updateHourlyJobSearch() { 

            sQL.updateHourly(dayID, "1" , hourID);

        }

        public void updateHourlyNone()
        {

            sQL.updateHourly(dayID, "", hourID);

        }
        public void updateHourlyAdministration()
        {

            sQL.updateHourly(dayID, "2", hourID);

        }
        public void updateHourlyFinance()
        {

            sQL.updateHourly(dayID, "3", hourID);

        }
        public void updateHourlyAutre()
        {

            sQL.updateHourly(dayID, "*", hourID);

        }
        public void updateHourlyLearn()
        {

            sQL.updateHourly(dayID, "4", hourID);

        }
    }

}
