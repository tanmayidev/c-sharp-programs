using System;

//72 54 59 30 31 78 2 77 82 72
// min element 2
// 2 54 59 30 31 78 72 77 82 72
// 2 30 59 54 31 78 72 77 82 72
// 2 30 31 54 59 78 72 77 82 72

//72 54 59 30 31 78 2 77 82 72
//72                        54 59 30 31 78 2 77 82 72
//54 72                     59 30 31 78 2 77 82 72  
//54 59 72                  30 31 78 2 77 82 72 
//30 54 59 72               31 78 2 77 82 72 
//30 31 54 59 72            78 2 77 82 72 
//30 31 54 59 72 78         2 77 82 72
//2 30 31 54 59 72 78       77 82 72
//2 30 31 54 59 72 77 78    82 72
//2 30 31 54 59 72 77 78 82 72
//2 30 31 54 59 72 72 77 78 82


//54 72 59 30 31 78 2 77 82 72


namespace SortAndSearch {
    class Program {
        public class CArray {
            private int[] arr;
            private int upper;
            private int numElements;
            public CArray(int size) {
                arr = new int[size];
                upper = size - 1;
                numElements = 0;
            }
            public void Insert(int item) {
                arr[numElements] = item;
                numElements++;
            }
            public void DisplayElements() {
                for (int i = 0; i <= upper; i++)
                    Console.Write(arr[i] + " ");

                Console.WriteLine();
            }
            public void Clear() {
                for (int i = 0; i <= upper; i++)
                    arr[i] = 0;
                numElements = 0;
            }
            public int RbinSearch(int value, int lower, int upper) {
                if (lower > upper)
                    return -1;
                else {
                    int mid;
                    mid = (int)(upper + lower) / 2;
                    if (value < arr[mid])
                        return RbinSearch(value, lower, mid - 1);
                    else if (value == arr[mid])
                        return mid;
                    else
                        return RbinSearch(value, mid + 1, upper);
                }                
            }
            public int binSearch(int value) {
                int upperBound, lowerBound, mid;
                upperBound = arr.Length - 1;
                lowerBound = 0;
                while (lowerBound <= upperBound) {
                    mid = (upperBound + lowerBound) / 2;
                    if (arr[mid] == value)
                        return mid;
                    else
                    if (value < arr[mid])
                        upperBound = mid - 1;
                    else
                        lowerBound = mid + 1;
                }
                return -1;
            }
            public void BubbleSort() {
                int temp;
                for (int outer = upper; outer >= 1; outer--) {
                    for (int inner = 0; inner <= outer - 1; inner++)
                        if ((int)arr[inner] > arr[inner + 1]) {
                            temp = arr[inner];
                            arr[inner] = arr[inner + 1];
                            arr[inner + 1] = temp;
                        }
                    //this.DisplayElements();
                }
               
            }

            public void SelectionSort() {
                int min, temp;
                for (int outer = 0; outer <= upper; outer++) {
                    min = outer;
                    for (int inner = outer + 1; inner <= upper; inner++)
                        if (arr[inner] < arr[min])
                            min = inner;
                    temp = arr[outer];
                    arr[outer] = arr[min];
                    arr[min] = temp;
                    //this.DisplayElements();
                }
            }

            public void InsertionSort() {
                int inner, temp;
                for (int outer = 1; outer <= upper; outer++) {
                    temp = arr[outer];
                    inner = outer;
                    while (inner > 0 && arr[inner - 1] >= temp) {
                        arr[inner] = arr[inner - 1];
                        inner -= 1;
                    }
                    arr[inner] = temp;
                    //this.DisplayElements();
                }
            }
            public void GenPrimes() {
                int temp;
                for (int outer = 2; outer <= arr.GetUpperBound(0); outer++)
                    for (int inner = outer + 1; inner <= arr.GetUpperBound(0); inner++)
                        if (arr[inner] == 1)
                            if ((inner % outer) == 0)
                                arr[inner] = 0;

                /*
                 * int desired = 8;
                 * for (int outer = 2; outer <= desired/2; outer++)  
                 * {                       
                            if ((desired % outer) == 0)
                                return false
                    }
                    return true;
                 */
            }
            public void ShowPrimes() {
                for (int i = 2; i <= arr.GetUpperBound(0); i++)
                    if (arr[i] == 1)
                        Console.Write(i + " ");
            }

        }

        //static void Main(string[] args) {
        //    Random random = new Random(100);
        //    CArray mynums = new CArray(9);
        //    for (int i = 0; i < 9; i++)
        //        mynums.Insert(random.Next(100));
        //    mynums.InsertionSort();
        //    mynums.DisplayElements();
        //    //int position = mynums.binSearch(34);
        //    int position = mynums.RbinSearch(34, 0, 8);
        //    if (position > -1) {
        //        Console.WriteLine("found item");
        //        mynums.DisplayElements();
        //    } else
        //        Console.WriteLine("Not in the array");
        //    Console.Read();
        //}

        static void Main() {
           //CArray nums = new CArray(10);
           //Random rnd = new Random(100);
           //for (int i = 0; i < 10; i++)
           //    nums.Insert((int)(rnd.NextDouble() * 100));
           //Console.WriteLine("Before sorting: \n");
           //nums.DisplayElements();
           //Console.WriteLine("During sorting: \n");
           ////nums.BubbleSort();
           ////nums.SelectionSort();
           //nums.InsertionSort();
           //Console.WriteLine("After sorting: \n");
           //nums.DisplayElements();
           Timing sortTime = new Timing();
           Random rnd = new Random(100);
           int numItems = 10000;
           CArray theArray = new CArray(numItems);
           for (int i = 0; i < numItems; i++)
               theArray.Insert((int)(rnd.NextDouble() * 100));
           sortTime.startTime();
           theArray.SelectionSort();
           sortTime.stopTime();
           Console.WriteLine("Time for Selection sort: " +
           sortTime.Result().TotalMilliseconds) ;
           theArray.Clear();
           for (int i = 0; i < numItems; i++)
               theArray.Insert((int)(rnd.NextDouble() * 100));
           sortTime.startTime();
           theArray.BubbleSort();
           sortTime.stopTime();
           Console.WriteLine("Time for Bubble sort: " +
           sortTime.Result().
           TotalMilliseconds);
           theArray.Clear();
           for (int i = 0; i < numItems; i++)
               theArray.Insert((int)(rnd.NextDouble() * 100));
           sortTime.startTime();
           theArray.InsertionSort();
           sortTime.stopTime();
           Console.WriteLine("Time for Insertion sort: " +
           sortTime.Result().
           TotalMilliseconds);
        }


    }
}
