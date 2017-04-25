#pragma once
#include <Windows.h>
#include "PhysicalMonitor.h"

using namespace System;
using namespace System::Windows;
using namespace System::Collections::Generic;


namespace SharpLib::MonitorConfig
{

    /// <summary>
    /// Summary for VirtualMonitor
    /// </summary>
    public ref class VirtualMonitor
    {
    public:
        VirtualMonitor(HMONITOR aHandle);
        ~VirtualMonitor();

        bool IsPrimary();
        //String Name();

        property String^ Name;
        property Rect Rect;

    private:
        HMONITOR iHandle;
        MONITORINFOEX* iInfo;
        DWORD iPhysicalMonitorCount;
        PHYSICAL_MONITOR* iPhysicalMonitorArray;
        // A virtual monitor has a collection of physical monitor
        List<PhysicalMonitor^> iPhysicalMonitors;
        //
        
    };
}
