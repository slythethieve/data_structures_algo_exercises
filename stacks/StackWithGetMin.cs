using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stacks
{
    public class StackWithGetMin
    {
        private int[] _array;

        private int emptyIndex = 0;

        private int minimumValue = 0;

        public StackWithGetMin(int length) {
            _array = new int[length];
        }

        public void Push(int item) {
            if (emptyIndex == _array.Length)
                throw new StackOverflowException("Stack is full");
            
            _array[emptyIndex++] = item;

            if (_array[emptyIndex - 1] <= _array[minimumValue]) {
                minimumValue = emptyIndex - 1;
            }
        }

        public int Pop() {
            if (emptyIndex == 0)
                throw new Exception("Stack is empty");

            if (minimumValue == emptyIndex - 1) 
                minimumValue = UpdateMinValue();

            return _array[--emptyIndex];
        }

        public int GetMinimum() {
            if  (emptyIndex == 0)
                throw new Exception("Stack is empty");

            return _array[minimumValue];
        }

        private int UpdateMinValue() {
            int newMinIndex = 0;
            for (int i = 0; i <= emptyIndex - 2; i++) {
                if (_array[i] <= _array[newMinIndex])
                    newMinIndex = i;
            }
            
            return newMinIndex;
        }

    }
}