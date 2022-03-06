using AudioSpace.DummyUnityClasses;


namespace OpenAL
{
    public class AudioListener : MonoBehaviour
    {
        IntPtr self = IntPtr.Zero;
        private int channel = 2;

        AudioListener()
        {
            self = NativeMethods.CreateAudioListener();
#if IsConsoleApp
    Start();
#endif
        }

        public void CreateAudioSource()
        {
            //NativeMethods.CreateAudioSource(self, );
        }
        
        void Start()
        {
            
        }
    }
}