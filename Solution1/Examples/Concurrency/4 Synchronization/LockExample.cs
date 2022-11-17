using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threads
{
    public class LockExample
    {
        public static void Start()
        {
            int numTasks = 5;
            var state = new SharedState();
            var tasks = new Task[numTasks];

            //start 5 tasks with shared state
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
        private int state;

        public void IncrementState()
        {
            //state++;
            Interlocked.Increment(ref state);
        }

        public int State { get => state; set => state = value; }


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
                Monitor.Enter(sharedState);
                {
                    sharedState.State += 1;
                    //sharedState.IncrementState();
                }
                Monitor.Exit(sharedState);
            }

        }
    }


}
