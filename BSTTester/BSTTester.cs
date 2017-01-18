using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using BSTree = BST.InsertDelete.BST;

namespace BSTTester
{
    [TestClass]
    public class BSTTester
    {
        [TestMethod]
        public void TestMethod1()
        {


            BST.Program.Main();
           
            Assert.IsNotNull(1);

            // Tester of delete method
            //bst.Delete(10);

            // Tester of isBST check
            //Console.WriteLine(bst.IsBST());
            //Tester of kthj smallest element
            //Console.WriteLine(bst.kthSmallestElement(5).Data);

            //bst.Inorder();


        }
    }
}
