using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFRONT
{
    internal class Learn
    {
        private SQL sQL;

        public Learn()
        {
            sQL = new SQL();
        }

        public DataAdapter dataAdapterLearn()
        {
            return sQL.GetDataAdapterLearn();
        }
    }
}
