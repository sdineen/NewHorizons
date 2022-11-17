using System;
using System.Runtime.InteropServices;

namespace ConsoleApplication.Examples.Interop
{
    //https://msdn.microsoft.com/en-us/library/ms173187.aspx
    public class CallNativeDll_Sound
    {
        static void Main(string[] args)
        {
            string file = @"..\..\examples\interop\enlightenment.wav";
            PlaySound(file, new IntPtr(), 0);
            Console.ReadKey();
        }

        //https://msdn.microsoft.com/en-us/library/windows/desktop/dd743680(v=vs.85).aspx
        [DllImport(
            "winmm.DLL", 
            EntryPoint = "PlaySound", 
            SetLastError = true, 
            CharSet = CharSet.Unicode, 
            ThrowOnUnmappableChar = true)]
        private static extern bool PlaySound(string szSound, IntPtr hMod, PlaySoundFlags flags);

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
