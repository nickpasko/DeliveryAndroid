using System;

using Xamarin.Forms;

namespace iDelivery
{
	public class CatMenuSelectPage : ContentPage
	{
		public CatMenuSelectPage ()
		{
			this.Title = "FOOD DELIVERY";

			Title = "Category Menu";
			Icon = "hometab.png";

			var tbiAdd = new ToolbarItem ("+", "cart.png", () => {
				Navigation.PushAsync(new CartPage());
			}, 0, 0);
			tbiAdd.StyleId = "ToolbarAdd";
			//tbiAdd.Order = ToolbarItemOrder.Secondary;
			ToolbarItems.Add (tbiAdd);


			Content = new StackLayout { 
				Children = {
					new Label { Text = "Category ContentPage" }
				}
			};



		}
	}
}


