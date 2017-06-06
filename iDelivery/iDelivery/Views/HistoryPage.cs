using System;

using Xamarin.Forms;

namespace iDelivery
{
	public class HistoryPage : ContentPage
	{
		public HistoryPage ()
		{
			Content = new StackLayout { 
				Children = {
					new Label { Text = "History ContentPage" }
				}
			};
		}
	}
}


