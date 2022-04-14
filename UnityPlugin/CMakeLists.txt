set(audioplugin_Headers "MyMath.h" "audioplugin.h" "MyDebug.h" "pch.h")
set(audioplugin_Source "MyMath.cpp" "audioplugin.cpp" "MyDebug.cpp" "pch.cpp")

add_library(audioplugin SHARED "MyMath.cpp" "audioplugin.cpp" "MyDebug.cpp" "pch.cpp" "AudioListener.cpp" "AudioBuffer.cpp" "AudioDevice.cpp")
target_link_libraries(audioplugin
PRIVATE ${LINKER_FLAGS} SndFile::SndFile ex-common ${MATH_LIB} ${UNICODE_FLAG})
message("Building Unity Plugin")
