#pragma once
#include <Windows.h>
#include "PhysicalMonitor.h"

using namespace System;
using namespace System::Windows;
using namespace System::Collections::Generic;
using namespace System::Drawing;


namespace SharpLib::MonitorConfig
{

    /// <summary>
    /// Each VirtualMonitor has a collection of PhysicalMonitor
    /// </summary>
    public ref class VirtualMonitor
    {
    public:
        // Constructor
        VirtualMonitor(HMONITOR aHandle, int aIndex);
        // Destructor
        ~VirtualMonitor();
        // Finalizer
        !VirtualMonitor();

        bool IsPrimary();
      
        /// The name of this monitor
        property String^ DeviceName;
        /// The friendly name of this monitor
        property String^ FriendlyName;
        /// Rectangle defining our monitor, check its size for monitor resolution
        property System::Drawing::Rectangle Rect;
        /// A virtual monitor has a collection of physical monitor
        property List<PhysicalMonitor^>^ PhysicalMonitors;
            
    private:
        void LoadFriendlyName(int aIndex);

    private:
        HMONITOR iHandle;
        MONITORINFOEX* iInfo;
        DWORD iPhysicalMonitorCount;
        PHYSICAL_MONITOR* iPhysicalMonitorArray;
    };
}
