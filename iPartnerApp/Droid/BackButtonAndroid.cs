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

[assembly: Xamarin.Forms.Dependency(typeof(iPartnerApp.Droid.BackButtonAndroid))]
namespace iPartnerApp.Droid
{
    /// <summary>
    /// Implements call back button on android
    /// </summary>
    public class BackButtonAndroid : IBackButtonAndroid
    {
        public static BackButtonAndroid Current { set; get; }
        public event EventHandler CallBackButton;
        public BackButtonAndroid()
        {
            //мега костыль =)

            Current = this;
        }
        public static void FireBackButtonCall()
        {
            if (Current != null && Current.CallBackButton != null)
                Current.CallBackButton(new object(), new EventArgs());
        }
    }
}