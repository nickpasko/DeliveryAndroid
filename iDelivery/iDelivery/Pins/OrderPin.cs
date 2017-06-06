using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iDelivery.Pins
{
    public class OrderPin: TK.CustomMap.TKCustomMapPin
    {
        public Model.Order OrderInfo { set; get; }
    }
}
