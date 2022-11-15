using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Streams
    {
        public static void WriteToFile(string text)
        {
            File.WriteAllText(@"Y:\file.txt", text);

            try
            {
                //UnauthorizedAccessException
                File.WriteAllText(@"C:\Users\Owner\Documents\temp\file.txt", text);
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                //always executed
            }

        }

        static void Main(string[] args)
        {
            try
            {
                WriteToFile("some text");
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

}
