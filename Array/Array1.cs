using System;

namespace CodePractice
{
    /// <summary>
    /// The array coding.
    /// </summary>
    public class ArrayCoding
    {
        /// <summary>
        /// Gets or sets the input.
        /// </summary>
        private int[] input { get; set; }

        ArrayCoding(int size)
        {
            input = new int[size];
        }
        private static int Min(int a, int b)
        {
            return a > b ? b : a;
        }

        private static int absoluteValue(int i, int j)
        {
            return i > j ? i - j : j - i;
        }
        public static int ProcessArray(int[] arr)
        {
            if (arr.Length <= 0)
                return 0;
            int max = 0;
            int start = 0;
            int End = arr.Length - 1;
            while (start < End)
            {
                var val = Min(arr[start], arr[End]) * absoluteValue(start, End);
                if (val > max)
                    max = val;
                if (arr[start] > arr[End])
                    End--;
                else
                    start++;
            }

            return max;

        }
    }
}