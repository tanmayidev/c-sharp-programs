using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;


//
// string name = "Jennifer Ingram";
// string name = "Arun is an \nInstructor, CIS\tRoom 305";
// Arun is an 
// Instructor, CIS  Room 305

// csv - comma separated value
// string data = "Arun, Kumar, 3000, Mysore, Karnataka, India, 570017"
/*
 * string data = "Mike,McMillan,3000 W. Scenic,North Little
    Rock,AR,72118";
    string[] sdata;
    char[] delimiter = new char[] {','};
    sdata = data.Split(delimiter, data.Length);
 * */

namespace String {
    class String {
        static void Main1() {
            string string1 = "Hello, world!";
            int len = string1.Length;
            int pos = string1.IndexOf(" ");
            string firstWord, secondWord;
            firstWord = string1.Substring(0, pos);
            secondWord = string1.Substring(pos + 1,
            (len - 1) - (pos + 1));
            Console.WriteLine("First word: " + firstWord);
            Console.WriteLine("Second word: " + secondWord);
            Console.Read();
        }

        static void Main2() {
            string astring = "Now is the time";
            int pos;
            string word;
            ArrayList words = new ArrayList();
            pos = astring.IndexOf(" ");
            while (pos > 0) {
                word = astring.Substring(0, pos);
                words.Add(word);
                astring = astring.Substring(pos + 1, astring.Length - (pos + 1));
                pos = astring.IndexOf(" ");
                if (pos == -1) {
                    word = astring.Substring(0, astring.Length);
                    words.Add(word);
                }
                Console.Read();
            }
        }
        

        static void Main3() {
            string astring = "now is the time for all good people";
            ArrayList words = new ArrayList();
            words = SplitWords(astring);
            foreach (string word in words)
                Console.Write(word + " ");
            Console.Read();
        }
        // the above Main3 uses SplitWords function


        static void Main() {
            string astring = "now is the time for all good people";
            string[] words = astring.Split(' ');
            foreach (string word in words)
                Console.Write(word + " ");
            Console.Read();
        }
        static void Main5() {
            string data = "Mike,McMillan,3000 W. Scenic,North Little Rock, AR,72118";
            string[] sdata;
            char[] delimiter = new char[] { ',' };
            sdata = data.Split(delimiter, data.Length);
            foreach (string word in sdata)
                Console.Write(word + " ");
            string joined;
            joined = String.Join(';', sdata);
            Console.Write(joined);
        }

        static void Main7() {
            string[] nouns = new string[] { "cat", "dog", "bird", "eggs", "bones" };
            ArrayList pluralNouns = new ArrayList();
            foreach (string noun in nouns)
                if (noun.EndsWith("s"))
                    pluralNouns.Add(noun);
            foreach (string noun in pluralNouns)
                Console.Write(noun + " ");
        }
        static void Main6() {
            string s1 = "m";
            string s2 = "n";
            int compVal = String.Compare(s1, s2);
            switch (compVal) {
                case 0:
                    Console.WriteLine(s1 + " " + s2 + " are equal");
                    break;
                default:
                    Console.WriteLine("Can't compare");
                    break;
            }
        }

        static void Main8() {
            string[] words = new string[]{"triangle",
                    "diagonal",
                    "trimester","bifocal",
                    "triglycerides"};
            ArrayList triWords = new ArrayList();
            foreach (string word in words)
                if (word.StartsWith("tri"))
                    triWords.Add(word);
            foreach (string word in triWords)
                Console.Write(word + " ");
        }
        static void Main9() {
            string s1 = "Hello, . Welcome to my class.";
            string name = "Clayton";
            int pos = s1.IndexOf(",");
            s1 = s1.Insert(pos + 2, name);
            Console.WriteLine(s1);
        }

