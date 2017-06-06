using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms.Maps;
using iDelivery.Model;
using System.Linq;
using iDelivery.Services;

namespace iDelivery
{
    public class DataService : ServiceBase
    {
        public async void AppQuit()
        {
            var url = BaseUrl + "mobile/custappquit.php";
            List<KeyValuePair<string, string>> data = new List<KeyValuePair<string, string>>();
            data.Add(new KeyValuePair<string, string>("custid", Client.Current.Id.ToString()));
            data.Add(new KeyValuePair<string, string>("secretkey", Client.Current.SecretKey));
            await MakePostRequestUrlEncoded<Response>(url, data);
        }

        public async Task<Response> Login(List<KeyValuePair<string, string>> keyValues)
        {
            var url = BaseUrl + "mobile/custlogin.php";

            var data = await MakePostRequestUrlEncoded<Response>(url, keyValues);
            return data;
        }

        public async Task<Response> Logout(List<KeyValuePair<string, string>> keyValues)
        {
            var url = BaseUrl + "mobile/custlogout.php";

            var data = await MakePostRequestUrlEncoded<Response>(url, keyValues);
            return data;
        }


        public async Task<Response> SignUp(List<KeyValuePair<string, string>> keyValues)
        {
            var url = BaseUrl + "mobile/msignup.php";

            var data = await MakePostRequestUrlEncoded<Response>(url, keyValues);
            return data;
        }

        public async Task<DriverListResponse> GetDriversAvailablePostion()
        {
            var url = BaseUrl + "mobile/displayalldrivers.php";
            var keys = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("custid", Client.Current != null? Client.Current.Id.ToString():string.Empty),
                new KeyValuePair<string, string>("secretkey", Client.Current != null? Client.Current.SecretKey:string.Empty),
            };
            var result = await MakePostRequestUrlEncodedWithCostyl<DriverListResponse>(url, keys);
            return result;
        }

        //temp return result route
        public Order GetDriverRoute()
        {
            var order = new Order
            {
                Id = 101,
                Latitude = 1.35,
                Longitude = 103.8,
                /*Driver = new DriverPostion {
                    DriverName  = "John",
                    VehicleN = "a456bp",
                    DriverPhoto = "http://img3.wikia.nocookie.net/__cb20160202013502/disney/images/thumb/f/fb/Zootopia_Clawhouser_pose.png/130px-0,248,5,224-Zootopia_Clawhouser_pose.png"
                }*/
            };
            return order;
        }

        public async Task<DriverInfo> GetDriverInfo(int driverId)
        {
            var url = BaseUrl + "mobile/displayalldrivers.php";
            var keys = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("custid", Client.Current != null? Client.Current.Id.ToString():string.Empty),
                new KeyValuePair<string, string>("secretkey", Client.Current != null? Client.Current.SecretKey:string.Empty),
            };
            var result = await MakePostRequestUrlEncoded<DriverInfo>(url, keys);
            return result;
        }

        public async Task<Position> GetDriverPosition(int driverId)
        {
            var url = BaseUrl + "mobile/drivercurrentlocation.php";
            var keys = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("driverid", driverId.ToString()),
                new KeyValuePair<string, string>("secretkey", "c0d29696fc1eea771df60ff95a4772ff41992940")//Client.Current != null? Client.Current.SecretKey:string.Empty),
            };
            var result = await MakePostRequestUrlEncoded<List<DriverPosition>>(url, keys);
            if (result == null || result.Count == 0)
                return new Position(1.35, 103.85);
            return new Position(result.FirstOrDefault().Latitude, result.FirstOrDefault().Longitude);
        }

        public async Task<List<DriverInfo>> GetDriverDeliveryPosition()
        {
            var url = BaseUrl + "mobile/getdriverdetails.php";
            var keys = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("custid", Client.Current != null? Client.Current.Id.ToString():string.Empty),
                new KeyValuePair<string, string>("secretkey", Client.Current != null? Client.Current.SecretKey:string.Empty),
            };
            var result = await MakePostRequestUrlEncoded<List<DriverInfo>>(url, keys);
            return result;
        }
    }
   
    public class LoginRequest
    {
        public String Email { get; set; }

        public string Password { get; set; }
    }

	public class LogoutRequest
	{
		public String Custid { get; set; }
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

