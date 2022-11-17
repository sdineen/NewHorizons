using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples.DesignPatterns.Decorator
{
    class Class1
    {
        static void Main()
        {



            FileStream fileStream = new FileStream(@"C:\Users\User\Documents\file1.bin", FileMode.Create);
            BufferedStream bufferedStream = new BufferedStream(fileStream);
            byte[] bytes = {10,20,127};
            bufferedStream.Write(bytes, 0, 3);
            bufferedStream.Close();
            fileStream.Close();

            Console.ReadKey();
        }
    }
}
