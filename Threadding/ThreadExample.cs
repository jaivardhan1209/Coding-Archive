using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;



namespace Codepractice.Threadding
{
    
    public class ThreadExample
    {
        //public Delegate ThreadDelegate(int arr);
        private readonly AutoResetEvent ResetEvent = new AutoResetEvent(true);

        public void ThreadExample1(int[] arr)
        {
            for(int i = 0; i < arr.Length; i = i +2)
            {
                ResetEvent.WaitOne();
                Console.WriteLine($"Thread1: {arr[i]}");
                ResetEvent.Set();
            }
        }

        public void ThreadExample2(int[] arr)
        {
            for (int i = 1; i < arr.Length; i = i + 2)
            {
                ResetEvent.WaitOne();
                Console.WriteLine($"Thread2: {arr[i]}");
                ResetEvent.Set();
            }
        }

        public void ThreadExample11()
        {
            int count = 0;
            while (count < 10)
            {
                Console.WriteLine("Thread1");
                count++;
            }
        }

        public void ThreadExample21()
        {
            int count = 0;
            while (count < 10)
            {
                Console.WriteLine("Thread2");
                count++;
            }
        }

        public void ThreadOperation()
        {
            var arr = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var abc = new object();

         //   var del1 = new ThreadDelegate();


            var thread1 = new Thread(() => ThreadExample1(arr));

            var thread2 = new Thread(() =>ThreadExample2(arr));


            //var thread3 = new Thread(new ThreadStart());
            //var thread4 = new Thread(new ParameterizedThreadStart(ThreadExample2(abc)));

            thread1.Start();
            thread2.Start();
        }
    }
}
