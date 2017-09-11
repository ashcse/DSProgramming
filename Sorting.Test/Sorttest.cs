using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Sorting.Test
{
    [TestClass]
    public class Sorttest
    {

        private void PrintArray (int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i]  + " " );
            }
        }

        [TestMethod]
        public void SortingTestBubble()
        {
            int[] arr = new int[] { 5, 4, 2, 3, 1 };
            BubbleSort.Sort(ref arr);

            PrintArray(arr);

        }

        [TestMethod]
        public void SortingTestInsertion()
        {
            int[] arr = new int[] { 5, 4, 3, 2, 1 };
            InsertionSort.Sort(ref arr);
            PrintArray(arr);
        }

        [TestMethod]
        public void SortingTestSelection()
        {
            int[] arr = new int[] { 3, 2, 4, 5, 1 };
            SelectionSort.Sort(ref arr);

            PrintArray(arr);
        }

        [TestMethod]
        public void SortingTestQuickSort()
        {
            // int[] arr = { 10, 80, 30, 90, 40, 50, 70 };
            //int[] arr = { 5, 3, 2, 6, 9 };// 2, 3, 1, 9, 7 };
            int[] arr = { 5, 4,3,2,1 };// 2, 3, 1, 9, 7 };
            QuickSortAlgo.QuickSort(ref arr);

            arr.ToList().ForEach(i => Console.Write(i + " "));
        }

        [TestMethod]
        public void SortingTestQuickSortLastElementAsPivot()
        {
            int[] arr = { 5, 4, 3, 2, 1 };// 2, 3, 1, 9, 7 };
            QuickSortWithLastElementAsPivot.Sort(ref arr);
            arr.ToList().ForEach(i => Console.Write(i + " "));
        }
    }
}

