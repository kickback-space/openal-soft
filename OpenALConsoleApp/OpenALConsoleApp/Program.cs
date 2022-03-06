using System.Drawing;
using System.Numerics;
using System.Runtime.InteropServices;
using AudioSpace;
using OpenAL;
using OpenALConsoleApp.Examples;

class Program
{
    public static Program program;
    public static void Main()
    {
        program = new Program();
        program.InitMyDebug();

        /*Vector3 vector3 = new Vector3(5,24, 0.124f);
        NativeMethods.MyTestDebugLogVector(vector3);*/

        SimpleAudioPlayer simpleAudioPlayer = new SimpleAudioPlayer();
        simpleAudioPlayer.Start("/LinuxData/Kickback/openal-soft/build/sample_audios/sample2.wav");
    }

    void InitMyDebug()
    {
        MyDebug myDebug = new MyDebug();
        myDebug.Register();
    }
}