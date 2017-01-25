using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BST.BinaryTree
{

    #region Binary tree node

    /// <summary>
    /// This class represent a node in Binary search tree.
    /// </summary>
    public class Node
    {
        public int Data { get; set; }

        public Node left { get; set; }

        public Node Right { get; set; }
    }
    
    #endregion

    /// <summary>
    /// Demonstrates binary search tree operations.
    /// </summary>
    public class BST
    {
        #region fields

        /// <summary>
        /// Root of this BST
        /// </summary>
        public Node  Root { get; set; }

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

        #region merge two BST into balanced BST using sorted array technique

        /// <summary>
        /// Calculates size (or number of nodes in the given binary search tree
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static int GetSize(Node node)
        {
            if (node == null)
                return 0;
            else return GetSize(node.left) + 1 + GetSize(node.Right);
        }

        /// <summary>
        /// Merge two binary search trees with limited space (space should be logN (same as height of the tree)
        /// RELATED PROBLEMS:
        /// 1. Merge two balanced binary search trees (AVL trees)
        /// Size should be given in the question if not then it can be claculated by method getSize
        /// First Approach: traverse each node from one tree and insert one by one into another tree.
        /// in this case if first tree size is m and second is n then total complexity will be: logn+ log (n +1) + log(n + 2)... + log(n + m -1)
        /// The value of thie expressioin can be mlogn.

        /// 2. Solution
        /// 1) Do inorder traversal of first tree and store the traversal in one temp array arr1[]. This step takes O(m) time.
        /// 2) Do inorder traversal of second tree and store the traversal in another temp array arr2[]. This step takes O(n) time.
        /// 3) The arrays created in step 1 and 2 are sorted arrays.Merge the two sorted arrays into one array of size m + n.This step takes O(m+n) time.
        /// 4) Construct a balanced BST from the merged tree.
        /// Time complexity of this method is O(m+n) which is better than method 1. This method takes O(m+n) time even if the input BSTs are not balanced.
        /// </summary>
        /// <returns></returns>
        private BST MergeTreesUsingArrayUtil(Node root1, Node root2, int[] firstArray, int[] secondArray)
        {
            int index = 0;
            // Create a sorted array from first BST
            StoreInorder(root1, firstArray, ref index);

            index = 0;

            // Create second sorted array from second BST using inorder traversal
            StoreInorder(root2, secondArray, ref index);

            
            int[] mergedArray = new int[firstArray.Length + secondArray.Length];

            MergeSortedArrays(firstArray, secondArray, ref mergedArray);

            Node root = SortedArrayToBSTUtil(mergedArray, 0, mergedArray.Length-1);

            // Both arrays are populated with the sorted tree nodes

            return new BST { Root = root };
        }

        /// <summary>
        /// This method mreges two sorted array : first array and second array into third array mergedarray
        /// </summary>
        /// <param name="firstArray"></param>
        /// <param name="secondArray"></param>
        /// <param name="mergedArray"></param>
        private void MergeSortedArrays(int[] firstArray, int[] secondArray, ref int[] mergedArray)
        {
            int i = 0;
            int j = 0;
            int k = 0;

            while ((i < firstArray.Length) && (j < secondArray.Length))
            {
                if (firstArray[i] <= secondArray[j])
                {
                    mergedArray[k++] = firstArray[i];
                    i++;
                }
                else
                {
                    mergedArray[k++] = secondArray[j];
                    j++;
                }              
            }

            while (i < firstArray.Length)
            {
                mergedArray[k++] = firstArray[i++];
            }

            while (j < secondArray.Length)
            {
                mergedArray[k++] = secondArray[j++];
            }
        }

        /// <summary>
        /// Stores inorder traversal into an array
        /// </summary>
        /// <param name="root"></param>
        /// <param name="array"></param>
        /// <param name="index"></param>
        private void StoreInorder(Node root, int[] array, ref int index)
        {
            if (root == null) return;

            StoreInorder(root.left, array, ref index);
            array[index++] = root.Data;
            StoreInorder(root.Right, array, ref index);
        }       

        /// <summary>
        /// This method converts sorted array to BST
        /// </summary>
        /// <param name="array">Array which is to be converted</param>
        /// <param name="low">lower index of array</param>
        /// <param name="high">higher index</param>
        /// <returns>root node of created BST</returns>
        public  Node SortedArrayToBSTUtil(int [] array, int low, int high)
        {
            if(low > high)
            {
                return null;
            }

            int mid = (high + low) / 2;
            Node root = new Node { Data = array[mid] };
            root.left = SortedArrayToBSTUtil(array, low, mid - 1);
            root.Right = SortedArrayToBSTUtil(array, mid + 1, high);
            return root;            
        }

        /// <summary>
        /// Api to create sorted array to BST
        /// </summary>
        /// <param name="array"></param>
        public void SortedArrayToBST(int[] array)
        {
            Root = SortedArrayToBSTUtil(array, 0, array.Length - 1);
        }

        /// <summary>
        /// Public method which merges two specified BST and returns merged one
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public BST MergeTreesUsingArray(BST first, BST second)
        {
            int[] firstArray = new int[GetSize(first.Root)];
            int[] secondArray = new int[GetSize(second.Root)];

            return MergeTreesUsingArrayUtil(first.Root, second.Root, firstArray, secondArray);
        }

        #endregion


        #region traversal

        /// <summary>
        /// Preorder traversal
        /// </summary>
        /// <param name="root"></param>
        private void PreorderUtil(Node root)
        {
            if(root == null)
            {
                return;
            }
            Console.WriteLine(root.Data);
            PreorderUtil(root.left);
            PreorderUtil(root.Right);
        }

        public void Preorder()
        {
            PreorderUtil(Root);
        }

        #endregion

        #endregion
    }



    /// <summary>
    /// Tester class for BST
    /// </summary>
    public class BSTTester
    {
        public void Test()
        {
            /*
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

            //bst.Inorder();

    */
            BST bst = new BST();
            int[] array = new int[] { 2, 3, 10, 15, 20, 28 };
            bst.SortedArrayToBST(array);
            //bst.Preorder();
            TraversalWithoutRecursion.InorderWithoutRecursion(bst.Root);
            Console.WriteLine();
            TraversalWithoutRecursion.PreorderTraversalWithoutRecusion(bst.Root);

            Console.WriteLine();
            TraversalWithoutRecursion.PostorderTraversalWithoutRecursion(bst.Root);

    
            //TestBSTMerge();
           
        }


        private static void TestBSTMerge()
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
            BST result =  merge.MergeTreesUsingArray(bst, bst1);

            result.Inorder();
            result.Preorder();           
           
        }
    }
}
