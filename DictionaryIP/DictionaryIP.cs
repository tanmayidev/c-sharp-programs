using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DictionaryIP {
    public class IPAddresses : DictionaryBase {
        public IPAddresses() {

        }
        public void Add(string name, string ip) {
            base.InnerHashtable.Add(name, ip);
        }
        public string Item(string name) {
            return base.InnerHashtable[name].ToString();
        }
        public void Remove(string name) {
            base.InnerHashtable.Remove(name);
        }

        static void Main() {
            IPAddresses myIPs = new IPAddresses();
            DictionaryEntry[] ips = new DictionaryEntry[6];
            myIPs.Add("Google", "216.58.203.132"); // 0x47, 0x4F, 0x4f, 0x67, 0x6c, 0x65 
            // 0100 0111
            // 0100 1111
            // 0100 1111 // OR
            // 0100 0111 // AND
            // 0000 1000 // XOR
            // 0100 1111
            // 0100 0111 // XOR
            //
            // 1111 1111
            // 0000 0000 
            myIPs.Add("Yahoo", "226.58.203.132");
            myIPs.Add("Microsoft", "196.58.203.132");
            myIPs.Add("Apple", "10.58.203.132");
            myIPs.Add("Netflix", "16.58.203.132");

            Console.WriteLine("THere are " + myIPs.Count + "IP Addresses");

            Console.WriteLine("The IP address of holosuit is " + myIPs.Item("HoloSuit"));
            myIPs.CopyTo(ips, 0);
            myIPs.Clear();

            Console.WriteLine("THere are " + myIPs.Count + "IP Addresses");

            
            

            for (int i = 0; i < ips.Length; ++i) {
                Console.WriteLine(ips[i].Key + " " + ips[i].Value + " ");
            }

            KeyValuePair<string, int>[] gradeBook = new
            KeyValuePair<string, int>[10];
            gradeBook[0] = new KeyValuePair<string,
            int>("McMillan", 99);
            gradeBook[1] = new KeyValuePair<string,
            int>("Ruff", 64);
            for (int i = 0; i <= gradeBook.GetUpperBound(0); i++)
                if (gradeBook[i].Value != 0)
                    Console.WriteLine(gradeBook[i].Key + ": " +
                    gradeBook[i].Value);
            //Console.Read();


            SortedList myips = new SortedList();
            myips.Add("Mike", "192.155.12.1");
            myips.Add("David", "192.155.12.2");
            myips.Add("Bernica", "192.155.12.3");
            for (int i = 0; i < myips.Count; ++i) {
                Console.WriteLine("Name " + myips.GetKey(i) + "\n" + " IP: " + myips.GetByIndex(i));
            }

        }
    }
}
