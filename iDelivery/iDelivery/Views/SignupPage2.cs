
using System;
using System.Collections.Generic;
using iDelivery;
using Xamarin.Forms;

using Acr.UserDialogs;
using Newtonsoft.Json.Linq;


namespace iDelivery
{
	public class SignupPage2 : ContentPage
	{
		

		public SignupPage2 ()
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


			var layout = new StackLayout 
			{ 
				Padding = 25, 
				Spacing=15,
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center
			};

			var label = new Label
			{
				Text = "Credit Card ",
				TextColor = Color.Black,
			};
			layout.Children.Add(label);

			Button btnSubmit  = new Button
			{
				HorizontalOptions = LayoutOptions.Fill,
				FontSize=18,
				BackgroundColor = Color.FromHex("#cd5b45"),
				TextColor = Color.Black,
				Text = "Sign Up Next >>"
			};
			layout.Children.Add(btnSubmit);

			btnSubmit.Clicked +=  ButtonClickedFunc;

			ScrollView scroll1 = new ScrollView {
				Content=layout,
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
			await Navigation.PushAsync(new SignupPage3());
			return;
		}

		void OnEntryTextChanged(object sender,TextChangedEventArgs e)
		{

			var text = e.NewTextValue;


		}





	}
}


