#include "MyDebug.h"

//-------------------------------------------------------------------
void  MyDebug::Log(const char* message, Color color) {
    if (callbackInstance != nullptr)
        callbackInstance(message, (int)color, (int)strlen(message));
}

void  MyDebug::Log(const std::string message, Color color) {
    const char* tmsg = message.c_str();
    if (callbackInstance != nullptr)
        callbackInstance(tmsg, (int)color, (int)strlen(tmsg));
}

void  MyDebug::Log(const int message, Color color) {
    std::stringstream ss;
    ss << message;
    send_log(ss, color);
}

void  MyDebug::Log(const char message, Color color) {
    std::stringstream ss;
    ss << message;
    send_log(ss, color);
}

void  MyDebug::Log(const float message, Color color) {
    std::stringstream ss;
    ss << message;
    send_log(ss, color);
}

void  MyDebug::Log(const double message, Color color) {
    std::stringstream ss;
    ss << message;
    send_log(ss, color);
}

void MyDebug::Log(const bool message, Color color) {
    std::stringstream ss;
    if (message)
        ss << "true";
    else
        ss << "false";

    send_log(ss, color);
}


void MyDebug::Log(const Vector3 message, Color color) {

    std::stringstream ss;
    ss << message;
    send_log(ss, color);
}

void MyDebug::send_log(const std::stringstream &ss, const Color &color) {
    const std::string tmp = ss.str();
    const char* tmsg = tmp.c_str();
    if (callbackInstance != nullptr)
        callbackInstance(tmsg, (int)color, (int)strlen(tmsg));
}
//-------------------------------------------------------------------

//Create a callback delegate
void RegisterDebugCallback(OnMyDebugCallback cb) {
    callbackInstance = cb;
}