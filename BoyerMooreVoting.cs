using DSARoadmap.Common.CommonServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace DSA_Roadmap.BoyerMooreVoting
{
    public class BoyerMooreVoting
    {
        private readonly CommonServices commonServices;

        public BoyerMooreVoting(CommonServices _commonServices)
        {
            commonServices = _commonServices;
            Console.WriteLine("Boyer-Moore Voting Algorithm:");
            int[] inputArray = new int[] { 3, 2, 3 };
            commonServices.WriteArray(inputArray, "Input Array: ");
            int majorityElement = FindMajorityElement(inputArray);
            Console.WriteLine($"Majority Element: {majorityElement}");
        }

        /// <summary>
        /// This method finds the majority element in an array using the Boyer-Moore Voting Algorithm.
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindMajorityElement(int[] nums)
        {
            // Boyer-Moore Voting Algorithm
            // Time Complexity: O(n)
            // Space Complexity: O(1)
            // The majority element is the element that appears more than n/2 times in the array.

            int count = 0; // count of the current candidate
            int candidate = 0; // current candidate for majority element

            // Iterate through each number in the array
            foreach (int num in nums)
            {
                if (count == 0) // if count is 0, we select a new candidate
                {
                    candidate = num; // set the current number as the new candidate
                }

                count += (num == candidate) ? 1 : -1; // increment or decrement the count
            }

            return candidate;
        }
    }
}
