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

        private String connectionString = Properties.Settings1.Default.msSqlConnString;

        private const string whereClauseDay = " ('*','1','2','3','4','5','6','7','8','9','0','+')  ";

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

            String sql = " SELECT ROUND(SUM(cnt)/2/2,2) FROM" +
                 "   (  SELECT COUNT(*) cnt FROM  [winman].[dbo].[TBL_THOUR]  WHERE colId > 0  and colSun IN " + whereClauseDay +
                 "      UNION ALL " +
                 "      SELECT COUNT(*) cnt FROM  [winman].[dbo].[TBL_THOUR]  WHERE colId > 0  and colSat IN " + whereClauseDay +
                 "      UNION ALL" +
                 "      SELECT COUNT(*) cnt FROM  [winman].[dbo].[TBL_THOUR]  WHERE colId > 0  and colFri IN " + whereClauseDay +
                 "      UNION ALL" +
                 "      SELECT COUNT(*) cnt FROM  [winman].[dbo].[TBL_THOUR]  WHERE colId > 0  and colThu IN " + whereClauseDay +
                 "      UNION ALL" +
                 "      SELECT COUNT(*) cnt FROM  [winman].[dbo].[TBL_THOUR]  WHERE colId > 0  and colWed IN " + whereClauseDay +
                 "      UNION ALL" +
                 "      SELECT COUNT(*) cnt FROM  [winman].[dbo].[TBL_THOUR]  WHERE colId > 0  and colTue IN " + whereClauseDay +
                 "      UNION ALL" +
                 "      SELECT COUNT(*) cnt FROM  [winman].[dbo].[TBL_THOUR]  WHERE colId > 0  and colMon IN " + whereClauseDay +
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
                   " (upper(DATENAME(weekday, GETDATE())) = '" + weekday + "') and " + weekcol + " IN " + whereClauseDay ;

        }

      
        public void updateHourly(string weekcol, string jobId, string hourId)
        {
            string sqlUpdate = " update [winman].[dbo].[TBL_THOUR] set " + weekcol + " = '" + jobId + "' where" +
                                " colTitle = '" + hourId + "'";

            updateSqlCommand(sqlUpdate);

        }

        public bool skipDays(string nbDays)
        {
            string sqlUpdate;

            sqlUpdate = "update[winman].[dbo].[TBL_TFRONT] set colDat = colDat +" + nbDays;
            updateSqlCommand(sqlUpdate);

            sqlUpdate = "update[winman].[dbo].[TBL_TLEARN] set colDat = colDat +" + nbDays;
            updateSqlCommand(sqlUpdate);

            return true;
        }


        public DataAdapter GetDataAdapterFront()
        {
            return getDataAdapter("select colid , colDat, colCycle from [winman].[dbo].[TBL_TFRONT]");
          
        }

        public DataAdapter GetDataAdapterBackup()
        {
            return getDataAdapter("select colid , colDat, colDesc from [winman].[dbo].[TBL_TBACKUP]");

        }

        public DataAdapter GetDataAdapterLearn()
        {
            return getDataAdapter("select colid , colDat, colLang from [winman].[dbo].[TBL_TLEARN] where colArch is null");

        }


        public DataAdapter GetDataAdapterHourly()
        {
            return getDataAdapter("select colid, colTitle, colMon, colTue, colWed, colThu, colFri, colSat, colSun  from [winman].[dbo].[TBL_THOUR] order by colTitle" );

        }

        public DataAdapter GetDataAdapterStat()
        {
            return getDataAdapter("\r\nselect  A1.[colMon]  colCod,\r\n\t\tcase \r\n\t\t\twhen A1.[colMon] = '4' then 'Learn'\r\n\t\t\twhen A1.[colMon] = '7' then 'Mada'\r\n\t\t\twhen A1.[colMon] = '5' then 'Le Temps'\r\n\t\t\twhen A1.[colMon] = '3' then 'Finance'\r\n\t\t\twhen A1.[colMon] = '6' then 'BCIC'\r\n\t\t\twhen A1.[colMon] = '*' then 'Autres'\r\n\t\t\twhen A1.[colMon] = '+' then 'Leadership'\r\n\t\t\twhen A1.[colMon] = '1' then 'Job Search'\r\n\t\t\twhen A1.[colMon] = '2' then 'Administration'\r\n\t\t\twhen A1.[colMon] = '9' then 'Stratégie'\r\n\t\t\telse '???'\r\n\t\tend as 'colDEsc' ,\r\n\t\tcount(*)/4 colTotal  \r\n  from \r\n  (\r\n\t\tSELECT   [colMon]  FROM [winman].[dbo].[TBL_THOUR] where colMon is not null \r\n\tunion all\r\n\t\tSELECT   [colTue]  FROM [winman].[dbo].[TBL_THOUR] where [colTue] is not null \r\n\tunion all\r\n\t\tSELECT   [colWed]  FROM [winman].[dbo].[TBL_THOUR] where [colWed] is not null \r\n\tunion all\r\n\t\tSELECT   [colWed]  FROM [winman].[dbo].[TBL_THOUR] where [colWed] is not null\r\n\tunion all\r\n\t\tSELECT   [colThu]  FROM [winman].[dbo].[TBL_THOUR] where [colThu] is not null\r\n\tunion all\r\n\t\tSELECT   [colFri]  FROM [winman].[dbo].[TBL_THOUR] where [colFri] is not null\r\n\tunion all\r\n\t\tSELECT   [colSat]  FROM [winman].[dbo].[TBL_THOUR] where [colSat] is not null\r\n\tunion all \r\n\t\tSELECT   [colSun]  FROM [winman].[dbo].[TBL_THOUR] where [colSun] is not null\r\n) A1\r\n\r\nwhere  A1.[colMon] !=''\r\ngroup by  A1.[colMon]\r\norder by colTotal desc\r\n");           
        }



        /// <summary>

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
