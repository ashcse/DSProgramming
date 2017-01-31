using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    /// <summary>
    /// Its divide and conquer algorithm. In worst case it give O(n2) complexity and in best case it gives O(nlogn).
    /// Complexity depends on which item is picked as pivot.
    /// </summary>
    public class QuickSortAlgo
    {      

        public static void QuickSort(ref int[] array)
        {
            int length = array.Length;
            QuickSort(ref array, 0, length - 1);          
        }

        public static void QuickSort(ref int[]array, int low, int high)
        {
            if (low >= high) return;
            int pivot = (low + high) / 2;
            int index = Partition(ref array, low, high, array[pivot]);

            QuickSort(ref array, low, index - 1);
            QuickSort(ref array, index, high);
        }

        private static int Partition(ref int[] array, int low, int high, int pivotItem)
        {
            while(low < high)
            {
                while (array[low] < pivotItem)
                    low++;

                while (array[high] > pivotItem)
                    high--;

                if(low< high)
                {
                    int temp = array[low];
                    array[low] = array[high];
                    array[high] = temp;
                }
            }

            return low;
        }
    }
}
