using iDelivery.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iDelivery.Model
{
    public class DriverPosition
    {
        public int DriverId { set; get; }
        public int ProductType { set; get;}
        public int CurrentZone { set; get; }
        public DriverStatus DriverStatus { set; get; }
        public double Latitude { set; get; }
        public double Longitude { set; get; }
    }
}
