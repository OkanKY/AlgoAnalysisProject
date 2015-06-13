using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoAnalysis.SortAlgoritm
{
    class BubbleSort : SortStrategy
    {
        	//------------- BUBBLE SORT ------------------
	public override int sort( int [] array, int n )
	{
		int i, j,t=0;
		int keycompcount=0;
		for(i = 0; i < n; i++){
			for(j = 1; j < (n-i); j++){
                if (array[j - 1] > array[j])
                {
					keycompcount++;// key comparision
                    t = array[j - 1];
                    array[j - 1] = array[j];
                    array[j] = t;
				}
			}
		}
		return keycompcount;
	}
    }
}
