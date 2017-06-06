using iDelivery.Pins;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TK.CustomMap;
using TK.CustomMap.Overlays;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace iDelivery
{
	public class TrackDriverPage : BaseMapPage<TrackMap, TKCustomMapPin>
	{
        private ObservableCollection<DriverRoute> _routes = new ObservableCollection<DriverRoute>();
        public ObservableCollection<DriverRoute> Routes { get { return _routes; } }
        private Label _arrivingLabel;
        ITimer _timer;
        public TrackDriverPage ()
		{
            Map.SetBinding(TKCustomMap.RoutesProperty, "Routes");
			Title = "Track";
			Icon = "hometab.png";
            _timer = DependencyService.Get<ITimer>();
            _timer.Tick += TimerTick;
            _timer.Interval = 5000;
            _arrivingLabel = new Label()
            {
                Text = "Calculate arriving",
                HorizontalTextAlignment = TextAlignment.Center,
                FontSize = 20,
                TextColor = Color.Black,
                VerticalTextAlignment = TextAlignment.Center,
                BackgroundColor = Color.Silver,
                IsVisible = false

            };
            AbsoluteLayout.SetLayoutFlags(_arrivingLabel, AbsoluteLayoutFlags.WidthProportional | AbsoluteLayoutFlags.YProportional| AbsoluteLayoutFlags.XProportional | AbsoluteLayoutFlags.HeightProportional);
            AbsoluteLayout.SetLayoutBounds(_arrivingLabel, new Rectangle(0.5,0.9, 0.5, 0.1));
            MainContent.Children.Add(_arrivingLabel);
            Map.RouteCalculationFinishedCommand = new Command<TKRoute>(r =>
            {
                _arrivingLabel.IsVisible = true;
                _arrivingLabel.Text = "Arriving in " + Math.Round(r.TravelTime/60) + " min";
            });
            DrawRoute();
        }
        ~TrackDriverPage()
        {
            _timer.Tick += TimerTick;
            _timer.StopTimer();
        }
        private async void DrawRoute()
        {
            var to = DataService.GetDriverRoute();
            var drivers = await DataService.GetDriverDeliveryPosition();
            Device.BeginInvokeOnMainThread(() =>
            {
                List<DriverPin> avPins = new List<DriverPin>();
                var driver = drivers.FirstOrDefault();
                if (driver != null)
                //foreach (var driver in drivers)
                {
                    DriverRoute route = Routes.FirstOrDefault(x => x.DriverInfo.DriverId == driver.DriverId);
                    if (route == null)
                    {
                        route = new DriverRoute
                        {
                            TravelMode = TKRouteTravelMode.Driving,
                            Source = new Position(driver.Latitude, driver.Longitude),
                            Destination = new Position(to.Latitude, to.Longitude),
                            Color = Color.Blue,
                            LineWidth = 20,
                            Selectable = false,
                            DriverInfo = new Model.DriverInfo
                            {
                                DriverId = driver.DriverId
                            }
                        };
                        Routes.Add(route);
                    }
                    else
                    {
                        route.Source = new Position(driver.Latitude, driver.Longitude);
                    }
                    DriverPin driverPin = Pins.OfType<DriverPin>().FirstOrDefault(x => x.DriverInfo.DriverId == driver.DriverId);
                    if (driverPin == null)
                    {
                        driverPin = new DriverPin()
                        {
                            Image = Device.OnPlatform("car_icon", "car_icon", string.Empty),
                            Position = new Position(driver.Latitude, driver.Longitude),
                            DriverInfo = driver,
                            ShowCallout = true,
                        };
                        Pins.Add(driverPin);
                    }
                    else
                    {
                        driverPin.Position = new Position(driver.Latitude, driver.Longitude);
                    }

                    var toPin = Pins.OfType<OrderPin>().FirstOrDefault(x => x.OrderInfo.Id == driver.DriverId);
                    if (toPin == null)
                    {
                        toPin = new OrderPin
                        {
                            Position = new Position(to.Latitude, to.Longitude),
                            DefaultPinColor = Color.Red,
                            OrderInfo = new Model.Order { Id = driver.DriverId }
                        };
                        Pins.Add(toPin);
                    }
                    else
                    {
                        toPin.Position = new Position(to.Latitude, to.Longitude);
                    }
                    avPins.Add(driverPin);
                }
                //clear not use pins 
                var castPins = Pins.OfType<DriverPin>();
                for (int i = 0; i < castPins.Count(); i++)
                {
                    if (avPins.FirstOrDefault(x => x.DriverInfo.DriverId == castPins.ElementAt(i).DriverInfo.DriverId) == null)
                    {
                        Routes.Remove(Routes.First(x => x.DriverInfo.DriverId == castPins.ElementAt(i).DriverInfo.DriverId));
                        Pins.Remove(Pins.OfType<OrderPin>().First(x => x.OrderInfo.Id == castPins.ElementAt(i).DriverInfo.DriverId));
                        Pins.Remove(castPins.ElementAt(i));
                        i = 0;
                    }
                }
            });
        }
        private void TimerTick(object s, EventArgs e) {
            DrawRoute();
        }
        
    }
}


