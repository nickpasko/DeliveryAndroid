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
[assembly: Xamarin.Forms.Dependency(typeof(iDelivery.Droid.BackButton))]
namespace iDelivery.Droid
{
    public class BackButton : IBackButton
    {
        public event EventHandler CallBackButton;
        public static BackButton Current { set; get; }
        public BackButton()
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