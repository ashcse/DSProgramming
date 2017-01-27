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

        /// <summary>
        /// Without any auxiliary space. This linked list first inserts new nodes alternatively in original list and after
        /// setting random pointers it restores original lists and cloned ist.
        /// </summary>
        /// <returns>cloned list</returns>
        public SLLNode ClonewithRandomPointer()
        {
            // algo: create copy of the list nodes and insert copy of the node after each node 

            SLLNode current = Head;
            SLLNode clonedList = new SLLNode();

            if (current == null)
                return null;

            clonedList = new SLLNode { Data = current.Data };
            SLLNode temp = current.Next;
            current.Next = clonedList;
            clonedList.Next = temp;

            current = current.Next.Next;

            while(current != null)
            {
                SLLNode newNode = new SLLNode { Data = current.Data };
                temp = current.Next;
                current.Next = newNode;
                newNode.Next = temp;
                current = current.Next.Next;
            }

            // Now iterate once to set random pointers 
            current = Head;

            while(current!=null)
            {
                current.Next.Random = current.Random.Next;
                current = current.Next.Next;   
            }

            current = Head;
            SLLNode cloneCurrent = current.Next;
            
            while((current != null) && (cloneCurrent.Next != null))
            {
                current.Next = current.Next.Next;
                cloneCurrent.Next = cloneCurrent.Next.Next;
                current = current.Next;
                cloneCurrent = cloneCurrent.Next;
            }
            cloneCurrent.Next = null;
            current.Next = null;            

            return clonedList;
        }


        public void DeleteAlternetNodes()
        {
            SLLNode current = Head;

            while(current != null && current.Next != null)
            {
                current.Next = current.Next.Next;
                current = current.Next;
            }
        }


        public SLLNode Intersect(SLLNode head1, SLLNode head2)
        {
            if ((head1 == null) || (head2 == null))
                return null;
            if(head1.Data < head2.Data)
                return Intersect(head1.Next, head2);

            if (head1.Data > head2.Data)
                return Intersect(head1, head2.Next);

            SLLNode newNode = new SLLNode { Data = head1.Data };
            newNode.Next = Intersect(head1.Next, head2.Next);

            return newNode;
        }

        /// <summary>
        /// This method needs to be fixed. reference swapping is not working after first swap.
        /// </summary>
       /* public void PairwiseSwap()
        {
            SLLNode current = Head;

            SLLNode prev = Head;
            SLLNode newHead = null;
            while((current != null) && (current.Next != null))
            {               
                SLLNode temp = current.Next;
                if(newHead == null)
                {
                    newHead = temp;
                }
                prev = temp;
                current.Next = temp.Next;
                temp.Next = current;

                
               current =          
            }

           Head = newHead;
        }*/

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

        public SLLNode Random { get; set; }

        #endregion
    }
}
