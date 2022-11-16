using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class CollectionExamples
    {
        static void Main(string[] args)
        {
            var keyValuePairs = new Dictionary<string, Product>();
            keyValuePairs.Add("p2", new Product(2, "Knife", 0.60, 1.31));
            keyValuePairs.Add("p3", new Product(3, "Fork", 0.75, 1.57));
            keyValuePairs.Add("p4", new Product(4, "Spaghetti", 0.90, 1.92));

            Product product;
            bool retrieved = keyValuePairs.TryGetValue("p5", out product);
            Console.WriteLine(product?.Name);

            Console.WriteLine(keyValuePairs["p2"]); //can throw KeyNotFoundException

            var keys = keyValuePairs.Keys;
            var values = keyValuePairs.Values;



            LinkedList<string> list = new LinkedList<string>();
            list.AddLast("alpha");
            list.AddLast("beta");
            list.AddLast("gamma");
            list.AddLast("delta");
            LinkedListNode<string> lastNode = list.Last;
            string last = lastNode.Previous.Value; //gamma

            LinkedListNode<string> firstNode = list.First;
            string first = firstNode.Value; //alpha

            list.RemoveFirst();
            first = list.First.Value; //beta


            Queue<string> queue = new Queue<string>();
            queue.Enqueue("alpha"); //alpha
            queue.Enqueue("beta"); //alpha
            queue.Enqueue("gamma");

            Console.WriteLine(queue.Peek());
            Console.WriteLine(queue.Dequeue()); //InvalidOperationException if empty
            Console.WriteLine(queue.Count);


            Stack<string> stack = new Stack<string>();
            stack.Push("alpha");
            stack.Push("beta");
            stack.Push("gamma");

            Console.WriteLine(stack.Peek()); //gamma
            Console.WriteLine(stack.Pop()); //gamma
            Console.WriteLine(stack.Count);



            HashSet<string> set = new HashSet<string>();
            bool a = set.Add("alpha");
            bool b = set.Add("beta");
            bool c = set.Add("gamma");
            bool d = set.Add("gamma"); //false

            bool e = set.Remove("alpha");
            bool f = set.Remove("alpha"); //false
            bool g = set.Contains("beta");

            Console.WriteLine(set.Count); //2

        }
    }
}
