using DS.BinaryTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// Line by line printing Binary tree without modifying Node Class
        /// </summary>
        /// <param name="root">Root of the tree</param>
        public static void LevelOrderTraversalLineByLine(Node root)
        {
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root);

            while (true)
            {
                int count = q.Count;

                if (count == 0)
                {
                    break;
                }

                while (count > 0)
                {
                    Node temp = q.Dequeue();
                    Console.Write(" " + temp.Data);

                    if (temp.left != null)
                    {
                        q.Enqueue(temp.left);
                    }

                    if (temp.Right != null)
                    {
                        q.Enqueue(temp.Right);
                    }

                    count--;
                }

                Console.WriteLine();
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

        public static void LevelOrderTraversalWithRecursion(Node root)
        {
            if (root == null)
                return;

            int height = CalculateHeight(root);

            for (int i = 1; i <= height; i++)
            {
                LevelOrderTraversalWithRecursion(root, i);
                Console.WriteLine();
            }
        }

        private static void LevelOrderTraversalWithRecursion(Node root, int i)
        {
            if (root == null)
                return;

            if (i == 1)
            {
                Console.Write(" " + root.Data);
            }
            else
            {
                LevelOrderTraversalWithRecursion(root.left, i - 1);
                LevelOrderTraversalWithRecursion(root.Right, i - 1);
            }
        }

        private static int CalculateHeight(Node root)
        {
            if (root == null)
            {
                return 0;
            }
            else
            {
                var leftheight = CalculateHeight(root.left);
                var righHeight = CalculateHeight(root.Right);

                return 1 + ((leftheight > righHeight) ? leftheight : righHeight);

            }
        }

        public static void PrintLevelWiseNodesUsingQueue(Node root)
        {
            if (root == null)
                return;

            StoreLevelIntoNodes(root, 1);

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);
            Node prevNode = null;

            while (queue.Count > 0)
            {
                Node temp = queue.Dequeue();


                if ((prevNode != null) && (prevNode.Level != temp.Level))
                {
                    Console.WriteLine();
                }

                Console.Write(" " + temp.Data);

                prevNode = temp;

                if (temp.left != null)
                {
                    queue.Enqueue(temp.left);

                }

                if (temp.Right != null)
                {
                    queue.Enqueue(temp.Right);
                }
            }
        }

        public static void LevelOrderTraversalWithQueue(Node root)
        {
            if (root == null)
                return;

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                Node temp = queue.Dequeue();

                Console.WriteLine(temp.Data);

                if (temp.left != null)
                {
                    queue.Enqueue(temp.left);

                }

                if (temp.Right != null)
                {
                    queue.Enqueue(temp.Right);
                }
            }

        }

        public static void StoreLevelIntoNodes(Node root, int i)
        {
            if (root == null)
                return;

            root.Level = i;

            StoreLevelIntoNodes(root.left, i + 1);
            StoreLevelIntoNodes(root.Right, i + 1);
        }


        public static void StoreInorderTraversalIntoArray(Node root, ref int[] array, ref int index)
        {
            if (root == null)
                return;

            StoreInorderTraversalIntoArray(root.left, ref array, ref index);
            array[index++] = root.Data;
            StoreInorderTraversalIntoArray(root.Right, ref array, ref index);
        }

    }
}
