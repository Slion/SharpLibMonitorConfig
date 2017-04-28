#pragma once
#include <windows.h>


namespace SharpLib::MonitorConfig
{
    /// Define a Monitor Configuration Setting
    public ref class Setting
    {        
    public:
        Setting();
        Setting(DWORD aMin, DWORD aCurrent, DWORD aMax);
        /// Maximum value this setting can take
        property DWORD Max;
        /// Minimum value this setting can take
        property DWORD Min;
        /// Current setting value 
        property DWORD Current;
    };
}