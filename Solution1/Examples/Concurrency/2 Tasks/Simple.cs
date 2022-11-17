using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Examples.Concurrency.Tasks
{
    public class Simple
    {
        public static void Main(string[] args)
        {
            TaskExample();
            Console.WriteLine("TaskExample called");
            Console.ReadKey();
        }

        static async void TaskExample()
        {
            Func<string> func = () =>
            {
                Thread.Sleep(1000);
                return "Hello";
            };
            Task<string> task = Task.Run(func);
            string result = await task;
            Console.WriteLine(result);
        }
    }
}
