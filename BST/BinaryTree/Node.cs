using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.BinaryTree
{
    /// <summary>
    /// This class represent a node in Binary search tree.
    /// </summary>
    public class Node
    {
        public int Data { get; set; }

        public Node left { get; set; }

        public Node Right { get; set; }

        public Node NextRight { get; set; }

        public int Level { get; set; }
    }
}
