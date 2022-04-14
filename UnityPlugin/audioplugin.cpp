#include "audioplugin.h"
#include "AudioDevice.h"
#include "AudioListener.h"
#include "AudioBuffer.h"
#include <iostream>

extern "C"
{
#pragma region DebugLog
    UNITY_INTERFACE_EXPORT void MyRegisterDebugCallback(OnMyDebugCallback cb)
    {
        RegisterDebugCallback(cb);
    }

    UNITY_INTERFACE_EXPORT void MyTestDebugLog(const char *msg)
    {
        MyDebug::Log(msg, Color::Black);
    }
    UNITY_INTERFACE_EXPORT void MyTestDebugLogVector(const Vector3 position)
    {
        MyDebug::Log(position, Color::Black);
    }
#pragma endregion

#pragma region Audio Device
    UNITY_INTERFACE_EXPORT AudioDevice *CreateAudioDevice()
    {
        AudioDevice *audiodevice = new AudioDevice();
        return audiodevice;
    }
    UNITY_INTERFACE_EXPORT void DeleteAudioDevice(AudioDevice *audiodevice)
    {
        delete audiodevice;
    }
#pragma endregion

#pragma region Audio Listener
    UNITY_INTERFACE_EXPORT void *CreateAudioListener(AudioDevice *audiodevice)
    {
        AudioListener *audioListener = new AudioListener();
        int err = audioListener->InitAudioListener(audiodevice);
        if (err != 0)
        {
            return nullptr;
        }
        return audioListener;
    }

    UNITY_INTERFACE_EXPORT void DestroyAudioListener(AudioListener *audioListener)
    {
        delete audioListener;
    }

    UNITY_INTERFACE_EXPORT void CreateAudioSource(AudioListener *audioListener, ALuint *buffer, int index, Vector3 position)
    {
        audioListener->CreateAudioSource(buffer, index, position);
    }

    UNITY_INTERFACE_EXPORT void PlayAudio(AudioListener *audioListener)
    {
        audioListener->PlayAudio();
    }

    UNITY_INTERFACE_EXPORT void StartListenerThread(AudioListener *audioListener)
    {
        audioListener->StartListenerThread();
    }
    UNITY_INTERFACE_EXPORT void StopListenerThread(AudioListener *audioListener)
    {
        audioListener->StopListenerThread();
    }

#pragma endregion

#pragma region Audio Buffer
    UNITY_INTERFACE_EXPORT AudioBuffer *
    CreateAudioBuffer(int bufferSize)
    {
        AudioBuffer *audioBuffer = new AudioBuffer(bufferSize);
        return audioBuffer;
    }
    UNITY_INTERFACE_EXPORT void DestroyAudioBuffer(AudioBuffer *audioBuffer)
    {
        delete audioBuffer;
    }
    UNITY_INTERFACE_EXPORT int CopyAudioToBuffer(AudioBuffer *audioBuffer, int buffer_index, void *input, int input_size, int samplerate, ALenum format)
    {
        int err = audioBuffer->CopyAudioToBuffer(buffer_index, input, input_size, samplerate, format);
        return err;
    }
#pragma endregion
}
