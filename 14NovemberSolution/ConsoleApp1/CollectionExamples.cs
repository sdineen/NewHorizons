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
