using iDelivery.Helpers;
using System;
using TK.CustomMap.Api.Google;
using Xamarin.Forms;

namespace iDelivery
{
    public class App : Application
    {
        public App()
        {
            CheckLogin();
            if (Device.OS == TargetPlatform.Android)
            {
                var back = DependencyService.Get<IBackButton>();
                back.CallBackButton += (s, e) =>
                {
                    new DataService().AppQuit();
                };
            }
        }

        private async void CheckLogin()
        {
            var userName = Settings.UserName;
            var userPassword = Settings.UserPassword;
            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(userPassword))
            {
                NavigateTo(!await LoginHelper.Login(userName, userPassword));
            }
            else
            {
                NavigateTo(true);
            }
        }

        private void NavigateTo(bool first)
        {
            if (first)
                MainPage = new NavigationPage(new FirstPage())
                {
                    BarBackgroundColor = Color.FromHex("#3898DC"),
                    BarTextColor = Color.White
                };
            else
                MainPage = new RootPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
        public void SetMapKey(string key)
        {
            GmsPlace.Init(key);
            GmsDirection.Init(key);
        }
    }
}

