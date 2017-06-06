
using System;
using System.Collections.Generic;
using iDelivery;
using Xamarin.Forms;

using Acr.UserDialogs;
using Newtonsoft.Json.Linq;

namespace iDelivery
{
	public class ProfilePage : ContentPage
	{

		private Label blkColCheck;
		private Label floorColCheck;
		private Label streetColCheck;
		private Label unitColCheck;
		private Label postalColCheck;

		private Entry hsetypeInput;
		private Entry blkInput;
		private Entry streetInput;
		private Entry floorInput;
		private Entry unitInput;
		private Entry postalInput;

		private string houseTypename;


		Dictionary<string, Color> houseType = new Dictionary<string, Color>
		{
			{ "HDB/HUDC", Color.Aqua }, 
			{ "Condominium", Color.Black },
			{ "Landed Property", Color.Blue }, 
			{ "Private HighRise", Color.Green },
			{ "Quarters", Color.Gray }
		};


		public ProfilePage ()
		{
			this.Title = "FOOD DELIVERY";

			var layout = new StackLayout 
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
			layout.Children.Add(backgroundImageTitle);

			Grid grid = new Grid
			{
				VerticalOptions = LayoutOptions.FillAndExpand,
				Padding=20,
				RowSpacing=20,

				RowDefinitions = 
				{
					new RowDefinition { Height = GridLength.Auto },
					new RowDefinition { Height = GridLength.Auto },
					new RowDefinition { Height = GridLength.Auto },
					new RowDefinition { Height = GridLength.Auto },
					new RowDefinition { Height = GridLength.Auto },
					new RowDefinition { Height = GridLength.Auto },
					new RowDefinition { Height = GridLength.Auto },
					new RowDefinition { Height = GridLength.Auto },
					new RowDefinition { Height = GridLength.Auto },

				},
				ColumnDefinitions = 
				{
					new ColumnDefinition { Width = new GridLength(30, GridUnitType.Absolute) },
					new ColumnDefinition { Width = new GridLength(220, GridUnitType.Absolute) },
					new ColumnDefinition { Width = new GridLength(20, GridUnitType.Absolute) }

				}
				};

			var pickerimage = new Image()
			{
				Source = Device.OnPlatform(
					iOS: ImageSource.FromFile("homentry.png"),
					Android: ImageSource.FromFile("homentry.png"),
					WinPhone: ImageSource.FromFile("homentry.png"))

			};
			grid.Children.Add(pickerimage, 0, 0);

			//=======================================================

			Picker picker = new Picker
			{
				Title = "Select House Type",
				VerticalOptions = LayoutOptions.CenterAndExpand
			};
			foreach (string housetype in houseType.Keys)
			{
				picker.Items.Add(housetype);
			}

			grid.Children.Add(picker, 1, 0);

			picker.SelectedIndexChanged += (sender, args) =>
			{
				houseTypename = picker.Items[picker.SelectedIndex];
			};

			var blknoImage = new Image()
			{
				Source = Device.OnPlatform(
					iOS: ImageSource.FromFile("mypro1.png"),
					Android: ImageSource.FromFile("mypro1.png"),
					WinPhone: ImageSource.FromFile("mypro1.png"))

			};
			grid.Children.Add(blknoImage, 0, 1);

			//=======================================================

			blkInput = new Entry 
			{ Placeholder = "Block No or House No" ,
				//IsPassword = true,
				Keyboard=Keyboard.Email
			};

			blkInput.Text = "488a";
			blkInput.TextColor = Color.Black;

			grid.Children.Add(blkInput, 1, 1);
			blkInput.TextChanged += OnEntryTextChanged;
			//=======================================================
			blkColCheck = new Label
			{
				Text = "",
				VerticalTextAlignment = TextAlignment.Center,
				TextColor = Color.Red,
				FontSize=12
			};
			blkColCheck.FontFamily=Device.OnPlatform(
				iOS: "Optima-Bold",
				Android: "Droid Sans Mono",
				WinPhone: "Comic Sans MS"
			);
			grid.Children.Add(blkColCheck, 2, 1);
			//				//=======================================================

			var streetImage = new Image()
			{
				Source = Device.OnPlatform(
					iOS: ImageSource.FromFile("mypro1.png"),
					Android: ImageSource.FromFile("mypro1.png"),
					WinPhone: ImageSource.FromFile("mypro1.png"))

			};
			grid.Children.Add(streetImage, 0, 2);

			//=======================================================

			streetInput = new Entry 
			{ Placeholder = "Street Name" ,
				//IsPassword = true,
				Keyboard=Keyboard.Email
			};
			streetInput.TextColor = Color.Black;

			grid.Children.Add(streetInput, 1, 2);
			streetInput.TextChanged += OnEntryTextChanged;
			//=======================================================
			streetColCheck = new Label
			{
				Text = "",
				VerticalTextAlignment = TextAlignment.Center,
				TextColor = Color.Red,
				FontSize=12
			};
			streetColCheck.FontFamily=Device.OnPlatform(
				iOS: "Optima-Bold",
				Android: "Droid Sans Mono",
				WinPhone: "Comic Sans MS"
			);
			grid.Children.Add(streetColCheck, 2, 2);
			//=======================================================

			var floorImage = new Image()
			{
				Source = Device.OnPlatform(
					iOS: ImageSource.FromFile("mypro1.png"),
					Android: ImageSource.FromFile("mypro1.png"),
					WinPhone: ImageSource.FromFile("mypro1.png"))

			};
			grid.Children.Add(floorImage, 0, 3);

			//=======================================================

			floorInput = new Entry 
			{ Placeholder = "Floor Number" ,
				//IsPassword = true,
				Keyboard=Keyboard.Email
			};
			floorInput.TextColor = Color.Black;

			grid.Children.Add(floorInput, 1, 3);
			floorInput.TextChanged += OnEntryTextChanged;
			//=======================================================
			floorColCheck = new Label
			{
				Text = "",
				VerticalTextAlignment = TextAlignment.Center,
				TextColor = Color.Red,
				FontSize=12
			};
			floorColCheck.FontFamily=Device.OnPlatform(
				iOS: "Optima-Bold",
				Android: "Droid Sans Mono",
				WinPhone: "Comic Sans MS"
			);
			grid.Children.Add(floorColCheck, 2, 3);
			//=======================================================

			var unitImage = new Image()
			{
				Source = Device.OnPlatform(
					iOS: ImageSource.FromFile("mypro1.png"),
					Android: ImageSource.FromFile("mypro1.png"),
					WinPhone: ImageSource.FromFile("mypro1.png"))

			};
			grid.Children.Add(unitImage, 0, 4);

			//=======================================================

			unitInput = new Entry 
			{ Placeholder = "Unit Number" ,
				//IsPassword = true,
				Keyboard=Keyboard.Email
			};
			unitInput.TextColor = Color.Black;

			grid.Children.Add(unitInput, 1, 4);
			unitInput.TextChanged += OnEntryTextChanged;
			//=======================================================
			unitColCheck = new Label
			{
				Text = "",
				VerticalTextAlignment = TextAlignment.Center,
				TextColor = Color.Red,
				FontSize=12
			};
			unitColCheck.FontFamily=Device.OnPlatform(
				iOS: "Optima-Bold",
				Android: "Droid Sans Mono",
				WinPhone: "Comic Sans MS"
			);
			grid.Children.Add(unitColCheck, 2, 4);
			//=======================================================

			var postalImage = new Image()
			{
				Source = Device.OnPlatform(
					iOS: ImageSource.FromFile("mypro1.png"),
					Android: ImageSource.FromFile("mypro1.png"),
					WinPhone: ImageSource.FromFile("mypro1.png"))

			};
			grid.Children.Add(postalImage, 0, 5);

			//=======================================================

			postalInput = new Entry 
			{ Placeholder = "Postal Code" ,
				//IsPassword = true,
				Keyboard=Keyboard.Email
			};
			postalInput.TextColor = Color.Black;

			grid.Children.Add(postalInput, 1, 5);
			postalInput.TextChanged += OnEntryTextChanged;
			//=======================================================
			postalColCheck = new Label
			{
				Text = "",
				VerticalTextAlignment = TextAlignment.Center,
				TextColor = Color.Red,
				FontSize=12
			};
			postalColCheck.FontFamily=Device.OnPlatform(
				iOS: "Optima-Bold",
				Android: "Droid Sans Mono",
				WinPhone: "Comic Sans MS"
			);
			grid.Children.Add(postalColCheck, 2, 5);
			//=======================================================



			var backgroundImage = new Image()
			{
				Aspect = Xamarin.Forms.Aspect.AspectFill,

				Source = Device.OnPlatform(
					iOS: ImageSource.FromFile("bluebg.png"),
					Android: ImageSource.FromFile("bluebg.png"),
					WinPhone: ImageSource.FromFile("bluebg.png"))

			};

			Image iconbtn = new Image ();
			iconbtn.Source=ImageSource.FromFile("signupbtn.png");
			iconbtn.VerticalOptions = LayoutOptions.Center;

			var icontap = new TapGestureRecognizer ();

			icontap.Tapped += Button_Clicked;

			iconbtn.GestureRecognizers.Add (icontap);
			iconbtn.Opacity = 0.6;
			iconbtn.FadeTo (1);
			grid.Children.Add(iconbtn,0,6);
			Grid.SetColumnSpan (iconbtn, 3);

			ScrollView scroll1 = new ScrollView {
				Content=grid,
				Orientation = ScrollOrientation.Vertical,
			};


			var relativeLayout = new RelativeLayout();

			relativeLayout.Children.Add(backgroundImage,
				Constraint.Constant(0),
				Constraint.Constant(0),
				Constraint.RelativeToParent((parent) => { return parent.Width; }),
				Constraint.RelativeToParent((parent) => { return parent.Height; }));

			relativeLayout.Children.Add(layout,
				Constraint.Constant(0),
				Constraint.Constant(0),
				Constraint.RelativeToParent((parent) => { return parent.Width; }),
				Constraint.RelativeToParent((parent) => { return parent.Height; }));


			relativeLayout.Children.Add(scroll1,
				Constraint.Constant(0),
				Constraint.Constant(70),
				Constraint.RelativeToParent((parent) => { return parent.Width; }),
				Constraint.RelativeToParent((parent) => { return parent.Height; }));


			// Build the page.
			this.Content = relativeLayout;


		}



