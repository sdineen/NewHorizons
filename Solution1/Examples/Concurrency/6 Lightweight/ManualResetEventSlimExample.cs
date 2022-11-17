using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threads
{
    public class ManualResetEventSlimExample
    {
        public static void Start()
        {
            const int taskCount = 4;

            // 4 thread synchronization events that, when signaled, must be reset manually. 
            ManualResetEventSlim[] manualResetEventSlim = new ManualResetEventSlim[taskCount];
            Calculator[] calcs = new Calculator[taskCount];

            for (int i = 0; i < taskCount; i++)
            {
                int i1 = i;
                // false to set the initial state to nonsignaled.
                manualResetEventSlim[i] = new ManualResetEventSlim(false);

                //build 4 calculator objects, passing different
                //ManualResetEventSlim objects into constructor
                calcs[i] = new Calculator(manualResetEventSlim[i]);

                //start 4 Tasks, calling the Calculation method of
                //each Calculator object
                Task.Run(() => calcs[i1].Calculation(i1 + 1, i1 + 3));
            }

            for (int i = 0; i < taskCount; i++)
            {
                manualResetEventSlim[i].Wait(); //wait until signalled from Calculation task
                manualResetEventSlim[i].Reset(); //returns state to nonsignaled 
                Console.WriteLine($"finished task for {i}, result: {calcs[i].Result}");
            }
        }
    }
    public class Calculator
    {
        private ManualResetEventSlim mEvent;

        public int Result { get; private set; }

        public Calculator(ManualResetEventSlim ev)
        {
            this.mEvent = ev;
        }

        public void Calculation(int x, int y)
        {
            Console.WriteLine($"Task {Task.CurrentId} starts calculation");
            Thread.Sleep(new Random().Next(3000));
            Result = x + y;

            Console.WriteLine($"Task {Task.CurrentId} is ready");
            //Sets the state of the event to signaled, 
            //which allows threads waiting on the event to proceed.
            mEvent.Set();
        }
    }
}
