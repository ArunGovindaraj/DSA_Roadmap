using DSARoadmap.Common.CommonServices;

namespace DSARoadmap.DSAProblemsTopicWise
{
    public class ArrayProblems
    {
        #region Variables
        private readonly CommonServices commonServices;
        #endregion

        #region Constructor
        public ArrayProblems(CommonServices _commonServices)
        {
            commonServices = _commonServices;
            Console.WriteLine("Largest Sum Contigous Subarray value: " + LargestSumContiguousSubarray(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }));
            commonServices.WriteArray(RotateArray(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 3));
            commonServices.WriteArray(MergeIntervals(new int[][] { new int[] { 1, 3 }, new int[] { 2, 6 }, new int[] { 8, 10 }, new int[] { 15, 18 } }).Select(interval => $"[{interval[0]}, {interval[1]}]"), "Merged Intervals: ");
            Console.WriteLine("Maximum Product of contigous subarray value: " + MaximumProductSubarray(new int[] { 2, 3, -2, 4 }));
            FindRepeatedAndMissingNumbers(new int[] { 1, 2, 2, 4 });
            SubarraySum(new int[] { 1, 2, 3, 4, 5 }, 9);
            Console.WriteLine("Longest Consecutive Sequence length: " + LongestConsecutive(new int[] { 100, 4, 200, 1, 3, 2 }));
            Console.WriteLine("Find Duplicate value: " + FindDuplicate(new int[] { 1, 3, 4, 2, 2 }));
            Console.WriteLine("No of times rain water trapped: " + TrappingRainWater(new int[] { 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 }));
            commonServices.WriteArray(NextPermutation(new int[] { 1, 2, 3 }), "Next Permutation: ");
        }
        #endregion

        #region Private Methods
        #region Reverse Array
        /// <summary>
        /// Reverses the elements of the specified array in place between the given start and end indices.
        /// </summary>
        /// <remarks>Only the elements between start and end, inclusive, are reversed. The original array
        /// is modified; no new array is created.</remarks>
        /// <param name="arr">The array whose elements are to be reversed. Cannot be null.</param>
        /// <param name="start">The zero-based index at which to begin reversing. Must be greater than or equal to 0 and less than or equal
        /// to end.</param>
        /// <param name="end">The zero-based index at which to end reversing. Must be greater than or equal to start and less than the
        /// length of the array.</param>
        private void ReverseArray(int[] arr, int start, int end)
        {
            while (start < end)
            {
                SwapArray(arr, start, end);
                start++;
                end--;
            }
        }
        #endregion

        #region Print Array
        /// <summary>
        /// Prints the elements of a subarray within the specified range to the console.
        /// </summary>
        /// <param name="arr">The array containing the elements to print. Cannot be null.</param>
        /// <param name="start">The zero-based starting index of the subarray to print. Must be greater than or equal to 0 and less than or
        /// equal to <paramref name="end"/>.</param>
        /// <param name="end">The zero-based ending index of the subarray to print. Must be greater than or equal to <paramref
        /// name="start"/> and less than the length of <paramref name="arr"/>.</param>
        private void PrintArray(int[] arr, int start, int end)
        {
            Console.WriteLine("Subarray found:");
            for (int i = start; i <= end; i++)
                Console.Write(arr[i] + " ");
        }
        #endregion

        #region Swap Array
        /// <summary>
        /// Swaps the elements at the specified indices in the given array.
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        private void SwapArray(int[] nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }
        #endregion
        #endregion

