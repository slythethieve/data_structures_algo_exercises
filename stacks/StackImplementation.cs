using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stacks
{
    public class StackImplementation
    {
        private int[] _array;
        private int _currentIndex = -1;

        public bool IsEmpty
        {
            get
            {
                return (_currentIndex >= 0) ? false : true;
            }
        }

        public StackImplementation(int length)
        {
            _array = new int[length];
        }

        

        public void Push(int item)
        {
            // I have decided to implement the stack with a dynamic array
            if (_currentIndex >= _array.Length)
            {
                var newArray = new int[_array.Length * 2];
                _array.CopyTo(newArray, 0);
                _array = newArray;
            }

            _array[++_currentIndex] = item;
        }

        public int Pop()
        {
            if (_currentIndex <= 0)
                throw new InvalidOperationException("The stack is empty");
            return _array[_currentIndex--];
        }

        public void PrintContent()
        {
            for (int i = _currentIndex; i >= 0; i--)
            {
                Console.WriteLine(_array[i]);
            }
        }

        public int Peek()
        {
            if (_currentIndex <= 0)
                throw new InvalidOperationException("The stack is empty");
            return _array[_currentIndex];
        }




    }
}