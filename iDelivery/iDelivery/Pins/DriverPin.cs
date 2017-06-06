using iDelivery.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iDelivery.Pins
{
    public class DriverPin:TK.CustomMap.TKCustomMapPin
    {
        public DriverPosition DriverPosition { set; get; }
        public DriverInfo DriverInfo { set; get; }
    }
}
