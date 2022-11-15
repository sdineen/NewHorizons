namespace MyApp
{
    internal class Maths
    {
        internal static double Factorial(int n)
        {
            if(n < 0)
            {
                throw new ArgumentOutOfRangeException("parameter can't be negative");
            }
            return n == 1 ? 1 : n * Factorial(n - 1);
        }
    }
}