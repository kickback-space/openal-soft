#pragma once
#include "pch.h"

/* LoadEffect loads the given initial reverb properties into the given OpenAL
 * effect object, and returns non-zero on success.
 */

class AudioListener
{
private:
    /* Filter object functions */
    LPALGENFILTERS alGenFilters;
    LPALDELETEFILTERS alDeleteFilters;
    LPALISFILTER alIsFilter;
    LPALFILTERI alFilteri;
    LPALFILTERIV alFilteriv;
    LPALFILTERF alFilterf;
    LPALFILTERFV alFilterfv;
    LPALGETFILTERI alGetFilteri;
    LPALGETFILTERIV alGetFilteriv;
    LPALGETFILTERF alGetFilterf;
    LPALGETFILTERFV alGetFilterfv;

    /* Effect object functions */
    LPALGENEFFECTS alGenEffects;
    LPALDELETEEFFECTS alDeleteEffects;
    LPALISEFFECT alIsEffect;
    LPALEFFECTI alEffecti;
    LPALEFFECTIV alEffectiv;
    LPALEFFECTF alEffectf;
    LPALEFFECTFV alEffectfv;
    LPALGETEFFECTI alGetEffecti;
    LPALGETEFFECTIV alGetEffectiv;
    LPALGETEFFECTF alGetEffectf;
    LPALGETEFFECTFV alGetEffectfv;

    /* Auxiliary Effect Slot object functions */
    LPALGENAUXILIARYEFFECTSLOTS alGenAuxiliaryEffectSlots;
    LPALDELETEAUXILIARYEFFECTSLOTS alDeleteAuxiliaryEffectSlots;
    LPALISAUXILIARYEFFECTSLOT alIsAuxiliaryEffectSlot;
    LPALAUXILIARYEFFECTSLOTI alAuxiliaryEffectSloti;
    LPALAUXILIARYEFFECTSLOTIV alAuxiliaryEffectSlotiv;
    LPALAUXILIARYEFFECTSLOTF alAuxiliaryEffectSlotf;
    LPALAUXILIARYEFFECTSLOTFV alAuxiliaryEffectSlotfv;
    LPALGETAUXILIARYEFFECTSLOTI alGetAuxiliaryEffectSloti;
    LPALGETAUXILIARYEFFECTSLOTIV alGetAuxiliaryEffectSlotiv;
    LPALGETAUXILIARYEFFECTSLOTF alGetAuxiliaryEffectSlotf;
    LPALGETAUXILIARYEFFECTSLOTFV alGetAuxiliaryEffectSlotfv;

    /* LoadEffect loads the given initial reverb properties into the given OpenAL
     * effect object, and returns non-zero on success.
     */

    static const int MaxTransitions = 8;
    EFXEAXREVERBPROPERTIES reverbs[2] = {
        EFX_REVERB_PRESET_CARPETEDHALLWAY,
        EFX_REVERB_PRESET_BATHROOM};
    ALCdevice *device = NULL;
    ALCcontext *context = NULL;
    ALuint effects[2] = {0, 0};
    ALuint slots[2] = {0, 0};
    ALuint direct_filter = 0;
    ALuint source = 0;
    ALCint num_sends = 0;
    ALenum state = AL_INITIAL;
    ALfloat direct_gain = 1.0f;
    int basetime = 0;
    int loops = 0;

public:
    int InitAudioListener();
    int PlayAudio();
    void CreateAudioSource(ALuint* buffer, int index, Vector3 position);
    void UpdateListenerAndEffects(float timediff, const ALuint slots[2], const ALuint effects[2], const EFXEAXREVERBPROPERTIES reverbs[2]);
    int LoadEffect(ALuint effect, const EFXEAXREVERBPROPERTIES *reverb);
};