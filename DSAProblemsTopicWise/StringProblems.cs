using DSARoadmap.Common.CommonServices;

namespace DSARoadmap.DSAProblemsTopicWise
{
    public class StringProblems
    {
        #region Variables
        private readonly CommonServices _commonServices;
        #endregion

        #region Constructor
        public StringProblems(CommonServices commonServices)
        {
            _commonServices = commonServices;
            Console.WriteLine("Longest Palindrome substring: " + LongestPalindrome("babad"));
            Console.WriteLine("Reverse Words in a String: " + ReverseWordsInString("Hello World"));
            Console.WriteLine("Longest Common Prefix: " + LongestCommonPrefix(new string[] { "flower", "flow", "flight" }));
            _commonServices.Print2DList(GroupAnagrams(new string[] { "eat", "tea", "tan", "ate", "nat", "bat" }));
            Console.WriteLine("Valid Parenthesis: " + CheckForValidParenthesis("()[]{}"));
            Console.WriteLine("My ATOI: " + MyATOI("   -42"));
            KMPSearch("ababcababc", "abc");
            Console.WriteLine("Minimum Window Substring: " + MinimumWindowSubstring("ADOBECODEBANC", "ABC"));
            Console.WriteLine("Reverse Each Word in sentence: " + ReverseEachWordInSentence("I'm Arun"));
        }
        #endregion

        #region Private Methods

        #endregion

        #region Public Methods
        #region Longest Palindromic Substring
        /// <summary>
        /// Finds the longest contiguous palindromic substring within the specified string.
        /// </summary>
        /// Time Complexity: O(n) - Manacher's algorithm allows us to find the longest palindromic substring in linear time.
        /// Space Complexity: O(n) - The transformed string and the array used to store palindrome lengths require linear space.
        /// Algorithm used: Manacher's Algorithm - This algorithm transforms the input string to handle even-length palindromes uniformly and uses a center expansion technique to find the longest palindrome efficiently.
        /// <remarks>If multiple longest palindromic substrings of equal length exist, the first one
        /// encountered is returned. The search is case-sensitive and considers the exact characters in the input
        /// string.</remarks>
        /// <param name="s">The input string to search for palindromic substrings. Cannot be null.</param>
        /// <returns>A string containing the longest palindromic substring found in the input. Returns an empty string if the
        /// input is null or empty.</returns>
        public string LongestPalindrome(string s)
        {
            // For Example: "babad" => "aba" or "bab"
            // Explanation: We can use Manacher's algorithm to find the longest palindromic substring in linear time.
            // The algorithm transforms the input string to handle even-length palindromes uniformly and uses a center
            // expansion technique to find the longest palindrome efficiently.
            // Step 1: Transform the string by inserting a special character (e.g., '#') between each character and at the
            // beginning and end of the string. This helps to handle even-length palindromes.
            // Step 2: Create an array P to store the radius of the palindrome around each center.
            // Step 3: Iterate through the transformed string and expand around each center to find the longest palindrome.
            // Step 4: Keep track of the center and right boundary of the current longest palindrome to optimize the expansion process.
            // Step 5: After processing, find the maximum length palindrome and extract the corresponding substring from the original string.
            // Step 6: Return the longest palindromic substring found.

            if (string.IsNullOrEmpty(s))
                return "";

            // Transform string
            string T = "^#" + string.Join("#", s.ToCharArray()) + "#$";
            int n = T.Length;
            int[] P = new int[n];
            int C = 0, R = 0;

            for (int i = 1; i < n - 1; i++)
            {
                int mirror = 2 * C - i;

                if (i < R)
                    P[i] = Math.Min(R - i, P[mirror]);

                // Expand around center i
                while (T[i + 1 + P[i]] == T[i - 1 - P[i]])
                    P[i]++;

                // Update center and right boundary
                if (i + P[i] > R)
                {
                    C = i;
                    R = i + P[i];
                }
            }

            // Find maximum palindrome
            int maxLen = 0;
            int centerIndex = 0;

            for (int i = 1; i < n - 1; i++)
            {
                if (P[i] > maxLen)
                {
                    maxLen = P[i];
                    centerIndex = i;
                }
            }

            // Extract original string index
            int start = (centerIndex - maxLen) / 2;

            return s.Substring(start, maxLen);
        }
        #endregion

