#include "AudioBuffer.h"

ALuint AudioBuffer::CreateAudioBuffer(void *input, int size, int samplerate)
{
    ALuint buffer = 0;
    ALenum format = AL_FORMAT_MONO16;
    printf("size: %d", size);
    printf("input*: %d", input);
    alGenBuffers(1, &buffer);
    alBufferData(buffer, format, input, size, samplerate);
    ALenum err = alGetError();
    if (err != AL_NO_ERROR)
    {
        fprintf(stderr, "OpenAL Error: %s\n", alGetString(err));
        if (buffer && alIsBuffer(buffer))
            alDeleteBuffers(1, &buffer);
        return 0;
    }
    return buffer;
}