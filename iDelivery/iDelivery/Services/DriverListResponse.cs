using iDelivery.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iDelivery.Services
{
    public class DriverListResponse:Response
    {
        public List<DriverPosition> Data { set; get; }
    }
}
