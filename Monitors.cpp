// This is the main DLL file.

#include "stdafx.h"

#include "Monitors.h"

namespace SharpLib::MonitorConfig
{
    void Monitors::Scan()
    {
        // Package into native type as per: http://stackoverflow.com/a/4163378/3969362
        gcroot<Monitors^>* self = new gcroot<Monitors^>(this);
        EnumDisplayMonitors(NULL, NULL, MonitorEnumCallback, (LPARAM)self);
        delete self;
    }

}
