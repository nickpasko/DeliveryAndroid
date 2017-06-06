using iPartnerApp.Helpers;
using Plugin.Settings;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace iPartnerApp.Views
{
    public partial class FirstPage : ContentPage
    {
        public FirstPage(bool showLogin = true)
        {
            this.Title = "GMG PARTNER APP";
            
            InitializeComponent();
            if (!showLogin)
                ButtonLogin.IsVisible = false;
            ButtonLogin.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new LoginPage());
            };

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        
        }

        
    }
}

