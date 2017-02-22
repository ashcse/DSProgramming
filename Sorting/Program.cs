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
            //QuickSortAlgo.QuickSort(ref array);

            //array.ToList().ForEach(s => Console.WriteLine(s));


            //int [] arr = { 12, 11, 13, 5, 6, 7 };

            //ergeSort.Sort(ref arr, 0, arr.Length - 1);
            MergeSortTester.Test();

            Console.ReadLine();


        }
    }
}
