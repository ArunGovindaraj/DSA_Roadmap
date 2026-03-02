using DSARoadmap.LinkedList;
using System.Reflection;

namespace DSARoadmap.Common.CommonServices
{
    public class CommonServices
    {
        #region Write Array With Indices
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
        #endregion

        #region Write Array
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
        #endregion

        #region Print 2D List
        /// <summary>
        /// Writes a 2D list of integers to the console in a matrix format.
        /// </summary>
        /// <param name="list"></param>
        public void Print2DList<T>(IList<IList<T>> list)
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
        #endregion

        #region Print Pascal's Triangle
        /// <summary>
        /// This method prints Pascal's Triangle in a formatted manner to the console. Each row of the triangle is centered
        /// </summary>
        /// <param name="triangle"></param>
        public void PrintPascalTriangle<T>(IList<IList<T>> triangle)
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
                foreach (T val in triangle[i])
                {
                    Console.Write(val + "   ");
                }

                Console.WriteLine();
            }
        }
        #endregion

        #region Print Dictionary with Custom Formatter
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
        #endregion

        #region Print Key-Value Pairs of Object(s)
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
        #endregion

        #region Print Single Object Properties and Values
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
        #endregion

        #region Reverse Array In-Place - Generic Method
        /// <summary>
        /// Reverses the elements of the specified array in place between the given start and end indices.
        /// </summary>
        /// <remarks>Only the elements between start and end, inclusive, are reversed. The operation
        /// modifies the original array. If start is equal to end, the array remains unchanged.</remarks>
        /// <typeparam name="T">The type of elements contained in the array.</typeparam>
        /// <param name="array">The array whose elements will be reversed. Cannot be null.</param>
        /// <param name="start">The zero-based index of the first element in the range to reverse. Must be greater than or equal to 0 and
        /// less than the length of the array.</param>
        /// <param name="end">The zero-based index of the last element in the range to reverse. Must be greater than or equal to start and
        /// less than the length of the array.</param>
        public static void ReverseArray<T>(T[] array, int start, int end)
        {
            while (start < end)
            {
                T temp = array[start];
                array[start] = array[end];
                array[end] = temp;
                start++;
                end--;
            }
        }
        #endregion

        #region Create ListNode from Array - Generic Method
        /// <summary>
        /// Creates a singly linked list from the specified array of values.
        /// </summary>
        /// <remarks>The returned linked list preserves the order of elements as they appear in the input
        /// array. Each element in the array corresponds to a node in the list. The method does not modify the input
        /// array.</remarks>
        /// <typeparam name="T">The type of the values to include in the linked list.</typeparam>
        /// <param name="values">An array containing the values to populate the linked list. Cannot be null. If the array is empty, the
        /// method returns null.</param>
        /// <returns>The head node of a singly linked list containing the values from the array, in the same order. Returns null
        /// if the array is null or empty.</returns>
        public static ListNode<T> CreateList<T>(T[] values)
        {
            if (values == null || values.Length == 0)
                return null;

            ListNode<T> head = new ListNode<T>(values[0]);
            ListNode<T> current = head;

            for (int i = 1; i < values.Length; i++)
            {
                current.Next = new ListNode<T>(values[i]);
                current = current.Next;
            }

            return head;
        }
        #endregion

        #region Print Linked List - Generic Method
        /// <summary>
        /// Prints the contents of a singly linked list to the console, displaying each node's data in sequence.
        /// </summary>
        /// <remarks>Each node's data is printed followed by an arrow (" -> "), ending with "null" to
        /// indicate the end of the list. This method is intended for diagnostic or display purposes and writes output
        /// directly to the console.</remarks>
        /// <typeparam name="T">The type of the data stored in each node of the linked list.</typeparam>
        /// <param name="head">The head node of the linked list to print. If <paramref name="head"/> is null, only "null" will be printed.</param>
        public static void PrintList<T>(ListNode<T> head)
        {
            while (head != null)
            {
                Console.Write(head.Data + " -> ");
                head = head.Next;
            }

            Console.WriteLine("null");
        }
        #endregion
    }
}
