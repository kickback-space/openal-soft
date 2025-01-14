using System.Diagnostics;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using OpenAL;
using Debug = AudioSpace.DummyUnityClasses.Debug;

namespace OpenALConsoleApp.Examples
{

    public class SimpleAudioPlayer
    {
        class UniquePtr<T> : IDisposable
        {
            public IntPtr ptr { get; }
            public int length = 0;

            public UniquePtr(int size)
            {
                Console.WriteLine("UniquePtr Created");
                ptr = Marshal.AllocHGlobal(size);
                length = size;
            }

            public UniquePtr(T type)
            {
                length = Marshal.SizeOf<T>();
                ptr = Marshal.AllocHGlobal(length);
            }

            ~UniquePtr()
            {
                ReleaseUnmanagedResources();
            }

            private void ReleaseUnmanagedResources()
            {
                Marshal.FreeHGlobal(ptr);
            }

            public void Dispose()
            {
                ReleaseUnmanagedResources();
                GC.SuppressFinalize(this);
            }
        }

        void ReadAudioFile(string path, out UniquePtr<byte> intPtr)
        {
            using (var stream = File.Open(path, FileMode.Open))
            {
                intPtr = new UniquePtr<byte>((int) stream.Length);
                using (var reader = new BinaryReader(stream, Encoding.UTF8, false))
                {
                    var readbytes = reader.ReadBytes((int) stream.Length);
                    Marshal.Copy(readbytes, 0, intPtr.ptr, readbytes.Length);
                }
            }
        }

        public void Start(string audiofilePath)
        {

            AudioListener audioListener = new AudioListener();
            
            UniquePtr<byte> audiodataPtr;
            ReadAudioFile(audiofilePath, out audiodataPtr);

            AudioBuffer audioBuffer = new AudioBuffer(3);
            int err = audioBuffer.CopyAudioToBuffer(2, audiodataPtr.ptr, audiodataPtr.length, 8000, AL_FORMAT.AL_FORMAT_MONO16);
            
            audioListener.CreateAudioSource(audioBuffer.GetBufferPtr(), 2, Vector3.One);
            audioListener.PlayAudio();
            Debug.Log("Playing....");

            audioBuffer.DestroyBuffer();
            audiodataPtr.Dispose();
        }
    }
}