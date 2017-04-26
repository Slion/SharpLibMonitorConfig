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
        DWORD monitorCapabilities=0;
        DWORD supportedColorTemperatures=0;
        if (!GetMonitorCapabilities(Handle, &monitorCapabilities, &supportedColorTemperatures))
        {
            // TODO: throw exception?
        }

        iMonitorCapabilities = monitorCapabilities;
        iSupportedColorTemperatures = supportedColorTemperatures;
    }

    PhysicalMonitor::~PhysicalMonitor()
    {
        this->!PhysicalMonitor();
    }

    PhysicalMonitor::!PhysicalMonitor()
    {
        delete Description;
        Description = nullptr;
    }

    ///
    /// Perform factory reset
    ///
    void PhysicalMonitor::RestoreFactoryDefaults()
    {
        RestoreMonitorFactoryDefaults(Handle);
    }

    ///
    /// Perform factory color reset
    ///
    void PhysicalMonitor::RestoreFactoryColorDefault()
    {
        RestoreMonitorFactoryColorDefaults(Handle);
    }

    ///
    /// 
    ///
    Setting^ PhysicalMonitor::Brightness::get()
    {
        DWORD min=0;
        DWORD max=0;
        DWORD current=0;
        // Get our values
        BOOL success = GetMonitorBrightness(Handle, &min, &current, &max);
        // Set our value
        iBrightness.Current = current;
        iBrightness.Min = min;
        iBrightness.Max = max;
        // Provide them
        return %iBrightness;
    }

    ///
    void PhysicalMonitor::Brightness::set(Setting^ aBrigthness)
    {
        BOOL success = SetMonitorBrightness(Handle, aBrigthness->Current);
    }

    ///
    Setting^ PhysicalMonitor::Contrast::get()
    {
        DWORD min = 0;
        DWORD max = 0;
        DWORD current = 0;
        // Get our values
        BOOL success = GetMonitorContrast(Handle, &min, &current, &max);
        // Set our value
        iContrast.Current = current;
        iContrast.Min = min;
        iContrast.Max = max;
        // Provide them
        return %iContrast;
    }

    ///
    void PhysicalMonitor::Contrast::set(Setting^ aContrast)
    {
        BOOL success = SetMonitorContrast(Handle, aContrast->Current);
    }
    
    ////////// Capabilities checks

    bool PhysicalMonitor::SupportsBrightness::get()
    {
        return (iMonitorCapabilities & MC_CAPS_BRIGHTNESS) != 0;
    }

    bool PhysicalMonitor::SupportsContrast::get()
    {
        return (iMonitorCapabilities & MC_CAPS_CONTRAST) != 0;
    }

    bool PhysicalMonitor::SupportsColourTemperature::get()
    {
        return (iMonitorCapabilities & MC_CAPS_COLOR_TEMPERATURE) != 0;
    }

    bool PhysicalMonitor::SupportsDegauss::get()
    {
        return (iMonitorCapabilities & MC_CAPS_DEGAUSS) != 0;
    }

    bool PhysicalMonitor::SupportsDisplayAreaPosition::get()
    {
        return (iMonitorCapabilities & MC_CAPS_DISPLAY_AREA_POSITION) != 0;
    }

    bool PhysicalMonitor::SupportsDisplayAreaSize::get()
    {
        return (iMonitorCapabilities & MC_CAPS_DISPLAY_AREA_SIZE) != 0;
    }

    bool PhysicalMonitor::SupportsTechnologyType::get()
    {
        return (iMonitorCapabilities & MC_CAPS_MONITOR_TECHNOLOGY_TYPE) != 0;
    }

    bool PhysicalMonitor::SupportsRgbDrive::get()
    {
        return (iMonitorCapabilities & MC_CAPS_RED_GREEN_BLUE_DRIVE) != 0;
    }

    bool PhysicalMonitor::SupportsRgbGain::get()
    {
        return (iMonitorCapabilities & MC_CAPS_RED_GREEN_BLUE_GAIN) != 0;
    }

    bool PhysicalMonitor::SupportsRestoreFactoryDefaults::get()
    {
        return (iMonitorCapabilities & MC_CAPS_RESTORE_FACTORY_DEFAULTS) != 0;
    }

    bool PhysicalMonitor::SupportsRestoreFactoryColorDefaults::get()
    {
        return (iMonitorCapabilities & MC_CAPS_RESTORE_FACTORY_COLOR_DEFAULTS) != 0;
    }

    ///
    /// What this means is explaing there: https://msdn.microsoft.com/en-us/library/dd692969(v=vs.85).aspx
    /// It's of litle interrests to us. 
    bool PhysicalMonitor::RestoringFactoryDefaultsEnablesMonitorSettings::get()
    {
        return (iMonitorCapabilities & MC_RESTORE_FACTORY_DEFAULTS_ENABLES_MONITOR_SETTINGS) != 0;
    }


}

