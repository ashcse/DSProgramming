using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class CountingSort
    {
        public static void Sort(int[] arr, int range)
        {

            int[] output = new int[arr.Length];
            
            int[] temp = new int[range];

            for (int i = 0; i < arr.Length; i++)
            {
                ++temp[arr[i]];
            }

            for (int i = 1; i < temp.Length; i++)
            {
                temp[i] = temp[i - 1] + temp[i];
            }

            //Build the output
            for (int i = 0; i < arr.Length; i++)
            {
                output[temp[arr[i]] - 1] = arr[i];
                temp[arr[i]]--;
            }

            for (int i = 0; i < arr.Length; i++)
                Console.WriteLine(output[i]);
        }

        public static void Test()
        {
            int[] arr = { 1, 4, 1, 2, 7, 5, 2 };
            Sort(arr, 9);
            Console.ReadLine();
        }
    }
}
