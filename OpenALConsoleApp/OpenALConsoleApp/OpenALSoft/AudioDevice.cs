namespace OpenAL;

public class AudioDevice
{
    private IntPtr self;

    public AudioDevice()
    {
        self = NativeMethods.CreateAudioDevice();
    }

    ~AudioDevice()
    {
        NativeMethods.DeleteAudioDevice(self);
    }

    public IntPtr GetDevice()
    {
        return self;
    }
}