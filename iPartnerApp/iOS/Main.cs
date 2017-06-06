using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin;
using Foundation;
using UIKit;

namespace iPartnerApp.iOS
{
	public class Application
	{
		// This is the main entry point of the application.
		static void Main (string[] args)
		{
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            Insights.Initialize("b4e84f033d5a063b8a2efcce69c58b8bd0ed5b6c");
            UIApplication.Main (args, null, "AppDelegate");
		}
	}
}