		void OnEntryTextChanged(object sender,TextChangedEventArgs e)
		{

			var text = e.NewTextValue;

			if(blkInput.Text != null || blkInput.Text !="" )
				blkColCheck.Text = "";

			if(streetInput.Text != null || streetInput.Text !="" )
				streetColCheck.Text = "";

			if(floorInput.Text != null || floorInput.Text !="" )
				floorColCheck.Text = "";

			if(unitInput.Text != null || unitInput.Text !="" )
				unitColCheck.Text = "";

			if(postalInput.Text != null || postalInput.Text !="" )
				postalColCheck.Text = "";

		}

		private async void Button_Clicked(object sender, EventArgs e)
		{
			//DisplayAlert("Good","Thanks", "OK");

			if (blkInput.Text == null || blkInput.Text=="") 
			{
				blkColCheck.Text = "***";
				blkColCheck.TextColor = Color.Red;
				blkInput.Focus ();
				return;
			}

			if (streetInput.Text == null || streetInput.Text=="") 
			{
				streetColCheck.Text = "***";
				streetColCheck.TextColor = Color.Red;
				streetInput.Focus ();
				return;
			}	

			if (floorInput.Text == null || floorInput.Text=="") 
			{
				floorColCheck.Text = "***";
				floorColCheck.TextColor = Color.Red;
				floorInput.Focus ();
				return;
			}

			if (unitInput.Text == null || unitInput.Text=="") 
			{
				unitColCheck.Text = "***";
				unitColCheck.TextColor = Color.Red;
				unitInput.Focus ();
				return;
			}			


			if (postalInput.Text == null || postalInput.Text=="") 
			{
				postalColCheck.Text = "***";
				postalColCheck.TextColor = Color.Red;
				postalInput.Focus ();
				return;
			}			


			try
			{
				await UserDialogs.Instance.AlertAsync(postalInput.Text,"Postal Code ");

			}
			catch (Exception ex)
			{
				this.IsBusy=false;
				UserDialogs.Instance.Loading().Hide();
				await UserDialogs.Instance.AlertAsync(ex.Message,"ERROR ");
				return;
			}

		} //end of class


	}

}


