using Acr.UserDialogs;
using iDelivery.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iDelivery.Helpers
{
    public class LoginHelper
    {
        /// <summary>
        /// Login client on server
        /// </summary>
        /// <param name="email">Email driver</param>
        /// <param name="password">Password driver</param>
        public static async Task<bool> Login(string email, string password)
        {
            //todo Переделать password из открытового на Hash
            UserDialogs.Instance.Loading("Logging In");
            var response = await new DataService().Login(new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("email", email),
                    new KeyValuePair<string, string>("password", password)
                });
            UserDialogs.Instance.Loading().Hide();
            if (response.Status == 0)
            {
                var custid = response.ErrorNo;
                Client.Current = new Client
                {
                    Id = int.Parse(custid.Split(',')[0]),
                    SecretKey = custid.Split(',')[1],
                    Password = password,
                    Email = email
                };
                return true;
            }
            UserDialogs.Instance.Alert(response.Message, "Sign In Failed");
            return false;
        }

        /// <summary>
        /// Logout client on server
        /// </summary>
        public static async Task<bool> Logout()
        {
            var response = await new DataService().Logout(new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("custid", Client.Current!=null?Client.Current.Id.ToString():string.Empty),
                new KeyValuePair<string, string>("secretkey", Client.Current!=null?Client.Current.SecretKey:string.Empty),
            });
            Client.Current = null;
            Settings.UserName = null;
            Settings.UserPassword = null;
            return response.Status == 0;
        }
    }
}
