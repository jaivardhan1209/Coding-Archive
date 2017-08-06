using System;
using System.Collections.Generic;

namespace Codepractice.String
{
    /// <summary>
    /// The string operarion.
    /// </summary>
    public class StringOperarion
    {

        #region Permutation
        /// <summary>
        /// The test recusion.
        /// </summary>
        public void TestRecusion()
        {
           // this._TestRecursion(0,len);
            var brr = new int[4];
            int[] arr = { 0, 1 };
           this._TestRecursion(arr, brr, 0, brr.Length);
        }

        private void _TestRecursion(int[] arr, int[] brr, int index, int len)
        {
            if (index == len)
            {
                this.PrintArrayInt(brr);
                return;
            }

            foreach (var t in arr)
            {
                brr[index] = t;
                this._TestRecursion(arr, brr, index + 1, len);
            }
        }

        /// <summary>
        /// The permutate.
        /// </summary>
        /// <param name="arr">
        /// The arr.
        /// </param>
        public void Permutate(char[] arr)
        {
            this._Permutate(arr, 0);
        }

        /// <summary>
        /// The print array int.
        /// </summary>
        /// <param name="b">
        /// The b.
        /// </param>
        private void PrintArrayInt(int[] b)
        {
            foreach (int t in b) Console.Write(t);
            Console.WriteLine();
        }

        /// <summary>
        /// The print array.
        /// </summary>
        /// <param name="b">
        /// The b.
        /// </param>
        private void PrintArray(IReadOnlyList<char> b)
        {
            for (int i = 0; i < b.Count; i++) Console.Write(b[i]);
            Console.WriteLine();
        }



        private void _Permutate(char[] a, int index)
        {
            if (a.Length == index)
            {
                PrintArray(a);
                return;
            }
            for (var i = index; i < a.Length; i++)
            {
                this.swap(a, i, index);
                _Permutate(a, index+1);

                this.swap(a, i, index);
            }
        }

        private void swap(char[] arr, int i, int j)
        {
            var temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        #endregion

        #region Longest Common sequence
        private int max(int a, int b)
        {
            return a > b ? a : b;
        }

        public int Lcs(string a, string b, int indexa, int indexb, ref string c)
        {
            if (a.Length <= indexa || b.Length <= indexb) return 0;

            if ((a[indexa]) == (b[indexb]))
            {
                c = c + a[indexa];
                return this.Lcs(a, b, indexa + 1, indexb + 1, ref c) + 1;
            }
            else
            {
                return this.max(this.Lcs(a, b, indexa + 1, indexb, ref c), this.Lcs(a, b, indexa, indexb + 1, ref c));
            }
        }

        public int LCSDP(string a, string b)
        {
            var lena = a.Length;
            var lenb = b.Length;
            var arr = new int[lena, lenb];

            if (a[0] == b[0]) arr[0, 0] = 1;

            for (var i = 1; i < a.Length; i++)
            {
                for (var j = 1; j < b.Length; j++)
                {
                    if (a[i - 1] == b[j - 1]) arr[i, j] = arr[i - 1, j - 1] + 1;
                    else
                    {
                        arr[i, j] = this.max(arr[i - 1, j], arr[i, j - 1]);
                    }
                }
            }

            return arr[lena - 1, lenb - 1];
        }

        #endregion

        #region powerSet
        /// Power set of the string 
        public void PowerSet(string a, string b, int index)
        {
            if (a.Length <= index)
            {
                Console.WriteLine(b);
                return;
            }

            PowerSet(a, b + a[index], index + 1);
            PowerSet(a, b, index + 1);
        }

        public void ProperPowerSet(string a, string b, int index)
        {
            if (a.Length <= index)
            {
                if(b.Length != 0 && b.Length != a.Length)
                Console.WriteLine(b);
                return;
            }

            ProperPowerSet(a, b + a[index], index + 1);
            ProperPowerSet(a, b, index + 1);
        }

        #endregion

        #region Minimum no of Partition for Pallindrom

        public void Substring(string a)
        {
            if (a.Length == 0) return;
            int len = a.Length;
            // iterate for each length
            for (int i = 1; i < a.Length; i++)
            {
                for (int j = 0; j <= a.Length - i; j++)
                {
                    Console.WriteLine(a.Substring(j, i));
                }
            }

        }

        // find minimum number of partition required
        public int MinPartition(string s, int lower, int upper, ref int value)
        {
            if (lower == upper)
                return 0;
            if (Ispallindrom(s, lower, upper))
                return 0;
            for (int i = lower; i <= upper; i++)
            {
                int val = MinPartition(s, lower, i, ref value) + MinPartition(s, i + 1, upper, ref value) + 1;
                if (val < value)
                    value = val;
            }
            return 0;
        }

        private bool Ispallindrom(string s, int lowerIndex, int upperIndex)
        {
            if (lowerIndex == upperIndex)
                return true;
            while (lowerIndex <= upperIndex)
            {
                if (s[lowerIndex] != s[upperIndex])
                    return false;
                lowerIndex++;
                upperIndex--;
            }

            return true;
        }

        #endregion
    }
}
