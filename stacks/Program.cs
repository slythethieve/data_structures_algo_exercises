using System.Text;
using stacks;


var stack = new StackWithGetMin(5);
stack.Push(8);
stack.Push(2);
stack.Push(1);
stack.Push(10);
stack.Push(15);
stack.Pop();
stack.Pop();
stack.Pop();
stack.Pop();
stack.Push(4);
Console.WriteLine(stack.GetMinimum());

