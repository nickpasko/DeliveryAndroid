
using System;

using Xamarin.Forms;
using System.Collections.Generic;
using ImageCircle.Forms.Plugin.Abstractions;

namespace iPartnerApp
{
	public class MenuPage : ContentPage
	{
		public ListView Menu { get; set; }

		public MenuPage ()
		{
			Icon = "menuthreeline.png";
			Title = "menu"; // The Title property must be set.
			BackgroundColor = Color.FromHex ("333333");

			Menu = new MenuListView ();

			var profileName = new ContentView {
				Padding = new Thickness (5, 5, 0, 5),
				Content = new Label {
					TextColor = Color.FromHex ("AAAAAA"),
					Text = "Profile - Name", 
				}
			};

			var profilePhoto = new ContentView {
				Padding = new Thickness (10, 36, 0, 5),
				Content  = new CircleImage {
					BorderColor = Color.FromHex ("#FAA128"),
					BorderThickness = 2,
					HeightRequest = 50,
					WidthRequest = 50,
					Aspect = Aspect.AspectFill,
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.Start,
					Source = new UriImageSource { Uri = new Uri ("http://i.imgur.com/Jl8Tmyw.png") },
				}};


			var menuLabel = new ContentView {
				Padding = new Thickness (10, 36, 0, 5),
				Content = new Label {
					TextColor = Color.FromHex ("AAAAAA"),
					Text = "MENU", 
				}
			};

			var layout = new StackLayout { 
				Spacing = 0, 
				VerticalOptions = LayoutOptions.FillAndExpand
			};

			layout.Children.Add (profilePhoto);
			layout.Children.Add (profileName);
			//layout.Children.Add (menuLabel);
			layout.Children.Add (Menu);

			Content = layout;
		}
	}
}


