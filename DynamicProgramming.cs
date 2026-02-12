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
        #endregion
    }
}
