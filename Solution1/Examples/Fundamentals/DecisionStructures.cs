using System;

namespace Examples.Fundamentals
{
    class DecisionStructures
    {
        static void Main()
        {
            {
                double number = Math.Pow(2, 31) - 1;
                if (number > int.MaxValue)
                {
                    Console.WriteLine("outside the range of an int");
                }
                else
                {
                    Console.WriteLine("within the range of an int");
                }
            }
            {
                double number = Math.Pow(2, 31) - 1;
                if (number > int.MaxValue)
                    Console.WriteLine("outside the range of an int");
            }
            {
                int arabic = 4;
                string roman = string.Empty;
                switch (arabic)
                {
                    case 1:
                        roman = "I";
                        break;
                    case 2:
                        roman = "II";
                        break;
                    case 3:
                        roman = "III";
                        break;
                    case 4:
                        roman = "IV";
                        break;
                    case 5:
                        roman = "V";
                        break;
                    default:
                        roman = "out of range";
                        break;
                }
                Console.WriteLine(roman);
            }
        }
    }
}
