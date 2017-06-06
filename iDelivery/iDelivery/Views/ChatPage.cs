using System;

using Xamarin.Forms;

namespace iDelivery
{
	public class ChatPage : ContentPage
	{
		public ChatPage ()
		{
			Content = new StackLayout { 
				Children = {
					new Label { Text = "Chat Page ContentPage" }
				}
			};
		}
	}
}


