using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Stack
{
    class Stack
    {
        private int p_index;
        private ArrayList list; // private int[] arr;
        public Stack() 
        {
            list = new ArrayList(); // arr = new int[size]
            p_index = -1;
        }

        public int count {
            get {
                return list.Count;
            }
        }

        public void push(object item) 
        {
            list.Add(item);
            p_index++;
        }

        public object pop()
        {
            object obj = list[p_index];
            list.RemoveAt(p_index);
            p_index--;
            return obj;
        }

        public void clear() 
        {
            list.Clear();
            p_index = -1;
        }

        public object peek()
        {
            return list[p_index];
        }

        public static void Main() {
            Stack myStack = new Stack();

            myStack.push(10);
            myStack.push(20);
            Console.WriteLine(myStack.pop());
            Console.WriteLine(myStack.peek());
            Console.WriteLine(myStack.pop());
            Console.ReadLine();
        }

        // //Checking for Palindrome
        // static void Main(string[] args) {
        //     Stack alist = new Stack();
        //     string ch;
        //     string word = "madam";
        //     bool isPalindrome = true;
        //     for (int x = 0; x < word.Length; x++)
        //         alist.push(word.Substring(x, 1));
        //     int pos = 0;
        //     while (alist.count > 0) {
        //         ch = alist.pop().ToString();
        //         if (ch != word.Substring(pos, 1)) {
        //             isPalindrome = false;
        //             break;
        //         }
        //         pos++;
        //     }
        //     if (isPalindrome)
        //        Console.WriteLine(word + " is a palindrome.");
        //    else
        //        Console.WriteLine(word + " is not a palindrome.");
        //    Console.Read();
        // }

    }
}
