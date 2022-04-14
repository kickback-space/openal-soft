#pragma once
#include <memory>
#include <sstream>
#include <bits/stringfwd.h>

#include <assert.h>
#include <inttypes.h>
#include <limits.h>
#include <math.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#include "sndfile.h"

#include "AL/al.h"
#include "AL/alc.h"
#include "AL/efx.h"
#include "AL/efx-presets.h"
#include "AL/alext.h"

#include "common/alhelpers.h"

#ifndef M_PI
#define M_PI 3.14159265358979323846
#endif

#include <iostream>
#include <thread>
#include <chrono>

#include "include/unity/IUnityInterface.h"
#include "MyMath.h"
#include "MyDebug.h"