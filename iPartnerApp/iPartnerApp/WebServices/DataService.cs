using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using iPartnerApp.Model;
using iPartnerApp.Enums;
using System.Linq;
using iPartnerApp.WebServices.Responses;

namespace iPartnerApp
{
    public class DataService : ServiceBase
    {
        public async Task<Response> Login(List<KeyValuePair<string, string>> keyValues)
        {
            var url = BaseUrl + "mobile/driverlogin.php";

            var data = await MakePostRequestUrlEncodedAsync<Response>(url, keyValues);
            return data;
        }

        public async Task<Response> Logout(List<KeyValuePair<string, string>> keyValues)
        {
            var url = BaseUrl + "mobile/driverlogout.php";
            var data = await MakePostRequestUrlEncodedAsync<Response>(url, keyValues);
            return data;
        }


        public async Task<Response> SignUp(List<KeyValuePair<string, string>> keyValues)
        {
            var url = BaseUrl + "mobile/msignup.php";

            var data = await MakePostRequestUrlEncodedAsync<Response>(url, keyValues);
            return data;
        }

        public async Task<Response> UpdateOnlineOfflineStatus()
        {
            var url = BaseUrl + "mobile/driveronlineoffline.php";
            if (Driver.Current == null)
                return null;
            List<KeyValuePair<string, string>> data = new List<KeyValuePair<string, string>>();
            data.Add(new KeyValuePair<string, string>("driverid", Driver.Current.Id.ToString()));
            data.Add(new KeyValuePair<string, string>("svendorid", Driver.Current.VendorId.ToString()));
            data.Add(new KeyValuePair<string, string>("longitude", Driver.Current.Position.Longitude.ToString()));
            data.Add(new KeyValuePair<string, string>("latitude", Driver.Current.Position.Latitude.ToString()));
            data.Add(new KeyValuePair<string, string>("status", ((int)Driver.Current.DriverStatus).ToString()));
            data.Add(new KeyValuePair<string, string>("zone", Driver.Current.Zone.ToString()));
            data.Add(new KeyValuePair<string, string>("errorstatus", ((int)Driver.Current.GpsStatus).ToString()));
            data.Add(new KeyValuePair<string, string>("secretkey", Driver.Current.SecretKey));
            return await MakePostRequestUrlEncodedAsync<Response>(url, data);
        }

        public async Task<Response> UpdatePositionDriver(Plugin.Geolocator.Abstractions.Position position, GpsStatus gpsStatus)
        {
            if (position == null || Driver.Current == null)
                return null;
            var url = BaseUrl + "mobile/driverinfoupdate.php";
            List<KeyValuePair<string, string>> data = new List<KeyValuePair<string, string>>();
            data.Add(new KeyValuePair<string, string>("driverid", Driver.Current.Id.ToString()));
            data.Add(new KeyValuePair<string, string>("svendorid", Driver.Current.VendorId.ToString()));
            data.Add(new KeyValuePair<string, string>("longitude", position.Longitude.ToString()));
            data.Add(new KeyValuePair<string, string>("latitude", position.Latitude.ToString()));
            data.Add(new KeyValuePair<string, string>("status", ((int)Driver.Current.DriverStatus).ToString()));
            data.Add(new KeyValuePair<string, string>("zone", Driver.Current.Zone.ToString()));
            data.Add(new KeyValuePair<string, string>("errorstatus", ((int)gpsStatus).ToString()));
            data.Add(new KeyValuePair<string, string>("secretkey", Driver.Current.SecretKey));
            return await MakePostRequestUrlEncodedAsync<Response>(url, data); ;
        }

        public async Task<Response> AppQuit()
        {
            var url = BaseUrl + "mobile/driverappquit.php";
            List<KeyValuePair<string, string>> data = new List<KeyValuePair<string, string>>();
            data.Add(new KeyValuePair<string, string>("driverid", Driver.Current.Id.ToString()));
            data.Add(new KeyValuePair<string, string>("secretkey", Driver.Current.SecretKey));
            return await MakePostRequestUrlEncodedAsync<Response>(url, data);
        }

        public async Task<DriverOrder> GetDriverOrder(int orderId)
        {
            var url = BaseUrl + "mobile/displayordersonmap.php";
            var result = await GetDriverOrdersOnMap();
            if (result != null && result.Status == 0)
                return result.Data.FirstOrDefault(x => x.OrderId == orderId);
            return null;
        }

        public async Task<DriverResponse> GetDriverOrdersOnMap()
        {
            var url = BaseUrl + "mobile/displayordersonmap.php";
            List<KeyValuePair<string, string>> data = new List<KeyValuePair<string, string>>();
            data.Add(new KeyValuePair<string, string>("driverid", Driver.Current != null ? Driver.Current.Id.ToString() : string.Empty));
            data.Add(new KeyValuePair<string, string>("secretkey", Driver.Current != null ? Driver.Current.SecretKey : string.Empty));
            return await MakePostRequestUrlEncodedAsync<DriverResponse>(url, data);
        }

        public async Task<List<OrderInfo>> GetOrdersForDriver()
        {
            var url = BaseUrl + "mobile/orderfordriver.php";
            List<KeyValuePair<string, string>> data = new List<KeyValuePair<string, string>>();
            data.Add(new KeyValuePair<string, string>("driverid", Driver.Current != null ? Driver.Current.Id.ToString() : string.Empty));
            data.Add(new KeyValuePair<string, string>("secretkey", Driver.Current != null ? Driver.Current.SecretKey : string.Empty));
            return await MakePostRequestUrlEncodedAsync<List<OrderInfo>>(url, data);
        }

        public async Task<object> SetOrderStatus(int orderId, OrderStatus orderStatus)
        {
            var url = BaseUrl + "mobile/driveraction.php";
            List<KeyValuePair<string, string>> data = new List<KeyValuePair<string, string>>();
            data.Add(new KeyValuePair<string, string>("driverid", Driver.Current != null ? Driver.Current.Id.ToString() : string.Empty));
            data.Add(new KeyValuePair<string, string>("secretkey", Driver.Current != null ? Driver.Current.SecretKey : string.Empty));
            data.Add(new KeyValuePair<string, string>("orderid", orderId.ToString()));
            data.Add(new KeyValuePair<string, string>("orderstatus", ((int)orderStatus).ToString()));
            return await MakePostRequestUrlEncodedAsync<object>(url, data);
        }
    }

    

    public class LoginRequest
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }

	public class LogoutRequest
	{
		public string Custid { get; set; }
	}

    public class RegisterRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public CcCard CreditCardInfo { get; set; }

    }

    public class CcCard
    {
        public string Number { get; set; }
        public string NameOnCard { get; set; }
        public string MM { get; set; }
        public string YY { get; set; }
        public string cc2 { get; set; }
    }


}

