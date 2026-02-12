using DSARoadmap.Common.CommonServices;

namespace DSARoadmap.PropelArrayChallenge
{
    public class PropelArrayChallenge
    {
        #region Variables
        private readonly CommonServices commonServices;
        #endregion

        #region Constructor 
        /// <summary>
        /// Constructor of BinarySearch class
        /// </summary>
        /// <param name="_commonServices"></param>
        public PropelArrayChallenge(CommonServices _commonServices)
        {
            commonServices = _commonServices;
            Console.WriteLine("Adjacent number found on the multiplication of: " + ArrayChallenge(8) + ".");
        }
        #endregion

        /// <summary>
        /// This method takes an integer input and repeatedly multiplies it by its first digit, appending the digits of the result to a list. The process continues until two adjacent digits in the list are the same, at which point the method returns the number of multiplications performed.
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public int ArrayChallenge(int num)
        {
            List<char> digits = new List<char>();
            string current = num.ToString();

            // add initial digits
            foreach (char c in current)
                digits.Add(c);

            int multiplications = 0;

            while (true)
            {
                // multiply by first digit of current number
                int multiplier = current[0] - '0';
                int result = int.Parse(current) * multiplier;
                string resultStr = result.ToString();

                multiplications++;

                // append digits and check adjacent duplicates
                foreach (char c in resultStr)
                {
                    if (digits.Count > 0 && digits[digits.Count - 1] == c)
                        return multiplications;

                    digits.Add(c);
                }

                // update current number
                current = resultStr;
            }
        }
    }
}
