using System;

using iPartnerApp;
using Xamarin.Forms;
using Newtonsoft.Json.Linq;

namespace iPartnerApp.Views
{
	public class ChatPage : BasePage
	{
		public ChatPage ()
		{
			this.Title = "FOOD DELIVERY";
			Title = "Chat & Support";
			Icon = "hometab.png";
			Content = new StackLayout { 
				Children = {
					new Label { Text = "Chat ContentPage" }
				}
			};
		}
	}
}


