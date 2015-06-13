using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoAnalysis.SortAlgoritm
{
    class Sorted
    {
        private SortStrategy strategy;
        public Sorted(SortStrategy strategy)
        {
            this.strategy = strategy;
        }
        public int sort(int[] array, int n)
        {
            return strategy.sort(array,n);
        }
    }
}
