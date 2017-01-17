using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BST.InsertDelete
{
    /// <summary>
    /// This class represent a node in Binary search tree.
    /// </summary>
    public class Node
    {
        public int Data { get; set; }

        public Node left { get; set; }

        public Node Right { get; set; }

    }

    /// <summary>
    /// Demonstrates binary search tree operations.
    /// </summary>
    public class BST
    {
        public Node  Root { get; set; }

        #region Private Methods

        /// <summary>
        /// Inorder traversal
        /// </summary>
        /// <param name="root"></param>
        private void InorderUtil(Node root)
        {
            if(root!= null)
            {
                InorderUtil(root.left);

                Console.WriteLine(root.Data);

                InorderUtil(root.Right);
            }
        }

        /// <summary>
        /// Utility function which actually inserts node into BST
        /// </summary>
        /// <param name="key"></param>
        /// <param name="root"></param>
        /// <returns></returns>
        private Node InsertUtil(int key, Node root = null)
        {
            if (root == null)
            {
                return new Node { Data = key };
            }

            if (key < root.Data)
            {
                root.left = InsertUtil(key, root.left);
            }
            else
            {
                root.Right = InsertUtil(key, root.Right);
            }

            // There are no duplicate nodes in BST hence dont do anything if there is any node with given key.
            return root;
        }

        /// <summary>
        /// Deletes the node with specified key from BST
        /// </summary>
        /// <param name="root"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        private Node DeleteUtil(Node root, int key)
        {
            if((root == null))
            {
                return null;
            }
            else if(key < root.Data)
            {
                root.left = DeleteUtil(root.left, key);
            }
            else if(key > root.Data)
            {
                root.Right = DeleteUtil(root.Right, key);
            }
            else
            {
                // if key is found then the given node has to be deleted
                if (root.left == null || root.Right == null)
                {
                    // This is the case of no child or only one child
                    Node temp = root.left != null ? root.left : root.Right;
                    root = temp;
                }
                else
                {
                    // This is the case when there are two children of the node
                    // find inorder successor and copy that to the current node and delete inorder successor node.
                    Node minNode = findMin(root.Right);
                    root.Data = minNode.Data;
                    root.Right = DeleteUtil(root.Right, minNode.Data);
                }               
            }

            return root;
        }


        /// <summary>
        /// Finds node with minimun value in BST 
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        private Node findMin(Node root)
        {
            Node temp = root;
            while(temp.left != null)
                temp = temp.left;
            return temp;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Public function for Inorder Traversal.
        /// </summary>
        public void Inorder()
        {
            InorderUtil(Root);
        }


        /// <summary>
        /// Api for inserting a node into BST
        /// </summary>
        /// <param name="key"></param>
        public void Insert(int key)
        {
            Root = InsertUtil(key, Root);
        }

        /// <summary>
        /// This method searches a given key in Binary search tree.
        /// </summary>
        /// <param name="root">root of the BST</param>
        /// <param name="key">key to find</param>
        /// <returns></returns>
        public Node Search(Node root, int key)
        {
            if ((root == null) && (root.Data == key))
            {
                return root;
            }

            if (key < root.Data)
            {
                return Search(root.left, key);
            }
            else
            {
                return Search(root.Right, key);
            }
        }

        /// <summary>
        /// Api to delete a given node from BST.
        /// </summary>
        /// <param name="key"></param>
        public Node Delete(int key)
        {
            return DeleteUtil(Root, key);
        }

        #endregion
    }

    public class BSTTester
    {
        public void Test()
        {
            BST bst = new BST();
            bst.Insert(10);
            bst.Insert(1);
            bst.Insert(3);
            bst.Insert(15);
            bst.Insert(18);
            bst.Insert(0);
            bst.Inorder();
        }
    }
}
