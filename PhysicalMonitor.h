#pragma once
#include <Windows.h>
#include <PhysicalMonitorEnumerationAPI.h>

using namespace System;



namespace SharpLib::MonitorConfig
{

    /// <summary>
    /// Summary for VirtualMonitor
    /// </summary>
    public ref class PhysicalMonitor
    {
    public:
        PhysicalMonitor(/*HMONITOR aHandle*/) //: iHandle(aHandle)
        {

            //
            //TODO: Add the constructor code here
            //
        }


    private:
        PHYSICAL_MONITOR* iData;
    };
}
