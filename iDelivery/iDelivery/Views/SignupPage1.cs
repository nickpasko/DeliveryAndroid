
using System;
using System.Collections.Generic;
using iDelivery;
using Xamarin.Forms;

using Acr.UserDialogs;
using Newtonsoft.Json.Linq;


namespace iDelivery
{
	public class SignupPage1 : ContentPage
	{
		private Label usernameColCheck;
		private Label emailColCheck;
		private Label passwordColCheck;
		private Label mobileColCheck;

		private Entry username;
		private Entry email;
		private Entry password;
		private Entry mobile;

		private Label usernameTitle;
		private Label emailTitle;
		private Label passwordTitle;
		private Label mobileTitle;



		public SignupPage1 ()
		{
			this.Title = "FOOD DELIVERY";


			// Background Image of the Page
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



			Grid grid = new Grid
			{
				VerticalOptions = LayoutOptions.FillAndExpand,
				Padding=60,

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
					new RowDefinition { Height = GridLength.Auto },
					new RowDefinition { Height = GridLength.Auto },
					new RowDefinition { Height = GridLength.Auto },
					new RowDefinition { Height = GridLength.Auto },
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
					new ColumnDefinition { Width = new GridLength(200, GridUnitType.Absolute) },

				}
				};


			//=======================================================

			usernameTitle = new Label
			{
				Text = "Name",
				TextColor = Color.Black,
				FontSize=13
			};
			usernameTitle.FontFamily=Device.OnPlatform(
				iOS: "Optima-Bold",
				Android: "Droid Sans Mono",
				WinPhone: "Comic Sans MS"
			);
			grid.Children.Add(usernameTitle, 0, 1);

			//=======================================================
			username = new Entry 
			{ Placeholder = "Name" ,
				//IsPassword = true,
				Keyboard=Keyboard.Text

			};
			username.TextColor = Color.Black;

			grid.Children.Add(username, 0, 2);
			username.TextChanged += OnEntryTextChanged;

			usernameColCheck = new Label
			{
				Text = "",
				TextColor = Color.Red,
				FontSize=12
			};
			usernameColCheck.FontFamily=Device.OnPlatform(
				iOS: "Optima-Bold",
				Android: "Droid Sans Mono",
				WinPhone: "Comic Sans MS"
			);

			grid.Children.Add(usernameColCheck, 0, 3);

			//=======================================================
			emailTitle = new Label
			{
				Text = "Email",
				TextColor = Color.Black,
				FontSize=13
			};
			emailTitle.FontFamily=Device.OnPlatform(
				iOS: "Optima-Bold",
				Android: "Droid Sans Mono",
				WinPhone: "Comic Sans MS"
			);
			grid.Children.Add(emailTitle, 0, 5);
			//=======================================================

			email = new Entry 
			{ Placeholder = "Email" ,
				//IsPassword = true,
				Keyboard=Keyboard.Email
			};
			email.TextColor = Color.Black;

			grid.Children.Add(email, 0, 6);
			email.TextChanged += OnEntryTextChanged;

			emailColCheck = new Label
			{
				Text = "",
				TextColor = Color.Red,
				FontSize=12
			};
			emailColCheck.FontFamily=Device.OnPlatform(
				iOS: "Optima-Bold",
				Android: "Droid Sans Mono",
				WinPhone: "Comic Sans MS"
			);

			grid.Children.Add(emailColCheck, 0, 7);

			//=======================================================

			passwordTitle = new Label
			{
				Text = "Password",
				TextColor = Color.Black,
				FontSize=13
			};
			passwordTitle.FontFamily=Device.OnPlatform(
				iOS: "Optima-Bold",
				Android: "Droid Sans Mono",
				WinPhone: "Comic Sans MS"
			);
			grid.Children.Add(passwordTitle, 0, 9);
			//=======================================================

			password = new Entry 
			{ Placeholder = "Password" ,
				IsPassword = true,
				Keyboard=Keyboard.Default
			};
			password.TextColor = Color.Black;

			grid.Children.Add(password, 0, 10);
			password.TextChanged += OnEntryTextChanged;

			passwordColCheck = new Label
			{
				Text = "",
				TextColor = Color.Red,
				FontSize=12
			};
			passwordColCheck.FontFamily=Device.OnPlatform(
				iOS: "Optima-Bold",
				Android: "Droid Sans Mono",
				WinPhone: "Comic Sans MS"
			);

			grid.Children.Add(passwordColCheck, 0, 11);

			//=======================================================

			mobileTitle = new Label
			{
				Text = "Mobile",
				TextColor = Color.Black,
				FontSize=13
			};
			mobileTitle.FontFamily=Device.OnPlatform(
				iOS: "Optima-Bold",
				Android: "Droid Sans Mono",
				WinPhone: "Comic Sans MS"
			);
			grid.Children.Add(mobileTitle, 0, 13);


			mobile = new Entry 
			{ Placeholder = "Mobile" ,
				//IsPassword = true,
				Keyboard=Keyboard.Numeric
			};
			mobile.TextColor = Color.Black;

