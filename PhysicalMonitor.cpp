#include "stdafx.h"
#include "PhysicalMonitor.h"

#include <HighLevelMonitorConfigurationAPI.h>

using namespace System;



namespace SharpLib::MonitorConfig
{

    PhysicalMonitor::PhysicalMonitor(PHYSICAL_MONITOR* aData) : iData(aData)
    {
        // Provide description
        Description = gcnew System::String(iData->szPhysicalMonitorDescription);

        // Get capabilities
        DWORD monitorCapabilities;
        DWORD supportedColorTemperatures;
        if (!GetMonitorCapabilities(iData->hPhysicalMonitor, &monitorCapabilities, &supportedColorTemperatures))
        {
            // TODO: throw exception?
        }

        iMonitorCapabilities = monitorCapabilities;
        iSupportedColorTemperatures = supportedColorTemperatures;
    }

    bool PhysicalMonitor::SupportsBrightness()
    {
        return (iMonitorCapabilities & MC_CAPS_BRIGHTNESS) != 0;
    }

    bool PhysicalMonitor::SupportsColourTemperature()
    {
        return (iMonitorCapabilities & MC_CAPS_COLOR_TEMPERATURE) != 0;
    }

    bool PhysicalMonitor::SupportsContrast()
    {
        return (iMonitorCapabilities & MC_CAPS_CONTRAST) != 0;
    }

    bool PhysicalMonitor::SupportsDegauss()
    {
        return (iMonitorCapabilities & MC_CAPS_DEGAUSS) != 0;
    }

    bool PhysicalMonitor::SupportsDisplayAreaPosition()
    {
        return (iMonitorCapabilities & MC_CAPS_DISPLAY_AREA_POSITION) != 0;
    }

    bool PhysicalMonitor::SupportsDisplayAreaSize()
    {
        return (iMonitorCapabilities & MC_CAPS_DISPLAY_AREA_SIZE) != 0;
    }

    bool PhysicalMonitor::SupportsTechnologyType()
    {
        return (iMonitorCapabilities & MC_CAPS_MONITOR_TECHNOLOGY_TYPE) != 0;
    }

    bool PhysicalMonitor::SupportsRGBDrive()
    {
        return (iMonitorCapabilities & MC_CAPS_RED_GREEN_BLUE_DRIVE) != 0;
    }

    bool PhysicalMonitor::SupportsRGBGain()
    {
        return (iMonitorCapabilities & MC_CAPS_RED_GREEN_BLUE_GAIN) != 0;
    }

    bool PhysicalMonitor::SupportsRestoreColourDefaults()
    {
        return (iMonitorCapabilities & MC_CAPS_RESTORE_FACTORY_COLOR_DEFAULTS) != 0;
    }

    bool PhysicalMonitor::SupportsRestoreDefaults()
    {
        return (iMonitorCapabilities & MC_CAPS_RESTORE_FACTORY_DEFAULTS) != 0;
    }

    bool PhysicalMonitor::SupportsRestoreDefaultEX()
    {
        return (iMonitorCapabilities & MC_RESTORE_FACTORY_DEFAULTS_ENABLES_MONITOR_SETTINGS) != 0;
    }


}

