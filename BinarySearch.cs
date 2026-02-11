using DSARoadmap.Common.CommonServices;

namespace DSA_Roadmap.BinarySearch
{
    public class BinarySearch
    {
        #region Variables
        private readonly CommonServices commonServices;
        #endregion

        #region Constructor 
        /// <summary>
        /// Constructor of BinarySearch class
        /// </summary>
        /// <param name="_commonServices"></param>
        public BinarySearch(CommonServices _commonServices) {
            commonServices = _commonServices;
            Console.WriteLine(BinarySearchAlgo(new int[] { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19 }, 7));
            Console.WriteLine(FirstBadVersion(10));
            commonServices.WriteArray(SearchRange(new int[] { 5,7,7,8,8,10 }, 8), "Search Range: ");
            commonServices.WriteArray(TargetIndices(new int[] { 1,2,5,2,3 }, 2), "Target Indices: ");
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Performs binary search on a sorted array to find the index of the target value.
        /// </summary>
        /// <param name="inputArray"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int BinarySearchAlgo(int[] inputArray, int target)
        {
            Console.WriteLine("Binary Search:");
            commonServices.WriteArray(inputArray, "Sorted Array: ");
            //Console.WriteLine("Sorted Array: [ " + string.Join(", ", inputArray) + " ]");
            int left = 0;
            int right = inputArray.Length - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2; // to avoid overflow
                if (inputArray[mid] == target)
                {
                    return mid; // target found at index mid
                }
                else if (inputArray[mid] < target)
                {
                    left = mid + 1; // search in the right half
                }
                else
                {
                    right = mid - 1; // search in the left half
                }
            }
            return -1; // target not found
        }

        /// <summary>
        /// To find the first bad version
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int FirstBadVersion(int n)
        {
            int left = 1;
            int right = n;
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (IsBadVersion(mid))
                    right = mid;
                else
                    left = mid + 1;
            }
            return left;
        }

        /// <summary>
        /// To find the starting and ending position of a given target value in a sorted array.
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] SearchRange(int[] nums, int target)
        {
            int[] result = new int[] { -1, -1 };

            result[0] = BinarySearchRange(nums, target, true);   // first position
            result[1] = BinarySearchRange(nums, target, false);  // last position

            return result;
        }

        /// <summary>
        /// To find the target indices after sorting the array, this is done without actually sorting the array.
        /// Using the counting method.
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public IList<int> TargetIndices(int[] nums, int target)
        {
            int countLess = 0;
            int countEqual = 0;

            // Count elements
            foreach (int num in nums)
            {
                if (num < target)
                    countLess++;
                else if (num == target)
                    countEqual++;
            }

            // Build result
            List<int> result = new List<int>();
            for (int i = 0; i < countEqual; i++)
            {
                result.Add(countLess + i); 
            }

            return result;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// This method performs a binary search to find either the first or last occurrence of a target value in a sorted array.
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <param name="findFirst"></param>
        /// <returns></returns>
        private int BinarySearchRange(int[] nums, int target, bool findFirst)
        {
            int left = 0, right = nums.Length - 1;
            int index = -1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (nums[mid] == target)
                {
                    index = mid;

                    if (findFirst)
                        right = mid - 1;  // go left
                    else
                        left = mid + 1;   // go right
                }
                else if (nums[mid] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return index;
        }

        /// <summary>
        /// To check if the version is bad or not
        /// </summary>
        /// <param name="version"></param>
        /// <returns></returns>
        private bool IsBadVersion(int version)
        {
            // Placeholder implementation for demonstration purposes.
            // In a real scenario, this method would check if the given version is bad.
            return version >= 4; // Example: versions 4 and above are bad
        }
        #endregion
    }
}