        #region Reverse Words in a String
        /// <summary>
        /// Reverses the order of words in the specified string.
        /// </summary>
        /// Time Complexity: O(n) - The algorithm processes each character in the string a constant number of times, resulting in linear time complexity.
        /// Space Complexity: O(n) - The space used to store the split words and the resulting reversed string is linear in relation to the input size.
        /// Algorithm used: Split and Reverse - The algorithm splits the input string into words, reverses the order of the words, and then joins them back together to form the final output.
        /// <remarks>Consecutive spaces are treated as a single delimiter, and leading or trailing spaces
        /// are ignored in the output.</remarks>
        /// <param name="s">The input string containing words to reverse. Words are delimited by spaces. Cannot be null.</param>
        /// <returns>A string with the words in reverse order, separated by single spaces. Returns the original string if it is
        /// null or empty.</returns>
        public string ReverseWordsInString(string s)
        {
            // For Example: "Hello World" => "World Hello"
            // Explanation: We can split the string into words, reverse the order of the words, and then join them back together.
            // Step 1: Split the input string into an array of words using space as a delimiter.
            // Step 2: Reverse the order of the words in the array.
            // Step 3: Join the reversed array of words back into a single string with spaces in between.
            // Step 4: Return the resulting string with the words in reversed order.

            if (string.IsNullOrEmpty(s))
                return s;

            string[] words = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            CommonServices.ReverseArray(words, 0, words.Length - 1);

            return string.Join(" ", words);
        }
        #endregion

        #region Longest Common Prefix
        /// <summary>
        /// Finds the longest common prefix string among an array of strings.
        /// </summary>
        /// Time Complexity: O(S) - Where S is the sum of all characters in all strings in the array. In the worst case, we compare each character of each string.
        /// Space Complexity: O(1) - The algorithm uses a constant amount of extra space for variables, regardless of the input size.
        /// Algorithm used: Horizontal Scanning - The algorithm starts with the first string as the initial prefix and iteratively compares it with each subsequent string, reducing the prefix length until a common prefix is found or it becomes empty.
        /// <remarks>If the input array contains only one string, that string is returned as the prefix.
        /// The comparison is case-sensitive. If any string in the array is empty, the result will be an empty
        /// string.</remarks>
        /// <param name="strs">An array of strings to compare for a common prefix. Cannot be null.</param>
        /// <returns>A string representing the longest common prefix shared by all strings in the array. Returns an empty string
        /// if there is no common prefix or if the array is empty.</returns>
        public string LongestCommonPrefix(string[] strs)
        {
            // For Example: ["flower","flow","flight"] => "fl"
            // Explanation: We can find the longest common prefix by comparing characters of the strings one by one until a mismatch is found.
            // Step 1: Check if the input array is empty. If it is, return an empty string as there are no strings to compare.
            // Step 2: Initialize the longest common prefix as the first string in the array.
            // Step 3: Iterate through the remaining strings in the array and compare them with the current longest common prefix.
            // Step 4: For each string, compare characters with the longest common prefix until a mismatch is found or the end of the prefix is reached.
            // Step 5: Update the longest common prefix to the substring that matches for all strings processed so far.
            // Step 6: If at any point the longest common prefix becomes an empty string, return it immediately as there can be no common prefix.
            // Step 7: After processing all strings, return the longest common prefix found.

            if (strs == null || strs.Length == 0)
                return "";

            string prefix = strs[0];

            for (int i = 1; i < strs.Length; i++)
            {
                while (strs[i].IndexOf(prefix) != 0)
                {
                    prefix = prefix.Substring(0, prefix.Length - 1);
                    if (string.IsNullOrEmpty(prefix))
                        return "";
                }
            }
            return prefix;
        }
        #endregion

