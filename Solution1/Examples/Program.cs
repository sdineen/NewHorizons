using Examples.Concurrency.ConcurrentCollections;
using Examples.Concurrency.Interlocking;
using Examples.Concurrency.Monitors;
using Examples.Concurrency.Mutexes;
using Examples.Concurrency.Semaphores;
using Examples.Concurrency.Tasks;
using Examples.Concurrency.Threads;
using Examples.Concurrency.Waithandle;
using Examples.Security;
using Examples.ServiceLayer;
using System;
using Threads;

namespace Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            AddProduct.Main();
            //Hashing.Main();
            //QueueExample.StartQueue();
            //QueueExample.StartConcurrentQueue();
            //ManualResetEventSlimExample.Start();
            //ManualResetEventCalculatorExample.Start();
            //AutoResetEventExample.Start();
            //ManualResetEventExample.Start();        
            //SemaphoreExample.Start();
            //SemaphoreSlimExample.Start();
            //page 587
            //MutexExample.Start();
            //page 586
            //MutexExample.Start();
            //page 585
            //MonitorExample.Start();
            //page 584
            //InterlockedExample.Start();
            //page 579
            //LockExample.Start();
            //page 577
            //new Deadlock().Start();
            //page 574
            //new Race().Start();
            //Primes.Start();
            //ThreadExamples.ThreadPoolExample();
            //ThreadExamples.ThreadExample();
            //Simple.Main(null);

        }
    }
}
