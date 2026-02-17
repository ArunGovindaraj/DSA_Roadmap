using DSARoadmap.Common.CommonServices;

namespace DSARoadmap.DynamicProgramming
{
    public class DynamicProgramming
    {
        #region Variables
        private readonly CommonServices commonServices;
        #endregion

        #region Constructor
        public DynamicProgramming(CommonServices _commonServices)
        {
            commonServices = _commonServices;
            Console.WriteLine("Dynamic Programming Problems:");
            Console.WriteLine("Pascal's Triangle Generation:");
            commonServices.PrintPascalTriangle(GeneratePascalTriangle(5));
            commonServices.WriteArray(GetRowFromPascalTriangle(3), "Row 3 of Pascal's Triangle: ");
            Console.WriteLine(IsRegularExpressionMatch("a*b*", "aabb") ? "Match" : "Not match");
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// This method generates Pascal's Triangle up to the specified number of rows.
        /// </summary>
        /// <param name="numRows"></param>
        /// <returns></returns>
        public IList<IList<int>> GeneratePascalTriangle(int numRows)
        {
            List<IList<int>> triangle = new List<IList<int>>();

            if (numRows == 0)
                return triangle;

            // First row
            triangle.Add(new List<int> { 1 });

            for (int i = 1; i < numRows; i++)
            {
                List<int> prevRow = (List<int>)triangle[i - 1];
                List<int> currRow = new List<int>();

                currRow.Add(1); // first element

                for (int j = 1; j < i; j++)
                {
                    currRow.Add(prevRow[j - 1] + prevRow[j]);
                }

                currRow.Add(1); // last element

                triangle.Add(currRow);
            }

            return triangle;
        }

        public IList<int> GetRowFromPascalTriangle(int rowIndex)
        {
            return GeneratePascalTriangle(rowIndex + 1)[rowIndex];
        }

        /// <summary>
        /// Determines whether the specified input string matches the given pattern, which supports '.' and '*' regular
        /// expression operators.
        /// </summary>
        /// <remarks>The pattern supports only the '.' and '*' operators, similar to a simplified regular
        /// expression engine. The entire input string must match the pattern for the method to return true.</remarks>
        /// <param name="s">The input string to test against the regular expression pattern. Cannot be null.</param>
        /// <param name="p">The regular expression pattern to match, where '.' matches any single character and '*' matches zero or more
        /// of the preceding element. Cannot be null.</param>
        /// <returns>true if the input string matches the pattern; otherwise, false.</returns>
        public bool IsRegularExpressionMatch(string s, string p)
        {
            // m = length of input string
            int m = s.Length;

            // n = length of pattern
            int n = p.Length;

            // Create DP table of size (m+1) x (n+1)
            // Why +1?
            // Because we also handle empty string case (0 characters)
            bool[,] dp = new bool[m + 1, n + 1];

            // Base case:
            // Empty string matches empty pattern
            dp[0, 0] = true;

            // -----------------------------------------
            // Handle patterns like: a*, a*b*, a*b*c*
            // These can match empty string
            // -----------------------------------------

            for (int j = 2; j <= n; j++)
            {
                // If current pattern character is '*'
                if (p[j - 1] == '*')
                {
                    // We check dp[0][j-2]
                    // Why j-2?
                    // Because '*' works with previous character
                    // So we ignore previous character + '*'
                    dp[0, j] = dp[0, j - 2];
                }
            }

            // -----------------------------------------
            // Fill the rest of DP table
            // -----------------------------------------

            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    // Case 1:
                    // If characters match OR pattern has '.'
                    if (p[j - 1] == '.' || p[j - 1] == s[i - 1])
                    {
                        // If current characters match,
                        // result depends on previous substring
                        dp[i, j] = dp[i - 1, j - 1];
                    }

                    // Case 2:
                    // If pattern character is '*'
                    else if (p[j - 1] == '*')
                    {
                        // Option 1: Treat '*' as ZERO occurrences
                        // So ignore previous char + '*'
                        dp[i, j] = dp[i, j - 2];

                        // Option 2: Treat '*' as ONE OR MORE occurrences
                        // This only works if preceding character matches
                        if (p[j - 2] == '.' || p[j - 2] == s[i - 1])
                        {
                            // If match,
                            // reduce string only (i-1)
                            // keep pattern same (j)
                            dp[i, j] |= dp[i - 1, j];
                        }
                    }

                    // Case 3:
                    // If no match and not '*'
                    // dp[i,j] remains false by default
                }
            }

            // Final answer:
            // Does full string match full pattern?
            return dp[m, n];
        }
        #endregion
    }
}
