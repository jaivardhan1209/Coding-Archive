using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codepractice.Queue
{
    public class CSharpQueue
    {

        public Queue<int> queue { get; private set; }

        public CSharpQueue(Queue<int> input)
        {
            this.queue = input;
        }

        public void addElement(int a)
        {
            this.queue.Enqueue(a);
        }

        public int RemoveElement()
        {
            return queue.Dequeue();
        }
    }
}
