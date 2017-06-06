using System;


[assembly: Xamarin.Forms.Dependency(typeof(iPartnerApp.Droid.Timer))]
namespace iPartnerApp.Droid
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
            if (_timer == null)
                return;
            _timer.Elapsed -= TickTimer;
            _timer.Stop();
            _timer.Dispose();
            _timer = null;
        }
    }
}