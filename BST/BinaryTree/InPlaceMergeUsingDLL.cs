
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BST.BinaryTree
{
    /// <summary>
    /// This class merges two balanced BSTs using Doubly Linked List.
    /// This is in place merge hence no extra space is required to merge the tree
    /// </summary>
    public class InPlaceMergeUsingDLL
    {
        /*
         * Algorithm to Merge in place two BSTs into another BST using DLL
         * 1. Convert first BST into DLL 
         * 2. Convert second BST into DLL
         * 3. Mewrge both DLLs and create BST from merged DLL
         * 
         */ 


        public static Node ConvertInPlaceByCircularDLL(Node first, Node second)
        {
            // Below statements converts BST trees to circular doulbly sorted linked lists. 
            // From binary search trees sorted circular doubly linked lists can be created.
            // Once we have two circular doubly linked lists they can be mreged to form 
            Node firstDLLList = ConvertBSTToDLL.ConvertBSTtoCircularDLL(first);
            Node secondDLLList = ConvertBSTToDLL.ConvertBSTtoCircularDLL(second);

            Node mergedDLLList = ConvertBSTToDLL.MergeSortedDll(firstDLLList, secondDLLList);


            return null;
        }
    }


    /*
         * Algorithm
         * Recursively convert left subtree to a circular DLL and call it left
         * Recursively convert right subtree to a circular DLL and call it right
         * Convert root of both subtree's to circular dll (make its next point to it and prev point to itself.
         * concatenate left with root circular DLL into a new Circular DLL
         * Concatenate resultant circular DLL with right circular DLL
         */

    /// <summary>
    /// This class converts given BST into a circular DLL
    /// left node becomes prev and right node becomes next. and order of the node is as same as in inorder traversal of the tree.
    /// First node in the traversal becaomes as head of the circular doubly linked list.
    /// </summary>
    public class ConvertBSTToDLL
    {
        public static Node MergeSortedDll(Node first, Node second)
        {
            if (first == null) return second;
            if (second == null) return first;


            // make both lists regular lists by removing circle which will help iterating and merging
            first.left.Right = null;
            first.left = null;

            second.left.Right = null;
            second.left = null;

           
            Node left = first;
            Node right = second;
            
            // Below logic merges both sorted linked lists into first doubly linked list
            // if first list's element is less than second list then it keeps traversing until it finds element which is greater then second element
            // of until list finishes. It then inserts element before current item (item on which cursor is).
            // Hence this logic only inserts element from second list into first list before element which algorithm selects.
            do
            {
                if (left.Data < right.Data)
                {
                    while ((left.Data < right.Data) && (left != first))
                    {
                        left = left.Right;
                    }

                    // Insert second lists element before element left
                    Node temp = right.Right;

                    left.left.Right = right;
                    right.left = left.left;

                    left.left = right;
                    right.Right = left;
                    
                    left = left.Right;
                    right = temp;

                }
                else
                {
                    Node rightRight = right.Right;
                    Node prevleft = left.left;
                    left.left = right;
                    right.Right = left;
                    prevleft.Right = right;
                    right.left = prevleft;


                    right = rightRight;
                }
            }
            while ((right != second) && (left!= first));

            left = first;

            while(right != second)
            {
                Node rightRight = right.Right;
                Node prevleft = left.left;
                left.left = right;
                right.Right = left;
                prevleft.Right = right;
                right.left = prevleft;


                right = rightRight;
            }

            return null;
        }

        /// <summary>
        /// Converts BST to circular DLL by concatenating recursively.
        /// </summary>
        /// <param name="bst"></param>
        /// <returns></returns>
        public static  Node ConvertBSTtoCircularDLL(Node bst)
        {
            if (bst == null) return null;
            
            Node leftList = ConvertBSTtoCircularDLL(bst.left);
            Node rightList = ConvertBSTtoCircularDLL(bst.Right);


            // Make circular DLL of single root node
            bst.Right = bst.left = bst;            
          
            return ConcatenateCircularDLL(ConcatenateCircularDLL(leftList, bst), rightList);
        }

        /// <summary>
        /// Displays circular DLL
        /// </summary>
        /// <param name="head">head of the list</param>
        public static  void Display(Node head)
        {
            Node temp = head;
            while (temp.Right != temp)
            {
                Console.WriteLine(temp.Data);
                temp = temp.Right;
            }
        }

        /// <summary>
        /// Concatenates two circular double linked lists represented by BST
        /// </summary>
        /// <param name="left">Left list head node</param>
        /// <param name="right">Right list head node</param>
        /// <returns></returns>
        public static Node ConcatenateCircularDLL(Node left, Node right)
        {
            if (left == null) return right;
            if (right == null) return left;

            Node lastOfFirst = left.left;
            Node lastOfSecond = right.left;

            lastOfFirst.Right = right;
            right.left = lastOfFirst;

            left.left = lastOfSecond;
            lastOfSecond.Right = left;
            return left;
        }
    }

    public class InPlaceBSTMergeTester
    {
        public static void Test()
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
            Node result = InPlaceMergeUsingDLL.ConvertInPlaceByCircularDLL(bst.Root, bst1.Root);

            BST tree = new BST { Root = result };

            tree.Inorder();
            tree.Preorder();     
        }
    }
}
