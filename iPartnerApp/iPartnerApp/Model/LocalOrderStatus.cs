using iPartnerApp.Enums;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPartnerApp.Model
{
    public class LocalOrderStatus
    {
        [PrimaryKey]
        public int OrderId { set; get; }
        public OrderStatus Status { set; get; }
    }
}
