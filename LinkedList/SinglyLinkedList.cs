using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    class SinglyLinkedList
    {
        public class Node {
            public Object Element;
            public Node Link;

            public Node() {
                Element = null;
                Link = null;
            }

            public Node(Object theElement) {
                Element = theElement;
                Link = null;
            }

            public class LinkedList {
                protected Node header;

                public LinkedList() {
                    header = new Node("header");
                }
            }

            private Node Find(Object item) {
                Node current = new Node();
                current = header;
                while (current != null && current.Element != item) {
                    current = current.Link;
                }
                return current;
            }

            public void Insert(Object newItem, Object after) {
                Node newNode = new Node(newItem);
                Node current = Find(after);
                newNode.Link = current.Link;
                current.Link = newNode;
            }

            public Node FindPrevious (Object n) {
                Node current = header;
                while (! (current.Link == null) && (current.Link.Element != n))
                    current = current.Link;
                return current;
            }

            public void Remove (Object n) {
                Node p = FindPrevious(n);
                if (!(p.Link == null))
                    p.Link = p.Link.Link;
            }

            public void PrintList() {
                Node current = new Node();
                current = header;
                while (! (current.Link == null)) {
                    Console.WriteLine(current.Link.Element);
                    current = current.Link;
                }
            }
        }
    }
}
