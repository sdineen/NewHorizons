using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threads
{
    //https://www.dotnetforall.com/manualresetevent-practical-c-example/
    public class ManualResetEventExample
    {
        private static ManualResetEvent manualResetEvent = new ManualResetEvent(false);

        public static void Start()
        {
            Method1();

            while (true)
            {
                Thread.Sleep(TimeSpan.FromSeconds(5));
                Console.WriteLine($"Set - Waiting threads are signaled");
                manualResetEvent.Set();
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
                    manualResetEvent.WaitOne();
                    manualResetEvent.Reset();
                }
            });
        }
    }
}
 