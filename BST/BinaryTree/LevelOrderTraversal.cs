using DS.BinaryTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.BinaryTree
{
    public class LevelOrderTraversal
    {
        /// <summary>
        /// Simple level order traversal with Queue
        /// </summary>
        /// <param name="root">Root node</param>
        public static void LevelOrderTraversalSimpleVersionWithQueue(Node root)
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

        /// <summary>
        /// Simple level order traversal with Queue
        /// </summary>
        /// <param name="root">Root node</param>
        public static int GetMaxWidthWithQueue(Node root)
        {
            if (root == null)
                return 0;

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);
            int count = queue.Count();
            int maxWidth = queue.Count();

            while (queue.Count > 0)
            {
                while (count > 0)
                {
                    Node temp = queue.Dequeue();
                   
                    if (temp.left != null)
                    {
                        queue.Enqueue(temp.left);

                    }

                    if (temp.Right != null)
                    {
                        queue.Enqueue(temp.Right);
                    }

                    count--;
                }

                count = queue.Count();

                if (count > maxWidth)
                    maxWidth = count;
            }

            return maxWidth;
        }

        public static void ConnectSameLevelNodesUsingLevelOrderTraversal(Node root)
        {
            if (root == null)
                return;

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);
            int count = queue.Count();
            int maxWidth = queue.Count();
            Node prev = null;

            while (queue.Count > 0)
            {
                prev = null;

                while (count > 0)
                {
                    Node temp = queue.Dequeue();

                    if(prev != null)
                    {
                        prev.NextRight = temp;
                    }

                    if (temp.left != null)
                    {
                        queue.Enqueue(temp.left);

                    }

                    if (temp.Right != null)
                    {
                        queue.Enqueue(temp.Right);
                    }
                    prev = temp;
                    count--;
                }

                if(prev != null)
                prev.NextRight = null;

                count = queue.Count();                
            }
        }



        /// <summary>
        /// Line by line printing Binary tree without modifying Node Class
        /// </summary>
        /// <param name="root">Root of the tree</param>
        public static void LevelOrderTraversalSimpleLineByLineWithQueue(Node root)
        {
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root);
            int count = q.Count();

            while (q.Count() >0)
            {
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
                count = q.Count();                
            }
        }

        public static void LevelOrderTraversalLineByLineWithRecursion(Node root)
        {
            if (root == null)
                return;

            int height = CalculateHeight(root);

            for (int i = 1; i <= height; i++)
            {
                PrintNodesAtSpecificLevel(root, i);
                Console.WriteLine();
            }
        }

        private static void PrintNodesAtSpecificLevel(Node root, int i)
        {
            if (root == null)
                return;

            if (i == 1)
            {
                Console.Write(" " + root.Data);
            }
            else
            {
                PrintNodesAtSpecificLevel(root.left, i - 1);
                PrintNodesAtSpecificLevel(root.Right, i - 1);
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

        

        public static void StoreLevelIntoNodes(Node root, int i)
        {
            if (root == null)
                return;

            root.Level = i;

            StoreLevelIntoNodes(root.left, i + 1);
            StoreLevelIntoNodes(root.Right, i + 1);
        }

    }
}
