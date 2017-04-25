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

        // Capability checks
        bool SupportsBrightness();
        bool SupportsColourTemperature();
        bool SupportsContrast();
        bool SupportsDegauss();
        bool SupportsDisplayAreaPosition();
        bool SupportsDisplayAreaSize();
        bool SupportsTechnologyType();
        bool SupportsRGBDrive();
        bool SupportsRGBGain();
        bool SupportsRestoreColourDefaults();
        bool SupportsRestoreDefaults();
        bool SupportsRestoreDefaultEX();

        //Brightness
        property Setting^ Brightness
        {
            Setting^ get();
            void set(Setting^ aSetting);
        }


        property String^ Description;

    private:
        PHYSICAL_MONITOR* iData; // Used
        DWORD iMonitorCapabilities;
        DWORD iSupportedColorTemperatures;
        //
        Setting iBrightness;
    };
}
