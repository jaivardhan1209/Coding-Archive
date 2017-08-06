using System;

namespace CodePractice
{
    /// <summary>
    /// The array product.
    /// </summary>
    public class ArrayProduct
    {
        /// <summary>
        /// The find max.
        /// </summary>
        /// <param name="arr">
        /// The arr.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public static int FindMax(int[] arr)
        {
            if (arr.Length <= 0 || (arr.Length == 1 && arr[0] < 0)) return 0;

            int GlobalMax = 1;
            int GlobalMin = 1;

            int localMax = 1;
            int localmin = 1;

            int maxSize = 0;
            int startIndex = 0;
            int EndIndex = 0;

            for(int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > 0)
                {
                    localMax = localMax * arr[i];
                    localmin = Min(localmin * arr[i], localmin);
                    EndIndex++;
                }

                if (arr[i] < 0)
                {
                    var localMaxtemp = Max(localMax, localmin * arr[i]);
                    localmin = Min(localMax * arr[i], localmin);
                    localMax = localMaxtemp;
                    EndIndex++;
                }
                if (arr[i] == 0)
                {
                    int temp = GlobalMax;
                    GlobalMax = GlobalMax < localMax ? localMax : GlobalMax;
                    maxSize = temp < localMax ? EndIndex - startIndex : maxSize;
                    localMax = 1;
                    localmin = 1;
                    startIndex = i;
                    EndIndex = i;
                }
            }
            //return GlobalMax < localMax ? localMax : GlobalMax;
            return maxSize;
        }

        /// <summary>
        /// The min.
        /// </summary>
        /// <param name="a">
        /// The a.
        /// </param>
        /// <param name="b">
        /// The b.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public static int Min(int a, int b)
        {
            return a > b ? b : a;
        }

        /// <summary>
        /// The max.
        /// </summary>
        /// <param name="a">
        /// The a.
        /// </param>
        /// <param name="b">
        /// The b.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public static int Max(int a, int b)
        {
            return a > b ? a : b;
        }
    }
}
