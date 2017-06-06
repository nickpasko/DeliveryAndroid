using System;
using Xamarin.Forms;
using System.Linq;
using iPartnerApp;
using iPartnerApp.Views;

namespace iPartnerApp
{
	public class RootPage : MasterDetailPage
	{
		MenuPage menuPage;

		public RootPage ()
		{
			menuPage = new MenuPage ();

			menuPage.Menu.ItemSelected += (sender, e) => NavigateTo (e.SelectedItem as MenuItem);

			Master = menuPage;
			Detail = new NavigationPage (new MainTabPage ())
			{ BarBackgroundColor = Color.FromHex ("3898DC"), BarTextColor = Color.White };

		}

		void NavigateTo (MenuItem menu)
		{
			if (menu == null)
				return;

			Page displayPage = (Page)Activator.CreateInstance (menu.TargetType);

			Detail = new NavigationPage (displayPage);

			menuPage.Menu.SelectedItem = null;
			IsPresented = false;
		}
	}
}


