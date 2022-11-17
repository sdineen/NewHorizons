using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.Examples.Interop
{
    class CallNativeDll_MessageBox
    {
        // Use DllImport to import the Win32 MessageBox function.
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern int MessageBox(IntPtr hWnd, String text, String caption, uint type);

        [DllImport(
    "winmm.DLL",
    EntryPoint = "PlaySound",
    SetLastError = true,
    CharSet = CharSet.Unicode,
    ThrowOnUnmappableChar = true)]
        private static extern bool PlaySound(string szSound, IntPtr hMod, PlaySoundFlags flags);


        [DllImport("msvcrt.dll")]
        public static extern int puts(string c);

        [DllImport("msvcrt.dll")]
        internal static extern int _flushall();


        static void Main()
        {
            puts("Test");
            _flushall();

            // Call the MessageBox function using platform invoke.
            MessageBox(new IntPtr(0), "Hello World!", "Hello Dialog", 0);

            string file = @"..\..\examples\interop\enlightenment.wav";
            PlaySound(file, new IntPtr(), 0);
            Console.ReadKey();
        }

        //Bit fields are generally used for lists of elements that might occur in combination, whereas enumeration constants are generally used for lists of mutually exclusive elements. 
        [Flags]
        public enum PlaySoundFlags : int
        {
            SND_SYNC = 0x0000,
            SND_ASYNC = 0x0001,
            SND_NODEFAULT = 0x0002,
            SND_LOOP = 0x0008,
            SND_NOSTOP = 0x0010,
            SND_NOWAIT = 0x00002000,
            SND_FILENAME = 0x00020000,
            SND_RESOURCE = 0x00040004
        }
    }
}