        #region Public Methods
        #region Array Problems
        #region Largest Sum Contiguous Subarray
        /// <summary>
        /// Finds the largest sum of any contiguous subarray within the specified array of integers.
        /// Time Complexity: O(n) - The algorithm iterates through the array once, making it linear in time complexity.
        /// Space Complexity: O(1) - The algorithm uses a constant amount of extra space for variables to track the current sum and maximum sum found.
        /// Algorithm used: Kadane's Algorithm - This algorithm efficiently computes the maximum sum of a contiguous subarray by iterating through the array and keeping track of the current sum and the maximum sum found so far. It updates the current sum by adding the current element or starting fresh from the current element if it is greater than the current sum. The maximum sum is updated whenever a new maximum is found.
        /// </summary>
        /// <remarks>This method uses an efficient algorithm to compute the result in linear time. If the
        /// array contains only negative numbers, the largest (least negative) value will be returned. The input array
        /// must not be empty.</remarks>
        /// <param name="arr">An array of integers to search for the contiguous subarray with the maximum sum. Cannot be null and must
        /// contain at least one element.</param>
        /// <returns>The maximum sum of any contiguous subarray found within the input array.</returns>
        public int LargestSumContiguousSubarray(int[] arr)
        {
            // For Example: If arr = [-2,1,-3,4,-1,2,1,-5,4], the output will be 6
            // Explanation: The contiguous subarray with the largest sum is [4, -1, 2, 1], which sums to 6.
            // Step 1: Initialize maxSoFar and currentSum to the first element of the array.
            // Step 2: Iterate through the array starting from the second element. For each element, update currentSum to be the maximum of the current element itself or the sum of currentSum and the current element. This step decides whether to start a new subarray at the current element or to continue the existing subarray.
            // Step 3: Update maxSoFar to be the maximum of maxSoFar and currentSum. This step keeps track of the largest sum found so far.
            // Step 4: After iterating through the array, maxSoFar will contain the largest sum of any contiguous subarray, which is returned as the result.

            int maxSoFar = arr[0];
            int currentSum = arr[0];

            for (int i = 1; i < arr.Length; i++)
            {
                currentSum = Math.Max(arr[i], currentSum + arr[i]);
                maxSoFar = Math.Max(maxSoFar, currentSum);
            }

            return maxSoFar;
        }
        #endregion

        #region Rotate Array
        /// <summary>
        /// Rotates the elements of the specified array to the right by a given number of positions.
        /// </summary>
        /// Time Complexity: O(n) - The algorithm iterates through the array a few times (reversing the entire array and then reversing parts of it), resulting in linear time complexity.
        /// Space Complexity: O(1) - The algorithm performs the rotation in-place, using only a constant amount of extra space for temporary variables during the reversal process.
        /// Algorithm used: Array Reversal - This algorithm rotates the array by first reversing the entire array, then reversing the first k elements, and finally reversing the remaining n-k elements. This approach effectively shifts the elements to the right by k positions while maintaining their relative order.
        /// <remarks>The rotation is performed in-place, modifying the original array. The method returns
        /// the same array instance that was provided as input.</remarks>
        /// <param name="arr">The array of integers to rotate. Cannot be null.</param>
        /// <param name="k">The number of positions to rotate the array to the right. If greater than the array length, only the
        /// remainder after division by the array length is used.</param>
        /// <returns>The rotated array, with elements shifted to the right by the specified number of positions.</returns>
        public int[] RotateArray(int[] arr, int k)
        {
            // For Example: If arr = [1, 2, 3, 4, 5, 6, 7] and k = 3, the output will be [5, 6, 7, 1, 2, 3, 4]
            // Explanation: The last 3 elements (5, 6, 7) are moved to the front, and the first 4 elements (1, 2, 3, 4) are shifted to the right.
            // Step 1: Reverse the entire array to get [7, 6, 5, 4, 3, 2, 1]
            // Step 2: Reverse the first k elements to get [5, 6, 7, 4, 3, 2, 1]
            // Step 3: Reverse the remaining n-k elements to get [5, 6, 7, 1, 2, 3, 4]

            int n = arr.Length;
            k = k % n; // Handle cases where k is greater than n
            // Reverse the entire array
            ReverseArray(arr, 0, n - 1);    
            // Reverse the first k elements
            ReverseArray(arr, 0, k - 1);
            // Reverse the remaining n-k elements
            ReverseArray(arr, k, n - 1);

            return arr;
        }
        #endregion

