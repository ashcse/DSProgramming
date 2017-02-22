using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheory
{
    public class AdjListNode
    {
        public int Destination { get; set; }

        public AdjListNode Next { get; set; }
    }

    public class AdjList
    {
        public AdjListNode Head { get; set; }
    }

    public class Graph
    {
        public int V { get; set; }

        public AdjList[] arr;

        public Graph(int v)
        {
            this.V = v;
            arr = new AdjList[v];

            for (int i =0; i< v; i++)
            {
                arr[i] = null;
            }
        }

        public void AddEdge(int source, int dest)
        {
            AdjListNode node = new AdjListNode { Destination = dest };

            if (arr[source] == null)
            {
                arr[source] = new AdjList { Head = node };
            }
            else
            {
                node.Next = arr[source].Head;
                arr[source].Head = node;
            }

            //Since this is undirected graph so add edge from destination to source also

            AdjListNode newNode = new AdjListNode { Destination = source };

            if (arr[dest] == null)
            {
                arr[dest] = new AdjList { Head = newNode };
            }
            else
            {
                newNode.Next = arr[dest].Head;
                arr[dest].Head = newNode;
            }
        }

        public void PrintGraph()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                AdjListNode current = arr[i].Head;
                Console.WriteLine(i);
                while (current != null)
                {
                    Console.WriteLine(" " + current.Destination);
                    current = current.Next;
                }
            }
        }

        public void BreadthFirstSearch(int startNode)
        {
            bool[] visitedNodes = new bool[V];

            Queue<int> q = new Queue<int>();
            // Consider first node as starting point of search.
            q.Enqueue(startNode);

            while(q.Count != 0)
            {
                int frontNode = q.Dequeue();

                if(visitedNodes[frontNode] == false)
                {
                    Console.WriteLine(frontNode);
                    visitedNodes[frontNode] = true;

                    if(arr[frontNode] != null)
                    {
                        AdjListNode current = arr[frontNode].Head;

                        while (current != null)
                        {
                            q.Enqueue(current.Destination);
                            current = current.Next;
                        }
                    }
                }
            }
        }

        public void DFS(int node)
        {
            bool[] visited = new bool[V];
            DFSUtil(node, ref visited);
        }

        private void DFSUtil(int v, ref bool[] visited)
        {
            visited[v] = true;
            Console.WriteLine(v);

            AdjListNode current = arr[v].Head;
            while(current != null)
            {
                if (visited[current.Destination] == false)
                {
                    DFSUtil(current.Destination, ref visited);
                }

                current = current.Next;
            }
        }
    }

    public class GraphTester
    {
        public static void TestGraph()
        {
            Graph graph = new Graph(5);
            graph.AddEdge(0, 1);
            graph.AddEdge(0, 4);

            graph.AddEdge(1, 2);
            graph.AddEdge(1, 3);
            graph.AddEdge(1, 4);

            graph.AddEdge(2, 3);

            graph.AddEdge(3, 4);

            //graph.PrintGraph();
            graph.DFS(0);

            //graph.BreadthFirstSearch(0);

            Graph g = new Graph(4);
            g.AddEdge(0, 1);
            g.AddEdge(0, 2);
            g.AddEdge(1, 2);
            g.AddEdge(2, 0);
            g.AddEdge(2, 3);
            g.AddEdge(3, 3);

            //g.BreadthFirstSearch(2);


           //


        }
    }
}

   