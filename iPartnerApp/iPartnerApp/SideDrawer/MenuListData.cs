using System;
using Xamarin.Forms;
using System.Collections.Generic;
using iPartnerApp.Views;

namespace iPartnerApp
{
	public class MenuListData : List<MenuItem>
	{
		public MenuListData ()
		{

			this.Add (new MenuItem () 
				{ 
					Title = "HOME", 
					IconSource = "home.png", 
					TargetType = typeof(MainTabPage)
				});
			
			this.Add (new MenuItem () 
				{ 
					Title = "PROFILE", 
					IconSource = "profile.png", 
					TargetType = typeof(MainTabPage)
				});


			this.Add (new MenuItem () 
				{ 
					Title = "ORDER(s)", 
					IconSource = "globerd.png", 
					TargetType = typeof(MainTabPage)
				});
			
			this.Add (new MenuItem () 
				{ 
					Title = "HISTORY", 
					IconSource = "globerd.png", 
					TargetType = typeof(MainTabPage)
				});
			
			this.Add (new MenuItem () 
				{ 
					Title = "SETTINGS", 
					IconSource = "settings.png", 
					TargetType = typeof(MainTabPage)
				});
			
			this.Add (new MenuItem () 
				{ 
					Title = "ABOUT", 
					IconSource = "about.png", 
					TargetType = typeof(MainTabPage)
				});

			this.Add (new MenuItem () 
				{ 
					Title = "SIGN OUT", 
					IconSource = "logoff.png", 
					TargetType = typeof(LogoutPage)
				});
		}

	}
}


