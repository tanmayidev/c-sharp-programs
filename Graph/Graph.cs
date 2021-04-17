using System;
using System.Collections.Generic;
using System.Text;

namespace Graph {
    public class Vertex {
        public bool wasVisited;
        public string label;
        public Vertex(string label) {
            this.label = label;
            wasVisited = false;
        }
    }

    /*
     * int nVertices = 0;
        vertices[nVertices] = new Vertex("A");
        nVertices++;
        vertices[nVertices] = new Vertex("B");
        nVertices++;
        vertices[nVertices] = new Vertex("C");
        nVertices++;
        vertices[nVertices] = new Vertex("D");

        adjMatrix[0,1] = 1;
        adjMatrix[1,0] = 1;
        adjMatrix[1,3] = 1;
        adjMatrix[3,1] = 1;
     * */
    public class Graph {
        private const int NUM_VERTICES = 20;
        private Vertex[] vertices;
        private int[,] adjMatrix;
        int numVerts;
        public Graph() {
            vertices = new Vertex[NUM_VERTICES];
            adjMatrix = new int[NUM_VERTICES, NUM_VERTICES];
            numVerts = 0;
            for (int j = 0; j <= NUM_VERTICES -1; j++)
                for (int k = 0; k <= NUM_VERTICES - 1; k++)
                    adjMatrix[j, k] = 0;
        }
        public void AddVertex(string label) {
            vertices[numVerts] = new Vertex(label);
            numVerts++;
        }
        public void AddEdge(int start, int eend) {
            adjMatrix[start, eend] = 1;
            //adjMatrix[eend, start] = 1;
        }
        public void ShowVertex(int v) {
            Console.Write(vertices[v].label + " ");
        }

        public int NoSuccessors() {
            bool isEdge = false;
            int row = 0;
            for (row = 0; row <= numVerts - 1; row++) {
                isEdge = false;
                for (int col = 0; col <= numVerts - 1; col++)
                    if (adjMatrix[row, col] > 0) {
                        isEdge = true;
                        break;
                    }
                if (!(isEdge))
                    return row;
            }
                       
            return -1;
          }

        /*
         * A B C D E F
         * A B D E F
         * 
         *    A B D E F 
         * A  0 1 0 0 1 
         * B  0 1 0 0 1 
         * D  0 1 0 0 1 
         * E  0 0 1 0 0 
         * F  1 1 0 0 1 
         * 
         */
        public void DelVertex(int vert) {
            if (vert != numVerts - 1) {
                for (int j = vert; j <= numVerts - 1; j++)
                    vertices[j] = vertices[j + 1];
                for (int row = vert; row <= numVerts - 1; row++)
                    MoveRow(row, numVerts);
                for (int col = vert; col <= numVerts - 1; col++)
                    MoveCol(col, numVerts - 1);
            }
            numVerts--;
        }
        
        private void MoveRow(int row, int length) {
            for(int col = 0; col <= length-1; col++)
                adjMatrix[row, col] = adjMatrix[row+1, col];
        }
        private void MoveCol(int col, int length) {
            for(int row = 0; row <= length-1; row++)
                adjMatrix[row, col] = adjMatrix[row, col+1];
        }
      
       public void TopSort() {
            int origVerts = numVerts;
            Stack<string> gStack = new Stack<string>();
            while(numVerts > 0) {
                int currVertex = NoSuccessors();
                if (currVertex == -1) {
                    Console.WriteLine("Error: graph has cycles.");
                    return;
                }

                gStack.Push(vertices[currVertex].label);
                DelVertex(currVertex);
            }
            Console.Write("Topological sorting order: ");
            while (gStack.Count > 0)
              Console.Write(gStack.Pop() + " ");
        }

        private int GetAdjUnvisitedVertex(int v) {
            for (int j = 0; j <= numVerts - 1; j++)
                if ((adjMatrix[v, j] == 1) && (vertices[j].wasVisited == false))
                    return j;
            return -1;
        }
        public void DepthFirstSearch() {
            Stack<int> gStack = new Stack<int>();
            vertices[0].wasVisited = true;
            ShowVertex(0);
            gStack.Push(0);
            int v;
            while (gStack.Count > 0) {
                v = GetAdjUnvisitedVertex(gStack.Peek());
                if (v == -1)
                    gStack.Pop();
                else {
                    vertices[v].wasVisited = true;
                    ShowVertex(v);
                    gStack.Push(v);
                }
            }
            for (int j = 0; j <= numVerts - 1; j++)
                vertices[j].wasVisited = false;
        }

