using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Examples.Concurrency.Monitors
{
    public class MonitorExample
    {
        public static void Start()
        {
            int numTasks = 5;
            var state = new SharedState();
            var tasks = new Task[numTasks];

            //start 20 tasks with shared state
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
            for (int i = 0; i < 1000; i++)
            {
                //bool lockTaken = false;
                //Monitor.Enter(sharedState);
                //Monitor.TryEnter(sharedState, 500, ref lockTaken);
                //if (! lockTaken)
                //{
                //    Console.WriteLine("lock taken");
                //    break;
                //}
                try
                {
                    sharedState.State += 1;
                }
                finally
                {
                    //Monitor.Exit(sharedState);
                }
            }

        }
    }


}
