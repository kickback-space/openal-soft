#include "AudioDevice.h"

AudioDevice::AudioDevice()
{
	alcLoopbackOpenDeviceSOFT = (LPALCLOOPBACKOPENDEVICESOFT)alcGetProcAddress(NULL, "alcLoopbackOpenDeviceSOFT");
	p_ALCDevice = alcLoopbackOpenDeviceSOFT(nullptr); // nullptr = get default device
	
	if (!p_ALCDevice)
		throw("failed to get sound device");

	// p_ALCContext = alcCreateContext(p_ALCDevice, attrs);  // create context
	// if(!p_ALCContext)
	// 	throw("Failed to set sound context");

	// if (!alcMakeContextCurrent(p_ALCContext))   // make context current
	// 	throw("failed to make context current");


	const ALCchar* name = nullptr;
	if (alcIsExtensionPresent(p_ALCDevice, "ALC_ENUMERATE_ALL_EXT"))
		name = alcGetString(p_ALCDevice, ALC_ALL_DEVICES_SPECIFIER);
	if (!name || alcGetError(p_ALCDevice) != AL_NO_ERROR)
		name = alcGetString(p_ALCDevice, ALC_DEVICE_SPECIFIER);
	printf("Opened \"%s\"\n", name);
	if (!alcIsExtensionPresent(NULL, "ALC_SOFT_loopback"))
		std::cout << "Loopback rendering not supported" << std::endl;
}

AudioDevice::~AudioDevice()
{
	if (!alcCloseDevice(p_ALCDevice)){
		std::cout << "failed to close sound device" << std::endl;
		printf("Error: Cannot Destroy AudioDevice");
		return;
	}
	printf("AudioDevice Destroyed");
}

ALCdevice* AudioDevice::GetDevice(){
	return p_ALCDevice;
}

LPALCLOOPBACKOPENDEVICESOFT AudioDevice::GetalcLoopbackOpenDeviceSOFT(){
	return alcLoopbackOpenDeviceSOFT;
}
