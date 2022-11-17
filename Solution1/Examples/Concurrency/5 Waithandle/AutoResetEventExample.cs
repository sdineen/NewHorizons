using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threads
{
    //https://www.dotnetforall.com/manualresetevent-practical-c-example/
    public class AutoResetEventExample
    {
        private static AutoResetEvent autoResetEvent = new AutoResetEvent(false);
        public static void Start()
        {
            Method1();

            while (true)
            {
                Thread.Sleep(TimeSpan.FromSeconds(5));
                Console.WriteLine($"Set - Waiting threads are signaled");
                autoResetEvent.Set();
            }

        }

        public async static Task Method1()
        {
            await Task.Run(() =>
            {
                while (true)
                {
                    Console.WriteLine($"Running");
                    //Blocks current thread until WaitHandle receives a signal
                    autoResetEvent.WaitOne();
                }
            });
        }
    }

}
