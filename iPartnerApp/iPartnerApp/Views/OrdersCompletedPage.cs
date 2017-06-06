using System;

using iPartnerApp;
using Xamarin.Forms;
using Newtonsoft.Json.Linq;
using Acr.UserDialogs;

namespace iPartnerApp.Views
{
	public class OrdersCompletedPage : BasePage
	{
		public OrdersCompletedPage ()
		{

			this.Title = "FOOD DELIVERY";

			// Tab Menu Image and Title
			Title = "Completed Orders";
			Icon = "hometab.png";



			Content = new StackLayout { 
				Children = {
					new Label { Text = "Orders Completed ContentPage" }
				}
			};
		}
	}
}


