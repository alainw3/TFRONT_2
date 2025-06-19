using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFRONT
{
    internal class SQL
    {
        public SQL() { }
        public SQL(string sql) { }
        public string getSqlUpdateTFront(string dateValue,string colIdValue) {
            return "UPDATE[winman].[dbo].[TBL_TFRONT]  set coldat = convert(datetime, '"
                    + dateValue + "',103) where colid ='" + colIdValue+"'";
                    }
        public string getSqlWeeklyHour()
        {

            return " SELECT ROUND(SUM(cnt)/2,2) FROM" +
                 "   (  SELECT COUNT(*) cnt FROM  [winman].[dbo].[TBL_THOUR]  WHERE colId > 6  and colSun ='*' " +
                 "      UNION ALL " +
                 "      SELECT COUNT(*) cnt FROM  [winman].[dbo].[TBL_THOUR]  WHERE colId > 6  and colSat='*' " +
                 "      UNION ALL" +
                 "      SELECT COUNT(*) cnt FROM  [winman].[dbo].[TBL_THOUR]  WHERE colId > 6  and colFri='*' " +
                 "      UNION ALL" +
                 "      SELECT COUNT(*) cnt FROM  [winman].[dbo].[TBL_THOUR]  WHERE colId > 6  and colThu='*' " +
                 "      UNION ALL" +
                 "      SELECT COUNT(*) cnt FROM  [winman].[dbo].[TBL_THOUR]  WHERE colId > 6  and colWed='*'  " +
                 "      UNION ALL" +
                 "      SELECT COUNT(*) cnt FROM  [winman].[dbo].[TBL_THOUR]  WHERE colId > 6  and colTue='*'  " +
                 "      UNION ALL" +
                 "      SELECT COUNT(*) cnt FROM  [winman].[dbo].[TBL_THOUR]  WHERE colId > 6  and colMon='*'  " +
                 "     ) A";

            //and(upper(DATENAME(weekday, GETDATE())) != 'FRIDAY')
        }

        public string getSqlResetDay(string weekday, string weekcol) {
            return " update[winman].[dbo].[TBL_THOUR] set " + weekcol +" = NULL where" +
                   " (upper(DATENAME(weekday, GETDATE())) = '" + weekday +"') and " + weekcol + " = '*' ";

        }
    }
}
