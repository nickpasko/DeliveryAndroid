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
using Android.Media;

[assembly: Xamarin.Forms.Dependency(typeof(iPartnerApp.Droid.SoundPlay))]
namespace iPartnerApp.Droid
{
    public class SoundPlay : ISoundPlay
    {
        public void PlaySound()
        {
            MediaPlayer.Create(Application.Context,Resource.Drawable.Incomingorders).Start();
        }
    }
}