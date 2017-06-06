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

[assembly: Xamarin.Forms.Dependency(typeof(iDelivery.Droid.Timer))]
namespace iDelivery.Droid
{
    public class Timer : Java.Lang.Object, ITimer
    {
        private System.Timers.Timer _timer;
        public int Interval
        {
            set
            {
                if (_timer != null)
                {
                    _timer.Elapsed -= TickTimer;
                    _timer.Stop();
                }
                _timer = new System.Timers.Timer();
                _timer.Elapsed += TickTimer;
                _timer.Enabled = true;
                _timer.Interval = value;
                _timer.AutoReset = true;
                _timer.Start();
            }
        }

        private void TickTimer(object state, System.Timers.ElapsedEventArgs handler)
        {
            if (Tick != null)
                Tick(this, new EventArgs());
        }

        public event EventHandler Tick;

        public void StopTimer()
        {
            _timer.Elapsed -= TickTimer;
            _timer.Stop();
            _timer.Dispose();
        }
    }
}