#pragma once
#include "pch.h"

class AudioBuffer
{
private:
    ALuint Buffer;
    int Size;
public:
    AudioBuffer(int size);
    ~AudioBuffer();
    int CopyAudioToBuffer(int bufferIndex,void *input, int size, int samplerate, ALenum format);
    void DeleteAudioBuffer();
};
