using LinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class MergeSortForLinkedList
    {
        public void PrintList(SLLNode head)
        {
            while (head != null)
            {
                Console.WriteLine(head.Data);
                head = head.Next;
            }
        }

        public void MergeSort(ref SLLNode head)
        {
            if ((head == null) || (head.Next == null))
            {
                return;
            }

            SLLNode front = null;
            SLLNode back = null;

            FrontBackSplit(head, ref front, ref back);

            MergeSort(ref front);
            MergeSort(ref back);
            head = SortedMerge(front, back);
        }

        #region helper methods

        /// <summary>
        /// Non recursive method for sorted merge. this can alos be acheived using recursive algo
        /// </summary>
        /// <param name="front"></param>
        /// <param name="back"></param>
        /// <returns></returns>
        private SLLNode SortedMerge(SLLNode front, SLLNode back)
        {

            if(front == null)
            {
                return back;
            }
            else if(back == null)
            {
                return front;
            }

            SLLNode newHead = new SLLNode();
            SLLNode cur = newHead;

            while ((front != null) && (back != null))
            {
                if (front.Data <= back.Data)
                {
                    cur.Next = front;
                    front = front.Next;
                }
                else
                {
                    cur.Next = back;
                    back = back.Next;
                }
                cur = cur.Next;
            }

            while(front != null)
            {
                cur.Next = front;
                front = front.Next;
                cur = cur.Next;
            }

            while(back != null)
            {
                cur.Next = back;
                cur = cur.Next;
                back = back.Next;
            }

            return newHead.Next;
        }

        private void FrontBackSplit(SLLNode head, ref SLLNode front, ref SLLNode back)
        {          
            SLLNode slow = head;
            SLLNode fast = head;

            if ((head == null) || (head.Next == null))
            {
                front = head;
                back = null;
                return;
            }
            else
            {
                SLLNode prev = slow;

                while (fast != null && fast.Next != null)
                {
                    prev = slow;
                    slow = slow.Next;
                    fast = fast.Next.Next;
                }

                if(fast == null)
                {
                    back = prev.Next;
                    prev.Next = null;                    
                }
                else
                {
                    back = slow.Next;
                    slow.Next = null;
                }

                front = head;
            }
        }

        #endregion
    }

    public class MergeSortTester
    {
        private SLLNode head = null;

        public void Push(int data)
        {
            if(head == null)
            {
                head = new SLLNode { Data = data };
            }
            else
            {
                SLLNode node = new SLLNode { Data = data };
                head.Next = node;
                head = node;
            }
        }

        public static void Test()
        {
            SLList list = new SLList();
            list.InsertAtBegining(15);
            list.InsertAtBegining(10); 
            list.InsertAtBegining(5); 

            list.InsertAtBegining(20); 
            list.InsertAtBegining(3);
            list.InsertAtBegining(2);

            /* Sort the above created Linked List */
            MergeSortForLinkedList obj = new MergeSortForLinkedList();
            SLLNode head = list.Head;
            obj.MergeSort(ref head);

            obj.PrintList(list.Head);
        }
    }
}
