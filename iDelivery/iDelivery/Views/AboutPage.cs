using System;

using Xamarin.Forms;

namespace iDelivery
{
	public class AboutPage : ContentPage
	{
		public AboutPage ()
		{
			Content = new StackLayout { 
				Children = {
					new Label { Text = "About ContentPage" }
				}
			};
		}
	}
}


