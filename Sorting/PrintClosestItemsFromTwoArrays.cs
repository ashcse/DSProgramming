using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class PrintClosestItemsFromTwoArrays
    {
        public static void PrintClosest(int [] arr1, int[] arr2, int x)
        {
            int m = arr1.Length;
            int n = arr2.Length;


        }


        public static void FindClosestPairInOneArray(int [] arr, int x)
        {
            int l = 0;
            int r = arr.Length - 1;
            int minSum = 1000000;

            while(l < r)
            {
                if( minSum > Math.Abs((arr[l] + arr[r]) -x))
                {
                    minSum = Math.Abs((arr[l] + arr[r])-x);
                }
                
                if((arr[l] + arr[r]) < x)
                {
                    l++;
                }       
                else
                {
                    r++;
                }         
            }

            Console.WriteLine(l + r);
        }
    }
}
