using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    /// <summary>
    /// There are multiple ways to achieve this. 
    /// 1. First sort the array and retrieve k-1th element from the array => time complexity O(nLogn)
    /// 2. Do bubble sort k times => time complexity O(n*k)
    /// 3. Use max heap:
    /// Create a max heap of first k elements and then iterate k to n-1 elements. When any item x is less then root of the
    /// heap then replace it and heapify to make if heap.
    /// At the end retrieve root of the heap. This will be the Kth smallest element.
    /// 
    /// 4. If K smallest elements are required then min heap can be created from first K elements and then any element smaller then heap root 
    /// if found in k to n-1 elements then it is replaced with min heap root. At the end K elements in the heap are K smallest
    /// elements.
    /// 
    /// 5. There is another way to use Quick sort to find the result.
    /// </summary>
    public class KthLargestSmalestElement
    {
        public static void FindKthSmallestElement(ref int[] arr)
        {

        }

        public static int QuickSelect(ref int[] arr, int l, int r, int k)
        {
            while((k>0) && (k <= r-l +1 ))
            {
                int pos = Partition(ref arr, l, r); 

                if(pos-l == k-1)
                {
                    return arr[pos];
                }
                if(pos -l > k-1)
                {

                }
            }
        }

        /// <summary>
        /// Partition algorithm when always last element is chosen.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        private static int Partition(ref int[] arr, int l, int r)
        {
            int pivot = arr[r];
            int i = l - 1;
            int j;
            int temp;

            for(j = l; j<r; j++)
            {
                if(arr[j]< pivot)
                {
                    i++;

                    temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

            i++;
            temp = arr[j];
            arr[j] = arr[i];
            arr[i] = temp;
            return i;            
        }
    }
}
