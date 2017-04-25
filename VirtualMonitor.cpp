#include "stdafx.h"
#include "VirtualMonitor.h"

using namespace System::Windows;

namespace SharpLib::MonitorConfig
{
    /**
    */
    VirtualMonitor::VirtualMonitor(HMONITOR aHandle) : iHandle(aHandle)
    {
        iInfo = new MONITORINFOEX();
        iInfo->cbSize = sizeof(MONITORINFOEX); //Need to set this to allow next function to identify Structure type

        if (GetMonitorInfo(aHandle, iInfo) == 0)
        {
            //TODO: handle error
            // Throw exception?
        }

        Name = gcnew System::String(iInfo->szDevice);
        PhysicalMonitors = gcnew List<PhysicalMonitor^>();
        //
        System::Windows::Point pt1(iInfo->rcMonitor.left, iInfo->rcMonitor.bottom);
        System::Windows::Point pt2(iInfo->rcMonitor.right, iInfo->rcMonitor.top);
        Rect = System::Windows::Rect(pt1,pt2);

        // Check how many physical monitor do we have
        DWORD count = 0;
        GetNumberOfPhysicalMonitorsFromHMONITOR(aHandle, &count);
        iPhysicalMonitorCount = count; // Keep track of our count

        // Fetch physical monitors
        if (count > 0) //Defensive
        {
            iPhysicalMonitorArray = new PHYSICAL_MONITOR[count];
            GetPhysicalMonitorsFromHMONITOR(aHandle, count, iPhysicalMonitorArray);
        }

        for (DWORD i = 0; i<count; i++)
        {
            //Create Physical Monitors
            PhysicalMonitors->Add(gcnew PhysicalMonitor(&iPhysicalMonitorArray[i]));
        }

    }

    /// Destructor
    VirtualMonitor::~VirtualMonitor()
    {
        // As per Microsoft recommandation we simply can the finalizer from here
        // See: https://msdn.microsoft.com/en-us/library/ke3a209d.aspx#Destructors%20and%20finalizers
        this->!VirtualMonitor();
    }

    /// Finalizer
    VirtualMonitor::!VirtualMonitor()
    {
        // Taking care of managed resources first, I guess
        delete Name;
        Name = nullptr;

        // Explicitly destroy our object, me thing that's like Dispose in C#
        for each (PhysicalMonitor^ m in PhysicalMonitors)
        {
            delete m;
        }
        PhysicalMonitors->Clear();

        // As per Microsoft recommandation we clean-up unmanaged resources
        delete iInfo;
        iInfo = NULL;

        delete iPhysicalMonitorArray;
        iPhysicalMonitorArray = NULL;
    }

    /**
    Tell whether this monitor is our primary monitor.
    */
    bool VirtualMonitor::IsPrimary()
    {
        if (iInfo == NULL)
        {
            return false;
        }

        return (iInfo->dwFlags & MONITORINFOF_PRIMARY) == MONITORINFOF_PRIMARY;
    }


    /**
    */
    /*
    String VirtualMonitor::Name()
    {
        if (iInfo == NULL)
        {
            return String::Empty;
        }


    }*/
}