        static void Main10() {
            string s1 = "Hello, . Welcome to my class.";
            string name = "Ella";
            int pos = s1.IndexOf(",");
            s1 = s1.Insert(pos + 2, name);
            Console.WriteLine(s1);
            s1 = s1.Remove(pos + 2, name.Length);
            Console.WriteLine(s1);
        }

        static void Main11() {
            string[] words = new string[]{"recieve", "decieve",
                "reciept"};
            for (int i = 0; i <= words.GetUpperBound(0); i++) {
                words[i] = words[i].Replace("cie", "cei");
                Console.WriteLine(words[i]);
            }
        }
        static void Main12() {
            string[,] names = new string[,]
                    {{"1504", "Mary", "Ella", "Steve", "Bob"},
                    {"1133", "Elizabeth", "Alex", "David", "Joe"},
                    {"2624", "Joel", "Chris", "Craig", "Bill"}};
            Console.WriteLine();
            Console.WriteLine();
            for (int outer = 0; outer <= names.GetUpperBound(0); outer++) {
                for (int inner = 0; inner <= names.GetUpperBound(1); inner++)
                    Console.Write(names[outer, inner] + " ");
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();
            for (int outer = 0; outer <= names.GetUpperBound(0);
            outer++) {
                for (int inner = 0; inner <= names.GetUpperBound(1); inner++)
                    Console.Write(names[outer, inner].PadRight(10) + " ");
                Console.WriteLine();
            }
        }
        static void Main13() {
            string s1 = "hello";
            string s2 = "world";
            string s3 = String.Concat(s1, " ", s2);
            Console.WriteLine(s3);
        }
        static void Main14() {
            StringBuilder stBuff = new StringBuilder();
            String[] words = new string[]
                {
                                "now ", "is ", "the ", "time ", "for ", "all ",
                "good ", "men ", "to ", "come ", "to ", "the ",
                "aid ", "of ", "their ", "party"};
            for (int i = 0; i <= words.GetUpperBound(0); i++)
                stBuff.Append(words[i]);
            Console.WriteLine(stBuff);
        }

        static void Main15() {
            StringBuilder stBuff = new StringBuilder();
            Console.WriteLine();
            stBuff.AppendFormat("Your order is for {0000} widgets.", 234);
            stBuff.AppendFormat("\nWe have {0000} widgets left.", 12);
            Console.WriteLine(stBuff);
        }

        static void Main16() {
            int size = 100;
            Timing timeSB = new Timing();
            Timing timeST = new Timing();
            Console.WriteLine();
            for (int i = 0; i <= 10; i++) {
                timeSB.startTime();
                BuildSB(size);
                timeSB.stopTime();
                timeST.startTime();
                //BuildString(size);
                timeST.stopTime();
                Console.WriteLine("Time (in milliseconds) to build StringBuilder"
                    + "object for " + size + " elements: " +
            timeSB.Result().TotalMilliseconds) ;
                Console.WriteLine("Time (in milliseconds) to build String object " 
                    + "for " + size + " elements: " +  timeST.Result().TotalMilliseconds) ;
                Console.WriteLine();
                size *= 10;
            }
        }
        static void BuildSB(int size) {
            StringBuilder sbObject = new StringBuilder();
            for (int i = 0; i <= size; i++)
                sbObject.Append("a");
        }
        static void BuildString(int size) {
            string stringObject = "";
            for (int i = 0; i <= size; i++)
                stringObject += "a";
        }
    

    static ArrayList SplitWords(string astring) {
            string[] ws = new string[astring.Length - 1];
            ArrayList words = new ArrayList();
            int pos;
            string word;
            pos = astring.IndexOf(" ");
            while (pos > 0) {
                word = astring.Substring(0, pos);
                words.Add(word);
                astring = astring.Substring(pos + 1, astring.Length - (pos + 1));
                pos = astring.IndexOf(" ");
                if (pos == -1) {
                    word = astring.Substring(0, astring.Length);
                    words.Add(word);
                }
            }
            return words;
        }
    }
}

