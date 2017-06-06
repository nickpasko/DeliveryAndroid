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
using iPartnerApp;
using DeviceOrientation.Forms.Plugin.Droid;
using Android.Content.Res;

namespace iPartnerApp.Droid
{
	[Activity (Label = "iPartnerApp.Droid", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, LaunchMode = LaunchMode.SingleTask)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			global::Xamarin.Forms.Forms.Init (this, bundle);
            Xamarin.FormsMaps.Init(this, bundle);
            UserDialogs.Init(this);
            DeviceOrientationImplementation.Init();

            Insights.Initialize("b4e84f033d5a063b8a2efcce69c58b8bd0ed5b6c", this);
            var app = new App();
            app.SetMapKey("AIzaSyDyAJ7CV-M44O0C_VcCWXiW6tBPX574l8c");
			LoadApplication (app);
		}
        /// <summary>
        /// Confirm exit from app
        /// </summary>
        public override void OnBackPressed()
        {
            new AlertDialog.Builder(this).SetMessage("Close application?").SetPositiveButton("Yes", (s, e) =>
            {
                BackButtonAndroid.FireBackButtonCall();
                Process.KillProcess(Process.MyPid());
            }).SetNegativeButton("No", (s, e) => { }).Show();
        }

        protected override void OnResume()
        {
            base.OnResume();
            ((NotificationManager)GetSystemService(NotificationService)).Cancel(0);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            ((NotificationManager)GetSystemService(NotificationService)).Cancel(0);
        }

        public override void OnConfigurationChanged(Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);
            DeviceOrientationImplementation.NotifyOrientationChange(newConfig);
        }

        protected override void OnStop()
        {
            base.OnStop();
            var intent = new Intent(this, Java.Lang.Class.FromType(typeof(MainActivity)));
            intent.SetFlags(ActivityFlags.ClearTop | ActivityFlags.SingleTop);
            PendingIntent intentPending = PendingIntent.GetActivity(Application, 0, intent, PendingIntentFlags.UpdateCurrent);
            var ntf = new Notification.Builder(this).SetSmallIcon(Resource.Drawable.icon).SetContentText("FOOD DELIVERY IS WORK").SetContentIntent(intentPending).Build();
            var manager = (NotificationManager)GetSystemService(NotificationService);
            manager.Notify(0, ntf);
        }

       
    }
}

