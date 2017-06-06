using iPartnerApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPartnerApp.WebServices.Responses
{
    public class DriverResponse: Response
    {
        public IList<DriverOrder> Data { set; get; }
    }
}
