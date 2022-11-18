namespace MyApp
{
    public class Maths
    {
        public async static Task<int> PrimesCountAsync(int max)
        {
            Func<int> func = () =>
                            (from n in Enumerable.Range(2, max - 1)
                             where Enumerable.Range(2, (int)Math.Sqrt(n) - 1)
                                                         .All(i => n % i > 0)
                             select n).Count();
            //Queues the specified work to run on the ThreadPool  
            //and returns a generic Task handle for that work.
            Task<int> task = Task.Run(func);
            //suspends evaluation of the enclosing method and  
            //returns control to the caller until the func completes
            int result = await task;
            return result;
        }

        public static double Factorial(int n)
        {
            if(n < 0)
            {
                throw new ArgumentOutOfRangeException("parameter can't be negative");
            }
            return n == 0 || n== 1  ? 1 : n * Factorial(n - 1);
        }
    }
}