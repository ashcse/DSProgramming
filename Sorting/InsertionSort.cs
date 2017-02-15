using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    /// <summary>
    ///  Insertion sort takes maximum time if element are reverse sorted. It takes minimum time if list is already sorted or almost O(n).
    ///  Its good when list is almost sorted only few items are misplaced.
    /// </summary>
    public class InsertionSort
    {
        public static void Sort(ref int [] array)
        {
            int length = array.Length;
            int i, j;

            for(i = 1; i< length; i++)
            {
                int key = array[i];
                j = i - 1;

                while ((j >= 0) && (key < array[j]))
                {
                    array[j + 1] = array[j];
                    j--;
                }

                array[j + 1] = array[i];
            }
        }

        /// <summary>
        /// Since insertion sort maintains sorted list at begining while processing the elements, new location to insert next element can 
        /// be found using binary search.
        /// </summary>
        /// <param name="array"></param>
        public static void SortWithBinarySearch(ref int [] array)
        {
            int length = array.Length;
            int i, j;

            for (i = 1; i < length; i++)
            {
                int key = array[i];
                j = i - 1;

                int loc = BinarySearch(array, 0, j, key);

                while(j >= loc)
                {
                    array[j + 1] = array[j];
                }

                array[j + 1] = key;

            }
        }

        private static int BinarySearch(int[] array, int low, int high, int item)
        {
            if (low >= high)
            {
                if (item > array[low])
                {
                    return low + 1;
                }
                else
                {
                    return low;
                }
            }

            int mid = (low + high) / 2;

            if(item == array[mid])
            {
                return mid + 1;
            }

            if (item < array[mid])
            {
                return BinarySearch(array, low, mid - 1, item);

            }
            else
            {
                return BinarySearch(array, mid + 1, high, item);
            }
        }
    }
}
