#pragma once
#include <Windows.h>

using namespace System;



namespace SharpLib::MonitorConfig
{

    /// <summary>
    /// Summary for VirtualMonitor
    /// </summary>
    public ref class VirtualMonitor
    {
    public:
        VirtualMonitor(HMONITOR aHandle): iHandle(aHandle)
        {

            //
            //TODO: Add the constructor code here
            //
        }


    private:
        HMONITOR iHandle;
    };
}
