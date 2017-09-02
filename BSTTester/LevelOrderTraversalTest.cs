using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DS.BinaryTree.Test
{
    [TestClass]
    public class LevelOrderTraversalTest
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
        public void TestSimplelevelOrderTraversalSimpleWithQueue()
        {
            LevelOrderTraversal.LevelOrderTraversalSimpleVersionWithQueue(bst.Root);
        }

        [TestMethod]
        public void TestLevelOrderTraversalSimpleLineByLineWithQueue()
        {
            LevelOrderTraversal.LevelOrderTraversalSimpleLineByLineWithQueue(bst.Root);
        }

        /// <summary>
        /// O(N2)
        /// </summary>
        [TestMethod]
        public void TestLevelOrderTraversalSimpleLineByLineWithRecursion()
        {
            LevelOrderTraversal.LevelOrderTraversalLineByLineWithRecursion(bst.Root);
        }

        //
        [TestMethod]
        public void TestGetMaxWidthWithQueue()
        {
            Console.WriteLine(LevelOrderTraversal.GetMaxWidthWithQueue(bst.Root));
        }


        [TestMethod]
        public void TestPrintLevelWiseNodesUsingQueue()
        {
            // O(n) operation
            LevelOrderTraversal.PrintLevelWiseNodesUsingQueue(bst.Root);
        }

        [TestMethod]
        public void ConnectSameLevelNodesByLevelOrderTraversal()
        {
            LevelOrderTraversal.ConnectSameLevelNodesUsingLevelOrderTraversal(bst.Root);
        }

          
    }
}
