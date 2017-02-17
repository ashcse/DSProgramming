
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    /// <summary>
    /// A binary heap is a complete binary tree whos all levels are complete except last one. and last level has most of the nodes at left side.
    /// A binary heap is represented by array and root element of the heap is Array[0] (zero index element).
    /// Array[index/2] returns a parent of array[index], array[index*2] returns left child and array[index*2 +1] returns right child.
    /// 
    /// Since there are no gaps hence it can be stored inside an array. 
    /// </summary>
    public class MinHeap
    {
        private int heap_size = 0;

        private int[] array;

        private int capacity;

        public MinHeap(int capacity)
        {
            heap_size = 0;
            this.capacity = capacity;
            array = new int[capacity];
        }

        public int GetLeftchildIndex(int i) { return 2 * i + 1; }

        public int GetRightchildIndex(int i) { return 2 * i + 2; }

        public int GetParentIndex(int i) { return (i - 1) / 2; }

        private bool HasLeftChild(int i) { return GetLeftchildIndex(i) < heap_size; }

        private bool HasRightChild(int i) { return GetRightchildIndex(i) < heap_size; }

        private bool HasParent(int i) { return GetParentIndex(i) >= 0; }

        private int RightChild(int i) { return array[GetRightchildIndex(i)]; }

        private int LeftChild(int i) { return array[GetLeftchildIndex(i)]; }

        private int Parent(int i) { return array[GetParentIndex(i)]; }

        private void Swap(int indexOne, int indexTwo)
        {
            int temp = array[indexOne];
            array[indexOne] = array[indexTwo];
            array[indexTwo] = temp;
        }

        public int peek()
        {
            if (heap_size == 0) throw new IndexOutOfRangeException(" there are no element");
            return array[0];
        }

        public int ExtractMin()
        {
            if (heap_size < 0)
            {
                throw new IndexOutOfRangeException();
            }

            //If there is only one element
            if (heap_size == 1)
            {
                heap_size = -1;
                return array[0];
            }

            int minElement = array[0];

            array[0] = array[heap_size - 1];
            array[heap_size - 1] = 0;
            heap_size = heap_size - 1;

            MinHeapifyDown(0);

            return minElement;
        }

        public void Insert(int key)
        {
            if (heap_size == capacity)
            {
                return;
            }

            heap_size += 1;

            array[heap_size - 1] = key;

            MinHeapifyUp();
        }

        private void MinHeapifyUp()
        {
            int index = heap_size - 1;
            while ((index != 0) && HasParent(index))
            {
                if (array[index] < array[GetParentIndex(index)])
                {
                    Swap(index, GetParentIndex(index));
                }
                index = GetParentIndex(index);
            }
        }

        private void MinHeapifyDown(int index)
        {           
            int smallerIndexChild = 0;

            while (HasLeftChild(index))
            {
                smallerIndexChild = GetLeftchildIndex(index);

                if (HasRightChild(index) && RightChild(index) < LeftChild(index))
                {

                    smallerIndexChild = GetRightchildIndex(index);
                }

                if (array[index] < array[smallerIndexChild])
                {
                    return;
                }
                else
                {
                    Swap(smallerIndexChild, index);
                }

                index = smallerIndexChild;
            }
        }
    }

    /// <summary>
    /// max heap for implementing heap sort
    /// </summary>
    public class MaxHeap
    {
        private int heap_size = 0;

        private int[] array;

        private int capacity;

        public MaxHeap(int capacity)
        {
            heap_size = 0;
            this.capacity = capacity;
            array = new int[capacity];
        }

        public int GetLeftchildIndex(int i) { return 2 * i + 1; }

        public int GetRightchildIndex(int i) { return 2 * i + 2; }

        public int GetParentIndex(int i) { return (i - 1) / 2; }

        private bool HasLeftChild(int i) { return GetLeftchildIndex(i) < heap_size; }

        private bool HasRightChild(int i) { return GetRightchildIndex(i) < heap_size; }

        private bool HasParent(int i) { return GetParentIndex(i) >= 0; }

        private int RightChild(int i) { return array[GetRightchildIndex(i)]; }

        private int LeftChild(int i) { return array[GetLeftchildIndex(i)]; }

        private int Parent(int i) { return array[GetParentIndex(i)]; }

        private void Swap(int indexOne, int indexTwo)
        {
            int temp = array[indexOne];
            array[indexOne] = array[indexTwo];
            array[indexTwo] = temp;
        }

        public int peek()
        {
            if (heap_size == 0) throw new IndexOutOfRangeException(" there are no element");
            return array[0];
        }

        public int ExtractMax()
        {
            if (heap_size < 0) { throw new IndexOutOfRangeException(); }

            //If there is only one element
            if (heap_size == 1)
            {
                heap_size = -1;
                return array[0];
            }

            int maxElement = array[0];

            array[0] = array[heap_size - 1];
            array[heap_size - 1] = 0;
            heap_size = heap_size - 1;

            MaxHeapifyDown(0);

            return maxElement;
        }

        public void Insert(int key)
        {
            if (heap_size == capacity)
            {
                return;
            }

            heap_size += 1;

            array[heap_size - 1] = key;

            MaxHeapifyUp();
        }

        private void MaxHeapifyUp()
        {
            int index = heap_size - 1;
            while ((index != 0) && HasParent(index))
            {
                if (array[index] > array[GetParentIndex(index)])
                {
                    Swap(index, GetParentIndex(index));
                }
                index = GetParentIndex(index);
            }
        }

        public static void MaxHeapify(ref int[] array, int n, int index)
        {
            int biggerChildIndex = 0;

            while ((2*index +1) < n)
            {
                biggerChildIndex = 2*index + 1;

                int rightIndex = 2 * index + 2;

                if ((rightIndex < n) && (array[rightIndex] > array[2*index +1]))
                {
                    biggerChildIndex = rightIndex;
                }

                if (array[index] > array[biggerChildIndex])
                {
                    return;
                }
                else
                {
                    int temp = array[index];
                    array[index] = array[biggerChildIndex];
                    array[biggerChildIndex] = temp;
                }

                index = biggerChildIndex;
            }

        }

        /// <summary>
        /// Assumption: leftchild(index) and rightChild(index) are already heap subtrees.
        /// If it is not the case then entire array needs to be adjusted to make it heap.
        /// </summary>
        /// <param name="index"></param>
        private void MaxHeapifyDown(int index)
        {
            int biggerChildIndex = 0;

            while (HasLeftChild(index))
            {
                biggerChildIndex = GetLeftchildIndex(index);

                if (HasRightChild(index) && RightChild(index) > LeftChild(index))
                {

                    biggerChildIndex = GetRightchildIndex(index);
                }

                if (array[index] > array[biggerChildIndex])
                {
                    return;
                }
                else
                {
                    Swap(biggerChildIndex, index);
                }

                index = biggerChildIndex;
            }
        }
    }
}
