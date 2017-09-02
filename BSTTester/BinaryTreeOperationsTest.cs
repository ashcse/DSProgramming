using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DS.BinaryTree.Test
{
    [TestClass]
    public class BinaryTreeOperationsTest
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

            //bst.Root.Right.left = new Node { Data = 6 };
            //bst.Root.Right.Right = new Node { Data = 7 };

            //bst.Root.left.left.left = new Node { Data = 8 };

            /********************************
                            1

                      2             3

                 4        5      6      7

             8

            **********************************/
        }

        [TestMethod]
        public void TestMirror()
        {
            BinaryTreeOperations.Mirror(bst.Root);
        }

        [TestMethod]
        public void TestDiameterN2()
        {
            int d = BinaryTreeOperations.Diameter(bst.Root);

            Assert.AreEqual(d, 6);
        }

        [TestMethod]
        public void TestIsSumTree()
        {
            Assert.AreEqual(false, BinaryTreeOperations.IsSumTree(bst.Root));

            bst = new BST();
            bst.Root = new Node { Data = 26 };
            bst.Root.left = new Node { Data = 10 };
            bst.Root.Right = new Node { Data = 3 };

            bst.Root.left.left = new Node { Data = 4 };
            bst.Root.left.Right = new Node { Data = 6 };

            bst.Root.Right.Right = new Node { Data = 3 };

            Assert.AreEqual(true, BinaryTreeOperations.IsSumTree(bst.Root));
        }
    }
}
