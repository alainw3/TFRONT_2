using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Data.SqlClient;

namespace TFRONT
{
    internal class SQL
    {
        SqlConnection conn;
        //SqlDataAdapter dataAdapter;

        private String connectionString = "Server=DESKTOP-H8VM3SA;Database=commande;User Id=sa;Password=1T2z565%ç*5çx54;;TrustServerCertificate=true";

        public SQL() { }

        public string getSqlUpdateTFront(string dateValue, string colIdValue) {
            return "UPDATE[winman].[dbo].[TBL_TFRONT]  set coldat = convert(datetime, '"
                    + dateValue + "',103) where colid ='" + colIdValue + "'";
        }

        public string getSqlWeeklyHour()
        {

            return " SELECT ROUND(SUM(cnt)/2,2) FROM" +
                 "   (  SELECT COUNT(*) cnt FROM  [winman].[dbo].[TBL_THOUR]  WHERE colId > 6  and colSun IN ('*','1','2','3','4') " +
                 "      UNION ALL " +
                 "      SELECT COUNT(*) cnt FROM  [winman].[dbo].[TBL_THOUR]  WHERE colId > 6  and colSat IN ('*','1','2','3','4')  " +
                 "      UNION ALL" +
                 "      SELECT COUNT(*) cnt FROM  [winman].[dbo].[TBL_THOUR]  WHERE colId > 6  and colFri IN ('*','1','2','3','4')  " +
                 "      UNION ALL" +
                 "      SELECT COUNT(*) cnt FROM  [winman].[dbo].[TBL_THOUR]  WHERE colId > 6  and colThu IN ('*','1','2','3','4')  " +
                 "      UNION ALL" +
                 "      SELECT COUNT(*) cnt FROM  [winman].[dbo].[TBL_THOUR]  WHERE colId > 6  and colWed IN ('*','1','2','3','4')   " +
                 "      UNION ALL" +
                 "      SELECT COUNT(*) cnt FROM  [winman].[dbo].[TBL_THOUR]  WHERE colId > 6  and colTue IN ('*','1','2','3','4')   " +
                 "      UNION ALL" +
                 "      SELECT COUNT(*) cnt FROM  [winman].[dbo].[TBL_THOUR]  WHERE colId > 6  and colMon IN ('*','1','2','3','4')   " +
                 "     ) A";

            //and(upper(DATENAME(weekday, GETDATE())) != 'FRIDAY')
        }

        public string getSqlResetDay(string weekday, string weekcol) {
            return " update[winman].[dbo].[TBL_THOUR] set " + weekcol + " = NULL where" +
                   " (upper(DATENAME(weekday, GETDATE())) = '" + weekday + "') and " + weekcol + " = '*' ";

        }

        public void updateHourly(string weekcol, string jobId, string hourId)
        {
            string sqlUpdate = " update[winman].[dbo].[TBL_THOUR] set " + weekcol + " = '" + jobId + "' where" +
                                " colTitle = '" + hourId + "'";

            updateSqlCommand(sqlUpdate);

        }

        public DataAdapter GetDataAdapterFront()
        {
            return getDataAdapter("select colid , colDat, colCycle from [winman].[dbo].[TBL_TFRONT]");
          
        }

        private DataAdapter getDataAdapter(string selectCommand) {

            connect();

            SqlCommand command = conn.CreateCommand();
            command.CommandText = selectCommand;
            return new SqlDataAdapter(command);
    
        }


        private void updateSqlCommand (string sqlCommand) {

            connect();

            SqlCommand command = conn.CreateCommand();

            command.CommandText = sqlCommand;

            command.ExecuteNonQuery();
        }


        private void connect()
        {
            if (conn == null)
            {
                try
                {
                    conn = new SqlConnection(connectionString);

                    conn.Open();

                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.ToString());
                }
            }
        }
    }

}
