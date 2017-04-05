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

            //SortInWaveForm.Test();

            Test();
            Console.ReadLine();
        }

        public static void Test()
        {
            int[] ar = new int[] { 2, 4, 6, 8, 3 };
            int n = ar.Length;

            for (int i = 1; i < n; i++)
            {
                int key = ar[i];
                int j = i - 1;
                for (; j >= 0; j--)
                {
                    if (ar[j] >= key)
                    {
                        ar[j + 1] = ar[j];
                    }
                }

                ar[j + 1] = key;

                for (int k = 0; k < n; k++)
                {
                    Console.Write(ar[k] + " ");
                }

                Console.WriteLine();
            }

        }
    }
}
