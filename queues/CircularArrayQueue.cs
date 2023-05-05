using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace queues
{
    public class CircularArrayQueue
    {
        private int[] _array;
        private int _front = 0;
        private int _rear = 0;

        private int count = 0;

        public bool IsEmpty
        {
            get
            {
                return count == 0;
            }
        }

        public bool IsFull
        {
            get
            {
                return count == _array.Length;
            }
        }

        public CircularArrayQueue(int length)
        {
            _array = new int[length];
        }

        public void Enqueue(int item)
        {
            if (IsFull)
                throw new Exception("The queue is full");

            _array[_rear] = item;
            _rear = (_rear + 1) % _array.Length;
            count++;
        }

        public int Dequeue() {
            if (IsEmpty)
                throw new Exception("The queue is empty");
            
            int result = _array[_front];
            _front = (_front + 1) % _array.Length;
            count--;
            return result;
        }

        public void PrintContent() {
            int index = _front;
            for (int i = 0; i < count; i++) {
                Console.WriteLine(_array[index]);
                index = (index + 1) % _array.Length;
            }
        }
    }
}