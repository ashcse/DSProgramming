using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    /// <summary>
    /// Binary heap is a complete binary tree. There are no gaps among the elements. All levels are full excpet possibly last one and 
    /// last level has elements as left as possible. This property makes it possible to store heap elements in array.
    /// heaps are used to sort an array. It is in place sorting algorithm with time complexity nlogn.
    /// </summary>
    public class HeapSort
    {
        public static void Heapsort(int[] array, int n)
        {
            for(int i = n/2 -1; i>=0; i--)
            {
                MaxHeap.MaxHeapify(ref array, n, i);
            }

            for( int i = n-1; i>=0; i--)
            {
                int temp = array[i];
                array[i] = array[0];
                array[0] = temp;

                MaxHeap.MaxHeapify(ref array, i, 0);
            }
        }
       
    }

    public class KLargestElements
    {
        // Write a program to find k largest elements in an array
        // ex: 1, 23, 12, 9, 2, 50  here when K = 3 then largest three elements: 50, 30, 23
        // Simple solution is to apply bubble sort for K times  and print
        // Time coplexity = O(k*n

        // Use max heap to find it
        // First make a heap by firt making array max heap O(n) time (heapify from n/2-1 to 0)
        // Now call extractMax K times : O(k*logn)
        // Total complexity = O(n + kLogn)


    }
}
