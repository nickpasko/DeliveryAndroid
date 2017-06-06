using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPartnerApp
{
    public interface ITimer
    {
        int Interval { set; }
        event EventHandler Tick;
        void StopTimer();
    }
}
