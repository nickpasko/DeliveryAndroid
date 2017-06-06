using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPartnerApp.WebServices.Responses
{
    public class Response
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public string ErrorNo { get; set; }
        public override string ToString()
        {
            return string.Format("Status:{0}, Message:{1}, ErrorNo:{2}", Status, Message, ErrorNo);
        }
    }
}
