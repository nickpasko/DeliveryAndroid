using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using iPartnerApp;
using Xamarin.Forms;
using Newtonsoft.Json.Linq;
using Acr.UserDialogs;
namespace iPartnerApp.Views
{
    public class LogoutPage : ContentPage
    {
        public LogoutPage()
        {
            LogOut();
        }

        private async void LogOut()
        {
            string customerid = "";
            await Helpers.LoginHelper.Logout(customerid);
            Application.Current.MainPage = new NavigationPage(new FirstPage());
        }
    }
}