        #region Merge Intervals
        /// <summary>
        /// Merges overlapping intervals in a collection and returns a new array containing the merged intervals.
        /// </summary>
        /// Time Complexity: O(n log n) - The algorithm first sorts the intervals, which takes O(n log n) time, and then iterates through the sorted intervals to merge them, which takes O(n) time. Therefore, the overall time complexity is dominated by the sorting step.
        /// Space Complexity: O(n) - In the worst case, if all intervals overlap, the merged intervals array will contain only one interval, but in general, it can contain up to n intervals if there are no overlaps. Therefore, the space complexity is O(n) for the output array.
        /// Algorithm used: Sorting and Merging - The algorithm first sorts the intervals based on their start times. Then, it iterates through the sorted intervals and merges them by comparing the current interval with the last merged interval. If they overlap, it updates the end time of the last merged interval; otherwise, it adds the current interval to the list of merged intervals.
        /// <remarks>Intervals are merged based on their start and end points. The order of intervals in
        /// the returned array corresponds to their sorted start times. If the input array contains zero or one
        /// interval, it is returned unchanged.</remarks>
        /// <param name="intervals">An array of intervals, where each interval is represented as an array of two integers specifying the start
        /// and end points. The array must not be null, and each interval must have exactly two elements.</param>
        /// <returns>An array of intervals, with all overlapping intervals merged. The returned array contains the minimal set of
        /// non-overlapping intervals covering all input intervals.</returns>
        public int[][] MergeIntervals(int[][] intervals)
        {
            // For Example: If intervals = [[1, 3], [2, 6], [8, 10], [15, 18]], the output will be [[1, 6], [8, 10], [15, 18]]
            // Explanation: The intervals [1, 3] and [2, 6] overlap and are merged into [1, 6]. The intervals [8, 10] and [15, 18] do not overlap with any other intervals and remain unchanged.
            // Step 1: Sort the intervals based on their start times to get [[1, 3], [2, 6], [8, 10], [15, 18]]
            // Step 2: Merge the intervals by iterating through the sorted list. The first two intervals overlap and are merged into [1, 6]. The remaining intervals do not overlap and are added to the result as they are.

            if (intervals.Length <= 1)
                return intervals;

            // Step 1: Sort by start time
            Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

            List<int[]> result = new List<int[]>();

            result.Add(intervals[0]);

            // Step 2: Merge
            for (int i = 1; i < intervals.Length; i++)
            {
                int[] last = result[result.Count - 1];
                int[] current = intervals[i];

                if (current[0] <= last[1]) // Overlap
                {
                    last[1] = Math.Max(last[1], current[1]);
                }
                else
                {
                    result.Add(current);
                }
            }

            return result.ToArray();
        }
        #endregion

        #region Find Duplicate Number
        /// <summary>
        /// Finds a duplicate number in the specified array where each integer is in the range 1 to n and only one
        /// number is duplicated.
        /// </summary>
        /// Time Complexity: O(n) - The algorithm uses a two-pointer technique (Floyd's Tortoise and Hare) to find the duplicate number in linear time.
        /// Space Complexity: O(1) - The algorithm uses only a constant amount of extra space for the two pointers, regardless of the input size.
        /// Algorithm used: Floyd's Tortoise and Hare (Cycle Detection) - This algorithm treats the array as a linked list where each index points to the value at that index. The duplicate number creates a cycle in this linked list. The algorithm uses two pointers (slow and fast) to detect the cycle and find the entry point of the cycle, which is the duplicate number.
        /// <remarks>The method assumes that the input array meets the problem constraints: it contains n
        /// + 1 integers where each integer is between 1 and n inclusive, and there is exactly one duplicated number.
        /// The method does not modify the input array and uses constant extra space. If the input does not meet these
        /// constraints, the result is undefined.</remarks>
        /// <param name="arr">An array of integers containing n + 1 elements, where each element is in the range 1 to n inclusive. The
        /// array must contain exactly one duplicate number, which may appear more than once.</param>
        /// <returns>The duplicated integer found in the array.</returns>
        public int FindDuplicate(int[] arr)
        {
            // For Example: If arr = [1, 3, 4, 2, 2], the output will be 2
            // Explanation: The number 2 appears twice in the array, making it the duplicate number.
            // Step 1: Initialize two pointers, slow and fast. The slow pointer moves one step at a time, while the fast pointer moves two steps at a time.
            // Step 2: Move the pointers through the array until they meet. This indicates that there is a cycle in the linked list representation of the array.
            // Step 3: Once they meet, reset one pointer to the start of the array and keep the other pointer at the meeting point. Move both pointers one step at a time until they meet again. The point at which they meet will be the duplicate number.
            
            int slow = arr[0];
            int fast = arr[0];

            do
            {
                slow = arr[slow];
                fast = arr[arr[fast]];
            } while (slow != fast);

            slow = arr[0];
            while (slow != fast)
            {
                slow = arr[slow];
                fast = arr[fast];
            }

            return slow;
        }
        #endregion

