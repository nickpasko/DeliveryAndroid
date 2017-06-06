using iDelivery.Helpers;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace iDelivery
{
	public partial class FirstPage : ContentPage
	{
		public FirstPage ()
		{
			this.Title = "FOOD DELIVERY";

			InitializeComponent ();

			ButtonLogin.Clicked += async (sender, e) => 
			{
                await Navigation.PushAsync(new LoginPage());
            };

			ButtonSignup.Clicked += async (sender, e) => 
			{
				await Navigation.PushAsync(new SignupPage1());
			};
		}
    }
}

