using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stacks
{
    public class StackImplementaionNormalArray
    {
        private int[] _array;

        private int emptyIndex1;
        private int emptyIndex2;

        public StackImplementaionNormalArray(int length) {
            if (length <= 1)
                throw new ArgumentException("Cannot have a double stack with a length of less than 2");
            _array = new int[length];
            emptyIndex1 = 0;
            emptyIndex2 = _array.Length - 1;
        }

        public bool IsEmpty1() {
            return emptyIndex1 == 0;
        }

        // Maybe there are some indices errors in this class. 
        public bool IsEmpty2() {
            return emptyIndex2 == _array.Length - 1;
        }

        public bool IsFull() {
            return emptyIndex1 == emptyIndex2;
        }

        public void Push1(int item) {
            if (IsFull()) 
                throw new Exception("Stack1 is full.");
            _array[emptyIndex1++] = item;
            
        }

        public void Push2(int item) {
            if (IsFull()) 
                throw new Exception("Stack2 is full.");
            _array[emptyIndex2--] = item;
        }

        
        public int Pop1() {
            if(IsEmpty1())
                throw new Exception("Stack 1 is empty");
            return _array[--emptyIndex1];
        }

        public int Pop2() {
            if(IsEmpty2()) 
                throw new Exception("Stack 2 is empty");
            return _array[++emptyIndex2];
        }

        public void PrintContent() {
            Console.WriteLine("Content of the first stack");
            if (emptyIndex1 == 0) 
                Console.WriteLine("First stack is empty");
            else{
                for(int i = emptyIndex1 - 1; i >= 0; i--) {
                    Console.WriteLine(_array[i]);
                }
            }
            Console.WriteLine("Content of the second stack");
            if (emptyIndex2 == _array.Length - 1) 
                Console.WriteLine("Second stack is empty");
            else{
                for(int i = emptyIndex2 + 1; i < _array.Length; i++) {
                    Console.WriteLine(_array[i]);
                }
            }

        }

    }
}