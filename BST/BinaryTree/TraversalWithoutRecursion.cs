using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.BinaryTree
{
    public class TraversalWithoutRecursion
    {


        public static void InorderWithoutRecursion(Node root)
        {
            bool done = false;
            Node current = root;

            Stack<Node> stack = new Stack<Node>();

            while (!done)
            {
                if(current != null)
                {
                    stack.Push(current);
                    current = current.left;
                }
                else
                {
                    if(stack.Count > 0)
                    {
                        current = stack.Pop();
                        Console.WriteLine(current.Data);

                        current = current.Right;
                    }
                    else
                    {
                        done = true;
                    }
                }
            }
        }


        public static void PreorderTraversalWithoutRecusion(Node root)
        {
            Stack<Node> stack = new Stack<Node>();

            Node current = root;          
            stack.Push(current);

            while (stack.Count > 0)
            {
                current = stack.Pop();
                
                Console.WriteLine(current.Data);

                if (current.Right != null)
                {
                    stack.Push(current.Right);
                }

                if (current.left != null)
                {
                    stack.Push(current.left);
                }
            }
         }

        public static void PostorderTraversalWithoutRecursion(Node root)
        {           

            Stack<Node> stack = new Stack<Node>();


            do
            {
                while (root != null)
                {
                    if (root.Right != null)
                    {
                        stack.Push(root.Right);
                    }

                    stack.Push(root);
                    root = root.left;
                }

                root = stack.Pop();

                if ((root.Right != null) && (stack.Count > 0) && (stack.Peek().Equals(root.Right)))
                {
                    stack.Pop();
                    stack.Push(root);
                    root = root.Right;
                }
                else
                {
                    Console.WriteLine(root.Data);
                    root = null;
                }
            }
            while (stack.Count > 0);
        }
    }
}
