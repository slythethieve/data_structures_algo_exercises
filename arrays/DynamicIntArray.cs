using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace arrays
{
    public class DynamicIntArray
    {
        private int[] _array;

        private int currentIndex = 0;
        public DynamicIntArray(int length) {
            _array = new int[length];
        }

        public int this[int index] {
            get { return _array[index]; }
        }

        public void Insert(int value) {
            if (currentIndex >= _array.Length) {
                var newArray = new int[currentIndex * 2];
                _array.CopyTo(newArray, 0);
                _array = newArray;
            }
            _array[currentIndex++] = value;
        }

        public void RemoveAt(int index) {
            if (index < 0 || index >= currentIndex)
                throw new ArgumentOutOfRangeException("You must supply an integer that lies in the bounds of the array");
            if (index == (currentIndex - 1)) {
                _array[currentIndex-- - 1] = 0;
            }else {
                while(index < (currentIndex -1))
                    _array[index] = _array[index++ + 1];
                _array[currentIndex-- - 1] = 0;
            }
        }

        public int IndexOf(int value) {
            for(int i = 0; i < _array.Length; i++){
                if (_array[i] == value)
                    return i;
            }
            return - 1;
        }

        public void PrintContent() {
            for (int j = 0; j < _array.Length; j++) {
                Console.WriteLine(_array[j]);
            }
        }

        public void Reverse() {
            var reverseArray = new int[_array.Length];
            for (int l = 0; l < reverseArray.Length; l++) {
                reverseArray[l] = _array[_array.Length - 1 - l];
            }
            _array = reverseArray;
        }

        // If I understood correctly this algorithm should have a running time of 
        // O(nlogn) + O(mlogm) + O(the shortest between m and n) + O(time to copy list to array)
        // If we simplify everything we should still get O(nlogn) 
        public int[] Intersect(params int[] otherArray) {
            Array.Sort(_array);
            Array.Sort(otherArray);
            List<int> commonElements = new List<int>();
            
            int pointer1 = 0;
            int pointer2 = 0;

            while(pointer1 < _array.Length && pointer2 < otherArray.Length) {
                if (_array[pointer1] == otherArray[pointer2]){
                    commonElements.Add(_array[pointer1]);
                    pointer1++;
                    pointer2++;
                }else {
                    if (_array[pointer1] < otherArray[pointer2])
                        pointer1++;
                    else
                        pointer2++;
                }
            }
            return commonElements.ToArray();
        }

        public int Max() {
            int max = 0;
            for (int k = 0; k < _array.Length; k++) {
                if (max <= _array[k])
                    max = _array[k];
            }
            return max;
        }
 
        public void InsertAt(int value, int index) {
            if(index < 0 || index > _array.Length)
                throw new ArgumentOutOfRangeException();
            _array[index] = value;
        }
    }
}