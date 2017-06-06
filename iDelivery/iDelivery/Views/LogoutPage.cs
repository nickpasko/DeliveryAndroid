using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using iDelivery;
using Xamarin.Forms;
using Newtonsoft.Json.Linq;
using Acr.UserDialogs;

namespace iDelivery
{
	public class LogoutPage : ContentPage
	{
		public LogoutPage ()
		{

            LogOut();
        }

        private async void LogOut()
        {
            await Helpers.LoginHelper.Logout();
            Application.Current.MainPage = new NavigationPage(new FirstPage());
        }
    }
}


