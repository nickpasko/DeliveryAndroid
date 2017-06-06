using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPartnerApp.Enums
{
    public enum OrderStatus
    {
        NewOrder,
        DriverAccepted,
        DeliveryStarted,
        DeliveryInProgress,
        CallBellCustomer,
        PaymentProcess = 6,
        DeliveryComplete = 7,
        OrderCancelledCustomer = 10,
        OrderCancelledDriver = 11,
        NoShowCustomerNotInHouse = 12,
        RescheduleDelivery =15,
    }
}