        #region Group Anagrams
        /// <summary>
        /// Groups a collection of strings into lists of anagrams, where each group contains words that are anagrams of
        /// each other.
        /// </summary>
        /// <remarks>The order of groups and the order of strings within each group is not guaranteed.
        /// Anagrams are determined by character composition, ignoring order.</remarks>
        /// <param name="strs">An array of strings to be grouped into anagrams. Cannot be null.</param>
        /// <returns>A list of groups, where each group is a list of strings that are anagrams of each other. Each input string
        /// appears in exactly one group. Returns an empty list if the input array is empty.</returns>
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            // For Example: ["eat", "tea", "tan", "ate", "nat", "bat"] => [["eat","tea","ate"],["tan","nat"],["bat"]]
            // Explanation: We can group anagrams by counting the frequency of each character in the strings. Anagrams will have the same character frequency.
            // Step 1: Create a dictionary to map the character frequency signature to a list of anagrams.
            // Step 2: For each string in the input array, count the frequency of each character (e.g., using an array of size 26 for lowercase letters).
            // Step 3: Convert the character frequency array into a string key that represents the signature of the anagram group.
            // Step 4: Use the key to group the strings in the dictionary. If the key does not exist, create a new list for that key.
            // Step 5: Add the current string to the list corresponding to its anagram signature in the dictionary.
            // Step 6: After processing all strings, return the values of the dictionary as a list of groups of anagrams.
            // Step 7: The order of groups and the order of strings within each group is not guaranteed, as the problem does not specify any particular ordering.
            // Step 8: Return the list of anagram groups.
            // Step 9: If the input array is empty, return an empty list.
            // Step 10: The algorithm efficiently groups anagrams by leveraging the character frequency signature, which allows for quick lookups and grouping in linear time relative to the total number of characters in the input strings.
            
            Dictionary<string, List<string>> map = new();

            foreach (var word in strs)
            {
                int[] count = new int[26];

                foreach (char c in word)
                    count[c - 'a']++;

                string key = string.Join("#", count);

                if (!map.ContainsKey(key))
                    map[key] = new List<string>();

                map[key].Add(word);
            }

            return new List<IList<string>>(map.Values);
        }
        #endregion

        #region Valid Parenthesis
        /// <summary>
        /// Determines whether the specified string contains a valid sequence of parentheses and brackets.
        /// </summary>
        /// Time Complexity: O(n) - The algorithm processes each character in the input string once, resulting in linear time complexity.
        /// Space Complexity: O(n) - In the worst case, the stack can hold all opening brackets if there are no closing brackets, resulting in linear space complexity.
        /// Algorithm used: Stack-Based Validation - The algorithm uses a stack to keep track of opening brackets and ensures that each closing bracket matches the most recent opening bracket.
        /// <remarks>A valid sequence requires that every opening bracket has a corresponding closing
        /// bracket of the same type and that brackets are properly nested. The method processes the input in linear
        /// time relative to its length.</remarks>
        /// <param name="parenthesisInput">A string consisting of parentheses and/or brackets to validate. The string may include '()', '{}', and '[]'
        /// characters in any order.</param>
        /// <returns>A string indicating whether the input is a valid parenthesis sequence. Returns "Valid Parenthesis." if the
        /// input is valid; otherwise, returns "Not a Valid Parenthesis.".</returns>
        public string CheckForValidParenthesis(string parenthesisInput)
        {
            // For Example: "()" => true, "()[]{}" => true, "(]" => false
            // Explanation: We can use a stack to check for valid parentheses. We will push opening brackets onto the stack and pop them when we encounter closing brackets, ensuring that they match.
            // Step 1: Create a stack to keep track of opening brackets.
            // Step 2: Create a mapping of closing brackets to their corresponding opening brackets for easy lookup.
            // Step 3: Iterate through each character in the input string.
            // Step 4: If the character is an opening bracket, push it onto the stack.
            // Step 5: If the character is a closing bracket, check if the stack is empty or if the top of the stack does not match the corresponding opening bracket. If either condition is true, return "Not a Valid Parenthesis."
            // Step 6: If the stack is not empty and the top of the stack matches the corresponding opening bracket, pop the stack.
            // Step 7: After processing all characters, check if the stack is empty. If it is empty, return "Valid Parenthesis." Otherwise, return "Not a Valid Parenthesis."
            // Step 8: The algorithm efficiently checks for valid parentheses in linear time relative to the length of the input string, as each character is processed once and stack operations are O(1).

            Stack<char> stack = new();

            Dictionary<char, char> map = new()
            {
                { ')', '(' },
                { '}', '{' },
                { ']', '[' },
            };

            foreach (char c in parenthesisInput)
            {
                if (map.ContainsValue(c))
                {
                    stack.Push(c);
                }
                else if (map.ContainsKey(c))
                {
                    if (stack.Count == 0 || stack.Pop() != map[c])
                        return "Not a Valid Parenthesis.";
                }
            }

            return stack.Count == 0 ? "Valid Parenthesis." : "Not a Valid Parenthesis.";
        }
        #endregion

