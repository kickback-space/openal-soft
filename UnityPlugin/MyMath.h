#pragma once
#include "AL/al.h"
#include <sstream>

struct Vector3;

struct Vector3
{
    //const zero = 
    Vector3(ALfloat _x, ALfloat _y, ALfloat _z)
    :x(_x), y(_y), z(_z)
    {}
    
    ALfloat x, y, z;

    friend std::stringstream &operator<<(std::stringstream &in, const Vector3 other)
    {
        in << "(" << other.x << "," << other.y << "," << other.z << ")";
        return in;
    }


    friend std::ostream &operator<<(std::ostream &in, const Vector3 other)
    {
        in << "(" << other.x << "," << other.y << "," << other.z << ")";
        return in;
    }
};

struct Vector4
{
    ALfloat x, y, z, w;
};

struct Transform
{
    // Vector3 position;
    // Vector4 rotation;
    // Vector3 scale;
};