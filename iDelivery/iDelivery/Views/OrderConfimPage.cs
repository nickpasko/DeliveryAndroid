using System;

using Xamarin.Forms;
using Acr.UserDialogs;

namespace iDelivery
{
	public class OrderConfimPage : ContentPage
	{
		Image iconbtn1 = new Image ();
		Image iconbtn2 = new Image ();
		Image iconbtn3 = new Image ();
		Image iconbtn4 = new Image ();
		Image iconbtn7 = new Image ();
		Image iconbtn8 = new Image ();

		private Label pricelbl;



		public OrderConfimPage (int options)
		{
			this.Title = "FOOD DELIVERY";

			var toplayout = new StackLayout 
			{ 
				Padding = 0, 
				Spacing=0,
				VerticalOptions = LayoutOptions.Start,
				HorizontalOptions = LayoutOptions.Center
			};

			if (options == 1) 
			{
				var backgroundImageTitle = new Image () {
					Aspect = Xamarin.Forms.Aspect.AspectFill,

					Source = Device.OnPlatform (
						iOS: ImageSource.FromFile ("PageTitle.png"),
						Android: ImageSource.FromFile ("PageTitle.png"),
						WinPhone: ImageSource.FromFile ("PageTitle.png"))
				};
				toplayout.Children.Add (backgroundImageTitle);
			}


			var backgroundImage = new Image()
			{
				Aspect = Xamarin.Forms.Aspect.AspectFill,
				Source = Device.OnPlatform(
					iOS: ImageSource.FromFile("bluebg.png"),
					Android: ImageSource.FromFile("bluebg.png"),
					WinPhone: ImageSource.FromFile("bluebg.png"))

			};

			Grid grid = new Grid
			{
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.Center,
				Padding = new Thickness (0, 20, 0, 0),
				RowSpacing=0,
				ColumnSpacing=20,

				RowDefinitions = 
				{
					new RowDefinition { Height = new GridLength(100, GridUnitType.Absolute) },
					new RowDefinition { Height = new GridLength(100, GridUnitType.Absolute) },
					new RowDefinition { Height = new GridLength(100, GridUnitType.Absolute) },
				},
				ColumnDefinitions = 
				{
					new ColumnDefinition { Width = new GridLength(125, GridUnitType.Absolute) },
					new ColumnDefinition { Width = new GridLength(125, GridUnitType.Absolute) },

				}
				};


			//Image iconbtn1 = new Image ();
			iconbtn1.Source=ImageSource.FromFile("office0.png");
			iconbtn1.HeightRequest = 100;
			iconbtn1.WidthRequest = 100;
			var icontap1 = new TapGestureRecognizer ();
			icontap1.Tapped += Button_Clicked1;
			iconbtn1.GestureRecognizers.Add (icontap1);
			iconbtn1.Opacity = 0.6;
			iconbtn1.FadeTo (1);
			grid.Children.Add(iconbtn1,0,0);

			//Image iconbtn2 = new Image ();
			iconbtn2.Source=ImageSource.FromFile("home0.png");
			iconbtn2.HeightRequest = 100;
			iconbtn2.WidthRequest = 100;
			var icontap2 = new TapGestureRecognizer ();
			icontap2.Tapped += Button_Clicked2;
			iconbtn2.GestureRecognizers.Add (icontap2);
			iconbtn2.Opacity = 0.6;
			iconbtn2.FadeTo (1);
			grid.Children.Add(iconbtn2,1,0);

			//Image iconbtn3 = new Image ();
			iconbtn3.Source=ImageSource.FromFile("express0.png");
			iconbtn3.HeightRequest = 100;
			iconbtn3.WidthRequest = 100;
			var icontap3 = new TapGestureRecognizer ();
			icontap3.Tapped += Button_Clicked3;
			iconbtn3.GestureRecognizers.Add (icontap3);
			iconbtn3.Opacity = 0.6;
			iconbtn3.FadeTo (1);
			grid.Children.Add(iconbtn3,0,1);

			//Image iconbtn4 = new Image ();
			iconbtn4.Source=ImageSource.FromFile("normal0.png");
			iconbtn4.HeightRequest = 100;
			iconbtn4.WidthRequest = 100;
			var icontap4 = new TapGestureRecognizer ();
			icontap4.Tapped += Button_Clicked4;
			iconbtn4.GestureRecognizers.Add (icontap4);
			iconbtn4.Opacity = 0.6;
			iconbtn4.FadeTo (1);
			grid.Children.Add(iconbtn4,1,1);

			//Image iconbtn3 = new Image ();
			iconbtn7.Source=ImageSource.FromFile("card0.png");
			iconbtn7.HeightRequest = 100;
			iconbtn7.WidthRequest = 100;
			var icontap7 = new TapGestureRecognizer ();
			icontap7.Tapped += Button_Clicked7;
			iconbtn7.GestureRecognizers.Add (icontap7);
			iconbtn7.Opacity = 0.6;
			iconbtn7.FadeTo (1);
			grid.Children.Add(iconbtn7,0,2);

			//Image iconbtn4 = new Image ();
			iconbtn8.Source=ImageSource.FromFile("cash0.png");
			iconbtn8.HeightRequest = 100;
			iconbtn8.WidthRequest = 100;
			var icontap8 = new TapGestureRecognizer ();
			icontap8.Tapped += Button_Clicked8;
			iconbtn8.GestureRecognizers.Add (icontap8);
			iconbtn8.Opacity = 0.6;
			iconbtn8.FadeTo (1);
			grid.Children.Add(iconbtn8,1,2);



			var layout = new StackLayout 
			{ 
				Padding = new Thickness (0, 50, 0, 0), 
				Spacing=0,
				VerticalOptions = LayoutOptions.Start,
				HorizontalOptions = LayoutOptions.Center
			};

			layout.Children.Add(grid);

			pricelbl = new Label {

				Text = "Price : $30.00\n",
				TextColor = Color.Black, 
				FontSize = 23,

				XAlign = TextAlignment.Center,
				YAlign = TextAlignment.Center

			};
			layout.Children.Add(pricelbl);

			var deliverytext = new Label
			{
				Text = "Delivery Address\n ",
				FontSize = 16,
				TextColor = Color.Black, 
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand
			};
			layout.Children.Add(deliverytext);

			var addresslbl = new Label
			{
				Text = "#02-123, Block 120, CCK Central 4,\n Singapore 669495\n",
				FontSize = 16,
				TextColor = Color.Black, 
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand
			};
			layout.Children.Add(addresslbl);


			Button btnSubmit  = new Button
			{
				HorizontalOptions = LayoutOptions.Fill,
				BackgroundColor = Color.FromHex("#3498DB"),
				TextColor = Color.Black,
				Text = "Confirm Order"
			};
			layout.Children.Add(btnSubmit);


			ScrollView scroll1 = new ScrollView {
				Content=layout
			};

			var relativeLayout = new RelativeLayout();

			relativeLayout.Children.Add(backgroundImage,
				Constraint.Constant(0),
				Constraint.Constant(0),
				Constraint.RelativeToParent((parent) => { return parent.Width; }),
				Constraint.RelativeToParent((parent) => { return parent.Height; }));

			relativeLayout.Children.Add(toplayout,
				Constraint.Constant(0),
				Constraint.Constant(0),
				Constraint.RelativeToParent((parent) => { return parent.Width; }),
				Constraint.RelativeToParent((parent) => { return parent.Height; }));

			relativeLayout.Children.Add(scroll1,
				Constraint.Constant(0),
				Constraint.Constant(0),
				Constraint.RelativeToParent((parent) => { return parent.Width; }),
				Constraint.RelativeToParent((parent) => { return parent.Height; }));

			Content = relativeLayout;



		}

