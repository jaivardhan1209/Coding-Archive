using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codepractice.Array
{
    public class MaxDiffArray
    {

        public int FindMAxDiff(int[] arr)
        {
           
            if (arr.Length == 0)
                return -1;
            int max = int.MinValue;
            int min = int.MaxValue;

            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i - 1] > arr[i])
                {
                    if (min > arr[i])
                    {
                        min = arr[i];
                        continue;
                    }
                }
                else
                {
                    max = max < arr[i] ? arr[i] : max;
                }
            }

            return max - min > 0 ? max - min : -1;
        }
    }
}