        public void BreadthFirstSearch() {
            Queue<int> gQueue = new Queue<int>();
            vertices[0].wasVisited = true;
            ShowVertex(0);
            gQueue.Enqueue(0);
            int vert1, vert2;
            while (gQueue.Count > 0) {
                vert1 = gQueue.Dequeue();
                vert2 = GetAdjUnvisitedVertex(vert1);
                while (vert2 != -1) {
                    vertices[vert2].wasVisited = true;
                    ShowVertex(vert2);
                    gQueue.Enqueue(vert2);
                    vert2 = GetAdjUnvisitedVertex(vert1);
                }
            }
            for (int i = 0; i <= numVerts - 1; i++)
                vertices[i].wasVisited = false;
        }
        static void BFSMain() {
            Graph aGraph = new Graph();
            aGraph.AddVertex("A");
            aGraph.AddVertex("B");
            aGraph.AddVertex("C");
            aGraph.AddVertex("D");
            aGraph.AddVertex("E");
            aGraph.AddVertex("F");
            aGraph.AddVertex("G");
            aGraph.AddVertex("H");
            aGraph.AddVertex("I");
            aGraph.AddVertex("J");
            aGraph.AddVertex("K");
            aGraph.AddVertex("L");
            aGraph.AddVertex("M");
            aGraph.AddEdge(0, 1);
            aGraph.AddEdge(1, 2);
            aGraph.AddEdge(2, 3);
            aGraph.AddEdge(0, 4);
            aGraph.AddEdge(4, 5);
            aGraph.AddEdge(5, 6);
            aGraph.AddEdge(0, 7);
            aGraph.AddEdge(7, 8);
            aGraph.AddEdge(8, 9);
            aGraph.AddEdge(0, 10);
            aGraph.AddEdge(10, 11);
            aGraph.AddEdge(11, 12);
            //aGraph.DepthFirstSearch();
            //Console.WriteLine();

            aGraph.BreadthFirstSearch();
            Console.WriteLine();

        }
       

        static void TopSortMain() {
            Graph theGraph = new Graph();
            //theGraph.AddVertex("A");
            //theGraph.AddVertex("B");
            //theGraph.AddVertex("C");
            //theGraph.AddVertex("D");
            //theGraph.AddVertex("E");
            //theGraph.AddVertex("F");
            //theGraph.AddEdge(0, 1);
            //theGraph.AddEdge(1, 2);
            //theGraph.AddEdge(1, 5);
            //theGraph.AddEdge(2, 3);
            //theGraph.AddEdge(3, 4);
            theGraph.AddVertex("CS1");
            theGraph.AddVertex("CS2");
            theGraph.AddVertex("DS");
            theGraph.AddVertex("OS");
            theGraph.AddVertex("ALG");
            theGraph.AddVertex("AL");
            theGraph.AddEdge(0, 1);
            theGraph.AddEdge(1, 2);
            theGraph.AddEdge(1, 5);
            theGraph.AddEdge(2, 3);
            theGraph.AddEdge(2, 4);
            theGraph.TopSort();
            Console.WriteLine();
            Console.WriteLine("Finished.");
        }
        public void Mst() {
            vertices[0].wasVisited = true;
            Stack<int> gStack = new Stack<int>();
            gStack.Push(0);
            int currVertex, ver;
            while (gStack.Count > 0) {
                currVertex = gStack.Peek();
                ver = GetAdjUnvisitedVertex(currVertex);
                if (ver == -1)
                    gStack.Pop();
                else {
                    vertices[ver].wasVisited = true;
                    gStack.Push(ver);
                    ShowVertex(currVertex);
                    ShowVertex(ver);
                    Console.Write(" ");
                }
            }
            for (int j = 0; j <= numVerts - 1; j++)
                vertices[j].wasVisited = false;
        }

        static void Main() {
            Graph aGraph = new Graph();
            aGraph.AddVertex("A");
            aGraph.AddVertex("B");
            aGraph.AddVertex("C");
            aGraph.AddVertex("D");
            aGraph.AddVertex("E");
            aGraph.AddVertex("F");
            aGraph.AddVertex("G");
            aGraph.AddEdge(0, 1);
            aGraph.AddEdge(0, 2);
            aGraph.AddEdge(0, 3);
            aGraph.AddEdge(1, 2);
            aGraph.AddEdge(1, 3);
            aGraph.AddEdge(1, 4);
            aGraph.AddEdge(2, 3);
            aGraph.AddEdge(2, 5);
            aGraph.AddEdge(3, 5);
            aGraph.AddEdge(3, 4);
            aGraph.AddEdge(3, 6);
            aGraph.AddEdge(4, 5);
            aGraph.AddEdge(4, 6);
            aGraph.AddEdge(5, 6);
            Console.WriteLine();
            aGraph.Mst();
        }

    }
}
