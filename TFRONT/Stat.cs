using System.Data.Common;

namespace TFRONT
{
    internal class Stat
    {
        private SQL sQL;

        public Stat()
        {
            sQL = new SQL();
        }

        public DataAdapter dataAdapterStat()
        {
            return sQL.GetDataAdapterStat();
        }
    }
}
