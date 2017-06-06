using System;

using Xamarin.Forms;

namespace iDelivery
{
	public class OrderPage : ContentPage
	{
		public OrderPage ()
		{
			Content = new StackLayout { 
				Children = {
					new Label { Text = "Hello ContentPage" }
				}
			};
		}
	}
}