        #region My ATOI
        /// <summary>
        /// Converts the specified string representation of a number to its 32-bit signed integer equivalent, following
        /// rules similar to the C 'atoi' function.
        /// </summary>
        /// Time Complexity: O(n) - The algorithm processes each character in the input string at most once, resulting in linear time complexity.
        /// Space Complexity: O(1) - The algorithm uses a constant amount of extra space for variables, regardless of the input size.
        /// Algorithm used: Iterative Parsing - The algorithm iteratively processes the input string, handling leading whitespace, optional signs, and digit characters to construct the resulting integer while checking for overflow conditions.
        /// <remarks>If the input string contains only whitespace or no valid digits, the method returns
        /// 0. If the parsed value exceeds the limits of Int32, the method returns int.MaxValue or int.MinValue as
        /// appropriate. Only decimal digits are considered; parsing stops at the first non-digit character after any
        /// optional sign.</remarks>
        /// <param name="s">The string containing the number to convert. Leading whitespace is ignored. An optional '+' or '-' sign is
        /// supported. Parsing stops at the first non-digit character.</param>
        /// <returns>The parsed integer value. Returns 0 if the string does not contain a valid integer representation. Returns
        /// int.MaxValue or int.MinValue if the value exceeds the range of a 32-bit signed integer.</returns>
        public int MyATOI(string s)
        {
            // For Example: "   -42" => -42
            // Explanation: We can implement the ATOI (ASCII to Integer) function by following these steps:
            // Step 1: Skip any leading whitespace characters in the input string.
            // Step 2: Check for an optional sign character ('+' or '-') to determine the sign of the resulting integer.
            // Step 3: Convert the subsequent characters to an integer until a non-digit character is encountered or the end of the string is reached.
            // Step 4: Handle potential overflow by checking if the resulting integer exceeds the limits of a 32-bit signed integer. If it does, return the appropriate limit (INT_MAX or INT_MIN).
            // Step 5: Return the final integer value, applying the determined sign.
            // Step 6: If the input string is empty or does not contain any valid integer representation, return 0.
            // The algorithm processes the input string in linear time relative to its length, as it iterates through the characters at most once. The space complexity is O(1) since we are using a constant amount of extra space for variables.

            if (string.IsNullOrEmpty(s))
                return 0;

            int i = 0, n = s.Length;

            // 1. Skip leading spaces
            while (i < n && s[i] == ' ')
                i++;

            if (i == n)
                return 0;

            // 2. Handle sign
            int sign = 1;
            if (s[i] == '+' || s[i] == '-')
            {
                sign = (s[i] == '-') ? -1 : 1;
                i++;
            }

            // 3. Convert digits
            long result = 0;

            while (i < n && char.IsDigit(s[i]))
            {
                result = result * 10 + (s[i] - '0');

                // 4. Handle overflow
                if (sign * result > int.MaxValue)
                    return int.MaxValue;

                if (sign * result < int.MinValue)
                    return int.MinValue;

                i++;
            }

            #region Using int and checking overflow before multiplying
            //int result = 0;

            //// 3. Process digits
            //while (i < n && char.IsDigit(s[i]))
            //{
            //    int digit = s[i] - '0';

            //    // 4. Check overflow BEFORE multiplying
            //    if (result > (int.MaxValue - digit) / 10)
            //        return sign == 1 ? int.MaxValue : int.MinValue;

            //    result = result * 10 + digit;
            //    i++;
            //}

            //return result * sign;
            #endregion

            return (int)(sign * result);
        }
        #endregion

