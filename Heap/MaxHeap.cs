using System;

namespace Codepractice.Heap
{
    public class MaxHeap
    {
        public int[] arr { get; set; }

        public MaxHeap(int[] a)
        {
            this.arr = a;
        }
        public void HeapOperation()
        {
            this._HeapOperation();
        }

        private void _HeapOperation()
        {
            int len = this.arr.Length-1;

            for(int i = len/2; i >= 0; i--)
            {
                int leftIndex = 2 * i + 1;
                int rightIndex = 2 * i + 2;
                int max = 0;
                if (rightIndex > len - 1)
                {
                    max = arr[leftIndex];
                }
                else
                {
                    max = arr[leftIndex] > arr[rightIndex] ? arr[leftIndex] : arr[rightIndex];
                }
                if(max > arr[i])
                {
                    int index = 0;
                    if (rightIndex > len - 1)
                    {
                        index = leftIndex;
                    }
                    else
                    {
                        index = arr[leftIndex] > arr[rightIndex] ? leftIndex : rightIndex;
                    }
                    int temp = arr[i];
                    arr[i] = max;
                    arr[index] = temp;
                    // call heapify for lower hierarchy node
                    _Heapify(index);
                }
            }
        }

        private void _Heapify(int currentIndex)
        {
            for(int i = currentIndex; i<= arr.Length/2;i++)
            {
                int leftIndex = 2 * i + 1;
                int rightIndex = 2 * i + 2;
                int max = 0;
                int index = 0;
                if (rightIndex > arr.Length - 1 && leftIndex > arr.Length -1)
                {
                    return;
                }
                else if(rightIndex > arr.Length - 1 && leftIndex <= arr.Length - 1)
                {
                    max = arr[leftIndex];
                    index = leftIndex;
                }
                else
                {
                    max = arr[leftIndex] > arr[rightIndex] ? arr[leftIndex] : arr[rightIndex];
                    index = arr[leftIndex] > arr[rightIndex] ? leftIndex : rightIndex;
                }
                if (max > arr[i])
                {
                    int temp = arr[i];
                    arr[i] = max;
                    arr[index] = temp;
                    // call heapify for lower hierarchy node
                    _Heapify(index);
                }
            }

        }

        public void showHeap()
        {
            foreach (var element in arr)
                Console.Write(element + " ");
        }
    }
}
