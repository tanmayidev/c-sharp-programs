using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1 {
    class Hashing {
        public static void Main() {

            //int[] arr = { 1000, 100, 9, 13, 22 };
            //for (int j = 0; j < arr.Length; ++j) {
            //    for (int i = 1; i < 9; ++i)
            //        Console.WriteLine(arr[j] + " Modulo " + i + " is " + arr[j] % i);
            //}

            string[] names = new string[10007];
            string name;

            string[] someNames = new string[]{"David",
                "Jennifer", "Donnie", "Mayo", "Raymond",
                "Bernica", "Mike", "Clayton", "Beata", "Michael"};
            int hashVal;
            for (int i = 0; i < 10; i++) {
                name = someNames[i];
                //hashVal = SimpleHash(name, names);
                hashVal = BetterHash(name, names);
                names[hashVal] = name;
            }
            ShowDistrib(names);

            Console.WriteLine(" Is Mike present " + InHash("Mike", names));

            Console.WriteLine(" Is Erica present " + InHash("Erica", names));
        }
        static bool InHash(string s, string[] arr) {
            int hval = BetterHash(s, arr);
            if (arr[hval] == s)
                return true;
            else
                return false;
        }

        static int SimpleHash(string s, string[] arr) {
            int tot = 0;
            char[] cname;
            cname = s.ToCharArray();
            for (int i = 0; i <= cname.GetUpperBound(0); i++)
                tot += (int)cname[i];
            return tot % arr.GetUpperBound(0);
        }
        static int BetterHash(string s, string[] arr) {
            long tot = 0;
            char[] cname;
            cname = s.ToCharArray();
            for (int i = 0; i <= cname.GetUpperBound(0); i++)
                tot += 37 * tot + (int)cname[i];
            tot = tot % arr.GetUpperBound(0);
            if (tot < 0)
                tot += arr.GetUpperBound(0);
            return (int)tot;
        }
        static void ShowDistrib(string[] arr) {
            for (int i = 0; i <= arr.GetUpperBound(0); i++)
                if (arr[i] != null)
                    Console.WriteLine(i + " " + arr[i]);
        }
    }
    
}