        #region KMP Algorithm for Pattern Searching
        /// <summary>
        /// Searches for all occurrences of a specified pattern within the given text using the Knuth-Morris-Pratt (KMP)
        /// algorithm. Outputs the starting index of each match to the console.
        /// </summary>
        /// Time Complexity: O(n + m) - The KMP algorithm processes the text and pattern in linear time, where n is the length of the text and m is the length of the pattern.
        /// Space Complexity: O(m) - The algorithm uses additional space to store the longest prefix-suffix (LPS) array for the pattern, which requires linear space relative to the length of the pattern.
        /// Algorithm used: Knuth-Morris-Pratt (KMP) - This algorithm preprocesses the pattern to create an LPS array that allows it to skip unnecessary comparisons when a mismatch occurs, resulting in efficient pattern searching.
        /// <remarks>This method writes the index of each pattern occurrence to the console. The search is
        /// case-sensitive. If the pattern is not found, no output is produced. The KMP algorithm provides efficient
        /// pattern searching, especially for large texts or repeated searches.</remarks>
        /// <param name="text">The text in which to search for the pattern. Cannot be null.</param>
        /// <param name="pattern">The pattern to search for within the text. Cannot be null or empty.</param>
        public void KMPSearch(string text, string pattern)
        {
            // For Example: text = "ababcababc", pattern = "abc" => Pattern found at index 2, Pattern found at index 7
            // Explanation: The KMP algorithm allows us to search for a pattern in a text efficiently by preprocessing the pattern to create an LPS (Longest Prefix Suffix) array. This array helps us skip unnecessary comparisons when a mismatch occurs during the search.
            // Step 1: Build the LPS array for the pattern using the BuildLPS method.
            // Step 2: Initialize two pointers, i for the text and j for the pattern, to keep track of the current position in both strings.
            // Step 3: Iterate through the text using the pointer i. For each character, compare it with the corresponding character in the pattern at position j.
            // Step 4: If the characters match, increment both pointers i and j.
            // Step 5: If j reaches the length of the pattern, it means we have found a match. Output the starting index of the match (i - j) and update j to the value in the LPS array at position j - 1 to continue searching for the next occurrence.
            // Step 6: If a mismatch occurs and j is not at the beginning of the pattern, update j to the value in the LPS array at position j - 1 to skip unnecessary comparisons. If j is at the beginning, simply increment i to move to the next character in the text.
            // Step 7: Continue this process until the end of the text is reached, allowing for efficient pattern searching with a time complexity of O(n + m) and space complexity of O(m) due to the LPS array.
            // Step 8: The method outputs the starting index of each occurrence of the pattern in the text to the console. If the pattern is not found, no output is produced.
            // Step 9: The search is case-sensitive, meaning that uppercase and lowercase characters are treated as distinct.
            // Step 10: The KMP algorithm is particularly efficient for large texts or repeated searches, as it minimizes the number of character comparisons needed to find matches.
            // Step 11: The overall efficiency of the KMP algorithm makes it a preferred choice for pattern searching in various applications, such as text editors, search engines, and bioinformatics.

            int n = text.Length;
            int m = pattern.Length;

            int[] lps = BuildLPS(pattern);

            int i = 0; // text index
            int j = 0; // pattern index

            while (i < n)
            {
                if (text[i] == pattern[j])
                {
                    i++;
                    j++;
                }

                if (j == m)
                {
                    Console.WriteLine("Pattern found at index " + (i - j));
                    j = lps[j - 1];
                }
                else if (i < n && text[i] != pattern[j])
                {
                    if (j != 0)
                        j = lps[j - 1];
                    else
                        i++;
                }
            }
        }