        #region Maximum Product Subarray
        /// <summary>
        /// Finds the contiguous subarray within the specified array that has the largest product and returns the
        /// product value.
        /// </summary>
        /// Time Complexity: O(n) - The algorithm iterates through the array once, making it linear in time complexity.
        /// Space Complexity: O(1) - The algorithm uses a constant amount of extra space for variables to track the maximum and minimum products up to the current index, as well as the overall maximum product found.
        /// Algorithm used: Dynamic Programming - The algorithm maintains two variables, maxSoFar and minSoFar, to keep track of the maximum and minimum products up to the current index. This is necessary because a negative number can turn a minimum product into a maximum product when multiplied. The algorithm iterates through the array, updating these variables based on the current element and the products calculated so far, while also keeping track of the overall maximum product found.
        /// <remarks>If the array contains only one element, that element is returned. The method accounts
        /// for negative numbers, which may affect the maximum product due to sign changes. The input array is not
        /// modified.</remarks>
        /// <param name="nums">An array of integers to search for the contiguous subarray with the maximum product. Cannot be null and must
        /// contain at least one element.</param>
        /// <returns>The maximum product of any contiguous subarray within the input array.</returns>
        public int MaximumProductSubarray(int[] nums)
        {
            // For Example: If nums = [2, 3, -2, 4], the output will be 6
            // Explanation: The contiguous subarray [2, 3] has the largest product, which is 6.
            // Step 1: Initialize maxSoFar, minSoFar, and result to the first element of the array. maxSoFar keeps track of the maximum product up to the current index, while minSoFar keeps track of the minimum product (which could become maximum if multiplied by a negative number).
            // Step 2: Iterate through the array starting from the second element. For each element, calculate the temporary maximum and minimum products by considering the current element itself, the product of maxSoFar and the current element, and the product of minSoFar and the current element. This step accounts for the possibility of negative numbers flipping the maximum and minimum products.
            // Step 3: Update maxSoFar and minSoFar with the temporary values calculated in the previous step.
            // Step 4: Update the result with the maximum of the current result and maxSoFar. This step keeps track of the largest product found so far.
            // Step 5: After iterating through the array, result will contain the largest product of any contiguous subarray, which is returned as the final output.

            int maxSoFar = nums[0];
            int minSoFar = nums[0];
            int result = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                int current = nums[i];

                int tempMax = Math.Max(current,
                              Math.Max(maxSoFar * current, minSoFar * current));

                int tempMin = Math.Min(current,
                              Math.Min(maxSoFar * current, minSoFar * current));

                maxSoFar = tempMax;
                minSoFar = tempMin;

                result = Math.Max(result, maxSoFar);
            }

