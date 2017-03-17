using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    /// <summary>
    /// This algorithm works as follows:
    /// 1. Convert each number into number with base n (where n is size of array)
    /// It is definite that after converting a number which is in range within 0 to n^2-1 
    /// first digit (least) will be at first position if D is element of array then (D/1)%n => least significant digit.
    /// perform sorting on this digit
    /// 
    /// 
    /// After first sorting perform second sorting for (D/n)%d of each element henc only two passes are required.
    /// </summary>
    public class SortzeroToN2Minus1Range
    {
        public static void Test()
        {
            int[] arr = { 40, 12, 45, 32, 33, 1, 22 };

            Sort(ref arr);

            arr.ToList().ForEach(i => Console.WriteLine(i));
        }

        public static void Sort(ref int[] arr)
        {
            SortUtil(ref arr, 1);
            SortUtil(ref arr, arr.Length);
        }

        private static void SortUtil(ref int[] arr, int exp)
        {
            int[] temp = new int[arr.Length];
            int n = arr.Length;
            int[] output = new int[arr.Length];

            for(int i =0; i<arr.Length; i++)
            {
                temp[(arr[i]/exp)%n]++;
            }

            for (int i = 1; i < n; i++)
                temp[i] = temp[i] + temp[i - 1];

            for(int i = n-1; i>=0;i--)
            {
                output[temp[((arr[i] / exp) % n)] - 1] = arr[i];
                temp[(arr[i] / exp) % n]--;
            }

            for (int i = 0; i < n; i++)
            {
                arr[i] = output[i];
            }
        }
    }


    public class RadixSort
    {
        public static void countSort(int[] arr, int n, int exp)
        {
            int[] output = new int[n]; // output array
            int i;
            int[] count = new int[10];

            // Store count of occurrences in count[]
            for (i = 0; i < n; i++)
                count[(arr[i] / exp) % 10]++;

            // Change count[i] so that count[i] now contains actual
            //  position of this digit in output[]
            for (i = 1; i < 10; i++)
                count[i] += count[i - 1];

            // Build the output array
            for (i = n - 1; i >= 0; i--)
            {
                output[count[(arr[i] / exp) % 10] - 1] = arr[i];
                count[(arr[i] / exp) % 10]--;
            }

            // Copy the output array to arr[], so that arr[] now
            // contains sorted numbers according to current digit
            for (i = 0; i < n; i++)
                arr[i] = output[i];
        }


        private static int getMax(int [] arr, int n)
        {
            int mx = arr[0];
            for (int i = 1; i < n; i++)
                if (arr[i] > mx)
                    mx = arr[i];
            return mx;
        }

        public static void Sort(ref int[] arr, int n)
        {
            // Find the maximum number to know number of digits
            int m = getMax(arr, n);

            // Do counting sort for every digit. Note that instead
            // of passing digit number, exp is passed. exp is 10^i
            // where i is current digit number
            for (int exp = 1; m / exp > 0; exp *= 10)
                countSort(arr, n, exp);
        }
    }

    public class RadixSortTester
    {
        public static void Test()
        {
            int[] arr = { 170, 45, 75, 90, 802, 24, 2, 66 };
            int n = arr.Length;

            RadixSort.Sort(ref arr, n);
            Console.ReadLine();
        }
    }
}
