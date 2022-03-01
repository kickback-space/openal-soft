using System;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using UnityEditor.Compilation;
using UnityEngine;
using static AudioSpace.AudioSpace;

namespace App.Scripts.Test
{
    public class TestAudioSpace : MonoBehaviour
    {
        class UniquePtr<T>
        {
            public IntPtr ptr{get;}
            public int length = 0;
            public UniquePtr(int size)
            {
                Debug.Log("UniquePtr Created");
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
                Debug.Log("UniquePtr destroyed");
                Marshal.FreeHGlobal(ptr);
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
                    Marshal.Copy(readbytes,0,intPtr.ptr, readbytes.Length);
                }
            }
        }
        UniquePtr<byte> soundsourceptr;
        private Thread th_audio;
        private void Start()
        {
            string soundfilePath = Application.dataPath + "/sample_audios/car-ignition-3.wav";
            ReadAudioFile(soundfilePath, out soundsourceptr);

            /*th_audio = new Thread(audioThread);
            th_audio.Start();*/
            
            MyTestDebugLog("hello world");
        }

        void audioThread()
        {
            PlayAudio();
        }

        private void OnDestroy()
        {
            //th_audio.Abort();
        }
    }
}