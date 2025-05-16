// This is the main DLL file.

#include "Monitors.h"

namespace SharpLib::MonitorConfig
{
    ///
    BOOL CALLBACK MonitorEnumCallback(HMONITOR aMonitor, HDC aHdc, LPRECT aRect, LPARAM aParam)
    {
        // Unpack our object
        gcroot<Monitors^>* self = (gcroot<Monitors^>*)aParam;
        // Add our virtual monitor
        (*self)->VirtualMonitors->Add(gcnew VirtualMonitor(aMonitor, (*self)->VirtualMonitors->Count));
        // Done here
        return TRUE;
    }

    Monitors::Monitors()
    { 
        Construct();
    }

    Monitors::~Monitors()
    {
        this->!Monitors();
    }

    Monitors::!Monitors()
    {
        Destruct();
    }

    void Monitors::Construct()
    {
        VirtualMonitors = gcnew List<VirtualMonitor^>();
    }

    void Monitors::Destruct()
    {
        if (VirtualMonitors != nullptr)
        {
            for each (VirtualMonitor^ vm in VirtualMonitors)
            {
                delete vm;
            }
            VirtualMonitors->Clear();
            delete VirtualMonitors;
            VirtualMonitors = nullptr;
        }
    }

    bool Monitors::Scan()
    {
        Destruct();
        Construct();
        // Package into native type as per: http://stackoverflow.com/a/4163378/3969362
        gcroot<Monitors^>* self = new gcroot<Monitors^>(this);
        bool success = EnumDisplayMonitors(NULL, NULL, MonitorEnumCallback, (LPARAM)self) != 0;
        delete self;
        return success;
    }

}
