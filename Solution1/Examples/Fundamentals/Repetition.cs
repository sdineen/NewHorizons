using System;

namespace Examples.Fundamentals
{
    class Repetition
    {
        static void Main()
        {
            ForLoops();
            WhileLoops();
            Console.ReadKey();
        }

        private static void ForLoops()
        {
            Console.WriteLine("******* for loop *********************");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("******* for loop *********************");
            int n = 0;
            for (;;)
            {
                Console.WriteLine(n);
                n++;
                if (n == 10)
                    break;
            }
        }

        private static void WhileLoops()
        {
            Console.WriteLine("******* while loop *******************");
            int j = 0;
            while (j < 10)
            {
                Console.WriteLine(j);
                j++;
            }

            Console.WriteLine("******* do while loop ****************");
            int k = 0;
            do
            {
                Console.WriteLine(k);
                k++;
            }
            while (k < 10);
        }
    }    
}