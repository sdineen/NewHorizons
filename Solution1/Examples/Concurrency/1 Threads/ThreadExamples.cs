using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Examples.Concurrency.Threads
{
    public class ThreadExamples
    {
        //page 572
        public static void BackgroundThreadExample()
        {
            ThreadStart ts = () =>
            {
                Console.WriteLine($"thread {Thread.CurrentThread.ManagedThreadId} started");
                Thread.Sleep(1000);
                //threads created with Thread class are foreground threads
                Console.WriteLine($"thread {Thread.CurrentThread.ManagedThreadId} ended");
            };
            var t1 = new Thread(ts);
            t1.IsBackground = false; //main thread will complete before background thread
            t1.Start();

            Console.WriteLine($"thread state {t1.ThreadState}");
            Console.WriteLine($"thread {Thread.CurrentThread.ManagedThreadId} ended");
        }
        
        //page 571
        public static void ThreadWithParametersExample()
        {
            Data data = new Data { Message = "hello" };
            ParameterizedThreadStart pts = obj => Console.WriteLine((obj as Data).Message);
            var t = new Thread(pts);
            t.Start(data);
        }

        public class Data
        {
            public string Message;
        }

        //page 570
        public static void ThreadExample()
        {
            Console.WriteLine($"main thread {Thread.CurrentThread.ManagedThreadId}");
            ThreadStart threadStart = () => Console.WriteLine($"worker thread {Thread.CurrentThread.ManagedThreadId}");
            var t1 = new Thread(threadStart);
            t1.Start();
        }

        //page 569
        public static void ThreadPoolExample()
        {
            //start 5 threads
            for (int i = 0; i < 5; i++)
            {
                WaitCallback waitCallback = state =>
                {
                    //each thread counts to 3
                    for (int j = 0; j < 3; j++)
                    {
                        Console.WriteLine($"loop {j} thread {Thread.CurrentThread.ManagedThreadId}");
                    }
                };
                ThreadPool.QueueUserWorkItem(waitCallback);
            }
            Thread.Sleep(500);
        }
    }
}
