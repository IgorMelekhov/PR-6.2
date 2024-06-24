using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_6
{
    internal class Facade
    {
        FireAlarm fireAlarm = new FireAlarm();
        SecurityAlarm securityAlarm = new SecurityAlarm();
        public int FireAlarm()
        {
            return fireAlarm.FireAlarmRandom();
        }
        public int SecurityAlarm()
        {
            return securityAlarm.SecurityAlarmRandom();
        }
    }
}
