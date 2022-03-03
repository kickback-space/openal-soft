using AudioSpace;
using OpenALConsoleApp.Examples;

class Program
{
    public static Program program;
    public static void Main()
    {
        program = new Program();
        program.InitMyDebug();

        SimpleAudioPlayer simpleAudioPlayer = new SimpleAudioPlayer();
        simpleAudioPlayer.Start("/LinuxData/Kickback/openal-soft/build/sample_audios/sample2.wav");
    }

    void InitMyDebug()
    {
        MyDebug myDebug = new MyDebug();
        myDebug.Register();
    }
}