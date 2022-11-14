
namespace MyApp
{
    internal class Program
    {
        static void Main(String[] args)
        {

            double result = Factorial(5);
            Console.WriteLine(result);
            int result2 = ArithmeticSeries(10);
            Console.WriteLine(result2);
            double result3 = GeometricSeries(10);
        }

        //sum of 2^0 + 2^1 .... + 2^10
        private static double GeometricSeries(int n)
        {
            throw new NotImplementedException();
        }

        //sum of 0 + 1 + 2 ... + 10
        private static int ArithmeticSeries(int n)
        {
            throw new NotImplementedException();
        }

        //5 x 4 x 3 x 3
        private static double Factorial(int n)
        {
            return 0;
        }
    }
}