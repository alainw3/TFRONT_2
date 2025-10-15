using System;
using System.Collections.Generic;
using System.Data.Common;
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

        public Hourly()
        {
            sQL = new SQL();
        }


        public DataAdapter dataAdapterHourly()
        {
            return sQL.GetDataAdapterHourly();
        }

        public void setJobID(string jobID)
        {
            this.jobID = jobID;
        }
        public void setHourID(string hourID)
        {
            this.hourID = hourID;

        }
        public void setDayID(string dayID)
        {
            this.dayID = dayID;
        }

        public void updateHourlyJobSearch()
        {

            sQL.updateHourly(dayID, "1", hourID);
        }
        public void updateHourlyLeTemps()
        {
            sQL.updateHourly(dayID, "5", hourID);
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
        public void updateHourlyBCIC()
        {
            sQL.updateHourly(dayID, "6", hourID);
        }

         
        public void updateHourlyMada()
        {
            sQL.updateHourly(dayID, "7", hourID);
        }


        public void resetHourly()
        {
            sQL.resetHourly();
        }
        public string getTotalHour()
        {
            return sQL.getTotalHour();
        }
        public bool  skipDays(string nbDays)
        {
            return sQL.skipDays(nbDays);
        }
    }

}
