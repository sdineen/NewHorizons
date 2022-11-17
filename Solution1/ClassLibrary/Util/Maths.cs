using System;
using System.Linq;
using System.Threading.Tasks;

namespace ClassLibrary.Util
{
    public class Maths
    {
        public static double Factorial(int n)
        {
            if (n < 0)
            {
                throw new ArgumentOutOfRangeException("argument can't be negative");
            }
            double result = 1;
            for (; n > 1; n--)
            {
                result *= n;
            }
            return result;
        }


        public static double RecursiveFactorial(int n)
        {
            if (n == 0)
            {
                return 1; //base case
            }
            else
            {
                return n * RecursiveFactorial(n - 1);
            }
            //return n==0 ? 1 : n * Factorial(n - 1);
        }

        public static double LinqFactorial(int n) =>
            Enumerable.Range(1, n).Aggregate((a, b) => a * b);


        public static int PrimesCount(int max)
        {
            return (from n in Enumerable.Range(2, max - 1)
                    where Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)
                    select n).Count();
        }

        public async static Task<int> PrimesCountAsync(int max)
        {
            Func<int> func = () => (from n in Enumerable.Range(2, max - 1).AsParallel()
                                    where Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)
                                    select n).Count();
            Task<int> task = Task.Run(func);
            int result = await task;
            return result;
        }

        public async static Task<int> PrimesCountAsync2(int max)
        {
            Func<int> func = () =>
                Enumerable.Range(2, max - 1)
                .AsParallel()
                .Where(p => Enumerable.Range(2, (int)Math.Sqrt(p) - 1).All(n => p % n > 0))
                .Count();
            //Queues the specified work to run on the ThreadPool 
            //and returns a Task<TResult> handle for that work.
            Task<int> task = Task.Run(func);
            //suspends evaluation of the enclosing method and  
            //returns control to the caller until the func completes
            int result = await task;
            return result;
        }


        public static double Combination(int n, int r)
        {
            return Factorial(n) / (Factorial(r) * Factorial(n - r));
        }

        public static bool IsPrime(int n)
        {
            for (int j = 2; j < n; j++)
            {
                if (n % j == 0)
                    return false;
            }
            return true;
        }

        public static void Fibonacci()
        {
            for (int fn = 0, f1 = 1, f2 = 1; fn < 100; fn = f1 + f2)
            {
                f1 = f2;
                f2 = fn;
                Console.WriteLine(fn);
            }
            Console.ReadKey();
        }

        public static int[] Fibonacci(int limit)
        {
            int[] sequence = new int[limit];
            int fn = 0, f1 = 1, f2 = 1;
            for (int count = 0; count < limit; fn = f1 + f2)
            {
                f1 = f2;
                f2 = fn;
                sequence[count++] = fn;
            }
            return sequence;
        }



        public static string ToRoman(int number)
        {
            //if ((number < 1 || (number > 4999))) return string.Empty;
            if (number >= 1000) return "M" + ToRoman(number - 1000);
            if (number >= 900) return "CM" + ToRoman(number - 900);
            if (number >= 500) return "D" + ToRoman(number - 500);
            if (number >= 400) return "CD" + ToRoman(number - 400);
            if (number >= 100) return "C" + ToRoman(number - 100);
            if (number >= 90) return "XC" + ToRoman(number - 90);
            if (number >= 50) return "L" + ToRoman(number - 50);
            if (number >= 40) return "XL" + ToRoman(number - 40);
            if (number >= 10) return "X" + ToRoman(number - 10);
            if (number >= 9) return "IX" + ToRoman(number - 9);
            if (number >= 5) return "V" + ToRoman(number - 5);
            if (number >= 4) return "IV" + ToRoman(number - 4);
            if (number >= 1) return "I" + ToRoman(number - 1);
            return string.Empty; //base case
        }




    }
}