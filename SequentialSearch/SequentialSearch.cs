using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SequentialSearch
{
     class SequentialSearch {
        static void Main() {
           int[] numbers = new int[72];
           StreamReader numFile =  File.OpenText("input.txt");
           for (int i = 0; i < numbers.Length-1; i++)
               numbers[i] = Convert.ToInt32(numFile.ReadLine(), 10);
            
            int searchNumber;
           for (int i = 0; i < 100; i++) {   
               Console.Write("Enter a number to search for: ");
               searchNumber = Convert.ToInt32(Console.ReadLine(),10);

               int foundAt;
               foundAt = SeqSearch(numbers, searchNumber);
               if (foundAt >= 0)
                   Console.WriteLine(searchNumber + " is in the array at position " + foundAt);
               else
                   Console.WriteLine(searchNumber + " is not in the array.");
           }

           //SEARCHING FOR MINIMUM AND MAXIMUM VALUES 
           int min = FindMin(numbers);
           Console.WriteLine("Min element is " + min);
           int max = FindMax(numbers);
           Console.WriteLine("Max element is " + max);

        }

        /*FUNTION 1 - THE FUNCTION RETURNS THE POSITION IN THE ARRAY 
                    WHERE THE SEARCHED-FOR VALUE IS FOUND OR A -1 IF 
                    THE VALUE CANNOT BE FOUND**/
        // static int SeqSearch(int[] arr, int sValue) {
        //     for (int index = 0; index < arr.Length-1; index++)
        //         return index;
        //     return -1;
        // }

        /*FUNCTION 2 - SELF-ORGANIZINF DATA
                WE MINIMIZE THE SEARCH TIMES BY PUTTING FREQUENTLY SEARCHED-FOR
                ITEMS AT THE BEGINNING OF THE DATA SET
                
                PROBABILITY DISTRIBUTION - PARETO DISTRIBUTIONS - "80-20 RULE"
                A DATA ITEM IS RELOCATED TO THE BEGINNING OF THE DATA SET ONLY 
                IF ITS LOCATION IS OUTSIDE THE FIRST 20% OF THE ITEMS IN THE 
                DATA SET 
        **/
        static void swap (int[] arr, int item1, int item2) {
            int temp = arr[item1];
            arr[item1] = arr[item2];
            arr[item2] = temp; 
        }
        static int SeqSearch(int[] arr, int sValue) {
            for (int index = 0; index < arr.Length-1 ; index++) {
                if (arr[index] == sValue && index > (arr.Length * 0.2)) {
                    swap(arr, index, index - 1);
                    return index;
                } else if (arr[index] == sValue) {
                    return index;
                }
            }
            return -1;
        }

        /*FUNCTION 3 - THIS METHOD SWAPS A FOUND ITEM WITH THE ELEMENT 
                THAT PRECEDES IT IN THE DATA SET. 
                THIS TECHNIQUE GAURANTEES THAT IF AN ITEM IS ALREADY AT 
                THE BEGINNING OF THE DATA SET, IT WON'T MOVE BACK DOWN 
        **/
        // static int SeqSearch(int[] arr, int sValue) {
        //     for (int index = 0; index < arr.Length-1; index++)
        //         if (arr[index] == sValue) {
        //             swap (arr, index, index-1);
        //         return index;
        //         }
        //     return -1;
        // }

        
        static int FindMin(int[] arr) {
            int min = arr[0];
            for (int index = 0; index < arr.Length-1; index++)
                if (arr[index] < min)
                    min = arr[index];
            return min;
        }

        static int FindMax(int[] arr) {
            int max = arr[0];
            for (int index = 0; index < arr.Length-1; index++)
                if (arr[index] > max)
                    max = arr[index];
            return max;
        }
    }
}
