using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BST.InsertDelete
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
        /// Insert utility function which actually performs insert
        /// </summary>
        /// <param name="rootNode"></param>
        /// <returns></returns>
        private Node InsertUtil(AVLNode rootNode)
        {
            return null;
        }

        /// <summary>
        /// Inserts a new key into this AVL tree
        /// </summary>
        /// <param name="key"></param>
        public void Insert(int key)
        {

        }

        #endregion 
    }
}
