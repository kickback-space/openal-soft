add_library(audioplugin SHARED audioplugin.cpp MyDebug.cpp pch.cpp)
target_link_libraries(audioplugin
PRIVATE ${LINKER_FLAGS} SndFile::SndFile ex-common ${MATH_LIB} ${UNICODE_FLAG})
message("Building Unity Plugin")

add_executable(audiospace audioplugin.cpp MyDebug.cpp pch.cpp)
target_link_libraries(audiospace
PRIVATE ${LINKER_FLAGS} SndFile::SndFile ex-common ${MATH_LIB} ${UNICODE_FLAG})

message("Building Unity Plugin Executable")