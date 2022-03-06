using System.Numerics;
using System.Runtime.InteropServices;

namespace OpenAL
{
    #region Variables

    public enum AL_FORMAT
    {
        AL_FORMAT_MONO8 = 0x1100,
        AL_FORMAT_MONO16 = 0x1101,
        AL_FORMAT_STEREO8 = 0x1102,
        AL_FORMAT_STEREO16 = 0x1103
    }

    #endregion
    
    public class NativeMethods
    {
        public const string LibName = "/LinuxData/Kickback/openal-soft/build/UnityPlugin/libaudioplugin.so";

        #region MyDebug

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void MyRegisterDebugCallback(MydebugCallbackDelegate cb);

        //Create string param callback delegate
        public delegate void MydebugCallbackDelegate(IntPtr request, int color, int size);

        [DllImport(LibName)]
        public static extern IntPtr MyTestDebugLog(string message);
        
        [DllImport(LibName)]
        public static extern IntPtr MyTestDebugLogVector(Vector3 message);

        #endregion



        #region Audio Listener

        [DllImport(LibName)]
        public static extern IntPtr CreateAudioListener();

        [DllImport(LibName)]
        public static extern void DestroyAudioListener(IntPtr audioListener);

        [DllImport(LibName)]
        public static extern void CreateAudioSource(IntPtr audioListener, IntPtr buffer, int index);

        [DllImport(LibName)]
        public static extern void PlayAudio(IntPtr audioListener);

        #endregion

        #region Audio Buffer

        [DllImport(LibName)]
        public static extern IntPtr CreateAudioBuffer(int bufferSize);

        [DllImport(LibName)]
        public static extern void DestroyAudioBuffer(IntPtr audioBuffer);

        [DllImport(LibName)]
        public static extern int CopyAudioToBuffer(IntPtr audioBuffer, int buffer_index, IntPtr input,
            int input_size, int samplerate, AL_FORMAT format);

        #endregion
    }
}