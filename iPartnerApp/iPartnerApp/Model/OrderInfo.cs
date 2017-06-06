using iPartnerApp.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPartnerApp.Model
{
    public class OrderInfo: INotifyPropertyChanged
    {
        public int OrderId { set; get; }
        public DateTime OrderDate { set; get; }
        public string UserName { set; get; }
        public string UserPhoto { set; get; }
        public string ProductType { set; get; }
        public string ProductName { set; get; }
        public int Qty { set; get; }
        public double Price { set; get; }
        public double ExpressPrice { set; get; }
        public string PaymentMode { set; get; }
        public string HouseType { set; get; }
        public string UnitNo { set; get; }
        public string FloorNo { set; get; }
        public string BlockNo { set; get; }
        public string StreetName { set; get; }
        public string PostalCode { set; get;}
        public string District { set; get; }
        public string AreaZone { set; get; }
        public OrderStatus OrderStatus { set; get;}

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public int AutoAccept { set; get; }

        public string OrderStatusText
        {
            get
            {
                switch (OrderStatus)
                {
                    case OrderStatus.NewOrder:
                        return "New";
                    case OrderStatus.DriverAccepted:
                        return "Accepted";
                    case OrderStatus.DeliveryStarted:
                    case OrderStatus.DeliveryInProgress:
                        return "Started";
                    case OrderStatus.CallBellCustomer:
                        return "Door Bell";
                    case OrderStatus.PaymentProcess:
                        return "Payment";
                }
                return ExpressPrice == 2 ? "URGENT" : string.Empty;
            }
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            var type = GetType();
            if (obj == null || type != obj.GetType())
            {
                return false;
            }
            var cmpObj = (OrderInfo)obj;
            return OrderId == cmpObj.OrderId
                && OrderDate == cmpObj.OrderDate 
                && ProductType == cmpObj.ProductType 
                && ProductName == cmpObj.ProductName
                && Qty == cmpObj.Qty
                && Price == cmpObj.Price
                && ExpressPrice == cmpObj.ExpressPrice
                && PaymentMode == cmpObj.PaymentMode
                && HouseType == cmpObj.HouseType
                && UnitNo == cmpObj.UnitNo
                && FloorNo == cmpObj.FloorNo
                && BlockNo == cmpObj.BlockNo
                && StreetName == cmpObj.StreetName
                && PostalCode == cmpObj.PostalCode
                && District == cmpObj.District
                && AreaZone == cmpObj.AreaZone
                && OrderStatus == cmpObj.OrderStatus;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
