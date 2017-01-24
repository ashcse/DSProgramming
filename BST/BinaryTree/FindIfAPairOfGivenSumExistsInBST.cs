using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BST.BinaryTree
{
    public class FindIfAPairOfGivenSumExistsInBST
    {
        public static bool IfPairOfGivenSumExists(Node root)
        {
            Node current1 = root, current2 = root;
            bool done1 = false, done2 = false;
            Stack<Node> stack1 = new Stack<Node>();
            Stack<Node> stack2 = new Stack<Node>();
            int value1 = 0, value2 = 0;

            while(true)
            {
                while(!done1)
                {
                    if(current1 != null)
                    {
                        stack1.Push(current1);
                        current1 = current1.left;
                    }
                    else if(stack1.Count > 0)
                    {
                        current1 = stack1.Pop();
                        value1 = current1.Data;

                        //write current1.data
                        current1 = current1.Right;

                        done1 = true;
                    }
                    else
                    {
                        done1 = true;
                    }
                }

                while(!done2)
                {
                    if(current2 != null)
                    {
                        stack2.Push(current2);
                        current2 = current2.Right;
                    }
                    else if(stack2.Count > 0)
                    {
                        current2 = stack2.Pop();
                        value2 = current2.Data;
                        current2 = current2.left;
                        done2 = true;
                    }
                    else
                    {
                        done2 = true;
                    }

                }


                if((value1 + value2) == 0)
                {
                    return true;
                }

                if((value1 + value2) > 0)
                {
                    done2 = false;
                }

                if((value1 + value2) < 0)
                {
                    done1 = false;
                }

                if(value1 > value2)
                {
                    return false;
                }

            }
        }
    }
}
