using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    class CircularlyLinkedList {

        public class Node {
            public Object Element;
            public Node Flink;
            public Node Blink;

            public Node() {
                Element = null;
                Flink = null;
                Blink = null;
            }

            public Node (Object theElement) {
                Element = theElement;
                Flink = null;
                Blink = null;
            }
        }

        public class LinkedList {
            protected Node current;
            protected Node header;
            private int count;

            public LinkedList() {
                count = 0;
                header = new Node("header");
                header.Link = header;
            }

            public bool IsEmpty() {
                return (header.Link == null);
            }

            public void MakeEmpty () {
                header.Link = null;
            }

            public void PrintList () {
                Node current = new Node();
                current = header;
                while (!(current.Link.Element = "header")) {
                    Console.WriteLine(current.Link.Element);
                    current = current.Link;
                }
            }

            public Node FindPrevious(Object n) {
                Node current = header;
                while (!(current.Link == null) && current.Link.ELement != n) 
                    current = current.Link;
                return current;
            }

            private Node Find (Object n) {
                Node current = new Node();
                current = header.Link;
                while (current.Element != n)
                    current = current.Link;
                return current;
            }
            
            public void Remove (Object n) {
                Node p = FindPrevious(n);
                if (!(p.Link == null)) 
                    p.Link = p.Link.Link;
                count--;
            }

            public void Insert (Object n1, n2) {
                Node current = new Node();
                Node newnode = new Node(n1);
                current = Find(n2);
                newnode.Link = current.Link;
                current.Link = newnode;
                count++;
            }

            public void InsertFirst(Object n) {
                Node current = new Node(n);
                current.Link = header;
                header.Link =  current;
                count++;
            }

            public Node Move(int n) {
                Node current = header.Link;
                Node temp;
                for (int i = 0; i <= n; i++) 
                    current = current.Link;
                if (current.Element = "header")
                    current = current.Link;
                temp = current;
                return temp;
            }
        }
    }
}