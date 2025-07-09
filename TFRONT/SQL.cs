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

        public void  SqlUpdateTFront(string dateValue, string colIdfilter) {
            string sqlUpdate = "UPDATE [winman].[dbo].[TBL_TFRONT]  set coldat = convert(datetime, '"
                    + dateValue + "',103) where " + colIdfilter + "";

            updateSqlCommand(sqlUpdate);
        }

        public string getTotalHour()
        {
            connect();
            String totalHour ;

            SqlCommand commandWeeklHour = conn.CreateCommand();

            String sql = " SELECT ROUND(SUM(cnt)/2,2) FROM" +
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

            commandWeeklHour.CommandText = sql;
            SqlDataReader rd = commandWeeklHour.ExecuteReader();
            //if (rd != null)
            //{
            //    if (rd.Read())
            //    {
            //        totalHour= rd[0].ToString();
            //    }
            //}
            rd.Read();
            totalHour = rd[0].ToString();

            rd.Close();

            return totalHour;
        }

        public void resetHourly()
        {
            resetDay("FRIDAY", "colFri");
           

            resetDay("MONDAY", "colMon");
           

            resetDay("THURSDAY", "colThu");
            

            resetDay("WEDNESDAY", "colWed");
            

            resetDay("TUESDAY", "colTue");
            

            resetDay("SUNDAY", "colSun");
            

            resetDay("SATURDAY", "colSat");
    

        }

        


        private void resetDay(string weekday, string weekcol)
        {
            string sqlReset = getSqlResetDay(weekday, weekcol);

            updateSqlCommand(sqlReset);
        }



        public string getSqlResetDay(string weekday, string weekcol) {
            return " update[winman].[dbo].[TBL_THOUR] set " + weekcol + " = NULL where" +
                   " (upper(DATENAME(weekday, GETDATE())) = '" + weekday + "') and " + weekcol + " IN ('*','1','2','3','4')  ";

        }

      
        public void updateHourly(string weekcol, string jobId, string hourId)
        {
            string sqlUpdate = " update [winman].[dbo].[TBL_THOUR] set " + weekcol + " = '" + jobId + "' where" +
                                " colTitle = '" + hourId + "'";

            updateSqlCommand(sqlUpdate);

        }

        public DataAdapter GetDataAdapterFront()
        {
            return getDataAdapter("select colid , colDat, colCycle from [winman].[dbo].[TBL_TFRONT]");
          
        }

        public DataAdapter GetDataAdapterLearn()
        {
            return getDataAdapter("select colid , colDat, colLang from [winman].[dbo].[TBL_TLEARN]");

        }


        public DataAdapter GetDataAdapterHourly()
        {
            return getDataAdapter("select colid, colTitle, colMon, colTue, colWed, colThu, colFri, colSat, colSun  from [winman].[dbo].[TBL_THOUR]");

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
