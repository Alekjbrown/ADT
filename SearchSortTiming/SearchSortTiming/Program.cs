using System;
using System.Diagnostics;

namespace SearchSortTiming
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            Random r = new Random();
            const int SIZE1 = 10000;
            const int SIZE2 = 100000;
            int[] intArray1 = new int[SIZE1];
            int[] intArray2 = new int[SIZE1];
            int[] intArray3 = new int[SIZE2];
            int[] intArray4 = new int[SIZE2];
            int[] intArray5 = new int[SIZE1];
            int[] intArray6 = new int[SIZE2];

            const int FIND = 32;

            for (int i = 0; i < intArray1.Length; i++)
            {
                intArray1[i] = r.Next(1, 100);
                intArray2[i] = intArray1[i];
                intArray5[i] = intArray1[i];
            }
            for (int i = 0; i < intArray3.Length; i++)
            {
                intArray3[i] = r.Next(1, 100);
                intArray4[i] = intArray3[i];
                intArray6[i] = intArray3[i];
            }

            //all actions first array length
            Console.WriteLine(LinearSearch(FIND, intArray1));
            Console.ReadKey();
            //print array before sort
            for (int i = 0; i < intArray1.Length; i++)
            {
                Console.WriteLine(intArray1[i]);
            }
            //time and sort
            sw.Start();
            BubbleSort(intArray1);
            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);
            Console.ReadKey();
            //print after sort
            for (int i = 0; i < intArray1.Length; i++)
            {
                Console.WriteLine(intArray1[i]);
            }
            Console.WriteLine(BinarySearch(intArray1, FIND));
            Console.ReadKey();
            //selectsort starts here
            Console.WriteLine(LinearSearch(FIND, intArray2));
            Console.ReadKey();
            //print array before sort
            for (int i = 0; i < intArray2.Length; i++)
            {
                Console.WriteLine(intArray2[i]);
            }
            //time and sort
            sw.Start();
            SelectionSort(intArray2);
            sw.Stop();
            ts = sw.Elapsed;
            elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);
            Console.ReadKey();
            //print after sort
            for (int i = 0; i < intArray2.Length; i++)
            {
                Console.WriteLine(intArray2[i]);
            }
            Console.WriteLine(BinarySearch(intArray2, FIND));
            Console.ReadKey();
            //Insertion sort starts here
            Console.WriteLine(LinearSearch(FIND, intArray5));
            Console.ReadKey();
            //print array before sort
            for (int i = 0; i < intArray5.Length; i++)
            {
                Console.WriteLine(intArray5[i]);
            }
            //time and sort
            sw.Start();
            InsertionSort(intArray5);
            sw.Stop();
            ts = sw.Elapsed;
            elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);
            Console.ReadKey();
            //print after sort
            for (int i = 0; i < intArray5.Length; i++)
            {
                Console.WriteLine(intArray5[i]);
            }
            Console.WriteLine(BinarySearch(intArray5, FIND));
            Console.ReadKey();

            //all actions array size 2
            Console.WriteLine(LinearSearch(FIND, intArray3));
            Console.ReadKey();
            //print array before sort
            for (int i = 0; i < intArray3.Length; i++)
            {
                Console.WriteLine(intArray3[i]);
            }
            //time and sort
            sw.Start();
            BubbleSort(intArray3);
            sw.Stop();
            ts = sw.Elapsed;
            elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);
            Console.ReadKey();
            //print after sort
            for (int i = 0; i < intArray3.Length; i++)
            {
                Console.WriteLine(intArray3[i]);
            }
            Console.WriteLine(BinarySearch(intArray3, FIND));
            Console.ReadKey();
            //selectsort starts here
            Console.WriteLine(LinearSearch(FIND, intArray4));
            Console.ReadKey();
            //print array before sort
            for (int i = 0; i < intArray4.Length; i++)
            {
                Console.WriteLine(intArray4[i]);
            }
            //time and sort
            sw.Start();
            SelectionSort(intArray4);
            sw.Stop();
            ts = sw.Elapsed;
            elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);
            Console.ReadKey();
            //print after sort
            for (int i = 0; i < intArray4.Length; i++)
            {
                Console.WriteLine(intArray4[i]);
            }
            Console.WriteLine(BinarySearch(intArray4, FIND));
            Console.ReadKey();
            //Insertion Sort Starts HERE
            Console.WriteLine(LinearSearch(FIND, intArray6));
            Console.ReadKey();
            //print array before sort
            for (int i = 0; i < intArray6.Length; i++)
            {
                Console.WriteLine(intArray6[i]);
            }
            //time and sort
            sw.Start();
            InsertionSort(intArray6);
            sw.Stop();
            ts = sw.Elapsed;
            elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);
            Console.ReadKey();
            //print after sort
            for (int i = 0; i < intArray6.Length; i++)
            {
                Console.WriteLine(intArray6[i]);
            }
            Console.WriteLine(BinarySearch(intArray6, FIND));
            Console.ReadKey();
        }

        //0(n) long processing times
        static bool LinearSearch(int valueToFind, int[] arrayToSearch)
        {

            //Linear search searches start to finish one index at a time
            //to compare for wanted value
            //works quickly for short arrays if you dont need it sorted
            bool found = false;
            for (int i = 0; i < arrayToSearch.Length; i++)
            {
                if (arrayToSearch[i] == valueToFind)
                {
                    return true;
                }
            }

            return found;
        }


        public static int BinarySearch(int[] iArray, int value)
        {
            //assumes already sorted array
            //start in middle and check low
            //if not found start in middle of high and split
            //if not found in low of high
            //check high etc..
            //BinarySearch method searches for specific item in array from center
            //of array (must be sorted to function correctly)
            //Used for long arrays with less processing time only if sorted
            //O(log n)
            int first = 0; //First Array element
            int last = iArray.Length - 1; //Last array element
            int middle; //Midpoint of search
            int position = -1; //Position of search value
            bool found = false; //Flag

            //search for the value
            while (!found && first <= last)
            {
                //Calculate the midpoint.
                middle = (first + last) / 2;

                //If value is found at midpoint
                if (iArray[middle] == value)
                {
                    found = true;
                    position = middle;
                }
                //else if value is in lower half...
                else if (iArray[middle] > value)
                {
                    last = middle - 1;
                }
                else
                {
                    first = middle + 1;
                }
            }

            //Return the position of the item, or -1 if it was not found.
            return position;
        }

        //Bubble sort
        public static void BubbleSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
                for (int j = 0; j < n - i - 1; j++)
                    if (arr[j] > arr[j + 1])
                    {
                        // swap temp and arr[i]
                        //int temp = arr[j];
                        //arr[j] = arr[j + 1];
                        //arr[j + 1] = temp;
                        Swap(ref arr[j], ref arr[j + 1]);
                    }
        }


        //SelectionSort method accepts an int array as an argument.
        //It uses the SelectionSor algorithm to sort the array.
        public static void SelectionSort(int[] iArray)
        {
            int minIndex; //Subscript of smallest value in scanned area
            int minValue; //smallest value in the scanned area

            //The outer loop steps through all the array elements except the last one.
            //The startScan variable marks the position where the scan should begin
            for (int startScan = 0; startScan < iArray.Length - 1; startScan++)
            {
                //Assume the first element in the scannable area is the smallest value.
                minIndex = startScan;
                minValue = iArray[startScan];

                //scan the array, starting at the 2nd element in the scannable area
                //looking for the smalles value
                for (int index = startScan + 1; index < iArray.Length; index++)
                {
                    if (iArray[index] < minValue)
                    {
                        minValue = iArray[index];
                        minIndex = index;
                    }
                }

                //Swap the element with the smallest value with the first element in the scannable area
                Swap(ref iArray[minIndex], ref iArray[startScan]);
            }
        }
        //The Swap method accepts two integer arguments, by reference, and swaps their contents
        public static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        public static void InsertionSort(int[] arr)
        {
            //builds array sorted one at a time
            //inefficient for large arrays
            int j, temp;
            for (int i = 1; i <= arr.Length - 1; i++)
            {
                temp = arr[i];
                j = i - 1;
                while (j >= 0 && arr[j] > temp)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = temp;
            }
        }
    }
}
