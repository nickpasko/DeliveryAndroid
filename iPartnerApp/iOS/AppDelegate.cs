using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using DeviceOrientation.Forms.Plugin.iOS;

namespace iPartnerApp.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init ();
            DeviceOrientationImplementation.Init();
            LoadApplication (new App ());

			return base.FinishedLaunching (app, options);
		}
	}
}

