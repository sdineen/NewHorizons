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
            try
            {
                //UnauthorizedAccessException
                File.WriteAllText(@"C:\Users\Owner\Documents\temp\file.txt", text);
                //DirectoryNotFoundException
                File.WriteAllText(@"Y:\file.txt", text);
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void Main(string[] args)
        {
            WriteToFile("some text");
        }
    }

}
