using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BST.BinaryTree
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
        #region fields

        /// <summary>
        /// Root of this BST
        /// </summary>
        Node  Root { get; set; }

        #endregion 

        #region Private helper Methods

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

        /// <summary>
        /// This method finds inorder successor of the given node.
        /// Algo: if node has right subtree than minimum value node in right subtree will be inorder successor.
        ///       if node doesn't have right subtree than from root entire tree needs to be checked.
        /// </summary>
        /// <param name="node"></param>
        /// <returns>inorder successor node if it exists</returns>
        private Node InorderSucc(Node node)
        {
            if (node.Right != null)
            {
                return findMin(node.Right);
            }
            else
            {
                Node succ = null;

                Node rootNode = Root;

                // If there is no right child then need to start from root
                while (rootNode != null && rootNode.Data != node.Data)
                {
                    if (node.Data < rootNode.Data)
                    {
                        succ = rootNode;
                        rootNode = rootNode.left;
                    }
                    else
                    {
                        rootNode = rootNode.Right;
                    }
                }

                return succ;
            }
        }

        private static Node prev = null;

        /// <summary>
        /// This method uses inorder traversal to check if this tree is BST or not. Inorder traversal always produces sorted result.
        /// This method makes use of a static member which keeps track of last visited node in inorder traversal
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        private bool IsBSTUtil(Node root)
        {
            if (root == null)
            {
                return true;
            }

            if (!IsBSTUtil(root.left))
            {
                return false;
            }

            if ((BST.prev != null) && (BST.prev.Data > root.Data))
            {
                return false;
            }
            BST.prev = root;

            if (!IsBSTUtil(root.Right))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// This method works base don min max value properties of BST. every node in BST is greater than maximum node in left subtree
        /// and is less than minimum value node in right subtree.
        /// While move down we need to narrow min max value based on currently visited node.
        /// </summary>
        /// <param name="rootNode"></param>
        /// <param name="max"></param>
        /// <param name="min"></param>
        private bool IsBSTUtilWithMinMaxCheck(Node rootNode, int max, int min)
        {
            if (rootNode == null)
            {
                return true;
            }
            if (rootNode.Data < min || rootNode.Data > max)
            {
                return false;
            }

            return IsBSTUtilWithMinMaxCheck(rootNode.left, min, rootNode.Data - 1) && IsBSTUtilWithMinMaxCheck(rootNode.Right, rootNode.Data + 1, max);
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

        /// <summary>
        /// Check if this tree is BST or not
        /// </summary>
        /// <returns>true/false - if this is a proper BST</returns>
        public bool IsBST()
        {
            prev = null;
            return IsBSTUtil(Root);
        }            
        
        /// <summary>
        /// This method returns kth smallest element in this BST
        /// </summary>
        /// <param name="k"></param>
        /// <returns>Kth smallest element from this tree</returns>
        public Node kthSmallestElement(int k)
        {
            Stack<Node> stack = new Stack<Node>();          
            Node crowl = Root;
            while(crowl != null)
            {
                stack.Push(crowl);
                crowl = crowl.left;
            }

            //Now we have smallest element node as top of stack

            while ((crowl = stack.Pop())!= null)
            {
                if(--k == 0)
                {
                    break;
                }
                else
                {
                    if (crowl.Right != null)
                    {
                        crowl = crowl.Right;
                        while(crowl!= null)
                        {
                            stack.Push(crowl);
                            crowl = crowl.left;
                        }
                    }
                }
            }

            return crowl;
        }  

        #endregion
    }

    /// <summary>
    /// Tester class for BST
    /// </summary>
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

            // Tester of inorder traversal
            bst.Inorder();

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
