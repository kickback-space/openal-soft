using System.Numerics;
using AudioSpace.DummyUnityClasses;


namespace OpenAL
{
    public class AudioListener : MonoBehaviour
    {
        IntPtr self = IntPtr.Zero;
        private int channel = 2;

        public AudioListener(IntPtr AudioDevice)
        {
            self = NativeMethods.CreateAudioListener(AudioDevice);
        }

        public void CreateAudioSource(IntPtr buffer, int index, Vector3 position)
        {
            NativeMethods.CreateAudioSource(self, buffer, index, position);
        }

        public void PlayAudio()
        {
            NativeMethods.PlayAudio(self);
        }

        public void StartListenerThread()
        {
            NativeMethods.StartListenerThread(self);
        }

        public void StopListenerThread()
        {
            NativeMethods.StopListenerThread(self);
        }

        ~AudioListener()
        {
            NativeMethods.DestroyAudioListener(self);
        }
    }
}