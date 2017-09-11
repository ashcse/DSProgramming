using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinkedList;

namespace LinkedListTest
{
    [TestClass]
    public class SLLTest
    {
         [TestMethod]
        public void TestReverse()
        {
            SLLNode first = new SLLNode { Data = 1 };
            first.Next = new SLLNode { Data = 2 };
           first.Next.Next = new SLLNode { Data = 3 };
            SLList.Print(first);

           
            //list.ReverseList();
            Console.WriteLine();
            //SLList.Print(list.Head);

            SLList.RecursiveReverse(ref first);
            
            SLList.Print(first);
                

        }
    }
}
