using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
[assembly: Xamarin.Forms.Dependency(typeof(iPartnerApp.Droid.ShowNavigate))]
namespace iPartnerApp.Droid
{
    public class ShowNavigate : IShowNavigate
    {
        /// <summary>
        /// Call navigation on the google maps
        /// </summary>
        public void StartNavigate(string address)
        {
            //Intent mapIntent = new Intent(Intent.ActionView, Android.Net.Uri.Parse(string.Format("google.navigation:q={0},{1}&mode=d", toLat.ToString().Replace(",", "."), toLon.ToString().Replace(",", "."))));
            Intent mapIntent = new Intent(Intent.ActionView, Android.Net.Uri.Parse(string.Format("google.navigation:q={0}&mode=d", address.Replace(" ", "+"))));
            mapIntent.SetPackage("com.google.android.apps.maps");
            mapIntent.SetFlags(ActivityFlags.NewTask);
            try
            {
                Application.Context.StartActivity(mapIntent);
            }
            catch
            {
            }
        }
    }
}