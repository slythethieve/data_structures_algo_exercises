using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace arrays
{
    public class CustomArray<T>
    {
        
        private T[] _array;

        public int Length { get {return _array.Length; } }

        private int _highestIndex = 0;
        public CustomArray(int length) {
            _array = new T[length];
        }

        public void Insert(T value) {
            if (_highestIndex == _array.Length){
                T[] newArray = new T[_array.Length * 2];
                _array.CopyTo(newArray, 0);
                _array = newArray;
                
            }
            _array[_highestIndex++] = value;
        }

        public void RemoveAt(int index) {
            if (index < 0 || index >= _array.Length) {
                Console.WriteLine("Error");
            }else if (index == _highestIndex) {
                Array.Clear(_array, _highestIndex--, 1);
            }else if (index < _highestIndex) {
                
            }
        }

        public int IndexOf(T value) {
            for(int i = 0; i < _array.Length; i++){
                if (_array[i].Equals(value))
                    return i;
            }
            return - 1;
        }

        public T this[int index] {
            get{ return _array[index]; }
        }

        
    }
}