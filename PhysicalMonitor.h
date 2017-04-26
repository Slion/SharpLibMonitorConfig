#pragma once
#include <Windows.h>
#include <PhysicalMonitorEnumerationAPI.h>
#include <HighLevelMonitorConfigurationAPI.h>
#include "Setting.h"

using namespace System;



namespace SharpLib::MonitorConfig
{

    /// <summary>
    /// Summary for VirtualMonitor
    /// </summary>
    public ref class PhysicalMonitor
    {
    public:
        PhysicalMonitor(PHYSICAL_MONITOR* aData);
        ~PhysicalMonitor();
        !PhysicalMonitor();

        // Actions
        void RestoreFactoryDefaults();
        void RestoreFactoryColorDefault();

        // Capability checks
        property bool SupportsBrightness { bool get(); }
        property bool SupportsContrast { bool get(); }
        property bool SupportsColourTemperature { bool get(); }
        property bool SupportsDegauss { bool get(); }
        property bool SupportsDisplayAreaPosition { bool get(); }
        property bool SupportsDisplayAreaSize { bool get(); }
        property bool SupportsTechnologyType { bool get(); }
        property bool SupportsRgbDrive { bool get(); }
        property bool SupportsRgbGain { bool get(); }
        property bool SupportsRestoreFactoryDefaults { bool get(); }
        property bool SupportsRestoreFactoryColorDefaults { bool get(); }
        property bool RestoringFactoryDefaultsEnablesMonitorSettings { bool get(); }

        // Brightness
        property Setting^ Brightness
        {
            Setting^ get();
            void set(Setting^ aSetting);
        }

        // Contrast
        property Setting^ Contrast
        {
            Setting^ get();
            void set(Setting^ aSetting);
        }


        property String^ Description;

    private:
        property HANDLE Handle { HANDLE get() { return iData->hPhysicalMonitor; } }

    private:
        PHYSICAL_MONITOR* iData; // Used
        DWORD iMonitorCapabilities;
        DWORD iSupportedColorTemperatures;
        //
        Setting iBrightness;
        Setting iContrast;
    };
}
