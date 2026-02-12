using System.Reflection;

namespace DSARoadmap.Common.CommonServices
{
    public class CommonServices
    {
        /// <summary>
        /// Writes each element of the specified collection to the console, displaying its value along with its index in
        /// the sequence.
        /// </summary>
        /// <remarks>The output format displays each element followed by its index in parentheses,
        /// separated by commas. This method is intended for diagnostic or display purposes and writes directly to the
        /// standard output.</remarks>
        /// <typeparam name="T">The type of elements contained in the input collection.</typeparam>
        /// <param name="inputArray">The collection of elements to be written to the console. Each element will be displayed with its
        /// corresponding index.</param>
        /// <param name="preText">An optional string to prefix the output. If not specified, no prefix is added.</param>
        public void WriteArrayWithIndices<T>(IEnumerable<T> inputArray, string preText = "Array: ")
        {
            Console.WriteLine($"{preText} [{string.Join(", ", inputArray.Select((value, index) => $"{value}({index})"))}]");
        }

        /// <summary>
        /// Writes the elements of the specified array to the console, prefixed by the specified text.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the input array.</typeparam>
        /// <param name="inputArray">The sequence of elements to write to the console. Cannot be null.</param>
        /// <param name="preText">The text to display before the array elements. If not specified, defaults to "Array: ".</param>
        public void WriteArray<T>(IEnumerable<T> inputArray, string preText = "Array: ")
        {
            Console.WriteLine($"{preText} [{string.Join(", ", inputArray)}]");
        }

        /// <summary>
        /// Writes a 2D list of integers to the console in a matrix format.
        /// </summary>
        /// <param name="list"></param>
        public void Print2DList(IList<IList<int>> list)
        {
            foreach (var row in list)
            {
                foreach (var val in row)
                {
                    Console.Write(val + " ");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// This method prints Pascal's Triangle in a formatted manner to the console. Each row of the triangle is centered
        /// </summary>
        /// <param name="triangle"></param>
        public void PrintPascalTriangle(IList<IList<int>> triangle)
        {
            int numRows = triangle.Count;

            for (int i = 0; i < numRows; i++)
            {
                // Print leading spaces (to center-align)
                for (int space = 0; space < numRows - i - 1; space++)
                {
                    Console.Write("  ");
                }

                // Print numbers in the row
                foreach (int val in triangle[i])
                {
                    Console.Write(val + "   ");
                }

                Console.WriteLine();
            }
        }

        /// <summary>
        /// This method prints the contents of a dictionary to the console using a custom formatter function.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="formatter"></param>
        public void PrintDictionary<TKey, TValue>(Dictionary<TKey, TValue> dictionary, Func<TKey, TValue, string> formatter)
        {
            if (dictionary == null || dictionary.Count == 0)
            {
                Console.WriteLine("Dictionary is empty.");
                return;
            }

            foreach (var item in dictionary)
            {
                Console.WriteLine(formatter(item.Key, item.Value));
            }
        }

        /// <summary>
        /// This method prints the properties and their values of an object or a collection of objects to the console.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="preText"></param>
        public void PrintKeyValue(object data, string preText = "List")
        {
            if (data == null)
            {
                Console.WriteLine(preText);
                Console.WriteLine("No data");
                return;
            }

            // Handle collection
            if (data is System.Collections.IEnumerable list && !(data is string))
            {
                Console.WriteLine(preText);
                int index = 1;
                foreach (var item in list)
                {
                    Console.WriteLine($"--- Record {index++} ---");
                    PrintSingleObject(item);
                    Console.WriteLine();
                }
            }
            else
            {
                PrintSingleObject(data);
            }
        }

        /// <summary>
        /// This method uses reflection to print the properties and their values of a single object to the console. It handles primitive types, strings, enums, and complex objects by iterating through their properties. If a property value cannot be retrieved, it catches the exception and prints an error message instead.
        /// </summary>
        /// <param name="obj"></param>
        private static void PrintSingleObject(object obj)
        {
            if (obj == null)
            {
                Console.WriteLine("NULL");
                return;
            }

            var type = obj.GetType();

            // Print primitives and strings directly
            if (type == typeof(string) || type.IsPrimitive || type.IsEnum || type == typeof(decimal))
            {
                Console.WriteLine(obj.ToString());
                return;
            }

            var properties = type.GetProperties();

            foreach (var prop in properties)
            {
                // Skip indexer properties (they require parameters)
                if (prop.GetIndexParameters().Length > 0)
                    continue;

                object value;
                try
                {
                    value = prop.GetValue(obj) ?? "NULL";
                }
                catch (TargetInvocationException)
                {
                    value = "Error retrieving value";
                }
                catch (TargetParameterCountException)
                {
                    value = "Indexer requires parameters";
                }

                Console.WriteLine($"{prop.Name} : {value}");
            }
        }
    }
}
