using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using iDelivery;
using Xamarin.Forms;
using Newtonsoft.Json.Linq;
using Acr.UserDialogs;
using iDelivery.Model;
using iDelivery.Helpers;

namespace iDelivery
{
	public class LoginPage : ContentPage
	{

		private Entry username;
		private Entry password;
		private Label lblMessage;

		private Label usernameColCheck;
		private Label passwordColCheck;
		public string custid="";


		public LoginPage ()
		{
			this.Title = "FOOD DELIVERY";

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

			var label = new Label
			{
				Text = " ",
				TextColor = Color.Black,
			};
			layout.Children.Add(label);

			var label2 = new Label
			{
				Text = " ",
				TextColor = Color.Black,
			};
			layout.Children.Add(label2);

			var label3 = new Label
			{
				Text = "Login Information ",
				TextColor = Color.Black,
			};
			layout.Children.Add(label3);


			username = new Entry 
			{ Placeholder = "Email" ,
				//IsPassword = true,
				Keyboard=Keyboard.Text

			};
			username.TextColor = Color.Black;

			layout.Children.Add(username);
			username.Focus();
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

			layout.Children.Add(usernameColCheck);


			password = new Entry 
			{ Placeholder = "Password" ,
				IsPassword = true,
				Keyboard=Keyboard.Default
			};
			password.TextColor = Color.Black;

			layout.Children.Add(password);
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

			layout.Children.Add(passwordColCheck);

			Image iconbtn = new Image ();
			iconbtn.Source=ImageSource.FromFile("loginbutton.png");
			var icontap = new TapGestureRecognizer ();
			icontap.Tapped += Button_Clicked;
			iconbtn.GestureRecognizers.Add (icontap);
			iconbtn.Opacity = 0.6;
			iconbtn.FadeTo (1);

			lblMessage = new Label()
			{
				TextColor = Color.Black
			};

			layout.Children.Add (lblMessage);

			//layout.Children.Add(buttonLogin);
			layout.Children.Add(iconbtn);

			var backgroundImage = new Image()
			{

				Aspect = Xamarin.Forms.Aspect.AspectFill,

				Source = Device.OnPlatform(
					iOS: ImageSource.FromFile("bluebg.png"),
					Android: ImageSource.FromFile("bluebg.png"),
					WinPhone: ImageSource.FromFile("bluebg.png"))

			};

			//Content = layout;

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

			relativeLayout.Children.Add(layout,
				Constraint.Constant(0),
				Constraint.Constant(0),
				Constraint.RelativeToParent((parent) => { return parent.Width; }),
				Constraint.RelativeToParent((parent) => { return parent.Height; }));

			Content = relativeLayout;

		}

		void OnEntryTextChanged(object sender,TextChangedEventArgs e)
		{

			var text = e.NewTextValue;

			if(username.Text != null || username.Text !="" )
				usernameColCheck.Text = "";

			if(password.Text != null || password.Text !="" )
				passwordColCheck.Text = "";

		}

		private async void Button_Clicked(object sender, EventArgs e)
		{

			if (username.Text == null) 
			{
				usernameColCheck.Text = "Required";
				usernameColCheck.TextColor = Color.Red;
				username.Focus ();
				return;
			}

			if (password.Text == null) 
			{
				passwordColCheck.Text = "Required";
				passwordColCheck.TextColor = Color.Red;
				password.Focus();
				return;
			}


			try
			{
                if (await LoginHelper.Login(username.Text, password.Text))
                {
                    Settings.UserName = username.Text;
                    Settings.UserPassword = password.Text;
                    Application.Current.MainPage = new RootPage();
                }
            }
			catch (Exception ex)
			{
				this.IsBusy=false;

				UserDialogs.Instance.Loading().Hide();
				//await DisplayAlert(ex.Message, "OK", "OK");
				await UserDialogs.Instance.AlertAsync(ex.Message,"ERROR ");

				return;
			}
		}

		async void Confirm() 
		{
			var r = await UserDialogs.Instance.ConfirmAsync("Pick a choice", "Pick Title");
			var text = (r ? "Yes" : "No");
			this.Result($"Confirmation Choice: {text}");
		}

		void Result(string msg) 
		{
			UserDialogs.Instance.Alert(msg);
		}

	}
}


