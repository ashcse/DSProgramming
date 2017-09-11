using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    ///Application of Merge Sort
    ///1. Merge sort is used to sort linked lists. It takes O(nLogn) time to sort linked list using this technique.
    ///Merge sort is appropriate for linked lists because items are sequentially accessed in merge sort.
    ///Whereas, in other sorts like Quick sort uses index to access element frequently which is not applicable for linked list.
    
    /// <summary>
    /// Merge sort is a divide and conquer algorithm. It divides the array into two halves, calls merge sort
    /// on both parts and merges them.
    /// Recurrence relation:
    /// T(n) = T(n/2) + T(n/2) + n => 2T(n/2) + n
    /// total time for two half items and then merge routine which is will iterate each element once
    /// keep substituting the complexities
    /// T(n/2) = 2^2T(n/2^2) + 2n
    /// .........
    /// T(n/2^k) = 2^k * T(n/2^k) + kn ---Equation 1
    /// here n/2^k = 1 (eventually there will be single element to sort)
    /// hence n = 2^k
    /// hence k = Log2N
    /// replace  Equation 1 
    /// n * Log2N + Log2N
    /// 
    /// whicih gives O(NLog2N) complexity
    /// </summary>
    public class MergeSort
    {
        public static void Sort(ref int[] array, int l, int r)
        {          
            if(l<r)
            {
                int m = (l + r) / 2;

                Sort(ref array, l, m);
                Sort(ref array, m + 1, r);
                Merge(ref array, l, m, r);
            }            
        }

        public static void Merge(ref int [] arr, int l, int m, int r)
        {
            int[] temp = new int[r - l + 1];
            int i = l, j = m+1;
            int k = 0;

            while ((i<= m) && (j<=r))
            {
                if(arr[i] <= arr[j])
                {
                    temp[k++] = arr[i];
                    i++;
                }
                else
                {
                    temp[k++] = arr[j];
                    j++;
                }              
            }

            while(i<=m)
            {
                temp[k++] = arr[i++];
            }

            while(j<=r)
            {
                temp[k++] = arr[j++];
            }
            
            for(i =0; i< temp.Length; i++)
            {
                arr[l++] = temp[i];
            }           
        }        
    }
}
