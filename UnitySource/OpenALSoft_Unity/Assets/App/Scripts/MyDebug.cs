using System;
using System.Runtime.InteropServices;
using AOT;
using UnityEngine;

namespace AudioSpace
{
    public class MyDebug: MonoBehaviour
    {
        public static MyDebug instance { get; private set; }

        // Use this for initialization
        void Awake()
        {
            if (instance != null)
            {
                DestroyImmediate(gameObject);
            }
            else
            {
                instance = this;
                AudioSpace.MyRegisterDebugCallback(OnDebugCallback);
            }
        }

        enum Color { red, green, blue, black, white, yellow, orange };
        [MonoPInvokeCallback(typeof(AudioSpace.MydebugCallbackDelegate))]
        static void OnDebugCallback(IntPtr request, int color, int size)
        {
            //Ptr to string
            string debug_string = Marshal.PtrToStringAnsi(request, size);

            //Add Specified Color
            debug_string =
                String.Format("{0}{1}{2}{3}{4}",
                    "<color=",
                    ((Color)color).ToString(),
                    ">",
                    debug_string,
                    "</color>"
                );

            UnityEngine.Debug.Log(debug_string);
        }

        public void TestDebugLog(string msg)
        {
            AudioSpace.MyTestDebugLog(msg);
        }
    }
}