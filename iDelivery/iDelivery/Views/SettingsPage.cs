using System;

using Xamarin.Forms;

namespace iDelivery
{
	public class SettingsPage : ContentPage
	{
		public SettingsPage ()
		{
			Content = new StackLayout { 
				Children = {
					new Label { Text = "Settings ContentPage" }
				}
			};
		}
	}
}


