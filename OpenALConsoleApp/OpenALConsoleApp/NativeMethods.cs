using System.Runtime.InteropServices;

namespace OpenAL
{
    public class NativeMethods
    {
        public const string LibName = "/LinuxData/Kickback/openal-soft/build/UnityPlugin/libaudioplugin.so";

        [DllImport(LibName)]
        public static extern int InitOpenAL();
        
        [DllImport(LibName)]
        public static extern int LoadSoundRaw(IntPtr input, int size, int samplerate);
        
        [DllImport(LibName)]
        public static extern int PlayAudio(int buffer_ID);
        
        #region MyDebug
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void MyRegisterDebugCallback(MydebugCallbackDelegate cb);
        //Create string param callback delegate
        public delegate void MydebugCallbackDelegate(IntPtr request, int color, int size);
        
        [DllImport(LibName)]
        public static extern IntPtr MyTestDebugLog(string message);
        #endregion
    }
}