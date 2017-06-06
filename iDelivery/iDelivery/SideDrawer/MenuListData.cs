using System;
using Xamarin.Forms;
using System.Collections.Generic;


namespace iDelivery
{
	public class MenuListData : List<MenuItem>
	{
		public MenuListData ()
		{

			this.Add (new MenuItem () 
				{ 
					Title = "HOME", 
					IconSource = "home", 
					TargetType = typeof(MainTabPage)
				});
			
			this.Add (new MenuItem () 
				{ 
					Title = "PROFILE", 
					IconSource = "profile", 
					TargetType = typeof(ProfilePage)
				});


			this.Add (new MenuItem () 
				{ 
					Title = "ORDER(s)", 
					IconSource = "globerd", 
					TargetType = typeof(OrderPage)
				});
			
			this.Add (new MenuItem () 
				{ 
					Title = "HISTORY", 
					IconSource = "globerd", 
					TargetType = typeof(HistoryPage)
				});
			
			this.Add (new MenuItem () 
				{ 
					Title = "SETTINGS", 
					IconSource = "settings", 
					TargetType = typeof(SettingsPage)
				});
			
			this.Add (new MenuItem () 
				{ 
					Title = "ABOUT", 
					IconSource = "about", 
					TargetType = typeof(AboutPage)
				});

			this.Add (new MenuItem () 
				{ 
					Title = "SIGN OUT", 
					IconSource = "logoff", 
					TargetType = typeof(LogoutPage)
				});
		}

	}
}


