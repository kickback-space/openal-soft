using AudioSpace.DummyUnityClasses;


namespace OpenAL
{
    public class AudioListener : MonoBehaviour
    {
        private int channel = 2;

        AudioListener()
        {
#if IsConsoleApp
    Start();
#endif
        }

        void Start()
        {
            
        }
    }
}