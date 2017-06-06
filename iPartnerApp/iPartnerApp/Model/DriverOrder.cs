using iPartnerApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPartnerApp.Model
{
    public class DriverOrder
    {
        public int OrderId { set; get; }
        public double Latitude { set; get; }
        public double Longitude { set; get; }
        public OrderStatus OrderStatus { set; get; }
    }
}
