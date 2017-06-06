using System;

using Xamarin.Forms;

namespace iDelivery
{
	public class MainTabPage : TabbedPage
	{
		public MainTabPage ()
		{
			this.Title = "FOOD DELIVERY";

			this.Children.Add (new QkMenuSelectPage());
			this.Children.Add (new CatMenuSelectPage ());
			this.Children.Add (new DriversAvailablePage ());
			this.Children.Add (new TrackDriverPage ());
		}
	}
}