		async void Button_Clicked1(object sender, EventArgs e)
		{
			iconbtn1.Source=ImageSource.FromFile("office1.png");
			iconbtn2.Source=ImageSource.FromFile("home0.png");
		} //end of class

		async void Button_Clicked2(object sender, EventArgs e)
		{
			iconbtn1.Source=ImageSource.FromFile("office0.png");
			iconbtn2.Source=ImageSource.FromFile("home1.png");
		} //end of class

		async void Button_Clicked3(object sender, EventArgs e)
		{
			iconbtn3.Source=ImageSource.FromFile("express1.png");
			iconbtn4.Source=ImageSource.FromFile("normal0.png");
			pricelbl.Text = "Price : $34.00";

		} //end of class

		async void Button_Clicked4(object sender, EventArgs e)
		{
			iconbtn3.Source=ImageSource.FromFile("express0.png");
			iconbtn4.Source=ImageSource.FromFile("normal1.png");
			pricelbl.Text = "Price : $32.00";

		} //end of class


		async void Button_Clicked7(object sender, EventArgs e)
		{
			iconbtn7.Source=ImageSource.FromFile("card1.png");
			iconbtn8.Source=ImageSource.FromFile("cash0.png");
		} //end of class

		async void Button_Clicked8(object sender, EventArgs e)
		{
			iconbtn7.Source=ImageSource.FromFile("card0.png");
			iconbtn8.Source=ImageSource.FromFile("cash1.png");
		} //end of class

	}
}


