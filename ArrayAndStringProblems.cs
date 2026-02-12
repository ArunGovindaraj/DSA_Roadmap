using DSARoadmap.Common.CommonServices;
using DSARoadmap.SortingAlgorithms;
using System.Globalization;
using System.Text;
using System.Transactions;

namespace DSARoadmap.ArrayAndStringProblems
{
    /// <summary>
    /// Represents a node in a binary tree, containing an integer value and references to left and right child nodes.
    /// </summary>
    /// <remarks>TreeNode is commonly used to construct binary trees for algorithms such as traversal, search,
    /// and manipulation. The left and right fields may be null if the node does not have the corresponding
    /// child.</remarks>
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class ArrayAndStringProblems
    {
        #region Variables
        private readonly CommonServices commonServices;
        private int[] emptyArray = new int[0];
        private int[] inputArrayForMinAndMax = new int[] { 3, 5, 1, 8, -2, 7 };
        private int[] inputArrayWithZeros = new int[] { 0, 1, 0, 3, 12, 0, 5 };
        #endregion

        #region Constructor
        public ArrayAndStringProblems(CommonServices _commonServices)
        {
            commonServices = _commonServices;
            Console.WriteLine("Array and String Problems Initialized");
            int maxValue = FindMaxInArray(inputArrayForMinAndMax);
            Console.WriteLine(maxValue.ToString());
            int minValue = FindMinInArray(inputArrayForMinAndMax);
            Console.WriteLine(minValue.ToString());
            int[] minAndMaxValue = FindMinAndMaxInArray(inputArrayForMinAndMax);
            commonServices.WriteArray(minAndMaxValue, "Min and Max Values: ");
            commonServices.WriteArray(inputArrayForMinAndMax, "Original Array: ");
            commonServices.WriteArray(ReverseAnArrayByBruteForce(inputArrayForMinAndMax), "Reversed Array: ");
            commonServices.WriteArray(inputArrayWithZeros, "Array with Zeros: ");
            commonServices.WriteArray(MoveZerosToEndInArrayByBruteForce(inputArrayWithZeros), "Array with Zeros Moved to End by Brute Force Method: ");
            commonServices.WriteArray(MoveZerosToEndInArrayInPlace(inputArrayWithZeros), "Array with Zeros Moved to End In-Place Method: ");
            commonServices.WriteArray(ApplyOperationToArrayAndMoveZerosToEnd(new int[] { 2, 2, 0, 4, 4, 8 }), "Array after Applying Operation and Moving Zeros to End: ");
            TreeNode bstRoot = SortedArrayToBST(new int[] { -10, -3, 0, 5, 9 });
            if (bstRoot != null)
            {
                // Helper method to get BST values in-order for display
                var bstValues = GetInOrderTraversal(bstRoot);
                commonServices.WriteArray(bstValues, "BST from Sorted Array (In-Order): ");
            }
            else
            {
                commonServices.WriteArray(Array.Empty<int>(), "BST from Sorted Array (In-Order): ");
            }
            var inputString = "racecar";
            var inputStringForIgnoreCaseAndNonAlphanumeric = "Rac!ecar";
            Console.WriteLine(IsStringPalindrome(inputString) == true ? inputString + " - String is a palindrome": inputString + " - String is not a palindrome");
            Console.WriteLine(IsStringPalindromeIgnoreCaseAndNonAlphanumeric(inputStringForIgnoreCaseAndNonAlphanumeric) == true ? inputStringForIgnoreCaseAndNonAlphanumeric + " - String is a palindrome ignoring case and non-alphanumeric": inputStringForIgnoreCaseAndNonAlphanumeric + " - String is not a palindrome ignoring case and non-alphanumeric");
            Console.WriteLine(SearchInsertPosition(new int[] { 1,3,6,7,8 }, 5));
            commonServices.WriteArray(FindWordsContaining(new string[] { "apple", "banana", "cherry", "date" }, 'a'), "Words Containing 'a': ");
            commonServices.WriteArray(SummaryRanges(new int[] { 0,1,2,4,5,7 }), "Summary Ranges: ");
            Console.WriteLine("Missing Number is: " + MissingNumber(new int[] { 3,0,1 })); 
            Console.WriteLine("Duplicate Number is: " + FindDuplicateNumber(new int[] { 1,3,4,2,2 }));
            commonServices.PrintDictionary<char, int>(CountOccurrences("hello world"), (key, value) => $"Character: {key}, Occurrences: {value}");
            Console.WriteLine("String after removing duplicates: " + RemoveDuplicates("hello world"));
            Console.WriteLine("Reversed Words in Sentence: " + ReverseWords("Hello World from DSA Roadmap"));
            Console.WriteLine("First Non-Repeating Character: " + FirstNonRepeatingChar("leetcode"));
            commonServices.PrintDictionary<int, int>(FrequencyInIntegerArray(new int[] { 1,2,2,3,3,3 }), (key, value) => $"Number: {key}, Frequency: {value}");
            Console.WriteLine("Missing Number using Formula: " + FindMissingNumberUsingFormula(new int[] { 1,3,4 }));
            Console.WriteLine("2nd Largest Element: " + FindNthLargest(new int[] { 3,1,2,5,4 }, 2));
            commonServices.WriteArray(RemoveDuplicatesIntegerArray(new int[] { 1,2,2,3,4,4,5 }), "Array after Removing Duplicates: ");
            commonServices.WriteArray(SortAndRemoveDuplicateIntegerArray(new int[] { 6,9,1,2,2,3,4,4,5,10,11,40 }), "Sorted Array after Removing Duplicates: ");
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Finds and returns the maximum value in the specified integer array.
        /// </summary>
        /// <param name="arr">The array of integers to search. Cannot be null or empty.</param>
        /// <returns>The largest integer value found in the array.</returns>
        /// <exception cref="ArgumentException">Thrown if the array is null or empty.</exception>
        public int FindMaxInArray(int[] arr)
        {
            try
            {
                if (arr == null || arr.Length == 0)
                    throw new ArgumentException("Array cannot be null or empty", nameof(arr));

                int max = arr[0];

                foreach (var num in arr)
                {
                    if (num > max)
                        max = num;
                }

                return max;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Finds and returns the minimum value in the specified integer array.
        /// </summary>
        /// <param name="arr">The array of integers to search for the minimum value. Cannot be null or empty.</param>
        /// <returns>The smallest integer value found in the array.</returns>
        /// <exception cref="ArgumentException">Thrown if the input array is null or empty.</exception>
        public int FindMinInArray(int[] arr)
        {
            try
            {
                if (arr == null || arr.Length == 0)
                    throw new ArgumentException("Array cannot be null or empty", nameof(arr));

                int min = arr[0];

                foreach (var num in arr)
                {
                    if (num < min)
                        min = num;
                }

                return min;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Finds the minimum and maximum values in the specified integer array.
        /// </summary>
        /// <param name="arr">The array of integers to search. Cannot be null or empty.</param>
        /// <returns>An array of two integers, where the first element is the minimum value and the second element is the maximum
        /// value found in the input array.</returns>
        /// <exception cref="ArgumentException">Thrown if the input array is null or empty.</exception>
        public int[] FindMinAndMaxInArray(int[] arr)
        {
            try
            {
                if (arr == null || arr.Length == 0)
                    throw new ArgumentException("Array cannot be null or empty", nameof(arr));

                int min = arr[0];
                int max = arr[0];

                foreach (var num in arr)
                {
                    if (num < min)
                        min = num;
                    if (num > max)
                        max = num;
                }
                return new int[] { min, max };
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Returns a new array containing the elements of the input array in reverse order.    
        /// </summary>
        /// <remarks>The original array is not modified. The returned array has the same length as the
        /// input array.</remarks>
        /// <param name="arr">The array of integers to reverse. Cannot be null.</param>
        /// <returns>A new array with the elements of <paramref name="arr"/> in reverse order.</returns>
        public int[] ReverseAnArrayByBruteForce(int[] arr)
        {
            int index = 0;
            int[] outputReversedArray = new int[arr.Length];

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                outputReversedArray[index] = arr[i];
                index++;
            }

            return outputReversedArray;
        }

        /// <summary>
        /// Reverses the elements of the specified array in place.
        /// </summary>
        /// <remarks>The method modifies the input array directly and also returns it for convenience. The
        /// original order of elements in the array is lost after this operation.</remarks>
        /// <param name="arr">The array of integers to reverse. Cannot be null.</param>
        /// <returns>The same array instance with its elements reversed.</returns>
        public int[] RevereseAnArrayInPlace(int[] arr)
        {
            int start = 0;
            int end = arr.Length - 1;
            int swap;

            while (start < end)
            {
                swap = arr[start];
                arr[start] = arr[end];
                arr[end] = swap;
                start++;
                end--;
            }
            return arr;
        }

        /// <summary>
        /// Determines whether the elements of the specified array are sorted in non-decreasing order.
        /// </summary>
        /// <param name="arr">The array of integers to check for sorted order. Cannot be null.</param>
        /// <returns>true if the elements in the array are in non-decreasing order; otherwise, false.</returns>
        public bool CheckIfArraySorted(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] > arr[i + 1])
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Moves all zero values in the specified array to the end, preserving the order of non-zero elements.
        /// </summary>
        /// <remarks>This method does not modify the input array. The operation is performed using a
        /// brute-force approach, which may be less efficient for large arrays.</remarks>
        /// <param name="arr">The array of integers to process. Cannot be null.</param>
        /// <returns>A new array containing the same elements as <paramref name="arr"/>, with all zeros moved to the end. The
        /// relative order of non-zero elements is maintained.</returns>
        public int[] MoveZerosToEndInArrayByBruteForce(int[] arr)
        {
            int[] outputArray = new int[arr.Length];
            int zerosAddedCount = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != 0)
                {
                    outputArray[i - zerosAddedCount] = arr[i];
                }
                else
                {
                    outputArray[arr.Length - 1 - zerosAddedCount] = arr[i];
                    zerosAddedCount++;
                }
            }

            return outputArray;
        }

        /// <summary>
        /// Moves all zero values in the specified array to the end while preserving the order of non-zero elements. The
        /// operation is performed in place.
        /// </summary>
        /// <remarks>This method modifies the input array directly and does not allocate a new array. If
        /// the array contains no zeros, its contents remain unchanged.</remarks>
        /// <param name="arr">The array of integers to be modified. Cannot be null.</param>
        /// <returns>The same array instance with all zeros moved to the end. The relative order of non-zero elements is
        /// preserved.</returns>
        public int[] MoveZerosToEndInArrayInPlace(int[] arr)
        {
            int nonZeroIndex = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != 0)
                {
                    arr[nonZeroIndex] = arr[i];
                    nonZeroIndex++;
                }
            }

            for (int i = nonZeroIndex; i < arr.Length; i++)
            {
                arr[i] = 0;
            }

            return arr;
        }

        /// <summary>
        /// Applies a merge operation to adjacent equal elements in the specified array and moves all zeros to the end
        /// of the array.
        /// </summary>
        /// <remarks>For each pair of adjacent equal elements, the first element is doubled and the second
        /// is set to zero. After processing, all nonzero elements retain their relative order, and all zeros are
        /// shifted to the end of the array. The input array is modified directly.</remarks>
        /// <param name="nums">The array of integers to process. Adjacent equal elements are merged, and zeros are moved to the end. Cannot
        /// be null.</param>
        /// <returns>The modified array after merging adjacent equal elements and moving all zeros to the end. The operation is
        /// performed in-place, and the same array instance is returned.</returns>
        public int[] ApplyOperationToArrayAndMoveZerosToEnd(int[] nums)
        {
            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] == nums[i + 1])
                {
                    nums[i] = nums[i] * 2;
                    nums[i + 1] = 0;
                    i++; // Skip the next element as it's already processed
                }
            }

