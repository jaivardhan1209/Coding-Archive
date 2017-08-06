using System;

namespace CodePractice
{
    public class SubArray
    {
        public static bool FindSubArrayDiffWay(int[] arr)
        {
            if (arr.Length <= 1)
                return false;

            //var sum = arr[0];
            var lenght = arr.Length - 1;
            // Create commutative sum array 
            for (int i = 1; i < arr.Length; i++)
            {
                arr[i] = arr[i-1] + arr[i];
            }
            // first value is potential candidate 
            if (arr[lenght] - arr[0] == 0)
                return true;
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i - 1] == arr[lenght] - arr[i])
                    return true;
            }
            return false;
        }

        public int MaxSubArray(int[] arr)
        {
            if (arr.Length == 0)
                return 0;

            int GlobalMax = 0;
            int sum = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
                if (sum > GlobalMax)
                    GlobalMax = sum;
                if (sum <= 0)
                {
                    // Reset the sum to start new sequence
                    sum = 0;
                }
            }

            return GlobalMax;
        }
    }
}