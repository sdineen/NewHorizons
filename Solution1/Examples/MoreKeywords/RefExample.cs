using System;

namespace Examples.MoreKeywords
{
    public class RefExample
    {
        public static void Main()
        {
            //argument passed to out parameter is written by called method
            int number;
            string str = "5";
            bool success = Int32.TryParse(str, out number);

            //argument passed to ref parameter must be initialized and read or written by called method
            object[] elements = new object[10];
            Array.Resize(ref elements, 20);

            //argument passed to in parameter is read by the called method
            int constant = 5;
            PassConstByRef(constant);
        }

        //example of method with ref parameter
        private static void Resize(ref object[] elements, int newSize)
        {
            object[] newArray = new object[newSize];
            Array.Copy(elements, newArray, elements.Length);
            elements = newArray;
        }

        //example of method with out parameter
        private static bool TryParse(string str, out int number)
        {
            try
            {
                number = Convert.ToInt32(str);
                return true;
            }
            catch (FormatException)
            {
                number = 0;
                return false;
            }
        }

        //in paramaters are readonly
        public static void PassConstByRef(in int i)
        {
            //read only
        }
    }
}
