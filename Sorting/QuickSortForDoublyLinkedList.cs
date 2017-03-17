using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    /// <summary>
    /// Doubly linked list node
    /// </summary>
    public class DLLNode
    {
        public DLLNode Prev { get; set; }
        public DLLNode Next { get; set; }
        public int Data { get; set; }
    }

    public class DLList
    {
        public DLLNode Head { get; set; }

        public void Push(int data)
        {
            if (Head == null)
            {
                Head = new DLLNode { Data = data };
            }
            else
            {
                DLLNode newNode = new DLLNode { Data = data };
                newNode.Next = Head;
                Head.Prev = newNode;
                Head = newNode;
            }
        }

        public DLLNode GetLastNode()
        {
            DLLNode temp = Head;
            while(temp.Next != null)
            {
                temp = temp.Next;
            }

            return temp;
        }

        public void Display()
        {
            DLLNode temp = Head;
            while(temp != null)
            {
                Console.WriteLine(temp.Data);
                temp = temp.Next;
            }
        }
    }


    public class QuickSortForDoublyLinkedList
    {
        public static void Sort(DLList dllList)
        {
            DLLNode lastNode = dllList.GetLastNode();
            SortUtil(dllList.Head, lastNode);
        }

        public static void SortUtil(DLLNode head, DLLNode last)
        {
            if ((head == null) || (last == null) || (head.Next == last))
                return;

            DLLNode pivotNode = Partition(head, last);
            SortUtil(head, pivotNode.Prev);
            SortUtil(pivotNode.Next, last);
        }

        /// <summary>
        /// This method uses last element as pivot element for partitioning.
        /// </summary>
        /// <param name="head"></param>
        /// <param name="lastNode"></param>
        /// <returns></returns>
        private static DLLNode Partition(DLLNode head, DLLNode lastNode)
        {
            DLLNode current = head;
            DLLNode pivotNode = lastNode;
            DLLNode prev = null;
            int temp;

            while (current != pivotNode)
            {
                if(current.Data< pivotNode.Data)
                {
                    prev = (prev == null) ? head : prev.Next;                   

                    temp = current.Data;
                    current.Data = prev.Data;
                    prev.Data = temp;

                }
                current = current.Next;
            }

            prev = (prev == null) ? head : prev.Next;

            temp = prev.Data;
            prev.Data = pivotNode.Data;
            pivotNode.Data = temp;
            return prev.Next;
        }

        public static void Test()
        {
            DLList list = new DLList();
            list.Push(8);
            list.Push(1);
            list.Push(10);
            list.Push(5);
            list.Push(3);
            list.Push(15);
            Sort(list);
            list.Display();
        }
    }
}
