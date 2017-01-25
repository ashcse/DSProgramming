using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{

    public class SLList
    {

        #region Fields

        public SLLNode Head { get; set; }

        #endregion

        public void InsertAtBegining(int data)
        {
            if(Head == null)
            {
                Head = new SLLNode { Data = data };
            }
            else
            {
                SLLNode temp = new SLLNode { Data = data };
                temp.Next = Head;
                Head = temp;
            }
        }

        public SLLNode Delete(int key)
        {
            if(Head == null)
                return null;

            SLLNode temp = null;

            if (Head.Data == key)
            {
                temp = Head;   
                Head = Head.Next;
            }
            else
            {
                SLLNode current = Head.Next;
                SLLNode prev = Head;

                while(current != null)
                {
                    if(current.Data == key)
                    {
                        temp = current;
                        prev.Next = current.Next;
                    }

                    prev = current;
                    current = current.Next;
                }
            }

            return temp;
        }

        public int GetSize()
        {
            SLLNode current = Head;
            int count = 0;

            while(current!= null)
            {
                current = current.Next;
                count++;
            }

            return count;
        }

        public SLLNode GetNthFromEnd(int n)
        {
            int size = GetSize();

            int l = size - n + 1;

            SLLNode current = Head;

            while((current != null) && (--l > 0)) 
            {
                current = current.Next;
            }

            return current;
        }

        public SLLNode GetNthNodeFromEndUsingTwoPointer(int n)
        {
            SLLNode refencePointer = Head;
            SLLNode current = Head;

            while((refencePointer != null) && (n-- > 0))
            {
                refencePointer = refencePointer.Next;
            }

            while(refencePointer != null)
            {
                current = current.Next;
                refencePointer = refencePointer.Next;
            }

            return current;
        }

        public SLLNode GetMiddle()
        {
            SLLNode fast = Head;
            SLLNode slow = Head;

            while((fast != null) && (fast.Next != null))
            {
                fast = fast.Next.Next;
                slow = slow.Next;
            }

            return slow;
        }

        public int GetNthNode(int n)
        {
            SLLNode current = Head;
           
            while(current != null && --n > 0)
            {
                current = current.Next;
            }

            if (current != null)
                return current.Data;
            return 0;
        }

        public void ReverseList()
        {
            SLLNode current = Head;
            SLLNode prev = null;
            SLLNode next = current;
            
            while(current != null)
            {
                next = current.Next;

                current.Next = prev;
                prev = current;
                current = next;
            }

            Head = prev;
        }

        public void RecursiveReverse(SLLNode head)
        {
            if (head == null)
                return;

            SLLNode first = head;
            SLLNode rest = first.Next;

            RecursiveReverse(rest);

            if (rest != null)
            {
                first.Next.Next = first;

                first.Next = null;
                head = rest;
            }
        }


        public bool IsPalindrom(ref SLLNode left, SLLNode right)
        {
            if (right == null)
                return true;
            bool isp = IsPalindrom(ref left, right.Next);
            if (isp == false)
                return false;

            isp = (left.Data == right.Data) ? true : false;

            left = left.Next;
            return isp;
        }

        public bool IsPalindrom()
        {
            SLLNode headref = Head;
            SLLNode headref1 = Head;
            return IsPalindrom(ref headref, headref1);
        }


        public SLLNode FindIntersectionPoint(SLLNode firstlist, SLLNode secondList)
        {
            return null;
        }

        public void Display()
        {
            SLLNode current = Head;
            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }

        }
    }

    public class SLLNode
    {
        #region  Fields

        public int Data { get; set; }

        public SLLNode Next { get; set; }

        #endregion
    }
}
