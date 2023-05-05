using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace linkedLists
{
    public class LinkedListInt
    {
        // Doing it like this I can access the fields from 
        // this linked list class. At the same time the outside 
        // cannot access or even see anything about the Node class.
        internal class Node {
            internal int value;
            internal Node? next;

            internal Node(int value){
                this.value = value;
            }
        }
        private Node? _head;
        private Node? _last;
        
        // Turns out what I had in mind with a public 
        // property called count was better than this, 
        // not to mention more efficient. My original
        // solution was of O(1). This in turn is O(n).
        public int Size() {
            int size = 0;
            var node = _head;
            if (IsEmpty())
                return size;
            while (node is not null) {
                size++;
                node = node.next;
            }
            return size;
        }

        public void RemoveFirst() {
            if (IsEmpty())
                throw new InvalidOperationException("The list is already empty");
            if (Size() == 1) {
                _head = _last = null;
                return;
            }
            var second = _head.next;
            _head.next = null;
            _head = second;
        }

        public void RemoveLast() {
            if (IsEmpty())
                throw new InvalidOperationException("The list is already empty");
            if (Size() == 1) {
                _head = _last = null;
                return;
            }
            var node = _head;
            while (node.next != _last) {
                node = node.next;
            }
            _last = node;
            _last.next = null;
        }

        public bool Contains(int value) {
            if(IsEmpty())
                return false;
            var node = _head;
            while(node is not null) {
                if(node.value == value)
                    return true;
                node = node.next;
            }
            return false;
        }

        public int IndexOf(int value) {
            if(IsEmpty())
                return -1;
            var node = _head;
            int index = 0;
            while (node is not null) {
                if (node.value == value) 
                    return index;
                node = node.next;
                index++;
            }

            return -1;
        }

        public void AddFirst(int value) {
            var node = new Node(value);
            if (IsEmpty()) {
                _head = _last = node;
            } else {
                node.next = _head;
                _head = node;
            }
        }

        private bool IsEmpty() {
            return _head == null;
        }

        public void AddLast(int value) {
            var node = new Node(value);
            if (IsEmpty()) {
                _head = _last = node;
            }else {
                _last.next = node;
                _last = node;
            }
        }
        

        public int[] ToArray() {
            if(IsEmpty())
                throw new InvalidOperationException("List is empty");
            var array = new int[this.Size()];
            var node = _head;
            var index = 0;
            while(node is not null) {
                array[index++] = node.value;
                node = node.next;
            }
            return array;
        }

        // 10 20 30 40
        public void Reverse() {
            if (IsEmpty()) return;

            var previous = _head;
            var current = _head.next;
            while(current is not null){
                var next = current.next;
                current.next = previous;
                previous = current;
                current = next;
            }

            _last = _head;
            _last.next = null;
            _head = previous;
        }

        public int GetKthNodeFromTheEnd(int k) {
            if (IsEmpty() || k <= 0 || k > Size()) 
                throw new InvalidOperationException();
            var first = _head;
            var second = _head;
            int distance = k - 1;
            while(second != null && distance > 0) {
                second = second.next;
                distance--;
            }
            
            while(second != _last) {
                second = second.next;
                first = first.next;
            }

            return first.value;
        }

        public void Print() {
            var current = _head;
            while(current is not null) {
                Console.WriteLine(current.value);
                current = current.next;
            }
        }

        public string PrintMiddle() {
            if (IsEmpty() || Size() <= 1) 
                throw new InvalidOperationException();
            var p1 = _head;
            var p2 = _head;
            while(p2 !=_last && p2.next != _last) {
                p2 = p2.next.next;
                p1 = p1.next;
            }

            if (p2 == _last) {
                return $"{p1.value}";
            }else {
                return $"{p1.value}, {p1.next.value}";
            }
        }

        public bool HasLoop() {
            var p1 = _head;
            var p2 = _head;

            while(p1 is not null && p2 is not null && p2.next is not null) {
                p2 = p2.next.next;
                p1 = p1.next;
                if(p1 == p2)
                    return true;
            }
            return false;

        }


    }
}