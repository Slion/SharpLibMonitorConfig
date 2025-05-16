#include "setting.h"


namespace SharpLib::MonitorConfig
{

        Setting::Setting()
        {
            Max = 0;
            Min = 0;
            Current = 0;
        }

        Setting::Setting(DWORD aMin, DWORD aCurrent, DWORD aMax)
        {
            Max = aMin;
            Current = aCurrent;
            Max = aMax;
        }

}