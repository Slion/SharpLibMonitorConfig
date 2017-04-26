#pragma once
#include <windows.h>


namespace SharpLib::MonitorConfig
{

    public ref class Setting
    {
        // TODO: Add your methods for this class here.
    public:
        Setting();
        Setting(DWORD aMin, DWORD aCurrent, DWORD aMax);

        property DWORD Max;
        property DWORD Min;
        property DWORD Current;
    };
}