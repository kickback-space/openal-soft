using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace AudioSpace
{
    public static class AudioSpace
    {
        public const string LibName = "audioplugin";
        
        [DllImport(LibName)]
        public static extern int LoadSoundRaw(IntPtr input, int size, int samplerate);
        
        [DllImport(LibName)]
        public static extern int PlayAudio();
        
        #region MyDebug
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void MyRegisterDebugCallback(MydebugCallbackDelegate cb);
        //Create string param callback delegate
        public delegate void MydebugCallbackDelegate(IntPtr request, int color, int size);
        
        [DllImport(LibName)]
        public static extern IntPtr MyTestDebugLog(string message);
        #endregion
    }
}