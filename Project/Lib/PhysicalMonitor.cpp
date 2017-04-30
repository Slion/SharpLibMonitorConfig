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
        Construct();
    }

    bool PhysicalMonitor::Construct()
    {
        //
        iTechnologyTypeName = String::Empty;

        // Get capabilities
        DWORD monitorCapabilities = 0;
        DWORD supportedColorTemperatures = 0;
        bool online = GetMonitorCapabilities(Handle, &monitorCapabilities, &supportedColorTemperatures)==TRUE;

        iMonitorCapabilities = monitorCapabilities;
        iSupportedColorTemperatures = supportedColorTemperatures;

        return online;
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
    void PhysicalMonitor::GetTechnologyTypeName()
    {
        MC_DISPLAY_TECHNOLOGY_TYPE type;
        if (GetMonitorTechnologyType(Handle, &type))
        {
            switch (type)
            {
            case MC_SHADOW_MASK_CATHODE_RAY_TUBE:
                iTechnologyTypeName = "Shadow Mask Cathode Ray Tube";
                break;
            case MC_APERTURE_GRILL_CATHODE_RAY_TUBE:
                iTechnologyTypeName = "Aperture Grill Cathode Ray Tube";
                break;
            case MC_THIN_FILM_TRANSISTOR:
                iTechnologyTypeName = "TFT LCD";
                break;
            case MC_LIQUID_CRYSTAL_ON_SILICON:
                iTechnologyTypeName = "LCD";
                break;
            case MC_PLASMA:
                iTechnologyTypeName = "Plasma";
                break;
            case MC_ORGANIC_LIGHT_EMITTING_DIODE:
                iTechnologyTypeName = "OLED";
                break;
            case MC_ELECTROLUMINESCENT:
                iTechnologyTypeName = "Electroluminescent";
                break;
            case MC_MICROELECTROMECHANICAL:
                iTechnologyTypeName = "Microelectromechanical";
                break;
            case MC_FIELD_EMISSION_DEVICE:
                iTechnologyTypeName = "Field Emission Device";
                break;         
            }

            return;
        }

        iTechnologyTypeName = "Unknown";
    }

    ///
    String^ PhysicalMonitor::TechnologyTypeName::get()
    {
        if (String::IsNullOrEmpty(iTechnologyTypeName))
        {
            GetTechnologyTypeName();
        }

        return iTechnologyTypeName;
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

    //
    // Constrast
    //

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

    //
    // Color Temperature
    //

    ColorTemperature PhysicalMonitor::ColorTemperature::get()
    {
        SharpLib::MonitorConfig::ColorTemperature t = SharpLib::MonitorConfig::ColorTemperature::Unknown;
        MC_COLOR_TEMPERATURE temp = MC_COLOR_TEMPERATURE_UNKNOWN;
        BOOL success = GetMonitorColorTemperature(Handle, &temp);
        t = (SharpLib::MonitorConfig::ColorTemperature)temp;
        return t;
    }

    void PhysicalMonitor::ColorTemperature::set(SharpLib::MonitorConfig::ColorTemperature aColorTemperature)
    {
        MC_COLOR_TEMPERATURE temp = (MC_COLOR_TEMPERATURE)aColorTemperature;
        BOOL success = SetMonitorColorTemperature(Handle, temp);
    }
    
    
    ///
    /// 
    ///
    Setting^ PhysicalMonitor::GainRed::get()
    {
        DWORD min = 0;
        DWORD max = 0;
        DWORD current = 0;
        // Get our values
        BOOL success = GetMonitorRedGreenOrBlueGain(Handle, MC_RED_GAIN, &min, &current, &max);
        // Set our value
        iGainRed.Current = current;
        iGainRed.Min = min;
        iGainRed.Max = max;
        // Provide them
        return %iGainRed;
    }

    ///
    void PhysicalMonitor::GainRed::set(Setting^ aSetting)
    {
        BOOL success = SetMonitorRedGreenOrBlueGain(Handle, MC_RED_GAIN, aSetting->Current);
    }

    ///
    /// 
    ///
    Setting^ PhysicalMonitor::GainGreen::get()
    {
        DWORD min = 0;
        DWORD max = 0;
        DWORD current = 0;
        // Get our values
        BOOL success = GetMonitorRedGreenOrBlueGain(Handle, MC_GREEN_GAIN, &min, &current, &max);
        // Set our value
        iGainGreen.Current = current;
        iGainGreen.Min = min;
        iGainGreen.Max = max;
        // Provide them
        return %iGainGreen;
    }

    ///
    void PhysicalMonitor::GainGreen::set(Setting^ aSetting)
    {
        BOOL success = SetMonitorRedGreenOrBlueGain(Handle, MC_GREEN_GAIN, aSetting->Current);
    }

    ///
    /// 
    ///
    Setting^ PhysicalMonitor::GainBlue::get()
    {
        DWORD min = 0;
        DWORD max = 0;
        DWORD current = 0;
        // Get our values
        BOOL success = GetMonitorRedGreenOrBlueGain(Handle, MC_BLUE_GAIN, &min, &current, &max);
        // Set our value
        iGainBlue.Current = current;
        iGainBlue.Min = min;
        iGainBlue.Max = max;
        // Provide them
        return %iGainBlue;
    }

    ///
    void PhysicalMonitor::GainBlue::set(Setting^ aSetting)
    {
        BOOL success = SetMonitorRedGreenOrBlueGain(Handle, MC_BLUE_GAIN, aSetting->Current);
    }

    ///
    /// 
    ///
    Setting^ PhysicalMonitor::DriveRed::get()
    {
        DWORD min = 0;
        DWORD max = 0;
        DWORD current = 0;
        // Get our values
        BOOL success = GetMonitorRedGreenOrBlueDrive(Handle, MC_RED_DRIVE, &min, &current, &max);
        // Set our value
        iGainRed.Current = current;
        iGainRed.Min = min;
        iGainRed.Max = max;
        // Provide them
        return %iGainRed;
    }

    ///
    void PhysicalMonitor::DriveRed::set(Setting^ aSetting)
    {
        BOOL success = SetMonitorRedGreenOrBlueDrive(Handle, MC_RED_DRIVE, aSetting->Current);
    }

    ///
    /// 
    ///
    Setting^ PhysicalMonitor::DriveGreen::get()
    {
        DWORD min = 0;
        DWORD max = 0;
        DWORD current = 0;
        // Get our values
        BOOL success = GetMonitorRedGreenOrBlueDrive(Handle, MC_GREEN_DRIVE, &min, &current, &max);
        // Set our value
        iGainGreen.Current = current;
        iGainGreen.Min = min;
        iGainGreen.Max = max;
        // Provide them
        return %iGainGreen;
    }

    ///
    void PhysicalMonitor::DriveGreen::set(Setting^ aSetting)
    {
        BOOL success = SetMonitorRedGreenOrBlueDrive(Handle, MC_GREEN_DRIVE, aSetting->Current);
    }

    ///
    /// 
    ///
    Setting^ PhysicalMonitor::DriveBlue::get()
    {
        DWORD min = 0;
        DWORD max = 0;
        DWORD current = 0;
        // Get our values
        BOOL success = GetMonitorRedGreenOrBlueDrive(Handle, MC_BLUE_DRIVE, &min, &current, &max);
        // Set our value
        iGainBlue.Current = current;
        iGainBlue.Min = min;
        iGainBlue.Max = max;
        // Provide them
        return %iGainBlue;
    }

    ///
    void PhysicalMonitor::DriveBlue::set(Setting^ aSetting)
    {
        BOOL success = SetMonitorRedGreenOrBlueDrive(Handle, MC_BLUE_DRIVE, aSetting->Current);
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

    bool PhysicalMonitor::SupportsColorTemperature::get()
    {
        return (iMonitorCapabilities & MC_CAPS_COLOR_TEMPERATURE) != 0;
    }

    bool PhysicalMonitor::SupportsColorTemperature4000K::get()
    { 
        return (iSupportedColorTemperatures & MC_SUPPORTED_COLOR_TEMPERATURE_4000K) != 0;
    }

    bool PhysicalMonitor::SupportsColorTemperature5000K::get()
    {
        return (iSupportedColorTemperatures & MC_SUPPORTED_COLOR_TEMPERATURE_5000K) != 0;
    }

    bool PhysicalMonitor::SupportsColorTemperature6500K::get()
    {
        return (iSupportedColorTemperatures & MC_SUPPORTED_COLOR_TEMPERATURE_6500K) != 0;
    }

    bool PhysicalMonitor::SupportsColorTemperature7500K::get()
    {
        return (iSupportedColorTemperatures & MC_SUPPORTED_COLOR_TEMPERATURE_7500K) != 0;
    }

    bool PhysicalMonitor::SupportsColorTemperature8200K::get()
    {
        return (iSupportedColorTemperatures & MC_SUPPORTED_COLOR_TEMPERATURE_8200K) != 0;
    }

    bool PhysicalMonitor::SupportsColorTemperature9300K::get()
    {
        return (iSupportedColorTemperatures & MC_SUPPORTED_COLOR_TEMPERATURE_9300K) != 0;
    }

    bool PhysicalMonitor::SupportsColorTemperature10000K::get()
    {
        return (iSupportedColorTemperatures & MC_SUPPORTED_COLOR_TEMPERATURE_10000K) != 0;
    }

    bool PhysicalMonitor::SupportsColorTemperature11500K::get()
    {
        return (iSupportedColorTemperatures & MC_SUPPORTED_COLOR_TEMPERATURE_11500K) != 0;
    }

}

