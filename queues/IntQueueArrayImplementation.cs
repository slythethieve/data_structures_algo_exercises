using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace queues
{

    // This time I've decided to just use a normal array.
    // It's not that difficult actually to implment one using a dynamic array
    public class IntQueueArrayImplementation
    {
        private int[] _array;

        private int emptyIndex = 0;

        public bool IsEmpty
        {
            get
            {
                return emptyIndex == 0 ? true : false;
            }
        }

        public bool IsFull
        {
            get
            {
                return emptyIndex == _array.Length ? true : false;
            }
        }

        public IntQueueArrayImplementation(int length)
        {
            _array = new int[length];
        }

        public void Enqueue(int item)
        {
            if (IsFull)
                throw new Exception("The queue is full");
            _array[emptyIndex++] = item;
        }

        public int Peek() {
            if(IsEmpty)
                throw new Exception("The queue is empty");
            return _array[0];
        }

        public int Dequeue() {
            if (IsEmpty)
                throw new Exception("The queue is empty");
            var item = _array[0];
            ShiftElements();
            emptyIndex--;
            return item;
        }

        private void ShiftElements() {
            for (int i = 1; i < emptyIndex; i++) {
                _array[i -1] = _array[i];
            }
            _array[emptyIndex - 1] = 0;
        }

        public void Reverse() {
            var stack = new Stack<int>();
            while(!IsEmpty)
                stack.Push(Dequeue());
            while(stack.Count != 0)
                Enqueue(stack.Pop());
        }

        public override string ToString()
        {
            if (IsEmpty)
                return "The queue is empty";

            var output = "";
            for (int i = 0; i < emptyIndex; i++)
            {
                output += _array[i] + " ";
            }
            return output;
        }


    }
}