        /// <summary>
        /// Builds the longest prefix-suffix (LPS) array for the specified pattern string. The LPS array is used in the
        /// Knuth-Morris-Pratt (KMP) string searching algorithm to optimize pattern matching.
        /// </summary>
        /// Time Complexity: O(m) - The algorithm processes each character of the pattern string once to compute the LPS array, resulting in linear time complexity relative to the length of the pattern.
        /// Space Complexity: O(m) - The algorithm uses an array of integers to store the LPS values, which requires linear space relative to the length of the pattern.
        /// Algorithm used: LPS Array Construction - The algorithm iteratively computes the length of the longest proper prefix which is also a suffix for each position in the pattern string, allowing for efficient pattern matching in the KMP algorithm.
        /// <remarks>The returned LPS array can be used to efficiently skip characters during pattern
        /// matching in the KMP algorithm. The length of the returned array is equal to the length of the input
        /// pattern.</remarks>
        /// <param name="pattern">The pattern string for which to compute the LPS array. Cannot be null.</param>
        /// <returns>An array of integers representing the LPS values for each position in the pattern. Each element indicates
        /// the length of the longest proper prefix which is also a suffix for the substring ending at that position.</returns>
        static int[] BuildLPS(string pattern)
        {
            // For Example: "ABABCABAB" => [0, 0, 1, 2, 0, 1, 2, 3, 4]
            // Explanation: The LPS (Longest Prefix Suffix) array is constructed by iterating through the pattern string and calculating the length of the longest proper prefix which is also a suffix for each position in the pattern. This allows the KMP algorithm to skip unnecessary comparisons when a mismatch occurs during pattern searching.
            // Step 1: Initialize an array lps of the same length as the pattern to store the LPS values.
            // Step 2: Use two pointers, len and i, to keep track of the length of the longest prefix-suffix and the current position in the pattern, respectively.
            // Step 3: Iterate through the pattern starting from the second character (i = 1) and compare it with the character at the position indicated by len.
            // Step 4: If the characters match, increment len and set lps[i] to len, then move to the next character (i++).
            // Step 5: If the characters do not match and len is not zero, update len to lps[len - 1] to check for shorter prefix-suffix matches.
            // Step 6: If the characters do not match and len is zero, set lps[i] to 0 and move to the next character (i++).
            // Step 7: Continue this process until the entire pattern has been processed, resulting in a complete LPS array that can be used for efficient pattern searching in the KMP algorithm.

            int m = pattern.Length;
            int[] lps = new int[m];

            int len = 0;
            int i = 1;

            while (i < m)
            {
                if (pattern[i] == pattern[len])
                {
                    len++;
                    lps[i] = len;
                    i++;
                }
                else
                {
                    if (len != 0)
                    {
                        len = lps[len - 1];
                    }
                    else
                    {
                        lps[i] = 0;
                        i++;
                    }
                }
            }

            return lps;
        }
        #endregion

