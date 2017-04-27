#pragma once
#include <Windows.h>
#include <HighLevelMonitorConfigurationAPI.h>


using namespace System;

namespace SharpLib::MonitorConfig
{
    public enum class ColorTemperature
    {
        Unknown = MC_COLOR_TEMPERATURE_UNKNOWN,
        K4000 = MC_COLOR_TEMPERATURE_4000K,
        K5000 = MC_COLOR_TEMPERATURE_5000K,
        K6500 = MC_COLOR_TEMPERATURE_6500K,
        K7500 = MC_COLOR_TEMPERATURE_7500K,
        K8200 = MC_COLOR_TEMPERATURE_8200K,
        K9300 = MC_COLOR_TEMPERATURE_9300K,
        K10000 = MC_COLOR_TEMPERATURE_10000K,
        K11500 = MC_COLOR_TEMPERATURE_11500K
    };

}