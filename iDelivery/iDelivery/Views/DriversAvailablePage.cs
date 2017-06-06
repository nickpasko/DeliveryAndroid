using System;
using System.Collections.ObjectModel;
using TK.CustomMap;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using System.Linq;
using System.Collections.Generic;
using iDelivery.Pins;

namespace iDelivery
{
    public class DriversAvailablePage : BaseMapPage<TrackMap,DriverPin>
    {
        ITimer _timer;
        public DriversAvailablePage()
        {
            Title = "Drivers";
            Icon = "hometab.png";
            DrawPins();
            _timer = DependencyService.Get<ITimer>();
            _timer.Tick += TimerTick;
            _timer.Interval = 5000;
        }
        int count = 0;
        private async void DrawPins()
        {

            var drivers = await DataService.GetDriversAvailablePostion();
            Device.BeginInvokeOnMainThread(() =>
            {
                if (Pins == null || drivers.Status != 0 || drivers.Data == null)
                    return;
                var availablePins = new List<DriverPin>();
                foreach (var driver in drivers.Data)
                {
                    var existPin = Pins.FirstOrDefault(x => x.DriverPosition.DriverId == driver.DriverId);
                    var icon = driver.ProductType == 0 ? "car1" : "car" + driver.ProductType;
                    if (existPin == null)
                    {
                        existPin = new DriverPin
                        {
                            DriverPosition = driver,
                            ShowCallout = true,
                            Position = new Position(driver.Latitude, driver.Longitude),
                            Image = Device.OnPlatform(icon, icon, string.Empty)
                        };
                        Pins.Add(existPin);
                    }
                    else
                    {
                        existPin.DriverPosition = driver;
                        existPin.Position = new Position(driver.Latitude, driver.Longitude);
                        existPin.Image = Device.OnPlatform(icon, icon, string.Empty);
                    }
                    availablePins.Add(existPin);
                }
                //clear not use pins 
                for (int i = 0; i < Pins.Count; i++)
                {
                    if (availablePins.FirstOrDefault(x => x.DriverPosition.DriverId == Pins[i].DriverPosition.DriverId) == null)
                    {
                        Pins.RemoveAt(i);
                        i--;
                    }
                }
            });
        }
        private void TimerTick(object s, EventArgs e)
        {
            DrawPins();
        }
    }
}


