using Heap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    class Program
    {
        static void Main(string[] args)
        {

            /* MinHeap minHeap = new MinHeap(6);
             minHeap.Insert(2);
             minHeap.Insert(4);
             minHeap.Insert(6);
             minHeap.Insert(8);
             minHeap.Insert(10);
             minHeap.Insert(12);

            int min = minHeap.ExtractMin();*/

            int[] array = new int[] { 4, 2, 6, 7, 1, 3 };

            HeapSort.Heapsort(array, array.Length);

            Console.ReadLine();

        }
    }
}
