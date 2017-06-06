using iDelivery.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TK.CustomMap.Overlays;

namespace iDelivery
{
    public class DriverRoute:TKRoute
    {
        public DriverInfo DriverInfo { set; get; }
    }
}
