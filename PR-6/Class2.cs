using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_6
{
    internal class SecurityAlarm
    {
        public int SecurityAlarmRandom()
        {
            return Form1.random.Next(2);
        }
    }
}
