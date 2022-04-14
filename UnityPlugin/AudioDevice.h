#pragma once
#include "pch.h"

class AudioDevice
{
private:
	ALCdevice* p_ALCDevice;
	LPALCLOOPBACKOPENDEVICESOFT alcLoopbackOpenDeviceSOFT;
public:
	AudioDevice();
	~AudioDevice();
	ALCdevice* GetDevice();
	LPALCLOOPBACKOPENDEVICESOFT GetalcLoopbackOpenDeviceSOFT();
};

