using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedListExample
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedListNode<string> node = new LinkedListNode<string> ("Mike");
            LinkedList<string> names = new LinkedList<string> ();
            names.AddFirst(node);
            LinkedListNode<string> node1 = new LinkedListNode<string> ("David");
            names.AddAfter(node, node1);
            LinkedListNode<string> node2 = new LinkedListNode<string> ("Raymond");
            names.AddAfter(node1, node2);
            LinkedListNode<string> node3 = new LinkedListNode<string> (null);
            LinkedListNode<string> aNode = names.First;

            while (aNode != null) {
                Console.WriteLine(aNode.Value);
                aNode = aNode.Next;
            }

            aNode = names.Find("David");
            if (aNode != null)
                aNode = names.First;

            while (aNode != null) {
                Console.WriteLine(aNode.Value);
                aNode = aNode.Next;
            }

            // // Below is the while loop to check for the end the list
            // while (aNode != names.Last) {
            //     Console.WriteLine(aNode.Value);
            //     aNode = aNode.Next;
            // }

            Console.Read();
        }
    }
}