            int nonZeroCount = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    nums[nonZeroCount] = nums[i];
                    nonZeroCount++;
                }
            }

            for (int i = nonZeroCount; i < nums.Length; i++)
            {
                nums[i] = 0;
            }

            return nums;
        }

        /// <summary>
        /// Converts a sorted array of integers to a height-balanced binary search tree (BST).
        /// </summary>
        /// <remarks>A height-balanced BST is defined as a binary tree in which the depth of the two
        /// subtrees of every node never differs by more than one. The resulting tree preserves the in-order sequence of
        /// the input array.</remarks>
        /// <param name="nums">An array of integers sorted in ascending order. Cannot be null or empty.</param>
        /// <returns>The root node of the height-balanced BST constructed from the input array, or null if the array is null or
        /// empty.</returns>
        public TreeNode SortedArrayToBST(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return null;

            return BuildBST(nums, 0, nums.Length - 1);
        }

        /// <summary>
        /// Performs a check to determine if the given string is a palindrome.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public bool IsStringPalindrome(string str)
        {
            int left = 0;
            int right = str.Length - 1;
            while (left < right)
            {
                if (str[left] != str[right])
                    return false;
                left++;
                right--;
            }
            return true;
        }

        /// <summary>
        /// Performs a check to determine if the given string is a palindrome, ignoring case and non-alphanumeric characters.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public bool IsStringPalindromeIgnoreCaseAndNonAlphanumeric(string str)
        {
            int left = 0;
            int right = str.Length - 1;
            while (left < right)
            {
                while (left < right && !char.IsLetterOrDigit(str[left]))
                    left++;
                while (left < right && !char.IsLetterOrDigit(str[right]))
                    right--;
                if (char.ToLower(str[left]) != char.ToLower(str[right]))
                    return false;
                left++;
                right--;
            }
            return true;
        }

        /// <summary>
        /// To find the index at which the target value should be inserted in the sorted array.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int SearchInsertPosition(int[] num, int target)
        {
            int left = 0;
            int right = num.Length - 1;

            while(left <= right)
            {
                int mid = left + (right - left) / 2; // To find mid index and shift the left and right pointers accordingly

                if (num[mid] == target)
                    return mid;
                else if(num[mid] < target)
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            return left;            
        }

        /// <summary>
        /// This method finds all indices of words in the given array that contain the specified character.
        /// </summary>
        /// <param name="words"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public IList<int> FindWordsContaining(string[] words, char x)
        {
            List<int> result = new List<int>();

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Contains(x))
                {
                    result.Add(i);
                }
            }

            return result;
        }

        /// <summary>
        /// This method summarizes consecutive ranges in a sorted integer array.
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<string> SummaryRanges(int[] nums)
        {
            List<string> result = new List<string>();

            if (nums.Length == 0)
                return result;

            int start = nums[0];

            for (int i = 1; i <= nums.Length; i++)
            {
                // End of array OR break in continuity
                if (i == nums.Length || nums[i] != nums[i - 1] + 1)
                {
                    int end = nums[i - 1];

                    if (start == end)
                        result.Add(start.ToString());
                    else
                        result.Add(start + "->" + end);

                    // Start a new range
                    if (i < nums.Length)
                        start = nums[i];
                }
            }

            return result;
        }

        /// <summary>
        /// This method finds the missing number in an array containing n distinct numbers from the range 0 to n.
        /// Using the formula for the sum of the first n natural numbers.
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MissingNumber(int[] nums)
        {
            // Using the formula for the sum of the first n natural numbers: n * (n + 1) / 2
            int n = nums.Length;
            int expectedSum = n * (n + 1) / 2;
            int actualSum = 0;
            foreach (int num in nums)
            {
                actualSum += num;
            }
            return expectedSum - actualSum;
        }

        /// <summary>
        /// This method finds the duplicate number in an array containing n + 1 integers where each integer is between 1 and n (inclusive).
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindDuplicateNumber(int[] nums)
        {
            // Floyd's Tortoise and Hare (Cycle Detection) algorithm
            int tortoise = nums[0];
            int hare = nums[0];

            // Phase 1: Finding the intersection point in the cycle
            do
            {
                tortoise = nums[tortoise];
                hare = nums[nums[hare]];
            } while (tortoise != hare);

            // Phase 2: Finding the entrance to the cycle
            tortoise = nums[0];
            while (tortoise != hare)
            {
                tortoise = nums[tortoise];
                hare = nums[hare];
            }

            return hare;
        }

        /// <summary>
        /// This method counts the occurrences of each character in the given string.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public Dictionary<char, int> CountOccurrences(string str)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            foreach (char c in str)
            {
                if (dict.ContainsKey(c))
                    dict[c]++;
                else
                    dict[c] = 1;
            }

            return dict;
        }

        /// <summary>
        /// This method removes duplicate characters from the given string, preserving the order of first occurrences.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string RemoveDuplicates(string str)
        {
            HashSet<char> seen = new HashSet<char>();
            StringBuilder result = new StringBuilder();

            foreach (char c in str)
            {
                if (!seen.Contains(c))
                {
                    seen.Add(c);
                    result.Append(c);
                }
            }

            return result.ToString();
        }

        /// <summary>
        /// This method reverses the order of words in a given sentence while preserving the order of characters within each word.
        /// </summary>
        /// <param name="sentence"></param>
        /// <returns></returns>
        public string ReverseWords(string sentence)
        {
            string[] words = sentence
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            int left = 0, right = words.Length - 1;

            while (left < right)
            {
                string temp = words[left];
                words[left] = words[right];
                words[right] = temp;
                left++;
                right--;
            }

            return string.Join(" ", words);
        }

        /// <summary>
        /// This method finds the first non-repeating character in a given string and returns it. If all characters are repeating, it returns a null character ('\0').
        /// Count character frequencies using a dictionary, then scan the string again to find
        /// the first character with frequency one.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public char FirstNonRepeatingChar(string str)
        {
            Dictionary<char, int> freq = new Dictionary<char, int>();

            // Step 1: Count frequency of each character
            foreach (char c in str)
            {
                if (freq.ContainsKey(c))
                    freq[c]++;
                else
                    freq[c] = 1;
            }

            // Step 2: Find first character with frequency = 1
            foreach (char c in str)
            {
                if (freq[c] == 1)
                    return c;
            }

            return '\0'; // No non-repeating character
        }

        /// <summary>
        /// This method calculates the frequency of each integer in the given array and returns a dictionary mapping each integer to its frequency count.
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public Dictionary<int, int> FrequencyInIntegerArray(int[] arr)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            foreach (int num in arr)
            {
                if (dict.ContainsKey(num))
                    dict[num]++;
                else
                    dict[num] = 1;
            }
            return dict;
        }

        /// <summary>
        /// This method finds the missing number in an array containing n distinct numbers from the range 0 to n using the formula approach.
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindMissingNumberUsingFormula(int[] nums)
        {
            //int n = nums.Length + 1; // if there are n distinct numbers from 0 to n, the length of the array will be n (since one number is missing)
            int n = nums.Length; // if there are n distinct numbers from 0 to n-1, the length of the array will be n (since one number is missing)
            int expectedSum = n * (n + 1) / 2;
            int actualSum = 0;
            foreach (int num in nums)
            {
                actualSum += num;
            }
            return expectedSum - actualSum;
        }

        /// <summary>
        /// This method finds the n-th largest element in an unsorted array of integers using the Quickselect algorithm, which has an average time complexity of O(n).
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public int FindNthLargest(int[] nums, int n)
        {
            int targetIndex = nums.Length - n;
            return QuickSelect(nums, 0, nums.Length - 1, targetIndex);
        }

        /// <summary>
        /// This method removes duplicate integers from the given array while preserving the order of first occurrences. The resulting array contains only unique integers from the input array.
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int[] RemoveDuplicatesIntegerArray(int[] arr)
        {
            HashSet<int> seen = new HashSet<int>();
            List<int> result = new List<int>();
            foreach (int num in arr)
            {
                if (!seen.Contains(num))
                {
                    seen.Add(num);
                    result.Add(num);
                }
            }
            return result.ToArray();
        }

        /// <summary>
        /// This method sorts the given array of integers in ascending order and removes duplicate values, returning a new array that contains only unique integers from the input array in sorted order.
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int[] SortAndRemoveDuplicateIntegerArray(int[] arr)
        {
            SortingAlgo sortingAlgo = new SortingAlgo(commonServices);
            int[] sortedArray = sortingAlgo.bubbleSortAlgo(arr);
            int[] uniqueSortedArray = RemoveDuplicatesIntegerArray(sortedArray);

            return uniqueSortedArray;
        }
        #endregion

        #region Private Helper Methods for SortedArrayToBST
        /// <summary>
        /// Recursively constructs a height-balanced binary search tree from a sorted subarray.
        /// </summary>
        /// <remarks>The method assumes that the input array is sorted in ascending order. The resulting
        /// tree is height-balanced, with the middle element of the subarray chosen as the root at each recursive
        /// step.</remarks>
        /// <param name="nums">The sorted array of integers from which to build the binary search tree.</param>
        /// <param name="left">The starting index of the subarray to use for constructing the subtree.</param>
        /// <param name="right">The ending index of the subarray to use for constructing the subtree.</param>
        /// <returns>The root node of the constructed binary search tree for the specified subarray, or null if the subarray is
        /// empty.</returns>
        private TreeNode BuildBST(int[] nums, int left, int right)
        {
            // Base case: no elements to construct subtree
            if (left > right)
                return null;

            // Choose middle element to keep tree balanced
            int mid = left + (right - left) / 2;

            // Create root node
            TreeNode root = new TreeNode(nums[mid]);

            // Recursively build left and right subtrees
            root.left = BuildBST(nums, left, mid - 1);
            root.right = BuildBST(nums, mid + 1, right);

            return root;
        }

        /// <summary>
        /// Performs an in-order traversal of the binary tree rooted at the specified node and returns the sequence of
        /// node values.
        /// </summary>
        /// <param name="root">The root node of the binary tree to traverse. If null, the returned sequence will be empty.</param>
        /// <returns>An enumerable collection of integers representing the values of the nodes in in-order sequence. The
        /// collection is empty if the tree is empty.</returns>
        private IEnumerable<int> GetInOrderTraversal(TreeNode root)
        {
            var result = new List<int>();
            InOrder(root, result);
            return result;
        }

        /// <summary>
        /// Performs a recursive in-order traversal of the binary tree and populates the result list with node values.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="result"></param>
        private void InOrder(TreeNode node, List<int> result)
        {
            if (node == null) return;
            InOrder(node.left, result);
            result.Add(node.val);
            InOrder(node.right, result);
        }
        #endregion

        #region Private Helper Methods for FindNthLargest
        /// <summary>
        /// This method implements the Quickselect algorithm to find the k-th smallest element in an array.
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        private int QuickSelect(int[] nums, int left, int right, int k)
        {
            if (left == right)
                return nums[left];

            int pivotIndex = Partition(nums, left, right);

            if (pivotIndex == k)
                return nums[k];
            else if (pivotIndex < k)
                return QuickSelect(nums, pivotIndex + 1, right, k);
            else
                return QuickSelect(nums, left, pivotIndex - 1, k);
        }

        /// <summary>
        /// This method partitions the array around a pivot element, rearranging elements such that those less than or equal to the pivot
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        private int Partition(int[] nums, int left, int right)
        {
            int pivot = nums[right];
            int i = left;

            for (int j = left; j < right; j++)
            {
                if (nums[j] <= pivot)
                {
                    (nums[i], nums[j]) = (nums[j], nums[i]);
                    i++;
                }
            }

            (nums[i], nums[right]) = (nums[right], nums[i]);

            return i;
        }
        #endregion
    }
}
