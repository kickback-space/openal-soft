#pragma once
#include "pch.h"

class AudioBuffer
{
private:
    /* data */
public:
    AudioBuffer(/* args */);
    ~AudioBuffer();
    ALuint CreateAudioBuffer(void *input, int size, int samplerate);
};

AudioBuffer::AudioBuffer(/* args */)
{
}

AudioBuffer::~AudioBuffer()
{
}
