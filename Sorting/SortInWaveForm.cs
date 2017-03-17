using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class SortInWaveForm
    {
        public static void Sort(ref int [] arr)
        {
            for (int i = 0; i < arr.Length; i += 2)
            {
                if (i > 0 && arr[i - 1] > arr[i])
                {
                    int temp = arr[i];
                    arr[i] = arr[i - 1];
                    arr[i - 1] = temp;
                }

                if ((i < arr.Length - 1) && (arr[i]< arr[i+1]))
                {
                    int temp = arr[i];
                    arr[i] = arr[i + 1];
                    arr[i + 1] = temp;
                }
            }
        }

        public static void Test()
        {
            int[] arr = { 10, 90, 49, 2, 1, 5, 23 };

            Sort(ref arr);

            arr.ToList().ForEach(i => Console.WriteLine(i));
        }
    }
}
