using System;

namespace ArrayMain
{
    class Program
    {
        /// <summary>
        /// Serves as the entry point for the application.
        /// </summary>
        /// <param name="args">An array of command-line arguments supplied to the application.</param>
        static void Main(string[] args)
        {
            int[] sampleArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            var test = ArrayRotationTool(sampleArray, 3); // rotates the array by 3 positions, resulting in {4, 5, 6, 7, 8, 9, 1, 2, 3}
            foreach (var item in test)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();

            int[] sampleArray2 = { 2, 4, 6, 8 };

            var test2 = PrefixSumArrayCalculator(sampleArray2); // results in {2, 6, 12, 20}
            foreach (var item in test2)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();

            int[] sampleArray3 = [1, 2, 3, 2, 4, 3, 5];

            Console.WriteLine(DuplicateFinder(sampleArray3)); // results in "Element 2 is duplicated 2 times. Element 3 is duplicated 2 times."

            int[] sampleArray4 = { 10, 20, 30, 40, 50 };
            var test4 = MoveElement(sampleArray4, 1, 3); // moves the element at index 1 (20) to index 3, resulting in {10, 30, 40, 20, 50}
            foreach (var item in test4)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();

            int[] sampleArray5 = { 0, 1, 0, 0, 1, 0 };
            var test5 = SortAnArray(sampleArray5); // results in {0, 0, 0, 0, 1, 1}
            foreach (var item in test5)
            {
                Console.Write(item + " ");
            }   

            Console.WriteLine();

            var test6 = DescendingOrderSortArray(sampleArray5); // results in {1, 1, 0, 0, 0, 0}
            foreach (var item in test6)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Rotates the elements of the specified array to the left by the given number of positions.
        /// </summary>
        /// <remarks>If positions is greater than the length of the array, the rotation wraps around using
        /// the remainder of positions divided by the array's length. The original array is not modified.</remarks>
        /// <param name="arr">The array of integers to rotate. Cannot be null.</param>
        /// <param name="positions">The number of positions to rotate the array to the left. Must be a non-negative integer.</param>
        /// <returns>A new array containing the elements of the original array rotated to the left by the specified number of
        /// positions.</returns>
        /// <exception cref="ArgumentException">Thrown when positions is less than or equal to 0.</exception>
        public static int[] ArrayRotationTool(int[] arr, int positions)
        {
            int[] answer = new int[arr.Length];

            if (positions <= 0)
            {
                throw new ArgumentException("Positions must be a non-negative integer.");
            }

            //Handle cases where positions > array length
            positions = positions % arr.Length;

            int[] leftSide = arr[..positions];
            int[] rightSide = arr[positions..];

            return answer = rightSide.Concat(leftSide).ToArray();
        }

        /// <summary>
        /// Calculates the prefix sum array for the specified input array.
        /// </summary>
        /// <param name="arr">The input array of integers for which to compute the prefix sums. Must contain at least one element.</param>
        /// <returns>An array of integers where each element at index n is the sum of all elements from index 0 to n in the input
        /// array.</returns>
        /// <exception cref="ArgumentException">Thrown when the input array contains no elements.</exception>
        public static int[] PrefixSumArrayCalculator(int[] arr)
        {
            int[] answer = new int[arr.Length];
            answer[0] = arr[0];

            if (arr.Length <= 0)
            {
                throw new ArgumentException("Array must contain at least one element.");
            }
            else if (arr.Length == 1)
            {
                return answer;
            }

            for (int i = 1; i < arr.Length; i++)
            {
                answer[i] = answer[i - 1] + arr[i];
            }

            return answer;
        }

        /// <summary>
        /// returns a string listing all duplicate elements in the array along with their counts.
        /// </summary>
        /// <param name="arr">The source array</param>
        /// <returns><see cref="String"> that gives the duplicate and the count</returns>
        /// <exception cref="ArgumentException">Thrown if the source array is empty</exception>
        public static string DuplicateFinder(int[] arr)
        {
            //edge case for empty array
            if (arr.Length <= 0)
            {
                throw new ArgumentException("Array must contain at least one element.");
            }

            //Using a dictionary to count occurrences of each element
            Dictionary<int, int> duplicatesTable = new Dictionary<int, int>();
            foreach (var item in arr)
            {
                //If the item is already in the dictionary, increment its count
                if (duplicatesTable.ContainsKey(item))
                {
                    duplicatesTable[item] += 1;
                }
                else
                {
                    duplicatesTable[item] = 1;
                }
            }

            string answer = String.Empty;
            foreach (var item in duplicatesTable)
            {
                if (item.Value > 1)
                {
                    answer += $"Element {item.Key} is duplicated {item.Value} times.\n";
                }
            }

            return answer;
        }

        /// <summary>
        /// Returns a new array with the element at the specified index moved to a new position within the array.
        /// </summary>
        /// <remarks>If the source and destination indices are the same, the returned array is a copy of
        /// the original. The relative order of other elements is preserved.</remarks>
        /// <param name="arr">The source array containing the elements to be reordered. Must not be empty.</param>
        /// <param name="indexToMove">The zero-based index of the element to move. Must be within the bounds of the array.</param>
        /// <param name="indexToMoveTo">The zero-based index to which the element should be moved. Must be within the bounds of the array.</param>
        /// <returns>A new array with the specified element moved to the new position. The original array is not modified.</returns>
        /// <exception cref="ArgumentException">Thrown if the array is empty or if either index is outside the bounds of the array.</exception>
        public static int[] MoveElement(int[] arr, int indexToMove, int indexToMoveTo)
        {
            // edge case for empty array
            if (arr.Length <= 0)
            {
                throw new ArgumentException("Array must contain at least one element.");
            }

            if (indexToMove < 0 || indexToMove >= arr.Length || indexToMoveTo < 0 || indexToMoveTo >= arr.Length)
            {
                throw new ArgumentException("Indices must be within the bounds of the array.");
            }

            int[] answer = (int[])arr.Clone();

            int value = answer[indexToMove];

            // Shift elements to make space for the moved element
            if (indexToMove < indexToMoveTo)
            {
                Array.Copy(answer, indexToMove + 1, answer, indexToMove, indexToMoveTo - indexToMove); // shift left
            }
            else
            {
                Array.Copy(answer, indexToMoveTo, answer, indexToMoveTo + 1, indexToMove - indexToMoveTo); // shift right
            }

            // Place the moved element at its new position
            answer[indexToMoveTo] = value;
            return answer;

        }

        /// <summary>
        /// Returns a new array containing the elements of the specified array sorted in ascending order.
        /// </summary>
        /// <param name="arr">The array of integers to sort. Must contain at least one element.</param>
        /// <returns>A new array with the elements of <paramref name="arr"/> sorted in ascending order. The original array is not
        /// modified.</returns>
        /// <exception cref="ArgumentException">Thrown if <paramref name="arr"/> is empty.</exception>
        public static int[] SortAnArray(int[] arr)
        {
            // edge case for empty array
            if (arr.Length <= 0)
            {
                throw new ArgumentException("Array must contain at least one element.");
            }

            int[] answer = (int[])arr.Clone();
            Array.Sort(answer);

            return answer;
        }

        /// <summary>
        /// Sorts the elements of the specified array in descending order and returns a new array containing the sorted
        /// elements.
        /// </summary>
        /// <param name="arr">The array of integers to sort. Must contain at least one element.</param>
        /// <returns>A new array containing the elements of <paramref name="arr"/> sorted in descending order.</returns>
        /// <exception cref="ArgumentException">Thrown if <paramref name="arr"/> is empty.</exception>
        public static int[] DescendingOrderSortArray(int[] arr)
        {
            // edge case for empty array
            if (arr.Length <= 0)
            {
                throw new ArgumentException("Array must contain at least one element.");
            }

            int[] answer = (int[])arr.Clone();
            Array.Sort(answer);
            
            return answer.Reverse().ToArray();
        }
    }
}