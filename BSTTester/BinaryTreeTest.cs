using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DS.BinaryTree.Test
{  
    [TestClass]
    public class BSTTest
    {   
        public BST bst { get; set; }
        
        [TestInitialize]
        public void Initialize()
        {
            bst = new BST();
            bst.Root = new Node { Data = 1 };
            bst.Root.left = new Node { Data = 2 };
            bst.Root.Right = new Node { Data = 3 };

            bst.Root.left.left = new Node { Data = 4 };
            bst.Root.left.Right = new Node { Data = 5 };

            bst.Root.Right.left = new Node { Data = 6 };
            bst.Root.Right.Right = new Node { Data = 7 };

            bst.Root.left.left.left = new Node { Data = 8 };

            /********************************
                            1

                      2             3

                 4        5      6      7

             8

            **********************************/
        }

        [TestMethod]
        public void TestInorderTraversal()
        {
            BST bst = new BST();
            bst.Insert(10);
            bst.Insert(1);
            bst.Insert(3);
            bst.Insert(15);
            bst.Insert(18);
            bst.Insert(0);

            // Tester of inorder traversal
             //BinarySearchTreeTraversal.Inorder();

            // Tester of delete method
            bst.Delete(10);

            // Tester of isBST check
            //Console.WriteLine(bst.IsBST());
            //Tester of kthj smallest element
            //Console.WriteLine(bst.kthSmallestElement(5).Data);

            //

            //bst.Inorder();
        }

        [TestMethod]
        public void TestBinaryTreeMerge()
        {
            BST bst = new BST();
            bst.Insert(10);
            bst.Insert(1);
            bst.Insert(3);
            bst.Insert(15);


            BST bst1 = new BST();
            bst1.Insert(11);
            bst1.Insert(12);
            bst1.Insert(2);
            bst1.Insert(18);
            bst1.Insert(14);

            BST merge = new BST();
            BST result = merge.MergeTreesUsingArray(bst, bst1);

        }
        

        [TestMethod]
        public void TestGetHeight()
        {
            int h = BinaryTreeOperations.GetHeight(bst.Root);
            Assert.AreEqual(4, h);
        }

        [TestMethod]
        public void TestSomething()
        {

            BST bst = new BST();
            bst.Insert(10);
            bst.Insert(1);
            bst.Insert(3);
            bst.Insert(15);
            bst.Insert(18);
            bst.Insert(0);

            // Tester of inorder traversal
            // bst.Inorder();

            // Tester of delete method
            //bst.Delete(10);

            // Tester of isBST check
            //Console.WriteLine(bst.IsBST());
            //Tester of kthj smallest element
            //Console.WriteLine(bst.kthSmallestElement(5).Data);

            // bst.Inorder();


            // BST bst = new BST();
            //int[] array = new int[] { 2, 3, 10, 15, 20, 28 };
            //bst.SortedArrayToBST(array);
            //bst.Preorder();
            //TraversalWithoutRecursion.InorderWithoutRecursion(bst.Root);
            //Console.WriteLine();
            //TraversalWithoutRecursion.PreorderTraversalWithoutRecusion(bst.Root);

            //Console.WriteLine();
            //TraversalWithoutRecursion.PostorderTraversalWithoutRecursion(bst.Root);    
            //TestBSTMerge();           

        }

    }
}

