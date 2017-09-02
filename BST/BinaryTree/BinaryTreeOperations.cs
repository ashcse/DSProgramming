using System;

namespace DS.BinaryTree
{
    public class BinaryTreeOperations
    {
        public static void Mirror(Node root)
        {
            if (root == null)
                return;

            Mirror(root.left);
            Mirror(root.Right);
            
            Node temp = root.left;
            root.left = root.Right;
            root.Right = temp;
        }

        public static int Diameter(Node root)
        {
            if (root == null)
                return 0;
            int lHeight = GetHeight(root.left);
            int rHeight = GetHeight(root.Right);

            return Max(lHeight + rHeight + 1,
                 Max(Diameter(root.left), Diameter(root.Right)));
        }

        private static int Max(int v1, int v2)
        {
            return (v1 > v2) ? v1 : v2;
        }

        public  static int GetHeight(Node root)
        {
            if (root == null)
                return 0;

            return 1 + Max(GetHeight(root.left), GetHeight(root.Right));
        }

        #region Sum Tree

        /// <summary>
        /// ON2
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static bool IsSumTree(Node root)
        {
            if (root == null)
                return true;

            if((root.left == null) && (root.Right == null))
            {
                return true;
            }

            int leftSum = GetSum(root.left);
            int rightSum = GetSum(root.Right);

            if ((root.Data == (leftSum + rightSum))
                && IsSumTree(root.left) & IsSumTree(root.Right))
            {
                return true;
            }

            return false;
        }

        private static int GetSum(Node root)
        {
            if (root == null)
                return 0;           

            return root.Data +  GetSum(root.left) + GetSum(root.Right);
        }


        public bool IsSumTreeOrderN(Node root)
        {
            int ls, rs;

            if (root == null)
                return true;

            if ((root.left == null) && (root.Right == null))
                return true;

            if(IsSumTreeOrderN(root.left) && IsSumTreeOrderN(root.Right))
            {
                if (root.left == null)
                {
                    ls = 0;
                }
                else if(IsLeafNode(root.left))
                {
                    ls = root.left.Data;
                }
                else
                {
                    ls = 2 * root.left.Data;
                }

                if(root.Right == null)
                {
                    rs = 0;
                }
                else if(IsLeafNode(root.Right))
                {
                    rs = root.Right.Data;
                }
                else
                {
                    rs = 2 * root.Right.Data;
                }

                if(root.Data == ls + rs)
                {
                    return true;
                }               

            }

            return false;
        }

        private bool IsLeafNode(Node left)
        {
            throw new NotImplementedException();
        }


        #endregion


    }
}
