using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoAnalysis.SortAlgoritm
{
    class QuickSort : SortStrategy
    {
        	//------------ QUICK SORT ---------------------
        public override int sort(int[] array, int n)
        {
            return quickSort(array, 0, array.Length - 1, 0);
        }
        public int[] partition(int[] arr, int left, int right, int keycomp)
    	{
	      int i = left, j = right,count=keycomp;
	      int[] dondur=new int[2];
	      int tmp;
	      int pivot = arr[(left + right) / 2];
	      while (i <= j) {
	            while (arr[i] < pivot)
	            {
	                  i++;
	                  count++;
	            }
	            while (arr[j] > pivot)
	            {
	                  j--;
	                  count++;
	            }
	            if (i <= j) {
	                  tmp = arr[i];
	                  arr[i] = arr[j];
	                  arr[j] = tmp;
	                  i++;
	                  j--;
	            }
	      };
	      dondur[0]=i;
	      dondur[1]=count;
	      return dondur;

	}

	 public int quickSort(int [] arr, int left, int right,int kcount) {

	      int[] donen = partition(arr, left, right , kcount);
	      int index=donen[0];
	      int count=donen[1];
	      if (left < index - 1)

	            quickSort(arr, left, index - 1,count);

	      if (index < right)

	            quickSort(arr, index, right,count);
	      return count;

	}
    }
}
