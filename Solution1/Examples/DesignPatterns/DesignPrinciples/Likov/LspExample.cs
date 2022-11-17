using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples.DesignPrinciples.Likov
{
    // Derived types must be completely substitutable for their base types.
    // Violation of Likov's Substitution Principle
    class MyCollection
    {
        public int Count { get; private set; }
        public virtual void AddItem(int item) { /*...*/ }
    }

    class MyArray : MyCollection
    {
        public override void AddItem(int item)
        {
            throw new System.NotSupportedException();
        }
    }
    public class Program
    {
        public static void Main()
        {
            MyCollection myCollection = new MyCollection();
            myCollection.AddItem(7);

            MyCollection myArray = new MyArray();
            myArray.AddItem(7);
        }
    }

}
