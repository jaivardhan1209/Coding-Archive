using System;
using System.Linq;
using System.Text;

namespace Codepractice.Recursion
{
    public class Permutation
    {

        public  void PrintAllPermutation()
        {
            int[] arr = new int[3];
            int[] b = new int[] { 0, 1 };
            _PrintAllPermutation(arr, b, 2, 0);
        }

        private void _PrintAllPermutation(int[] arr, int[] b, int len, int index)
        {
            if(index > len)
            {
                
                _PrintAray(arr);
                return;
            }

            for(int i = 0; i< len; i++)
            {
                arr[index] = b[i];
                _PrintAllPermutation(arr, b, len, index+1);
            }
        }

        private void _PrintAray(int[] arr)
        {
            foreach(var data in arr)
            {
                Console.Write(data);
            }
            Console.WriteLine();
        }

        public void Combination()
        {
            StringBuilder abc = new StringBuilder("abc");
            _Combination(abc, 0);
        }

        private void _Combination(StringBuilder abc,int index)
        {
            if(index == abc.Length)
            {
                Console.WriteLine(abc);
                return;
            }

            for(int i = index; i < abc.Length; i++)
            {
                Swap(abc, i, index);
                _Combination(abc, index + 1);
                Swap(abc, index, i);

            }
        }

        private void Swap(StringBuilder abc, int indexa, int indexb)
        {
            var temp = abc[indexa];
            abc[indexa] = abc[indexb];
            abc[indexb] = temp;
        }
    }
}
