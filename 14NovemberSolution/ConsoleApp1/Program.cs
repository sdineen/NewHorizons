
namespace MyApp
{
    internal class Program
    {
        static void Main(String[] args)
        {
            int result1 = ArithmeticSeries(10);
            Console.WriteLine(result1);
            double result2 = GeometricSeries(10);
            Console.WriteLine(result2);
            double result3 = Factorial(5);
            Console.WriteLine(result3);
            double result4 = FactorialRecursion(5);
            Console.WriteLine(result4);
        }

        private static double FactorialRecursion(int n)
        {
            return n==1 ? 1 : n * FactorialRecursion(n-1);
        }

        private static double Factorial(int n)
        {
            double result = 1;
            for (; n>1; n--)
            {
                result *= n;
            }
            return result;
        }

        private static double GeometricSeries(int n)
        {
            double result = 0;
            for (int i = 0; i <=n; i++)
            {
                result += Math.Pow(2, i);
            }
            return result;
        }

        private static int ArithmeticSeries(int n)
        {
            int result = 0;
            for (int i = 0; i <=n ; i++)
            {
                result += i;
            }
            return result;
        }
    }
}