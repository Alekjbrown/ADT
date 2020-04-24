using System;

namespace SearchingSortingLabBrown
{
    class Program
    {
        static void Main(string[] args)
        {
            const int ARRAY_SIZE = 100;
            int[] myValues = new int[ARRAY_SIZE];
            Random r = new Random();
            const int FIND = 32;

            for (int i = 0; i < myValues.Length; i++)
            {
                myValues[i] = r.Next(1, 100);
            }

            Console.WriteLine(search(FIND, myValues));

            SelectionSort(myValues);

        }


        //0(n) long processing times
        static bool search(int valueToFind, int[] arrayToSearch)
        {
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

        //assumes already sorted array
        //start in middle and check low
        //if not found start in middle of high and split
        //if not found in low of high
        //check high etc..
        //BinarySearch method searches for specific item in array from center of array (must be sorted to function correctly)
        //O(log n)
        public static int BinarySearch(int[] iArray, int value)
        {
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
    }
}