        #region Minimum Window Substring
        /// <summary>
        /// Finds the smallest substring in the specified source string that contains all the characters of the target
        /// string, including duplicates.
        /// </summary>
        /// Time Complexity: O(n + m) - The algorithm processes the source string and the target string in linear time, where n is the length of the source string and m is the length of the target string.
        /// Space Complexity: O(m) - The algorithm uses a dictionary to store the frequency of characters in the target string, which requires linear space relative to the length of the target string.
        /// Algorithm used: Sliding Window - The algorithm uses a sliding window approach to expand and contract the window in the source string while maintaining a count of characters to find the minimum window that contains all characters of the target string.
        /// <remarks>The search is case-sensitive and considers duplicate characters in the target string.
        /// If multiple minimum windows exist, the first occurring window is returned.</remarks>
        /// <param name="s">The source string in which to search for the minimum window substring.</param>
        /// <param name="t">The target string containing the set of characters to be included in the window. All characters, including
        /// duplicates, must be present in the window.</param>
        /// <returns>A substring of the source string that is the minimum window containing all characters from the target
        /// string. Returns an empty string if no such window exists.</returns>
        public string MinimumWindowSubstring(string s, string t)
        {
            // For Example: s = "ADOBECODEBANC", t = "ABC" => "BANC"
            // Explanation: We can use a sliding window approach to find the minimum window substring. We will maintain a frequency map of the characters in the target string and use two pointers to expand and contract the window in the source string while keeping track of how many characters from the target string are currently in the window.
            // Step 1: Create a frequency map for the characters in the target string to keep track of how many of each character we need to find in the source string.
            // Step 2: Initialize two pointers, left and right, to represent the current window in the source string. Also, initialize variables to keep track of the number of unique characters from the target string that are currently in the window (formed) and the total number of unique characters required (required).
            // Step 3: Expand the right pointer to include characters from the source string until the window contains all characters from the target string (formed == required).
            // Step 4: Once a valid window is found, try to contract the window from the left pointer to find the minimum window. Update the minimum length and starting index of the minimum window whenever a smaller valid window is found.
            // Step 5: If contracting the window causes it to no longer contain all characters from the target string, move the left pointer back to expand the window again.
            // Step 6: Continue this process until the right pointer reaches the end of the source string, ensuring that all possible windows are checked for validity and minimum length.
            // Step 7: Return the minimum window substring found, or an empty string if no valid window exists. The search is case-sensitive and considers duplicate characters in the target string, ensuring that the resulting window contains all required characters with the correct frequency.
            // Step 8: The algorithm efficiently finds the minimum window substring in linear time relative to the lengths of the source and target strings, making it suitable for large inputs.

            if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(t))
                return "";

            Dictionary<char, int> map = new();

            // Step 1: Build frequency map for t
            foreach (char c in t)
            {
                if (!map.ContainsKey(c))
                    map[c] = 0;
                map[c]++;
            }

            int left = 0, right = 0;
            int required = map.Count;
            int formed = 0;

            Dictionary<char, int> windowCounts = new();

            int minLen = int.MaxValue;
            int minStart = 0;

            while (right < s.Length)
            {
                char c = s[right];

                if (!windowCounts.ContainsKey(c))
                    windowCounts[c] = 0;

                windowCounts[c]++;

                if (map.ContainsKey(c) && windowCounts[c] == map[c])
                    formed++;

                // Try shrinking
                while (left <= right && formed == required)
                {
                    if (right - left + 1 < minLen)
                    {
                        minLen = right - left + 1;
                        minStart = left;
                    }

                    char leftChar = s[left];
                    windowCounts[leftChar]--;

                    if (map.ContainsKey(leftChar) &&
                        windowCounts[leftChar] < map[leftChar])
                    {
                        formed--;
                    }

                    left++;
                }

                right++;
            }

            return minLen == int.MaxValue
                ? ""
                : s.Substring(minStart, minLen);
        }
        #endregion

        #region Reverse Each Word in a Sentence
        /// <summary>
        /// Reverses the characters of each word in the given sentence while maintaining the original order of the words. Words are defined as sequences of non-space characters, and the method handles multiple spaces by treating them as a single delimiter.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string ReverseEachWordInSentence(string s)
        {
            if (string.IsNullOrEmpty(s))
                return s;

            string[] words = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < words.Length; i++)
            {
                char[] charArray = words[i].ToCharArray();
                int left = 0; 
                int right = charArray.Length - 1;

                while(left < right)
                {
                    char temp = charArray[left];
                    charArray[left] = charArray[right];
                    charArray[right] = temp;
                    left++;
                    right--;
                }

                words[i] = new string(charArray);

                //Array.Reverse(charArray);
                //words[i] = new string(charArray);
            }

            return string.Join(" ", words);
        }
        #endregion
        #endregion
    }
}
