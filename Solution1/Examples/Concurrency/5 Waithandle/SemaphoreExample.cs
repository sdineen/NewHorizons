using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Examples.Concurrency.Semaphores
{
    //Semaphore is a counting Mutex that can be used by multiple threads
    public class SemaphoreExample
    {
        public static void Start()
        {
            int taskCount = 6;
            int semaphoreCount = 3;

            //initial and maximum concurrent requests
            var semaphore = new Semaphore(semaphoreCount, semaphoreCount);
            var tasks = new Task[taskCount];

            for (int i = 0; i < taskCount; i++)
            {
                tasks[i] = Task.Run(() => TaskMain(semaphore));
            }

            Task.WaitAll(tasks);

            Console.WriteLine("All tasks finished");
        }

        static void TaskMain(Semaphore semaphore)
        {
            bool isCompleted = false;
            while (!isCompleted)
            {
                //decrement semaphore count, block for 600ms if zero
                if (semaphore.WaitOne(TimeSpan.FromSeconds(0.6)))
                {
                    try
                    {
                        Console.WriteLine($"Task {Task.CurrentId} locks the semaphore for 2 seconds");
                        Thread.Sleep(TimeSpan.FromSeconds(2));
                    }
                    finally
                    {                        
                        semaphore.Release(); //thread exits sempaphore
                        Console.WriteLine($"Task {Task.CurrentId} releases the semaphore");
                        isCompleted = true;
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
