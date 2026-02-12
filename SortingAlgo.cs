using DSARoadmap.Common.CommonServices;

namespace DSARoadmap.SortingAlgorithms
{
    public class SortingAlgo
    {
        #region Variables
        private readonly CommonServices commonServices;
        #endregion

        #region Constructor
        public SortingAlgo(CommonServices _commonServices)
        {
            commonServices = _commonServices;
            commonServices.WriteArray(bubbleSortAlgo(new int[] { 64, 34, 25, 12, 22, 11, 90 }), "Sorted Array: ");
            commonServices.WriteArray(selectionSortAlgo(new int[] { 64, 25, 12, 22, 11 }), "Sorted Array: ");
        }
        #endregion

        #region Bubble Sort
        public int[] bubbleSortAlgo(int[] inputArray)
        {
            Console.WriteLine("Bubble Sort:");
            commonServices.WriteArray(inputArray, "Unsorted Array: ");
            //Console.WriteLine("Unsorted Array: [ " + string.Join(", ", inputArray) + " ]");

            int length = inputArray.Length;
            int swap;
            int rounds = 0;
            bool sorted = false;

            while(!sorted)
            {
                // set sorted to true at the start, so if it swap the array values then it will change to false if not array is sorted.
                sorted = true;

                // length = number of values in the array
                // - 1 = no need to check and swap the last value of a array so we use -1
                // - rounds = each time when one loop is completed we increment rounds variable that means there is the last element is sorted so we can skip that index.
                for (int i = 0; i < length - 1 - rounds; i++)
                {
                    if (inputArray[i] > inputArray[i + 1]) // if the value of index i > i + 1 then swap and set sorted = false else skip the if condition
                    {
                        swap = inputArray[i];
                        inputArray[i] = inputArray[i + 1];
                        inputArray[i + 1] = swap;

                        sorted = false;
                    }
                }
                commonServices.WriteArray(inputArray, $"Array after round {rounds + 1}: ");
                rounds++; // increment rounds variable on each for loop completion
            }

            return inputArray;
            //commonServices.WriteArray(inputArray, "Sorted Array: ");
            //Console.WriteLine($"Sorted Array: [ {string.Join(", ", inputArray)} ]");
        }
        #endregion

        #region Selection Sort
        public int[] selectionSortAlgo(int[] inputArray)
        {
            Console.WriteLine("Selection Sort:");
            commonServices.WriteArray(inputArray, "Unsorted Array: ");
            //Console.WriteLine("Unsorted Array: [ " + string.Join(", ", inputArray) + " ]");

            int length = inputArray.Length; // to find length of an array
            int swap; // to swap posMin value
            int posMin; // to store pos of min value in a array

            for (int i = 0; i < length; i++)
            {
                posMin = i; // considering the index 0 is the min
                for (int j = i + 1; j < length; j++) // checking the i element with i + 1 to end of the array
                {
                    if (inputArray[posMin] > inputArray[j]) // if index of posMin > j then update the posMin with the index.
                    {
                        posMin = j;
                    }
                }
                // after finding the index of min value swap it with the i index
                swap = inputArray[posMin];
                inputArray[posMin] = inputArray[i];
                inputArray[i] = swap;
                commonServices.WriteArray(inputArray, $"Swapped Position in Array: {i} and {posMin} Array after swap: ");
                //Console.WriteLine($"Swapped Position in Array: {i} and {posMin} Array after swap: [ {string.Join(", ", inputArray)} ]");
            }

            return inputArray;
            //commonServices.WriteArray(inputArray, "Sorted Array: ");
            //Console.WriteLine($"Sorted Array: [ {string.Join(", ", inputArray)} ]");
        }
        #endregion

        #region

        #endregion
    }
}
