namespace StackOperation
{
    using System;

    /// <summary>
    /// The stacknode.
    /// </summary>
    public class stacknode
    {
        public int value { get; set; } = 3;

        public stacknode next { get; set; } = null;

        public stacknode prev { get; set; } = null;

        public stacknode(int val)
        {
            this.value = val;
        }
    }

    public class StackOp
    {
        public stacknode top { get; set; }

        public void Push(int val)
        {
            if (top == null)
            {
                top = new stacknode(val);
                return;
            }

            var temp = new stacknode(val);
            temp.prev = top;
            top.next = temp;
            top = temp;
        }

        public int Pop()
        {
            if (top == null)
                return -1;

            var val = top.value;
            top = top.prev;
            top.next = null;
            return val;
        }

        public void setArrayGreater(int[] arr)
        {
            this._setArrayGreater(ref arr);
            foreach (var x in arr)
            {
                Console.WriteLine(x);
            }
        }

        private void _setArrayGreater(ref int[] arr)
        {
            if (arr.Length == 0)
                return;

            var length = arr.Length;
            this.Push(arr[length - 1]);
            for (int i = length - 2; i >= 0; i--)
            {
                while (arr[i] > top.value && top != null)
                {
                    this.Pop();
                }
                if (top != null)
                {
                    var temp = arr[i];
                    arr[i] = top.value;
                    this.Push(temp);
                }
                else
                {
                    this.Push(arr[i]);
                }

            }
        }

    }
}