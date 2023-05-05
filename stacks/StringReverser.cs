using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stacks
{
    public class StringReverser
    {
        

        public static String Reverse(String str) {
            var stack = new Stack<char>();
            var result = new StringBuilder();

            foreach (var c in str) 
                stack.Push(c);

            while (stack.Count != 0)
                result.Append(stack.Pop());

            return result.ToString();
        }
    }
}