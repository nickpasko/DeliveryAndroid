using Acr.UserDialogs;
using iPartnerApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPartnerApp.Helpers
{
    public class LoginHelper
    { 
        /// <summary>
        /// Login client on server
        /// </summary>
        /// <param name="email">Email driver</param>
        /// <param name="password">Password driver</param>
        public static async Task<bool> Login(string email, string password, bool showMessage = true)
        {
            //todo Переделать password из открытового на Hash
            UserDialogs.Instance.Loading("Logging In");
            var response = await new DataService().Login(new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("email", email),
                    new KeyValuePair<string, string>("password", password)
                });
            UserDialogs.Instance.Loading().Hide();
			if (response == null)
				return false;
            if (response.Status == 0)
            {
                var custid = response.ErrorNo;
                Driver.Current = new Driver
                {
                    ProductType = int.Parse(custid.Split(',')[4].Trim()),
                    Id = int.Parse(custid.Split(',')[0].Trim()),
                    SecretKey  = custid.Split(',')[1].Trim(),
                    Password = password,
                    Email = email,
                    VendorId = int.Parse(custid.Split(',')[2].Trim()),
                    DriverStatus = Enums.DriverStatus.Online,
                    Zone = int.Parse(custid.Split(',')[3].Trim())
                };
                return true;
            }
            /*Settings.UserName = null;
            Settings.UserPassword = null;*/
            if(showMessage)
                UserDialogs.Instance.Alert(response.Message, "Sign In Failed");
            return false;
        }

        /// <summary>
        /// Logout client on server
        /// </summary>
        public static async Task<bool> Logout(string custid)
        {
            var response = await new DataService().Logout(new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("driverid", Driver.Current.Id.ToString()),
                new KeyValuePair<string, string>("secretkey", Driver.Current.SecretKey)
            });
            Driver.Current = null;
            Settings.UserName = null;
            Settings.UserPassword = null;
            return response.Status == 0;
        }
    }
}
