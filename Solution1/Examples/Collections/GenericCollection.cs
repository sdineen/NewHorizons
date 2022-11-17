using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Examples.Collections
{
    public class GenericCollection<T> : ICollection<T>
    {
        private int size = 10;
        private object[] elements = new object[10];        
        public int Count { get; private set; } //auto property    
        public bool IsReadOnly => false; //expression bodied read only property
        public void Add(T item)
        {
            if (Count == size)
            {
                size *= 2;
                Array.Resize(ref elements, size);
            }
            elements[Count++] = item;
        }
        public void Clear()
        {
            elements = new object[size];
            Count = 0;
        }
        public bool Contains(T item)
        {
            return Array.Exists(elements, element => element.Equals(item));
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            Array.Copy(elements, array, Count);
        }
        public IEnumerator<T> GetEnumerator()
        {
            //Using yield to define an iterator removes the need for an 
            //explicit implemetation of IEnumerator. The compiler generates 
            //an implicit implementation (a state machine) that tracks the current 
            //state and has a MoveNext method that's called by the foreach expression
            for (int i = 0; i < Count; i++)
            {
                yield return (T)elements[i];
            }
        }
        public bool Remove(T item)
        {
            int index = Array.IndexOf(elements, item);
            if (index == -1)
            {
                return false;
            }
            elements[index] = null;
            Count -= 1;
            for (int i = index; i < Count; i++)
            {
                elements[i] = elements[i + 1];
            }
            Array.Resize(ref elements, Count);
            return true;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
namespace Examples.Collections
{
    public class Program
    {
        public static void Main()
        {
            GenericCollection<int> collection = new GenericCollection<int>();
            for (int i = 1; i <= 15; i++)
            {
                collection.Add(i);
            }
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("remove 2");
            collection.Remove(2);

            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"count {collection.Count}");
            Console.WriteLine($"element at 1 {collection.ElementAt(1)}");
        }
    }
}


