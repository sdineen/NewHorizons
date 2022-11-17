using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Examples.Concurrency.Mutexes
{
    //offers synchronization across multiple processes.
    public class MutexExample
    {
        public static void Start()
        {
            bool createdNew;
            Mutex mutex = new Mutex(false, "MyMutex", out createdNew);
            Console.WriteLine($"main method {createdNew}");

            int numTasks = 2;
            var state = new SharedState();
            var tasks = new Task[numTasks];

            for (int i = 0; i < numTasks; i++)
            {
                tasks[i] = Task.Run(() => new Job(state).DoTheJob());
            }

            Task.WaitAll(tasks);

            Console.WriteLine("summarized {0}", state.State);
        }
    }

    public class SharedState
    {
        public int State { get; set; }
    }

    public class Job
    {
        SharedState sharedState;
        public Job(SharedState sharedState)
        {
            this.sharedState = sharedState;
        }
        public void DoTheJob()
        {
            for (int i = 0; i < 5; i++)
            {
                bool createdNew;
                Mutex mutex = new Mutex(false, "MyMutex", out createdNew);
                //Console.WriteLine($"DoTheJob {i} task {Task.CurrentId} new={createdNew}");
                mutex.WaitOne();
                try
                {
                    sharedState.State += 1;
                }
                finally
                {
                    mutex.ReleaseMutex();
                }
            }
        }
    }


}
