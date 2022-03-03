using System;
using System.Runtime.InteropServices;
using OpenAL;

namespace AudioSpace
{
    public class MyDebug
    {

        // Use this for initialization
        public void Register()
        {
            NativeMethods.MyRegisterDebugCallback(OnDebugCallback);
        }

        enum Color { red, green, blue, black, white, yellow, orange };

        static void OnDebugCallback(IntPtr request, int color, int size)
        {
            //Ptr to string
            string debug_string = Marshal.PtrToStringAnsi(request, size);

            //Add Specified Color
            /*debug_string =
                String.Format("{0}{1}{2}{3}{4}",
                    "<color=",
                    ((Color)color).ToString(),
                    ">",
                    debug_string,
                    "</color>"
                );*/

            Console.WriteLine("Plugin debugger: "+debug_string);
        }

        public void TestDebugLog(string msg)
        {
            NativeMethods.MyTestDebugLog(msg);
        }
    }
}