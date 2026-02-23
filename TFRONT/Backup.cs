using System.Data.Common;

namespace TFRONT
{
    internal class Backup
    {
        private SQL sQL;

        public Backup()
        {
            sQL = new SQL();
        }

        public DataAdapter dataAdapterBackup()
        {
            return sQL.GetDataAdapterBackup();
        }
    }
}
