using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using OpenAL;

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
                Console.WriteLine("ReleaseUnmanagedResources");
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
            UniquePtr<byte> audiodataPtr;
            ReadAudioFile(audiofilePath, out audiodataPtr);
            
            
            
            audiodataPtr.Dispose();
        }
    }
}