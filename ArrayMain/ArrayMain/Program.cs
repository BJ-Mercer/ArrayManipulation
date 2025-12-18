using System;

namespace ArrayMain
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sampleArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // Example usage of ArrayRotationTool
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

        }

        //A function to rotate an array by a given number of positions
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

        //A function to calculate the prefix sum of a given array
        public static int[] PrefixSumArrayCalculator(int[] arr)
        {
            int[] answer = new int[arr.Length];
            answer[0] = arr[0];

            if(arr.Length <= 0)
            {
                throw new ArgumentException("Array must contain at least one element.");
            }
            else if(arr.Length == 1)
            {
                return answer;
            }

            for (int i = 1; i < arr.Length; i++)
            {
                answer[i] = answer[i - 1] + arr[i];
            }

            return answer;
        }

        //A function to find duplicate elements in an array
        public static string DuplicateFinder(int[] arr)
        {
            //edge case for empty array
            if (arr.Length <= 0)
            {
                throw new ArgumentException("Array must contain at least one element.");
            }

            //Using a dictionary to count occurrences of each element
            Dictionary<int,int> duplicatesTable = new Dictionary<int,int>();
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
                if(item.Value > 1)
                {
                    answer += $"Element {item.Key} is duplicated {item.Value} times.\n";
                }
            }

            return answer;
        }


    }
}