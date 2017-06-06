using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using Xamarin;

namespace iDelivery.iOS
{
	public class Application
	{
		// This is the main entry point of the application.
		static void Main (string[] args)
		{
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            Insights.Initialize("5f7125ed05d7368a4f301901b240636eeaa70000");
            UIApplication.Main (args, null, "AppDelegate");
		}
	}
}

