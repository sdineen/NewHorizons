
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Examples.Concurrency.Semaphores
{
    //Semaphore is a counting Mutex that can be used by multiple threads
    public class SemaphoreSlimExample
    {
        public static void Start()
        {
            int taskCount = 6;
            int semaphoreCount = 3;

            //initial and maximum concurrent requests
            var semaphore = new SemaphoreSlim(semaphoreCount, semaphoreCount);
            var tasks = new Task[taskCount];

            for (int i = 0; i < taskCount; i++)
            {
                tasks[i] = Task.Run(() => TaskMain(semaphore));
            }

            Task.WaitAll(tasks);

            Console.WriteLine("All tasks finished");
        }

        static void TaskMain(SemaphoreSlim semaphore)
        {
            bool isCompleted = false;
            while (!isCompleted)
            {
                //block current thread
                if (semaphore.Wait(600))
                {
                    try
                    {
                        Console.WriteLine($"Task {Task.CurrentId} locks the semaphore");
                        Thread.Sleep(2000);
                    }
                    finally
                    {                        
                        semaphore.Release();
                        isCompleted = true;
                        Console.WriteLine($"Task {Task.CurrentId} releases the semaphore");
                    }
                }
                else
                {
                    Console.WriteLine($"Timeout for task {Task.CurrentId}; wait again");
                }
            }
        }
    }
}
