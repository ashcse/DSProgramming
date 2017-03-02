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
            while(temp != null)
            {
                temp = temp.Next;
            }
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

            if ((dllList.Head == null ) || (lastNode.Next == null) 
                || (dllList.Head.Next == lastNode))
                return;


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
