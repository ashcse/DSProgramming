using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] array = new int[] { 1, 2, 5, 3, 4 };// 3, 2, 4, 1, 7, 6 };

            //BubbleSort.Sort( ref array);

            //SelectionSort.Sort(ref array);
            //InsertionSort.Sort(ref array);
            //QuickSortAlgo.Test();
            //QuickSortWithLastElementAsPivot.Test();

            //array.ToList().ForEach(s => Console.WriteLine(s));

            //QuickSortForDoublyLinkedList.Test();

            //int [] arr = { 12, 11, 13, 5, 6, 7 };

            //ergeSort.Sort(ref arr, 0, arr.Length - 1);
            //MergeSortTester.Test();

            //CountingSort.Test();
            //RadixSortTester.Test();


            //int result = TailRecursion.FactorialUsingTailRecursive(5);


            //SortzeroToN2Minus1Range.Test();

            SortInWaveForm.Test();
            Console.ReadLine();
        }
    }
}
