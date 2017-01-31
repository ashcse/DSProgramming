using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class SelectionSort
    {
        /// <summary>
        /// Time complexity O(n2)
        /// Auxiliary space: O(1)
        /// Selection sort never makes more than n swaps hence its good when memory read/write is constly
        /// </summary>
        /// <param name="array"></param>
        public static void Sort(ref int [] array)
        {
            int i = 0, minIndex, length = array.Length;

            for(i = 0; i< length; i++)
            {
                minIndex = i;

                for(int j = i+1; j< length; j++)
                {
                    if(array[j]< array[minIndex])
                    {
                        minIndex = j;
                    }                  
                }

                int temp = array[minIndex];
                array[minIndex] = array[i];
                array[i] = temp;
            }
        }
    }
}
