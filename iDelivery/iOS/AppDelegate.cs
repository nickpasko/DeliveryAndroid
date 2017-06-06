using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

using ImageCircle.Forms.Plugin.iOS;
using TK.CustomMap.iOSUnified;

namespace iDelivery.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{

			UINavigationBar.Appearance.BarTintColor = UIColor.FromRGB(145, 37, 0); //bar background

			UINavigationBar.Appearance.TintColor = UIColor.White; //Tint color of button items
			UINavigationBar.Appearance.SetTitleTextAttributes(new UITextAttributes()
			{
				Font = UIFont.FromName("HelveticaNeue-Light", (nfloat)20f),
				TextColor = UIColor.White
			});
			
			global::Xamarin.Forms.Forms.Init ();
			global::Xamarin.FormsMaps.Init ();
			ImageCircleRenderer.Init();
            TKCustomMapRenderer.InitMapRenderer();
			NativePlacesApi.Init();
            App a = new App();
			a.SetMapKey ("AIzaSyBj7y_h1cMFZZTr1YHP3szNj3CYoago3Hw");
			LoadApplication (a);

			return base.FinishedLaunching (app, options);
		}
	}
}

