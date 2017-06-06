using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iDelivery.Model
{
    public class Order
    {
        public int Id { set; get; }
        public double Longitude { set; get; }
        public double Latitude { set; get; }
        public DriverPosition Driver { set; get; }
    }
}
