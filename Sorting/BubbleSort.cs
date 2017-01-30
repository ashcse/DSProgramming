using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class BubbleSort
    {
        /// <summary>
        /// This is the raw bubble sort algorithm whch doesnt has any optimization. It can be optimized by breaking from the loop in 
        /// case if there are no swap operation.
        /// This is an in place sorting algorithm. In best case it takes O(n) time; when list is already sorted.
        /// </summary>
        /// <param name="array"></param>
        public static void Sort(ref int[] array)
        {
            bool swap = true;
            for (int i = 0; i < array.Length; i++)
            {
                if(!swap)
                {
                    break;
                }

                swap = false;

                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (array[j] > array[j +1])
                    {
                        int temp = array[j];
                        array[j] = array[j+1];
                        array[j+1] = temp;

                        swap = true;                    
                    }
                }
            }
        }
    }
}
