#pragma once
#include <Windows.h>
#include <PhysicalMonitorEnumerationAPI.h>
#include <HighLevelMonitorConfigurationAPI.h>

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


        String^ Description;

    private:
        PHYSICAL_MONITOR* iData; // Used
        DWORD iMonitorCapabilities;
        DWORD iSupportedColorTemperatures;
    };
}