            return result;
        }
        #endregion

        #region Find Repeated and Missing Numbers
        /// <summary>
        /// Finds and outputs the repeating and missing numbers in an array containing integers from 1 to n, where one
        /// number is missing and one number is repeated.
        /// </summary>
        /// Time Complexity: O(n) - The algorithm iterates through the array a few times (to calculate sums and differences), resulting in linear time complexity.
        /// Space Complexity: O(1) - The algorithm uses a constant amount of extra space for variables to store sums, differences, and the final repeating and missing numbers, regardless of the input size.
        /// Algorithm used: Mathematical Formulas - The algorithm calculates the sum and sum of squares of the elements in the array and compares them to the expected sums for the first n natural numbers. By deriving equations from these sums, it can determine the values of the repeating and missing numbers without modifying the input array.
        /// <remarks>The method writes the repeating and missing numbers to the console in the format:
        /// "Repeating: {repeating}, Missing: {missing}". The input array must contain exactly one repeated number and
        /// one missing number; otherwise, the output may be incorrect. The method does not return a value or modify the
        /// input array.</remarks>
        /// <param name="arr">An array of integers containing n elements, where each element is expected to be in the range from 1 to n,
        /// with exactly one number missing and one number repeated.</param>
        public void FindRepeatedAndMissingNumbers(int[] arr)
        {
            // For Example: If arr = [1, 2, 2, 4], the output will be Repeating: 2, Missing: 3
            // Explanation: The number 2 is repeated in the array, and the number 3 is missing from the sequence of integers from 1 to 4.
            // Step 1: Calculate the sum and sum of squares of the elements in the array. This will help us derive the equations needed to find the repeating and missing numbers.
            // Step 2: Calculate the expected sum and expected sum of squares for the first n natural numbers, where n is the length of the array. This is based on the formulas for the sum of the first n natural numbers and the sum of squares of the first n natural numbers.
            // Step 3: Compute the differences between the actual sum and expected sum, and between the actual sum of squares and expected sum of squares. These differences will be used to derive the values of the repeating and missing numbers.
            // Step 4: Use the differences to derive the equations for the repeating and missing numbers. The sum of the repeating and missing numbers can be found by dividing the difference in squares by the difference in sums.
            // Step 5: Finally, calculate the repeating and missing numbers using the derived equations and output the results.
            // Note: This method assumes that there is exactly one repeating number and one missing number in the input array, which contains integers from 1 to n.

            int n = arr.Length;

            long sum = 0, squareSum = 0;

            for (int i = 0; i < n; i++)
            {
                sum += arr[i];
                squareSum += (long)arr[i] * arr[i];
            }

            long expectedSum = (long)n * (n + 1) / 2;
            long expectedSquareSum = (long)n * (n + 1) * (2 * n + 1) / 6;

            long diff = sum - expectedSum;
            long squareDiff = squareSum - expectedSquareSum;

            long sumXY = squareDiff / diff;

            long repeating = (diff + sumXY) / 2;
            long missing = repeating - diff;

            Console.WriteLine($"Repeating: {repeating}, Missing: {missing}");
        }
        #endregion

        #region Subarray Sum
        /// <summary>
        /// Finds and prints the first contiguous subarray within the specified array whose elements sum to the given
        /// target value.
        /// </summary>
        /// Time Complexity: O(n) - The algorithm iterates through the array once, maintaining a cumulative sum and using a dictionary to track previously seen sums, resulting in linear time complexity.
        /// Space Complexity: O(n) - In the worst case, if all cumulative sums are unique, the dictionary will store n entries, leading to linear space complexity.
        /// Algorithm used: Hash Map (Dictionary) - The algorithm uses a dictionary to store the cumulative sum at each index. As it iterates through the array, it checks if the current cumulative sum equals the target value or if there is a previous cumulative sum that, when subtracted from the current cumulative sum, equals the target value. This allows it to identify the start and end indices of the contiguous subarray that sums to the target value efficiently.
        /// <remarks>If a contiguous subarray summing to the specified value is found, the method prints
        /// the subarray to the console and returns immediately. If no such subarray exists, a message is printed
        /// indicating that no subarray was found. The method does not return a value. Only the first matching subarray
        /// is printed if multiple exist.</remarks>
        /// <param name="arr">The array of integers to search for a contiguous subarray whose sum equals the target value. Cannot be null.</param>
        /// <param name="k">The target sum to search for within the contiguous subarrays of the array.</param>
        public void SubarraySum(int[] arr, int k)
        {
            // For Example: If arr = [1, 2, 3, 4, 5] and k = 9, the output will be Subarray found: 2 3 4
            // Explanation: The contiguous subarray [2, 3, 4] sums to 9, which is the target value k.
            // Step 1: Initialize a dictionary to store the cumulative sum up to each index and its corresponding index. This will help us quickly find if there is a previous cumulative sum that, when subtracted from the current cumulative sum, equals k.
            // Step 2: Iterate through the array while maintaining a running cumulative sum. For each element, add it to the cumulative sum.
            // Step 3: Check if the cumulative sum equals k. If it does, it means we have found a subarray from the start of the array to the current index that sums to k, and we can print that subarray.
            // Step 4: If the cumulative sum minus k exists in the dictionary, it means there is a previous cumulative sum that, when subtracted from the current cumulative sum, equals k. This indicates that the subarray between the index of that previous cumulative sum and the current index sums to k, and we can print that subarray.
            // Step 5: If the current cumulative sum is not already in the dictionary, add it along with the current index. This allows us to track the cumulative sums as we iterate through the array.
            // Step 6: If we finish iterating through the array without finding a subarray that sums to k, we can print a message indicating that no such subarray was found.
            // Note: This method assumes that the input array contains integers and that k is an integer. The method does not return a value but prints the result directly to the console.

            Dictionary<int, int> map = new Dictionary<int, int>();
            int sum = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];

                if (sum == k)
                {
                    PrintArray(arr, 0, i);
                    return;
                }   

                if (map.ContainsKey(sum - k))
                {
                    PrintArray(arr, map[sum - k] + 1, i);
                    return;
                }

                if (!map.ContainsKey(sum))
                    map.Add(sum, i);
            }

            Console.WriteLine("No subarray found");
        }
        #endregion

        #region Longest Consecutive Sequence
        /// <summary>
        /// Finds the length of the longest sequence of consecutive integers in an array.
        /// </summary>
        /// Time Complexity: O(n) - The algorithm iterates through the array once to build a hash set and then iterates through the set to find consecutive sequences, resulting in linear time complexity.
        /// Space Complexity: O(n) - The algorithm uses a hash set to store the unique integers from the array, which can contain up to n elements in the worst case (if all elements are unique).
        /// Algorithm used: Hash Set - The algorithm first adds all elements of the array to a hash set for O(1) average time complexity lookups. Then, it iterates through the set and for each number, it checks if it is the start of a sequence (i.e., the previous number is not in the set). If it is the start, it counts how many consecutive numbers follow it in the set and updates the longest sequence length found.
        /// <remarks>Duplicate numbers in the input array do not affect the result. The method operates in
        /// linear time relative to the size of the input array by using a hash set for efficient lookups.</remarks>
        /// <param name="nums">An array of integers to search for consecutive sequences. The array may contain duplicates and can be in any
        /// order.</param>
        /// <returns>The length of the longest consecutive elements sequence found in the array. Returns 0 if the array is empty.</returns>
        public int LongestConsecutive(int[] nums)
        {
            // For Example: If nums = [100, 4, 200, 1, 3, 2], the output will be 4
            // Explanation: The longest consecutive elements sequence is [1, 2, 3, 4]. Therefore, the length of this sequence is 4.
            // Step 1: If the input array is empty, return 0 as there are no elements to form a consecutive sequence.
            // Step 2: Create a HashSet from the input array to allow for O(1) average time complexity when checking for the presence of elements. This will help us efficiently determine if consecutive numbers exist in the array.
            // Step 3: Initialize a variable longest to keep track of the length of the longest consecutive sequence found.
            // Step 4: Iterate through each number in the HashSet. For each number, check if it is the start of a sequence by verifying that the previous number (num - 1) is not in the set.
            // Step 5: If the current number is the start of a sequence, initialize a variable current to the current number and a count variable to 1 to track the length of the current sequence.
            // Step 6: Use a while loop to check for the presence of the next consecutive number (current + 1) in the set. If it exists, increment current and count to continue tracking the length of the sequence.
            // Step 7: After exiting the while loop, update longest with the maximum of longest and count to keep track of the longest sequence found so far.
            // Step 8: After iterating through all numbers in the set, return longest as the length of the longest consecutive sequence found in the input array.
            // Note: This method assumes that the input array may contain duplicate numbers, but the presence of duplicates does not affect the length of the longest consecutive sequence. The method efficiently finds the longest sequence in linear time by leveraging a HashSet for quick lookups.

            if (nums.Length == 0)
                return 0;

            HashSet<int> set = new HashSet<int>(nums);
            int longest = 0;

            foreach (int num in set)
            {
                // Check if it is start of sequence
                if (!set.Contains(num - 1))
                {
                    int current = num;
                    int count = 1;

                    while (set.Contains(current + 1))
                    {
                        current++;
                        count++;
                    }

                    longest = Math.Max(longest, count);
                }
            }

            return longest;
        }
        #endregion

        #region Trapping Rain Water
        /// <summary>
        /// Calculates the total amount of water that can be trapped between bars in an elevation map represented by an
        /// array of heights.
        /// </summary>
        /// Time Complexity: O(n) - The algorithm uses a two-pointer approach to traverse the array once, resulting in linear time complexity.
        /// Space Complexity: O(1) - The algorithm uses a constant amount of extra space for the two pointers and variables to track the maximum heights and total water, regardless of the input size.
        /// Algorithm used: Two-Pointer Approach - The algorithm initializes two pointers at the start and end of the array and moves them towards each other based on the heights at those pointers. It keeps track of the maximum height encountered from both sides and calculates the trapped water at each step by comparing the current height with the maximum heights. This approach allows it to efficiently compute the total trapped water in a single pass through the array.
        /// <remarks>This method uses a two-pointer approach to efficiently compute the trapped water in
        /// linear time. The calculation assumes that the input array represents an elevation map with contiguous bars
        /// of width 1. The method does not modify the input array.</remarks>
        /// <param name="height">An array of non-negative integers representing the height of bars in the elevation map. Each element
        /// corresponds to the height at that position. The width of each bar is assumed to be 1 unit.</param>
        /// <returns>The total number of units of water that can be trapped between the bars. Returns 0 if no water can be
        /// trapped.</returns>
        public int TrappingRainWater(int[] height)
        {
            // For Example: If height = [0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1], the output will be 6
            // Explanation: The elevation map represented by the array has bars of varying heights.
            //              The water trapped between the bars can be visualized as follows:
            //              - Between the bars of height 1 and 2, 1 unit of water is trapped.
            //              - Between the bars of height 0 and 3, 2 units of water are trapped.
            //              - Between the bars of height 1 and 3, 1 unit of water is trapped.
            //              - Between the bars of height 0 and 2, 1 unit of water is trapped.
            //              - Between the bars of height 1 and 2, 1 unit of water is trapped.
            //              In total, 6 units of water are trapped.
            // Step 1: Initialize two pointers, left and right, to the start and end of the array, respectively.
            // Also, initialize variables leftMax and rightMax to keep track of the maximum height encountered
            // from the left and right sides, and a variable totalWater to accumulate the total amount of trapped water.
            // Step 2: Use a while loop to iterate until the left pointer is less than the right pointer.
            // In each iteration, compare the heights at the left and right pointers.
            // Step 3: If the height at the left pointer is less than the height at the right pointer,
            // it means that the amount of water that can be trapped at the left pointer is limited
            // by the maximum height encountered from the left side. If the height at the left pointer is
            // greater than or equal to leftMax, update leftMax to this height. Otherwise, calculate the
            // water trapped at this position as leftMax minus the height at the left pointer and add it to
            // totalWater. Then, move the left pointer one step to the right.
            // Step 4: If the height at the right pointer is less than or equal to the height at the left pointer,
            // it means that the amount of water that can be trapped at the right pointer is limited
            // by the maximum height encountered from the right side. If the height at the right pointer is
            // greater than or equal to rightMax, update rightMax to this height. Otherwise, calculate the
            // water trapped at this position as rightMax minus the height at the right pointer and add it to
            // totalWater. Then, move the right pointer one step to the left.
            // Step 5: After the loop terminates, totalWater will contain the total amount of water trapped between the bars, which is returned as the final result.
            // Note: This method assumes that the input array represents an elevation map where the width of each bar is 1 unit. The method efficiently calculates the total trapped water in linear time by using a two-pointer approach.

            int left = 0, right = height.Length - 1;
            int leftMax = 0, rightMax = 0;
            int totalWater = 0;

            while (left < right)
            {
                if (height[left] < height[right])
                {
                    if (height[left] >= leftMax)
                        leftMax = height[left];
                    else
                        totalWater += leftMax - height[left];

                    left++;
                }
                else
                {
                    if (height[right] >= rightMax)
                        rightMax = height[right];
                    else
                        totalWater += rightMax - height[right];

                    right--;
                }
            }

            return totalWater;
        }
        #endregion

        #region Next Permutation
        /// <summary>
        /// Transforms the specified array of integers into its next lexicographical permutation and returns the
        /// modified array.
        /// </summary>
        /// Time Complexity: O(n) - The algorithm iterates through the array a few times (to find the breakpoint, find the next greater element, and reverse the subarray), resulting in linear time complexity.
        /// Space Complexity: O(1) - The algorithm modifies the input array in place and uses only a constant amount of extra space for temporary variables during the process, regardless of the input size.
        /// Algorithm used: Next Permutation Algorithm - The algorithm identifies the rightmost pair of indices where the first index has a smaller value than the second index (the breakpoint). It then finds the rightmost index where the value is greater than the value at the breakpoint, swaps these two values, and finally reverses the subarray to the right of the breakpoint to get the next permutation in lexicographical order.
        /// <remarks>If the input array is empty or contains only one element, it is returned unchanged.
        /// This method modifies the input array in place; callers should not rely on the original order of the array
        /// after calling this method.</remarks>
        /// <param name="nums">The array of integers to permute. The array is modified in place to represent its next permutation in
        /// lexicographical order.</param>
        /// <returns>The same array instance, modified to its next lexicographical permutation. If the input array is already at
        /// its highest permutation, it is transformed to the lowest permutation (sorted in ascending order).</returns>
        public int[] NextPermutation(int[] nums)
        {
            // For Example: If nums = [1, 2, 3], the output will be [1, 3, 2]
            // Explanation: The next permutation of the array [1, 2, 3] is [1, 3, 2], which is the next lexicographically greater arrangement of the numbers. The algorithm identifies the rightmost pair of indices where the first index has a smaller value than the second index (the breakpoint), then finds the rightmost index where the value is greater than the value at the breakpoint, swaps these two values, and finally reverses the subarray to the right of the breakpoint to get the next permutation.
            // Step 1: Start from the end of the array and move backwards to find the first pair of indices (i, i+1) where nums[i] < nums[i+1]. This index i is called the breakpoint. If no such index exists, it means the array is in descending order, and we can simply reverse the entire array to get the lowest order (first permutation).
            // Step 2: If a breakpoint is found, start from the end of the array again and find the first index j where nums[j] > nums[i]. This means that nums[j] is the next larger element than nums[i] to the right of the breakpoint.
            // Step 3: Swap the values at indices i and j. This will place the next larger element at the breakpoint index.
            // Step 4: Finally, reverse the subarray from index i+1 to the end of the array. This will rearrange the elements to the right of the breakpoint in ascending order, giving us the next permutation.
            // Step 5: Return the modified array, which now represents the next permutation of the original array.
            // Note: This method modifies the input array in place and returns the same array instance. If the input array is already at its highest permutation, it will be transformed to the lowest permutation (sorted in ascending order).

            int n = nums.Length;
            int i = n - 2;

            // Step 1: Find breakpoint
            while (i >= 0 && nums[i] >= nums[i + 1])
                i--;

            if (i >= 0)
            {
                int j = n - 1;

                // Step 2: Find next greater element
                while (nums[j] <= nums[i])
                    j--;

                // Swap
                SwapArray(nums, i, j);
            }

            // Step 3: Reverse the right part
            ReverseArray(nums, i + 1, n - 1);

            return nums;
        }
        #endregion
        #endregion
        #endregion
    }
}