			grid.Children.Add(mobile, 0, 14);
			mobile.TextChanged += OnEntryTextChanged;

			mobileColCheck = new Label
			{
				Text = "",
				TextColor = Color.Red,
				FontSize=12
			};
			mobileColCheck.FontFamily=Device.OnPlatform(
				iOS: "Optima-Bold",
				Android: "Droid Sans Mono",
				WinPhone: "Comic Sans MS"
			);

			grid.Children.Add(mobileColCheck, 0, 15);


			mobileTitle = new Label
			{
				Text = "Payment by CASH or CREDIT CARD",
				TextColor = Color.Black,
				FontSize=13
			};
			mobileTitle.FontFamily=Device.OnPlatform(
				iOS: "Optima-Bold",
				Android: "Droid Sans Mono",
				WinPhone: "Comic Sans MS"
			);
			grid.Children.Add(mobileTitle, 0, 17);


			Button btnSubmit  = new Button
			{
				HorizontalOptions = LayoutOptions.Fill,
				FontSize=18,
				BackgroundColor = Color.FromHex("#cd5b45"),
				TextColor = Color.Black,
				Text = "Sign Up Next >>"
			};
			grid.Children.Add(btnSubmit,0,19);

			btnSubmit.Clicked +=  ButtonClickedFunc;

			Image iconbtn = new Image ();
			iconbtn.Source=ImageSource.FromFile("signupbtn.png");
			iconbtn.HeightRequest = 100;
			iconbtn.WidthRequest = 100;
			var icontap = new TapGestureRecognizer ();

			icontap.Tapped += Button_Clicked;

			iconbtn.GestureRecognizers.Add (icontap);
			iconbtn.Opacity = 0.6;
			iconbtn.FadeTo (1);

			grid.Children.Add(iconbtn,0,21);

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

			// Build the page.
			this.Content = relativeLayout;


		}  // end of class

		private async void  ButtonClickedFunc (object sender, EventArgs e)
		{
			//DisplayAlert("Good","Thanks", "OK");
			await Navigation.PushAsync(new SignupPage2());
			return;
		}

		void OnEntryTextChanged(object sender,TextChangedEventArgs e)
		{

			var text = e.NewTextValue;

			if(username.Text != null || username.Text !="" )
				usernameColCheck.Text = "";

			if(email.Text != null || email.Text !="" )
				emailColCheck.Text = "";

			if(password.Text != null || password.Text !="" )
				passwordColCheck.Text = "";

			if(mobile.Text != null || mobile.Text !="" )
				mobileColCheck.Text = "";

		}

		private async void Button_Clicked(object sender, EventArgs e)
		{
			//DisplayAlert("Good","Thanks", "OK");

			if (username.Text == null || username.Text=="") 
			{
				usernameColCheck.Text = "Required";
				usernameColCheck.TextColor = Color.Red;
				username.Focus ();
				return;
			}
			if (email.Text == null || email.Text=="")  
			{
				emailColCheck.Text = "Required";
				emailColCheck.TextColor = Color.Red;
				email.Focus ();
				return;
			}
			if (password.Text == null || password.Text=="") 
			{
				passwordColCheck.Text = "Required";
				passwordColCheck.TextColor = Color.Red;
				password.Focus ();
				return;
			}
			if (mobile.Text == null || mobile.Text=="") 
			{
				mobileColCheck.Text = "Required";
				mobileColCheck.TextColor = Color.Red;
				mobile.Focus ();
				return;
			}


			try
			{
				var indicator = new ActivityIndicator
				{
					HorizontalOptions = LayoutOptions.CenterAndExpand,
					Color = Color.Black,
				};

				indicator.IsRunning = true;
				indicator.IsEnabled = true;
				indicator.BindingContext = this;
				indicator.SetBinding (ActivityIndicator.IsVisibleProperty, "IsBusy");

				this.IsBusy = true;

				UserDialogs.Instance.Loading("Updating");

				var postJsonClient = new DataService();

				var keyValues = new List<KeyValuePair<string, string>>
				{
					new KeyValuePair<string, string>("firstname", username.Text),
					new KeyValuePair<string, string>("lastname", " "),
					new KeyValuePair<string, string>("email", email.Text),
					new KeyValuePair<string, string>("mobile", mobile.Text),
					new KeyValuePair<string, string>("password", password.Text)
				};

				var response = await postJsonClient.SignUp(keyValues);

				this.IsBusy=false;

				UserDialogs.Instance.Loading().Hide();

				if (response.Status == 0)
				{
					//logged in succesfully
					UserDialogs.Instance.ShowSuccess(response.Status.ToString());
					//Application.Current.MainPage = new NavigationPage(new HomePage());
					return;

				}
				else
				{
					UserDialogs.Instance.Alert("Warning..."+response.Message);
					return;
				}

			}
			catch (Exception ex)
			{
				this.IsBusy=false;
				UserDialogs.Instance.Loading().Hide();
				await UserDialogs.Instance.AlertAsync(ex.Message,"ERROR ");
				return;
			}
			return;


		} //end of class




	}
}


