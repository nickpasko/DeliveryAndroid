using System;

using Xamarin.Forms;

namespace iDelivery
{
	public class CartPage : ContentPage
	{
		public CartPage ()
		{
			this.Title = "FOOD DELIVERY";

			Content = new StackLayout { 
				Children = {
					new Label { Text = "Cart PAge ContentPage" }
				}
			};
		}
	}
}


