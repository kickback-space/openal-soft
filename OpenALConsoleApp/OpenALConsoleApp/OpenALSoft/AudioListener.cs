using System.Numerics;
using AudioSpace.DummyUnityClasses;


namespace OpenAL
{
    public class AudioListener : MonoBehaviour
    {
        IntPtr self = IntPtr.Zero;
        private int channel = 2;

        public AudioListener()
        {
            unsafe
            {
                self = (IntPtr) NativeMethods.CreateAudioListener();
            }
        }

        public void CreateAudioSource(IntPtr buffer, int index, Vector3 position)
        {
            NativeMethods.CreateAudioSource(self, buffer, index, position);
        }
        
        public void PlayAudio()
        {
            NativeMethods.PlayAudio(self);
        }

        ~AudioListener()
        {
            NativeMethods.DestroyAudioListener(self);
        }
    }
}