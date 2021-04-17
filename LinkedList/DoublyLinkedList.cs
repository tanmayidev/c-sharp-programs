
using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    class DoublyLinkedList
    {
        public class Node {
            public Object Element;
            public Node Flink;
            public Node Blink;

            public Node() {
                Element = null;
                Flink = null;
                Blink = null;
            }
        }

        public void Insert (Object newItem, Object after) {
            Node current = new Node();
            Node newNode = new Node(newItem);
            current = Find(after);
            newNode.Flink = current.Link;
            newNode.Blink = current;
            current.Flink = newNode;
        }

        public void Remove (Object n) {
            Node p = Find(n);
            if (!(p.Flink == null)) {
                p.Blink.Flink = p.Flink;
                p.Flink.Blink = p.Blink;
                p.Flink = null;
                p.Blink = null;
            }
        }

        private Node FindLast() {
            Node current = new Node();
            current = header;
            while(!(current.Flink == null))
                current = current.Flink;
            return current;
        }

        public void PrintReverse () {
            Node current = new Node();
            current = FindLast();
            while (!(current.Blink == null)) {
                Console.WriteLine(current.Element);
                current = current.Blink;
            }
        }
    }
}