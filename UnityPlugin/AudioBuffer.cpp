#include "AudioBuffer.h"

AudioBuffer::AudioBuffer(int size)
{
    ALenum format = AL_FORMAT_MONO16;
    printf("size: %d", size);

    Buffer = new ALuint[size];
    Size = size;

    alGenBuffers(Size, Buffer);
    ALenum err = alGetError();
    if (err != AL_NO_ERROR)
    {
        fprintf(stderr, "OpenAL Error: %s\n", alGetString(err));
        if (Buffer && alIsBuffer(Buffer[0]))
            alDeleteBuffers(Size, Buffer);
    }
}

AudioBuffer::~AudioBuffer()
{
    AudioBuffer::DeleteAudioBuffer();
    delete Buffer;
}

int AudioBuffer::CopyAudioToBuffer(int bufferIndex, void *input, int size, int samplerate, ALenum format){
    alBufferData(Buffer[bufferIndex], format, input, size, samplerate);
    ALenum err = alGetError();
    if (err != AL_NO_ERROR)
    {
        fprintf(stderr, "OpenAL Error: %s\n", alGetString(err));
        if (Buffer && alIsBuffer(Buffer[bufferIndex]))
            DeleteAudioBuffer();
    }
    return err;
}

void AudioBuffer::DeleteAudioBuffer()
{
    alDeleteBuffers(Size, Buffer);
    Size = 0;
}