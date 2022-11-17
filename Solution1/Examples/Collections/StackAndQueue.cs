using System;
using System.Collections.Generic;
using System.Text;

namespace Examples.Collections
{
    public class StackAndQueue
    {
        public static void Main()
        {
            Stack<string> stack = new Stack<string>();
            stack.Push("alpha");
            stack.Push("beta");
            stack.Push("gamma");

            Console.WriteLine(stack.Peek()); //gamma
            Console.WriteLine(stack.Pop()); //gamma
            Console.WriteLine(stack.Count); //2


            Queue<string> queue = new Queue<string>();
            queue.Enqueue("alpha");
            queue.Enqueue("beta");
            queue.Enqueue("gamma");

            Console.WriteLine(queue.Peek()); //alpha
            Console.WriteLine(queue.Dequeue()); //alpha
            //InvalidOperationException if empty
            Console.WriteLine(queue.Count); //2


        }
    }
}
