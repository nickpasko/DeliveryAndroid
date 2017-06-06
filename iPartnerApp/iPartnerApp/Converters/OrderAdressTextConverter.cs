using iPartnerApp.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace iPartnerApp.Converters
{
    public class OrderAdressTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var order = value as OrderInfo;
            if (order == null)
                return "";
            return string.Format("#{0}-{1},{2},{3},{4}", order.UnitNo, order.FloorNo, order.BlockNo, order.StreetName, order.PostalCode);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
