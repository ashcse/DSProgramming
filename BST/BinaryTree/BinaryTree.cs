using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BST.BinaryTree
{
    /// <summary>
    /// This class represent Binary tree.
    /// It explains underlying concepts of binary tree by performing operations on it.
    /// </summary>
    class BinaryTree
    {

        public static void StoreInorderTraversalIntoArray(Node root, ref int[] array, ref int index)
        {
            if (root == null)
                return;

            StoreInorderTraversalIntoArray(root.left, ref array, ref index);
            array[index++] = root.Data;
            StoreInorderTraversalIntoArray(root.Right, ref array, ref index);
        }

        public static void CopyArrayToBTree(Node root, int[] array, ref int index)
        {
            if (root == null) return;

            CopyArrayToBTree(root.left, array, ref index);

            root.Data = array[index++];

            CopyArrayToBTree(root.Right, array, ref index);
        }

        public static Node ConvertBTreeToBST(Node root)
        {
            int size = BST.GetSize(root);
            int[] array = new int[size];
            int index = 0;

            StoreInorderTraversalIntoArray(root, ref array, ref index);
            Sorting.BubbleSort.Sort(ref array);
            index = 0;

            CopyArrayToBTree(root, array, ref index);

            return root;
        }
    }
}
