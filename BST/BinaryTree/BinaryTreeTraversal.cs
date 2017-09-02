using System;

namespace DS.BinaryTree
{
    public class BinaryTreeTraversal
    {
        /// <summary>
        /// Public function for Inorder Traversal.
        /// </summary>
        public static void Inorder(Node root)
        {
            if (root != null)
            {
                Inorder(root.left);

                Console.WriteLine(root.Data);

                Inorder(root.Right);
            }
        }

        

        /// <summary>
        /// Preorder traversal
        /// </summary>
        /// <param name="root"></param>
        private void Preorder(Node root)
        {
            if (root == null)
            {
                return;
            }
            Console.WriteLine(root.Data);
            Preorder(root.left);
            Preorder(root.Right);
        }       

       

        public static void StoreInorderTraversalIntoArray(Node root, ref int[] array, ref int index)
        {
            if (root == null)
                return;

            StoreInorderTraversalIntoArray(root.left, ref array, ref index);
            array[index++] = root.Data;
            StoreInorderTraversalIntoArray(root.Right, ref array, ref index);
        }
       

        public static void InorderWithoutRecursionAndStack(Node root)
        {
            if(root == null)
            {
                return;
            }

            Node current = root;
            Node prev = null;


            while(current != null)
            {
                if(current.left == null)
                {
                    Console.WriteLine(current.Data);
                    //prev = current;
                    if (current.Right != null)
                    {
                        current = current.Right;
                       // prev.Right = null;
                    }
                    else
                    {
                        //Console.WriteLine(current.Data);
                        current.Right = prev;

                        current = current.Right;
                       // prev = current;
                    }
                }
                else
                {
                    //prev = current;
                    current = current.left;
                }
            }

        }

    }
}
