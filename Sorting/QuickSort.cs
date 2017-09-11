using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    /// <summary> 
    /// Its divide and conquer algorithm. 
    /// In worst case it give O(n2) complexity and in best case it gives O(nlogn).
    /// Complexity depends on which item is picked as pivot.
    /// -- If pivot is picked as last element
    /// -- If pivot is picked as first element 
    /// -- if pivot is picked random element
    /// -- If pivot is picked as medion of first, middle and last element.
    /// -- Worst cases occure when pivot is alwasy largest or smallest element of the array in that case comparision 
    ///needs to traverse entire array for each iteration
    /// </summary>
    public class QuickSortAlgo
    {
        /// <summary>
        /// Quick sort algorithm which uses middle element as pivot. This will give worst case complexity if
        /// middle element always is greater or smallest element. because it will make new lists as one less then 
        /// original ist hence n2 complexity. If middle element divides list into two parts then it will 
        /// give log2n complexity.
        /// </summary>
        /// <param name="array"></param>
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
            QuickSort(ref array, index + 1, high);
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

    public class QuickSortWithLastElementAsPivot
    {
        public static void Sort(ref int[] arr)
        {
            int length = arr.Length;
            Sort(ref arr, 0, length-1);
        }

        /// <summary>
        /// This method remains same for all variations of the quick sort.
        /// We need to partition the array and then apply same sorting algorithm
        /// on both the parts of array.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        public static void Sort(ref int[] arr, int low, int high)
        {
            if(low >=high)
            {
                return;
            }

            int pivot = arr[high];

            int index = Partition(ref arr, low, high);

            Sort(ref arr, low, index - 1);
            Sort(ref arr, index + 1, high);
        }

        /// <summary>
        /// This method varies based on the pivot selected
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <returns></returns>
        public static int Partition(ref int[] arr, int low, int high)
        {
            int pivot = arr[high];    // pivot
            int i = (low - 1);  // Index of smaller element
            int temp;

            for (int j = low; j <= high - 1; j++)
            {
                // If current element is smaller than or
                // equal to pivot
                if (arr[j] <= pivot)
                {
                    i++;    // increment index of smaller element
                    temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }
            
            //swap pivot with 
            temp = arr[i+1];
            arr[i+1] = arr[high];
            arr[high] = temp;
            return (i + 1);
        }

        public static void Test()
        {
            // int[] arr = { 10, 80, 30, 90, 40, 50, 70 };
            int[] arr = { 2, 3, 1, 9, 7 };
            Sort(ref arr);

            arr.ToList().ForEach(i => Console.WriteLine(i));

            Console.ReadLine();

        }
    }
}
