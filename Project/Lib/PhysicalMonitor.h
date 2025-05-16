#pragma once
#include <Windows.h>
#include <PhysicalMonitorEnumerationAPI.h>
#include <HighLevelMonitorConfigurationAPI.h>
#include "Setting.h"
#include "ColorTemperature.h"

using namespace System;



namespace SharpLib::MonitorConfig
{

    /// <summary>
    /// 
    /// </summary>
    public ref class PhysicalMonitor
    {
    public:
        PhysicalMonitor(PHYSICAL_MONITOR* aData);
        ~PhysicalMonitor();
        !PhysicalMonitor();

        bool Construct();

        // Actions
        void RestoreFactoryDefaults();
        void RestoreFactoryColorDefault();

        // Type
        property String^ TechnologyTypeName
        { 
            String^ get();
        }

        // Capability checks
        property bool SupportsBrightness { bool get(); }
        property bool SupportsContrast { bool get(); }        
        property bool SupportsDegauss { bool get(); }
        property bool SupportsDisplayAreaPosition { bool get(); }
        property bool SupportsDisplayAreaSize { bool get(); }
        property bool SupportsTechnologyType { bool get(); }
        property bool SupportsRgbDrive { bool get(); }
        property bool SupportsRgbGain { bool get(); }
        property bool SupportsRestoreFactoryDefaults { bool get(); }
        property bool SupportsRestoreFactoryColorDefaults { bool get(); }
        property bool RestoringFactoryDefaultsEnablesMonitorSettings { bool get(); }
        // Color temperatures
        property bool SupportsColorTemperature { bool get(); }
        property bool SupportsColorTemperature4000K { bool get(); }
        property bool SupportsColorTemperature5000K { bool get(); }
        property bool SupportsColorTemperature6500K { bool get(); }
        property bool SupportsColorTemperature7500K { bool get(); }
        property bool SupportsColorTemperature8200K { bool get(); }
        property bool SupportsColorTemperature9300K { bool get(); }
        property bool SupportsColorTemperature10000K { bool get(); }
        property bool SupportsColorTemperature11500K { bool get(); }

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

        // Color temperature
        property SharpLib::MonitorConfig::ColorTemperature ColorTemperature
        {
            SharpLib::MonitorConfig::ColorTemperature get();
            void set(SharpLib::MonitorConfig::ColorTemperature aColorTemperature);
        }

        // Gain Red
        property Setting^ GainRed
        {
            Setting^ get();
            void set(Setting^ aSetting);
        }

        // Gain Green
        property Setting^ GainGreen
        {
            Setting^ get();
            void set(Setting^ aSetting);
        }

        // Gain Blue
        property Setting^ GainBlue
        {
            Setting^ get();
            void set(Setting^ aSetting);
        }

        // Drive Red
        property Setting^ DriveRed
        {
            Setting^ get();
            void set(Setting^ aSetting);
        }

        // Drive Green
        property Setting^ DriveGreen
        {
            Setting^ get();
            void set(Setting^ aSetting);
        }

        // Drive Blue
        property Setting^ DriveBlue
        {
            Setting^ get();
            void set(Setting^ aSetting);
        }


        property String^ Description;

    private:
        property HANDLE Handle { HANDLE get() { return iData->hPhysicalMonitor; } }

        void GetTechnologyTypeName();

    private:
        PHYSICAL_MONITOR* iData; // Used
        DWORD iMonitorCapabilities;
        DWORD iSupportedColorTemperatures;
        //
        Setting iBrightness;
        Setting iContrast;
        //
        Setting iGainRed;
        Setting iGainGreen;
        Setting iGainBlue;
        //
        Setting iDriveRed;
        Setting iDriveGreen;
        Setting iDriveBlue;
        //
        String^ iTechnologyTypeName;
    };
}
