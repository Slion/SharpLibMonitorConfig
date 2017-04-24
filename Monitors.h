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
        void Scan();

    private:


    public:
        List<VirtualMonitor^> iVirtualMonitors;
    };


//#pragma unmanaged
    BOOL CALLBACK MonitorEnumCallback(HMONITOR aMonitor, HDC aHdc, LPRECT aRect, LPARAM aParam)
    {
        // Unpack our object
        gcroot<Monitors^>* self = (gcroot<Monitors^>*)aParam;
        // Add our virtual monitor
        (*self)->iVirtualMonitors.Add(gcnew VirtualMonitor(aMonitor));
        // Done here
        return TRUE;
    }
//#pragma managed

}
