using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using static ConsoleApp1.Program;

/*
 * 00000000b        0d  (bytes)
 * 00000001b        1d   
 * 00000010b        2d
 * 00000011b        3d
 * 00000100b        4d
 * 00000101b        5d
 * 00000110b        6d
 * 00000111b        7d
 * 00001000b        8d
 * 00001001b        9d
 * 
 * 
 * 00101010b       0 + 2^1 + 0 + 2^3 + 0 + 2^5 + 0 + 0 =  0 + 2 + 0 + 8 + 0 + 32 + 0 + 0 = 42
 * 11111111b = 1 + 2 + 4 + 8 + 16 + 32 + 64 + 128 = 255
 * 00000001 00000000b (unsigned short)
 * 11111111 
 * 
 *  00000001 And 00000000 -> 00000000
    00000001 And 00000001 -> 00000001
    00000010 And 00000001 -> 00000000

    00000000 Or 00000001 -> 00000001
    00000001 Or 00000000 -> 00000001
    00000010 Or 00000001 -> 00000011

    00000000 Xor 00000001 -> 00000001
    00000001 Xor 00000000 -> 00000001
    00000001 Xor 00000001 -> 00000000


    1b << 1            = 10b = 2d
    10b >> 1           = 1b = 1d
    11b << 1          = 110b = 6d
    110b >> 1          = 11b = 3d

    BitArray BitSet = new BitArray(32);
    BitArray BitSet = new BitArray(32, True);

    byte[] ByteSet = new byte[] {1, 2, 3, 4, 5};
    BitArray BitSet = new BitArray(ByteSet);

    True False False False False False False False
    0 0 0 0 0 0 0 1
 */


namespace ConsoleApp1 {
    class PrimeNumber {

        static void Main() {
           int size = 100;
           CArray primes = new CArray(size - 1);
           for (int i = 0; i < size - 1; i++)
               primes.Insert(1);
           primes.GenPrimes();
           primes.ShowPrimes();
        }
    }

    class BitTesting {
        //static void Main() {
        //    //byte[] ByteSet = new byte[] { 1, 2, 3, 4, 5 };
        //    //BitArray bitSet = new BitArray(ByteSet);
        //    //for (int bits = 0; bits <= bitSet.Count - 1; bits++)
        //    //    Console.Write(bitSet.Get(bits) + " ");

        //    int bits;
        //    string[] binNumber = new string[8];
        //    int binary;
        //    byte[] ByteSet = new byte[] { 1, 2, 3, 4, 5 };
        //    BitArray BitSet = new BitArray(ByteSet);
        //    bits = 0;
        //    binary = 7;
        //    for (int i = 0; i <= BitSet.Count - 1; i++) {
        //        if (BitSet.Get(i) == true)
        //            binNumber[binary] = "1";
        //        else
        //            binNumber[binary] = "0";
        //        bits++;
        //        binary--;
        //        if ((bits % 8) == 0) {
        //            binary = 7;
        //            bits = 0;
        //            for (int j = 0; j <= 7; j++)
        //                Console.Write(binNumber[j]);
        //        }
        //    }
        //}
    }
}
