using System;
using System.Collections.Generic;

namespace Examples.Fundamentals
{
    public class Operators
    {
        public static void Main()
        {
            {
                int a = 5;
                double b = a;

                double c = 5;
                int d = (int)c;

                double e = Math.Pow(2, 32);
                int f = (int)e;
                a = int.MinValue;
            }
            {
                string a = "cat";
                string b = "dog";
                bool c = a == b;
                bool d = a != b;
            }
            {
                int number = 7;
                int remainder = number % 2;
            }
            {
                bool x = true;
                bool y = false;
                bool a = x | y;
                bool b = x & y;
                bool c = x || y;
                bool d = x && y;
                bool e = x ^ y;
            }
            {
                int i = 0;
                int j = i++; //postfix operator has left associativity

                int a = 0;
                int b = ++a; //unary operators have right associativity
            }
            {
                double d = -5;
                string s = d >= 0 ? "positive" : "negative";
            }
            {
                int x = 5;     //101
                int y = 4;     //100
                int z = x & y; //100


                int a = 5;       //101
                int b = a >> 1;  //10
                int c = a << 1;  //1010
            }
            {
                int i = 5;
                double d = i;

                double a = 2147483648; // maximum 1.7 x 10308
                int b = (int)a; // maximum 231 -1 (2147483647)
                Console.WriteLine(b);
            }
            {
                //null-condition operator
                //Used to test for null before performing a member access (?.) or index (?[) operation.
                string a = null;
                //string b = a.ToLower();
                string c = a?.ToLower();
            }
            {
                //The ?? operator is called the null-coalescing operator. 
                //It returns the left-hand operand if the operand is not null; 
                //otherwise it returns the right hand operand.
                string a = null;
                string b = a ?? "a is null";
            }
            {
                //null-coalescing assignment operator ??= assigns the right to left
                //if the left-hand operand is null
                List<int> numbers = null;
                numbers ??= new List<int>();
            }
        }
    }
}
