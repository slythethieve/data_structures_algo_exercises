using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stacks
{
    public class CheckBalancedExpression
    {
        public static bool IsExpressionValid(String str) {
            var stack = new Stack<char>();

            foreach (var c in str)
            {
                if (c.Equals('(')) 
                    stack.Push(')');
                else if (c.Equals('['))
                    stack.Push(']');
                else if (c.Equals('{'))
                    stack.Push('}');
                else if (stack.Count == 0 || stack.Pop() != c) 
                    return false;
            }
            if (stack.Count == 0) 
                return true;

            return false;
        }

    }
}