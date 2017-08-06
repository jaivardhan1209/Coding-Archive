namespace Codepractice.Array
{
    public class Grab_Array
    {
        public int FindTriplet(int[] arr)
        {
            // base condition for minimum length Array
            if (arr == null || (arr.Length < 5))
            {
                return 0;
            }

            // Commutative sum till current index from left
            var tillLeftSum = new int[arr.Length];
            // Commutative sum till current index from right
            var tillRightSum = new int[arr.Length];

            tillLeftSum[0] = arr[0];

            // populate left Array
            for (var index = 1; index < arr.Length; index++)
            {
                tillLeftSum[index] += tillLeftSum[index - 1] + arr[index];
            }

            // Populate right sum array
            tillRightSum[arr.Length - 1] = arr[arr.Length - 1];
            for (var indexright = arr.Length - 2; indexright >= 0; indexright--)
            {
                tillRightSum[indexright] += tillRightSum[indexright + 1] + arr[indexright];
            }
            
            // run loop to find index
            int i = 1, j = arr.Length - 2;

            var totalsum = tillLeftSum[tillLeftSum.Length - 1];
            // run loop to find index
            while (i < j)
            {

                var leftSum = tillLeftSum[i - 1];

                var rightSum = tillRightSum[j + 1];

                var midSum = totalsum - tillLeftSum[i] - tillRightSum[j];

                // if Left sum greater than right decrese index of right to increase its value
                if (leftSum > rightSum)
                {
                    j--;
                }
                // if rightsum > leftsum increase left index
                else if (leftSum < rightSum)
                {
                    i++;
                }
                // Happy codition leftsum = rightsum 
                else
                {
                    if (leftSum == rightSum && rightSum == midSum)
                        return 1;
                    // incerase left index and decrease right index
                    i++;
                    j--;
                }
            }

            return 0;
        }
    }
}
