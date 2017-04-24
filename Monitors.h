// SharpLibMonitorConfig.h

#pragma once
#include <windows.h>
#include < vcclr.h >
#include "VirtualMonitor.h"

using namespace System;
using namespace System::Collections::Generic;


namespace SharpLib::MonitorConfig
{

    public ref class Monitors
    {
        // TODO: Add your methods for this class here.
    public:                   
        bool Scan();

    private:


    public:
        List<VirtualMonitor^> iVirtualMonitors;
    };


}
