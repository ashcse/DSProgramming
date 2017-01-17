using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BST.InsertDelete
{
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
        /// <summary>
        /// This method searches a given key in Binary search tree.
        /// </summary>
        /// <param name="root">root of the BST</param>
        /// <param name="key">key to find</param>
        /// <returns></returns>
        public Node Search(Node root, int key)
        {
            if((root == null )&&(root.Data == key))
            {
                return root;
            }

            if(key < root.Data)
            {
                return Search(root.left, key);
            }
            else
            {
                return Search(root.Right, key);
            }
        }


    }

    class BSTOperation
    {

    }
}
