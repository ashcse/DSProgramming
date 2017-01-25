using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            TestSLL();
            Console.ReadLine();
        }

        public static void TestSLL()
        {
            SLList list = new SLList();
            list.InsertAtBegining(10);
            list.InsertAtBegining(20);
            list.InsertAtBegining(30);
            list.InsertAtBegining(20);
            list.InsertAtBegining(10);
          

            list.Display();

            ////Console.WriteLine(list.GetNthNode(5));

            //Console.WriteLine(" Middle element" + list.GetMiddle().Data);

            //Console.WriteLine("5th from end " + list.GetNthNodeFromEndUsingTwoPointer(1).Data);

            //list.ReverseList();
            //Console.WriteLine("Reversed list");
            //list.Display();


            Console.WriteLine(" is Palindrom" + list.IsPalindrom());
        }

        public static void TestSortedMerge()
        {
            SLLNode root = new SLLNode { Data = 10 };
            root.Next = new SLLNode { Data = 15 };
            root.Next.Next = new SLLNode { Data = 20 };
            root.Next.Next.Next = new SLLNode { Data = 25 };
            root.Next.Next.Next.Next = new SLLNode { Data = 30 };


            SLLNode second = new SLLNode { Data = 5 };
            second.Next = new SLLNode { Data = 12 };
            second.Next.Next = new SLLNode { Data = 21 };
            second.Next.Next.Next = new SLLNode { Data = 24 };
            second.Next.Next.Next.Next = new SLLNode { Data = 32 };

            SLLNode resultList = SortedMerge.DoSortedMerge(root, second);

            while (resultList != null)
            {
                Console.WriteLine(resultList.Data);
                resultList = resultList.Next;
            }
        }
    }
}
