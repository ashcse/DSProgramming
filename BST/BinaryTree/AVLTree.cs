using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.BinaryTree
{
    /// <summary>
    /// This class represent a single node in AVL tree
    /// </summary>
    class AVLNode
    {
        public int Data { get; set; }
        public AVLNode Left { get; set; }
        public AVLNode Right { get; set; }
        public int Height { get; set; }
    }

    /// <summary>
    /// This class represents AVL tree
    /// It explains concepts related to the AVL tree
    /// AVL tree is height balanced BST, which maintains hight of a BST as LogN.
    /// In order to manage this hight it has contraint that difference between left and right subtree for any node in AVL tree
    /// should not be greater than 1
    /// </summary>
    class AVLTree
    {
        #region Fields

        public AVLNode Root { get; set; }

        #endregion

        #region Private helper mehtods

        /// <summary>
        /// Returns height property of any avl node
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private int GetHeight(AVLNode node)
        {
            return (node == null)?0: node.Height;
        }

        /// <summary>
        /// Returns max item
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private int Max(int a, int b)
        {
            return (a > b) ? a : b;
        }        

        #endregion

        #region public methods

        /// <summary>
        /// Returns balance factor
        /// </summary>       
        /// <returns>balance factor for given node</returns>
        public int GetBalance(AVLNode node)
        {
            if (node == null) return 0;
            return GetHeight( node.Left) - GetHeight(node.Right);
        }
        /// <summary>
        /// this method roates node y towards right 
        /// </summary>
        /// <param name="y">Root node which needs to be rotated right</param>
        /// <returns>new root node after rotation</returns>
        private AVLNode RightRotate(AVLNode y)
        {
            AVLNode x = y.Left;
            AVLNode t2 = x.Right;

            x.Right = y;
            y.Left = t2;

            y.Height = Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;
            x.Height = Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;

            return x;
        }

        /// <summary>
        /// This method rotates node x towards left.
        /// </summary>
        /// <param name="x">root of tree which needs to be roatated left</param>
        /// <returns>new root after rotation</returns>
        private AVLNode LeftRotate(AVLNode x)
        {
            AVLNode y = x.Right;
            AVLNode t2 = y.Left;

            y.Height = Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;
            x.Height = Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;

            return y;
        }

        /// <summary>
        /// Insert utility function which actually performs insert
        /// </summary>
        /// <param name="rootNode"></param>
        /// <returns></returns>
        private AVLNode InsertUtil(AVLNode rootNode, int key)
        {
            if (rootNode == null)
                return new AVLNode { Height = 1, Data = key, Left = null, Right = null };

            if(key< rootNode.Data)
            {
                rootNode.Left = InsertUtil(rootNode.Left, key);
            }
            else if(key> rootNode.Data)
            {
                rootNode.Right = InsertUtil(rootNode.Right, key);
            }
            else
            {
                // No duplicate key are allowed in AVL or BST
                return rootNode;
            }

            rootNode.Height = Max(GetHeight(rootNode.Left), GetHeight(rootNode.Right)) + 1;

            int balance = GetBalance(rootNode);

            // If added node is in right subtree of rootNode's (parent node's) left node 
            // This is clase of LL (hence only one right rotation is required) on left child of current node (which is parent)
            if((balance > 1) && (key< rootNode.Left.Data ))
            {
                rootNode = RightRotate(rootNode);
            }
            if((balance >1 ) && (key> rootNode.Left.Data))
            {
                //This is the case of LR where inserted key is greated then key of left child of current node (which is parent)
                // In this case two rotations are required
                // first rotation helps bigger key node to bring as parent of left child of current node
                rootNode.Left = LeftRotate(rootNode.Left);
                rootNode = RightRotate(rootNode);
            }

            if ((balance < -1) && (key > GetHeight(rootNode.Right)))
            {
                // This is case of 'RR' hence only one left rotate will balance the tree
               rootNode =  LeftRotate(rootNode);
            }

            if((balance <-1 ) && (key<GetHeight(rootNode.Right)))
            {
                // This is case of "RL" where inserted node key is less than right child of parent node (which is current node in  function stack )
                rootNode.Right = RightRotate(rootNode.Right);
                rootNode = LeftRotate(rootNode);
            }
              
            return rootNode;
        }

        /// <summary>
        /// Inserts a new key into this AVL tree
        /// </summary>
        /// <param name="key"></param>
        public void Insert(int key)
        {
            Root = InsertUtil(Root, key);
        }

        /// <summary>
        /// Method to find minimum value node in a tree rooted with passed node
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        private AVLNode findMin(AVLNode root)
        {
            if(root == null)
            {
                return null;
            }

            while(root.Left != null)
            {
                root = root.Left;
            }

            return root;
        }

        private AVLNode DeleteUtil(AVLNode root, int key)
        {
            if (root == null)
                return null;

            if (key < root.Data)
            {
                root.Left = DeleteUtil(root.Left, key);
            }

            else if (key > root.Data)
            {
                root.Right = DeleteUtil(root.Right, key);
            }
            else
            {
                // root is the node which is to be deleted
                // perform standard BST delete operation, followed by AVL balance operation

                if ((root.Left == null) || (root.Right == null))
                {
                    AVLNode temp = (root.Left != null) ? root.Left : root.Right;
                    root = temp;
                }

                if((root.Left != null) && (root.Right != null))
                {
                    // If both nodes are there then copy contents of inorder successor and delete inorder successor node.
                    AVLNode min = findMin(root.Right);
                    root.Data = min.Data;
                    root.Right = DeleteUtil(root.Right, min.Data);
                }
            }

            root.Height = Max(GetHeight(root.Left), GetHeight(root.Right)) + 1;

            int balance = GetBalance(root);


            // at this point deletion is done. root is the parent node whose child is deleted
            // we need to perform balancing from this root upward
            if((balance > 1) && (GetBalance(root.Left) > 0))
            {
                root = RightRotate(root);
            }

            if ((balance > 1) && (GetBalance(root.Left) <= 0))
            {
                root.Left = LeftRotate(root.Left);
                root = RightRotate(root);
            }

            if((balance< -1) && (GetBalance(root.Right)<=0))
            {
                root = LeftRotate(root);
            }
            if((balance < -1) && (GetBalance(root.Right) > 0))
            {
                root.Right = RightRotate(root.Right);
                root = LeftRotate(root);
            }

            return root;
                        
        }

        public void Delete(int key)
        {
            Root = DeleteUtil(Root, key);
        }


        private void PreorderUtil(AVLNode root)
        {
            if (root == null)
                return;

            PreorderUtil(root.Left);
            PreorderUtil(root.Right);
            Console.WriteLine(root.Data);
        }

        public void PreOrder()
        {
            PreorderUtil(Root);
        }

        #endregion 
    }

    public class AVLTreeTester
    {
        public static void Test()
        {

            AVLTree testTree = new AVLTree();

            testTree.Insert(10);
            testTree.Insert(5);
            testTree.Insert(3);
            testTree.Insert(2);

            testTree.PreOrder();
        }
    }
}
