using System;
using System.Collections.Generic;
using System.Text;

namespace Examples.Collections
{
    public class HashSetExample
    {
        public static void Main()
        {
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
