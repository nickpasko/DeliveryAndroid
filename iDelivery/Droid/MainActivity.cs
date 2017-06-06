using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin;
using Acr.UserDialogs;
using ImageCircle.Forms.Plugin.Droid;
using Android.Graphics;

namespace iDelivery.Droid
{
	[Activity (Label = "iDelivery.Droid", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			global::Xamarin.Forms.Forms.Init (this, bundle);
			ImageCircleRenderer.Init();
			UserDialogs.Init(this);
            Xamarin.FormsMaps.Init(this, bundle);
            Insights.Initialize("5f7125ed05d7368a4f301901b240636eeaa70000", this);
            App app = new App ();
			app.SetMapKey ("AIzaSyDyAJ7CV-M44O0C_VcCWXiW6tBPX574l8c");
			LoadApplication (app);
		}
        /// <summary>
        /// Confirm exit from app
        /// </summary>
        public override void OnBackPressed()
        {
            new AlertDialog.Builder(this).SetMessage("Close application?").SetPositiveButton("Yes", (s, e) =>
            {
                BackButton.FireBackButtonCall();
                Process.KillProcess(Process.MyPid());
            }).SetNegativeButton("No", (s, e) => { }).Show();
        }
    }
}

