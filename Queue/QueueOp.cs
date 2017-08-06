using System;

namespace queueoperation
{
    public class QueueNode
    {
        public int value { get; set; }
        public QueueNode next { get; set; }
        public QueueNode prev { get; set; }

        public QueueNode(int val)
        {
            this.next = null;
            this.prev = null;
            this.value = val;
        }
    }

    public class QueueOperation
    {
        private QueueNode front { get; set; }
        private QueueNode rear { get; set; }
        public void Enqueue(int num)
        {
            var node = new QueueNode(num);
            if (front == null && rear == null)
            {
                front = node;
                rear = node;
            }
            else
            {
                rear.next = node;
                node.prev = rear;
                rear = node;
            }
        }

        public int Dequeue()
        {
            if (rear == null)
                return -1;

            var val = front.value;
            front = front.next;
            return val;
        }

        public void display()
        {
            var node = front;
            while (node != null)
            {
                Console.WriteLine(node.value);
                node = node.next;
            }
        }
    }
}