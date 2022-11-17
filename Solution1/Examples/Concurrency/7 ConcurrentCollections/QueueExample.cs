using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Examples.Concurrency.ConcurrentCollections
{
    public class QueueExample
    {
        public static void StartQueue()
        {
            // Construct a Queue.
            Queue<int> cq = new Queue<int>();

            // Populate the queue.
            for (int i = 0; i < 10000; i++)
            {
                cq.Enqueue(i);
            }

            int outerSum = 0;
            // An action to consume the Queue.
            Action action = () =>
            {
                int localSum = 0;
                int localValue;
                while (cq.TryDequeue(out localValue))
                {
                    localSum += localValue;
                }
                Interlocked.Add(ref outerSum, localSum);
            };

            // Start 4 concurrent consuming actions.
            Parallel.Invoke(action, action, action, action);

            Console.WriteLine($"outerSum = {outerSum}, should be {Enumerable.Range(0, 10000).Sum()}");
        }
        public static void StartConcurrentQueue()
        {
            // Construct a ConcurrentQueue.
            ConcurrentQueue<int> cq = new ConcurrentQueue<int>();

            // Populate the queue.
            for (int i = 0; i < 10000; i++)
            {
                cq.Enqueue(i);
            }

            int outerSum = 0;
            // An action to consume the ConcurrentQueue.
            Action action = () =>
            {
                int localSum = 0;
                int localValue;
                while (cq.TryDequeue(out localValue)) {
                    localSum += localValue;
                }
                Interlocked.Add(ref outerSum, localSum);
            };

            // Start 4 concurrent consuming actions.
            Parallel.Invoke(action, action, action, action);

            Console.WriteLine($"outerSum = {outerSum}, should be {Enumerable.Range(0, 10000).Sum()}");
        }
    }
}
