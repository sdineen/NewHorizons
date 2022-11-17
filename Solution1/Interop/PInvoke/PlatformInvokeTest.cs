using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.Examples.Interop.PInvoke
{
    public class PlatformInvokeTest
    {
        [DllImport("msvcrt.dll")]
        public static extern int puts(string c);
        [DllImport("msvcrt.dll")]
        internal static extern int _flushall();

        public static void Main()
        {
            puts("Test");
            _flushall();
        }
    }
}
