using System;
using System.Linq;
using iPartnerApp;
using Xamarin.Forms;
using Newtonsoft.Json.Linq;
using Acr.UserDialogs;
using TK.CustomMap;
using System.Collections.ObjectModel;
using Xamarin.Forms.Maps;
using iPartnerApp.Model;
using System.Collections.Generic;

namespace iPartnerApp.Views
{
    public class DriverMapPage : BaseMapPage<TKCustomMap, OrderPin>
    {
        private ITimer _timer;

        public DriverMapPage()
        {
            _timer = DependencyService.Get<ITimer>(DependencyFetchTarget.NewInstance);
            _timer.Tick += UpdateListCart;
            _timer.Interval = 5000;
            Title = "Home";
            Icon = "chat.png";
            Map.BindingContext = this;
            Map.SetBinding(TKCustomMap.CustomPinsProperty, "Pins");
            Map.SetBinding(TKCustomMap.MapCenterProperty, "MapCenter");
            Map.SetBinding(TKCustomMap.MapRegionProperty, "MapRegion");
        }
        ~DriverMapPage()
        {
            _timer.Tick -= UpdateListCart;
            _timer.StopTimer();
        }
        Enums.OrderStatus[] availableStatus = 
            {
                Enums.OrderStatus.NewOrder,
                Enums.OrderStatus.DriverAccepted
            };
        private async void UpdateListCart(object sender, EventArgs e)
        {
            if (Driver.Current == null)
                return;
            var result = await DataService.GetDriverOrdersOnMap();
            if (result == null || result.Status != 0)
                return;
            Device.BeginInvokeOnMainThread(() =>
            {
                //list of showing pins in map
                var availablePins = new List<OrderPin>();
                foreach (var r in result.Data)
                {
                    if (!availableStatus.Contains(r.OrderStatus))
                        continue;
                    var existPin = Pins.FirstOrDefault(x => x.Id == r.OrderId);
                    string namePin = r.OrderStatus == Enums.OrderStatus.NewOrder ? "red_pin" : "green_pin";
                    if (existPin == null)
                    {
                        existPin = new OrderPin
                        {
                            Id = r.OrderId,
                            Position = new Position(r.Latitude, r.Longitude),
                            Title = "Order No:" + r.OrderId,
                            Image = Device.OnPlatform(namePin, namePin, string.Empty),
                            ShowCallout = true,
                        };
                        Pins.Add(existPin);

                    }
                    else {
                        existPin.Image = Device.OnPlatform(namePin, namePin, string.Empty);
                    }
                    availablePins.Add(existPin);
                }
                //delete older pins
                for (int i = 0; i < Pins.Count; i++)
                {
                    if (availablePins.FirstOrDefault(x => x.Id == Pins[i].Id) == null)
                    {
							if(Pins!=null){
                        Pins.RemoveAt(i);
                        i--;
							}
						}
					}
            });
        }
    }
}
