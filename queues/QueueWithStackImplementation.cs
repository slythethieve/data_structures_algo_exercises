using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace queues
{
    public class QueueWithStackImplementation
    {
        private Stack<int> _firstStack;
        private Stack<int> _secondStack;

        public QueueWithStackImplementation() {
            _firstStack = new Stack<int>();
            _secondStack = new Stack<int>();
        }

        public void Enqueue(int item) {
            if(_firstStack.Count == 0)
                throw new Exception("Queue is empty");

            while (_firstStack.Count != 0) {
                _secondStack.Push(_firstStack.Pop());
            }

            _firstStack.Push(item);
            
            while (_secondStack.Count != 0) {
                _firstStack.Push(_secondStack.Pop());
            }
        }

        public int Dequeue() {
            if(_firstStack.Count == 0)
                throw new Exception("Queue is empty");

            var result = _firstStack.Pop();
            return result;
        }
    }
}