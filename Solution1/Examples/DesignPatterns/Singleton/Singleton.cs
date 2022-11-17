using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples.DesignPatterns.Singleton
{
    public class Singleton
    {
        private static Singleton instance;
        private Singleton()
                => Console.WriteLine("instantiated");
        
        //null-coalescing assignment operator
        public static Singleton Instance 
                => instance ??= new Singleton();

        public void DoSomething()
        {

        }
    }

    public class Program
    {
        public static void Main()
        {
            Singleton s1 = Singleton.Instance;
            Singleton s2 = Singleton.Instance;
            Console.WriteLine(s1 == s2);
        }
    }
}
