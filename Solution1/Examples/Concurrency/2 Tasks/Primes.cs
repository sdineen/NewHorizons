using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threads
{
    public class Primes
    {
        public static void Start()
        {
            int limit = 10000000;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int primes = PrimeCountAsync(limit).Result;

            sw.Stop();
            Console.WriteLine($"{primes} prime numbers. Calculated in {sw.Elapsed.TotalSeconds} seconds");
        }

        public static int PrimeCount(int max)
        {
            int result = (from n in Enumerable.Range(2, max)
                          where Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)
                          select n).Count();
            return result;
        }

        public static int PrimeCountPlinq(int max)
        {
            int result = (from n in Enumerable.Range(2, max).AsParallel()
                          where Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)
                          select n).Count();
            return result;
        }


        public async static Task<int> PrimeCountAsync(int max)
        {
            int result = await Task.Run(() => (from n in Enumerable.Range(2, max).AsParallel()
                                               where Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)
                                               select n).Count());
            return result;
        }

        public async void IoBound()
        {
            Task task = Task.Delay(1000);
            await task;
        }
    }
}
