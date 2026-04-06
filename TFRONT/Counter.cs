using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFRONT
{
    internal class Counter
    {
        private int countRed;
        private int countAll;

        public Counter()
        {
            countRed = 0;
            countAll = 0;
        }

        public void IncrementAll()
        {
            countAll++;
        }
        public void IncrementRed()
        {
            countRed++;
        }

        public int GetCountPercent()
        {
            if (countAll == 0)
                return 0;
            return (int)(100-((double)countRed / countAll * 100));
        }

    }
}
