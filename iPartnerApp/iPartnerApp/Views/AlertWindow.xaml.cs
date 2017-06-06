using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace iPartnerApp.Views
{
	public partial class AlertWindow : ContentPage
	{
		public AlertWindow (string header, string message, string icon, Action retry, Action cancel)
		{
			InitializeComponent ();
			Header.Text = header.ToUpper();
			Message.Text = message;
			Icon.Source = Device.OnPlatform (icon, icon, icon);
			Retry.Clicked += (s, e) => {
				if (retry != null)
					retry.Invoke ();
				Navigation.PopModalAsync();
			};
			Cancel.Clicked += (s, e) => {
				if (cancel != null)
					cancel.Invoke ();
				Navigation.PopModalAsync();
			};
		}

	}
}

