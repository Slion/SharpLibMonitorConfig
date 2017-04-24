// This is the main DLL file.

#include "stdafx.h"

#include "Monitors.h"

namespace SharpLib::MonitorConfig
{
    ///
    BOOL CALLBACK MonitorEnumCallback(HMONITOR aMonitor, HDC aHdc, LPRECT aRect, LPARAM aParam)
    {
        // Unpack our object
        gcroot<Monitors^>* self = (gcroot<Monitors^>*)aParam;
        // Add our virtual monitor
        (*self)->iVirtualMonitors.Add(gcnew VirtualMonitor(aMonitor));
        // Done here
        return TRUE;
    }


    bool Monitors::Scan()
    {
        // Package into native type as per: http://stackoverflow.com/a/4163378/3969362
        gcroot<Monitors^>* self = new gcroot<Monitors^>(this);
        bool success = EnumDisplayMonitors(NULL, NULL, MonitorEnumCallback, (LPARAM)self) != 0;
        delete self;
        return success;
    }

}
