#include "stdafx.h"
#include "VirtualMonitor.h"

using namespace System::Windows;

namespace SharpLib::MonitorConfig
{
    /**
    */
    VirtualMonitor::VirtualMonitor(HMONITOR aHandle, int aIndex) : iHandle(aHandle)
    {
        iInfo = new MONITORINFOEX();
        iInfo->cbSize = sizeof(MONITORINFOEX); //Need to set this to allow next function to identify Structure type

        if (GetMonitorInfo(aHandle, iInfo) == 0)
        {
            //TODO: handle error
            // Throw exception?
        }

        DeviceName = gcnew System::String(iInfo->szDevice);
        PhysicalMonitors = gcnew List<PhysicalMonitor^>();
        
        /*
        DISPLAY_DEVICE displayDevice;
        displayDevice.cb = sizeof(DISPLAY_DEVICE);
        BOOL res = EnumDisplayDevices(iInfo->szDevice, 0, &displayDevice, 0);

        DEVMODE devMode;
        devMode.dmSize = sizeof(DEVMODE);
        res = EnumDisplaySettings(iInfo->szDevice, ENUM_CURRENT_SETTINGS, &devMode);
        */

        LoadFriendlyName(aIndex);

        //Build a Rect to be able to get the resolution conveniently
        //System::Drawing::Point pt1(iInfo->rcMonitor.left, iInfo->rcMonitor.top);
        System::Drawing::Point pt1(0, 0);
        System::Drawing::Size pt2(iInfo->rcMonitor.right - iInfo->rcMonitor.left, iInfo->rcMonitor.bottom - iInfo->rcMonitor.top);
        Rect = System::Drawing::Rectangle(pt1,pt2);

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
        // As per Microsoft recommandation we simply call the finalizer from here
        // See: https://msdn.microsoft.com/en-us/library/ke3a209d.aspx#Destructors%20and%20finalizers
        this->!VirtualMonitor();
    }

    /// Finalizer
    VirtualMonitor::!VirtualMonitor()
    {
        // Taking care of managed resources first, I guess
        delete DeviceName;
        DeviceName = nullptr;

        // Explicitly destroy our object, me thing that's like Dispose in C#
        if (PhysicalMonitors != nullptr)
        {
            for each (PhysicalMonitor^ m in PhysicalMonitors)
            {
                delete m;
            }
            PhysicalMonitors->Clear();
            PhysicalMonitors = nullptr;
        }
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

    ///
    /// That does not make sense if the monitor is actually virtual but who cares for now
    ///
    void VirtualMonitor::LoadFriendlyName(int aIndex)
    {
        // Set default
        FriendlyName = String::Empty;

        UINT32 pathCount = 0;
        UINT32 modeCount = 0;
        LONG err = GetDisplayConfigBufferSizes(QDC_ONLY_ACTIVE_PATHS, &pathCount, &modeCount);
        if (err != ERROR_SUCCESS)
        {
            return;
        }

        DISPLAYCONFIG_PATH_INFO* displayPaths = new DISPLAYCONFIG_PATH_INFO[pathCount];
        DISPLAYCONFIG_MODE_INFO* displayModes = new DISPLAYCONFIG_MODE_INFO[modeCount];

        err = QueryDisplayConfig(QDC_ONLY_ACTIVE_PATHS, &pathCount, displayPaths, &modeCount, displayModes, 0);
        if (err != ERROR_SUCCESS)
        {            
            delete displayPaths;
            delete displayModes;
            return;
        }

        int modeTargetCount = 0;
        for (UINT32 i = 0; i < modeCount; i++)
        {
            if (displayModes[i].infoType == DISPLAYCONFIG_MODE_INFO_TYPE_TARGET)
            {
                if (modeTargetCount == aIndex) // Is that the proper display, clumsy OMG
                {
                    // Now fetch that bloody name
                    DISPLAYCONFIG_TARGET_DEVICE_NAME deviceName;
                    deviceName.header.size = sizeof(DISPLAYCONFIG_TARGET_DEVICE_NAME);
                    deviceName.header.adapterId = displayModes[i].adapterId;
                    deviceName.header.id = displayModes[i].id;
                    deviceName.header.type = DISPLAYCONFIG_DEVICE_INFO_GET_TARGET_NAME;
                    err = DisplayConfigGetDeviceInfo(&deviceName.header);
                    if (err == ERROR_SUCCESS)
                    {
                        FriendlyName = gcnew String(deviceName.monitorFriendlyDeviceName);
                        break;
                    }
                }
                modeTargetCount++;
            }
        }

        // Clean-up
        delete displayPaths;
        delete displayModes;
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
