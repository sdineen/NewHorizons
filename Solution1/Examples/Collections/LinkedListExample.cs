using System;
using System.Collections.Generic;
using System.Text;

namespace Examples.Collections
{
    class LinkedListExample
    {
        static void Main()
        {
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
            first = list.First.Value; //beta
        }

    }
}
