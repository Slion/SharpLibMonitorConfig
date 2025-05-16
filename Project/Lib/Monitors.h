// SharpLibMonitorConfig.h

#pragma once
#include <windows.h>
#include < vcclr.h >
#include "VirtualMonitor.h"

using namespace System;
using namespace System::Collections::Generic;


namespace SharpLib::MonitorConfig
{

    /// <summary>
    /// 
    /// </summary>
    public ref class Monitors
    {
        // TODO: Add your methods for this class here.
    public:
        Monitors();
        ~Monitors();
        !Monitors();

        property List<VirtualMonitor^>^ VirtualMonitors;

        bool Scan();

    private:
        void Construct();
        void Destruct();
        
    };


}
