using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iDelivery.Model
{
    public class DriverInfo
    {
        public int OrderId { set; get; }
        public int DriverId { set; get; }
        public string DriverSecretKey { set; get; }
        public string DriverName { set; get; }
        public string DriverPhoto { set; get; }
        public string VehicleNo { set; get; }
        public string PostalCode { set; get; }
        public double Latitude { set; get; }
        public double Longitude { set; get; }
    }
}
