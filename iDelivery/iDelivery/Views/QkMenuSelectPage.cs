using System;

using Xamarin.Forms;

namespace iDelivery
{
	public class QkMenuSelectPage : ContentPage
	{
		int selectOption=0;

		public QkMenuSelectPage ()
		{
			this.Title = "FOOD DELIVERY";

			// Tab Menu Image and Title
			Title = "Quick Menu";
			Icon = "hometab.png";

			// ToolBar Information
			var tbiAdd = new ToolbarItem ("+", "chat.png", () => {
				Navigation.PushAsync(new ChatPage());
			}, 0, 0);
			tbiAdd.StyleId = "ToolbarAdd";
			//tbiAdd.Order = ToolbarItemOrder.Secondary;
			ToolbarItems.Add (tbiAdd);

			// Page Background image
			var backgroundImage = new Image()
			{

				Aspect = Xamarin.Forms.Aspect.AspectFill,

				Source = Device.OnPlatform(
					iOS: ImageSource.FromFile("bluebg.png"),
					Android: ImageSource.FromFile("bluebg.png"),
					WinPhone: ImageSource.FromFile("bluebg.png"))

			};

			// Page Title Image
			var toplayout = new StackLayout 
			{ 
				Padding = 0, 
				Spacing=0,
				VerticalOptions = LayoutOptions.Start,
				HorizontalOptions = LayoutOptions.Center
			};

			var backgroundImageTitle = new Image()
			{
				Aspect = Xamarin.Forms.Aspect.AspectFill,

				Source = Device.OnPlatform(
					iOS: ImageSource.FromFile("PageTitle.png"),
					Android: ImageSource.FromFile("PageTitle.png"),
					WinPhone: ImageSource.FromFile("PageTitle.png"))
			};
			toplayout.Children.Add(backgroundImageTitle);


			var layout = new StackLayout 
			{ 
				Padding = 25, 
				Spacing=15,
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center
			};


			Grid grid = new Grid
			{
				VerticalOptions = LayoutOptions.FillAndExpand,
				Padding=55,
				RowSpacing=15,
				ColumnSpacing=20,

				RowDefinitions = 
				{
					new RowDefinition { Height = new GridLength(145, GridUnitType.Absolute) },
					new RowDefinition { Height = new GridLength(145, GridUnitType.Absolute) },
					new RowDefinition { Height = new GridLength(145, GridUnitType.Absolute) },
					new RowDefinition { Height = new GridLength(90, GridUnitType.Absolute) },
				},
				ColumnDefinitions = 
				{
					new ColumnDefinition { Width = new GridLength(145, GridUnitType.Absolute) },
					new ColumnDefinition { Width = new GridLength(145, GridUnitType.Absolute) },

				}
				};

			Image iconbtn1 = new Image ();
			iconbtn1.Source=ImageSource.FromFile("Menu1.png");
			var icontap1 = new TapGestureRecognizer ();
			icontap1.Tapped += Button_Clicked1;
			iconbtn1.GestureRecognizers.Add (icontap1);
			iconbtn1.Opacity = 0.6;
			iconbtn1.FadeTo (1);
			grid.Children.Add(iconbtn1,0,0);

			Image iconbtn2 = new Image ();
			iconbtn2.Source=ImageSource.FromFile("Menu2.png");
			var icontap2 = new TapGestureRecognizer ();
			//icontap2.Tapped += Button_Clicked2;
			iconbtn2.GestureRecognizers.Add (icontap2);
			iconbtn2.Opacity = 0.6;
			iconbtn2.FadeTo (1);
			grid.Children.Add(iconbtn2,1,0);

			Image iconbtn3 = new Image ();
			iconbtn3.Source=ImageSource.FromFile("Menu3.png");
			var icontap3 = new TapGestureRecognizer ();
			//icontap3.Tapped += Button_Clicked3;
			iconbtn3.GestureRecognizers.Add (icontap3);
			iconbtn3.Opacity = 0.6;
			iconbtn3.FadeTo (1);
			grid.Children.Add(iconbtn3,0,1);

			Image iconbtn4 = new Image ();
			iconbtn4.Source=ImageSource.FromFile("Menu4.png");
			var icontap4 = new TapGestureRecognizer ();
			//icontap4.Tapped += Button_Clicked4;
			iconbtn4.GestureRecognizers.Add (icontap4);
			iconbtn4.Opacity = 0.6;
			iconbtn4.FadeTo (1);
			grid.Children.Add(iconbtn4,1,1);

			Image iconbtn5 = new Image ();
			iconbtn5.Source=ImageSource.FromFile("Menu1.png");
			var icontap5 = new TapGestureRecognizer ();
			//icontap5.Tapped += Button_Clicked5;
			iconbtn5.GestureRecognizers.Add (icontap5);
			iconbtn5.Opacity = 0.6;
			iconbtn5.FadeTo (1);

			grid.Children.Add(iconbtn5,0,2);
			Grid.SetColumnSpan(iconbtn5,2);
			//grid.ColumnSpan = 2;

			var newContent = new StackLayout
			{
				Children = { grid },
				Padding = new Thickness(0, 10, 0, 0),
				VerticalOptions = LayoutOptions.StartAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand

			};

//			var label = new Label
//			{
//				Text = "QUICK MENU DISPLAY IN GRID FROM JSON FORMAT",
//				TextColor = Color.Black,
//			};
//			layout.Children.Add(label);
//
//			Button btnSubmit  = new Button
//			{
//				HorizontalOptions = LayoutOptions.Fill,
//				FontSize=18,
//				BackgroundColor = Color.FromHex("#cd5b45"),
//				TextColor = Color.Black,
//				Text = " Image Selected "
//			};
//			layout.Children.Add(btnSubmit);
//
//			btnSubmit.Clicked +=  ButtonClickedFunc;

			ScrollView scroll1 = new ScrollView {
				Content=newContent,
				Orientation = ScrollOrientation.Vertical,
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

		private async void  ButtonClickedFunc (object sender, EventArgs e)
		{
			//DisplayAlert("Good","Thanks", "OK");
			await Navigation.PushAsync(new QuickMenuPage1());
			return;
		}

		async void Button_Clicked1(object sender, EventArgs e)
		{
			selectOption = 1;
			//await UserDialogs.Instance.AlertAsync("Selected one","Sign In Failed");
			await Navigation.PushAsync(new OrderConfimPage(selectOption));
		} //end of class


	}
}


