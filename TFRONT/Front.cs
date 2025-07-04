using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace TFRONT
{
    internal class Front
    {
        private SQL sQL;

        public Front() {
            sQL = new SQL();
        }

        public DataAdapter dataAdapterFront() { 
            return sQL.GetDataAdapterFront();
        }

        public void updateFront(string dateValue, string colIdFilter)
        {
          sQL.SqlUpdateTFront(dateValue, colIdFilter);
        }
    }
}
