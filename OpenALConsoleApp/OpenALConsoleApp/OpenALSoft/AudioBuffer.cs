
using System.Diagnostics;

using AudioSpace.DummyUnityClasses;
using Debug = AudioSpace.DummyUnityClasses.Debug;

namespace OpenAL
{
    public class AudioBuffer
    {
        public int BufferSize { private set; get; }
        private IntPtr self;

        public AudioBuffer(int bufferSize)
        {
            self = NativeMethods.CreateAudioBuffer(bufferSize);
            BufferSize = bufferSize;
        }

        public int CopyAudioToBuffer(int bufferIndex, IntPtr input,
            int input_size, int samplerate, AL_FORMAT format)
        {
            if (bufferIndex > BufferSize)
            {
                return 1;
            }
            int err = NativeMethods.CopyAudioToBuffer(self, bufferIndex, input, input_size, samplerate, format);
            return err;
        }

        public void DestroyBuffer()
        {
            Debug.Log("DestroyBuffer");
            if (self != IntPtr.Zero)
            {
                NativeMethods.DestroyAudioBuffer(self);
                BufferSize = 0;
                self = IntPtr.Zero;
            }
        }

        public IntPtr GetBufferPtr()
        {
            return self;
        }
        
        ~AudioBuffer()
        {
            DestroyBuffer();
        }
    }
}