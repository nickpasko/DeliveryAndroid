using iPartnerApp.Model;
using Plugin.Geolocator.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using TK.CustomMap;
using TK.CustomMap.Overlays;
using Xamarin.Forms;

namespace iPartnerApp.Views
{
    public class NavigationDriverPage : BaseMapPage<TKCustomMap, TKCustomMapPin>
    {
        private ObservableCollection<TKRoute> _routes = new ObservableCollection<TKRoute>();
        public ObservableCollection<TKRoute> Routes { get { return _routes; } }
        private Label _arrivingLabel;
        private TKCustomMapPin _driverPin;
        private OrderPin _toPin;
        private TKRoute _route;
        private ITimer _timer;
        private int _orderId;
        public NavigationDriverPage(int orederId) : base(true)
        {
            Map.SetBinding(TKCustomMap.RoutesProperty, "Routes");
            Map.IsShowingUser = false;
            _orderId = orederId;
            Title = "Track";
            Icon = "hometab.png";
            _timer = DependencyService.Get<ITimer>(DependencyFetchTarget.NewInstance);
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

            };
            AbsoluteLayout.SetLayoutFlags(_arrivingLabel, AbsoluteLayoutFlags.WidthProportional | AbsoluteLayoutFlags.YProportional | AbsoluteLayoutFlags.XProportional | AbsoluteLayoutFlags.HeightProportional);
            AbsoluteLayout.SetLayoutBounds(_arrivingLabel, new Rectangle(0.5, 0.9, 0.5, 0.1));
            MainContent.Children.Add(_arrivingLabel);
            Map.RouteCalculationFinishedCommand = new Command<TKRoute>(r =>
            {
                _arrivingLabel.Text = "Arriving in " + Math.Round(r.TravelTime / 60) + " min";
            });
            DrawRoute();
        }

        ~NavigationDriverPage()
        {
            _timer.Tick -= TimerTick;
            _timer.StopTimer();
            _timer = null;
        }

        private async void DrawRoute()
        {
            var to = await DataService.GetDriverOrder(_orderId);
            if (to == null)
                return;
            Device.BeginInvokeOnMainThread(() =>
            {
                if (CurrentPosition == null)
                    return;
                _route = new TKRoute
                {
                    TravelMode = TKRouteTravelMode.Driving,
                    Source = CurrentPosition,
                    Destination = new Xamarin.Forms.Maps.Position(to.Latitude, to.Longitude),
                    Color = Color.Blue,
                    LineWidth = 20,
                    Selectable = false
                };
                Routes.Add(_route);
                Pins.Clear();
                _driverPin = new TKCustomMapPin
                {
                    Image = Device.OnPlatform("car_icon.png", "car_icon.png", string.Empty),
                    Position = CurrentPosition
                };
                _toPin = new OrderPin
                {
                    Position = new Xamarin.Forms.Maps.Position(to.Latitude, to.Longitude),
                    Id = 1,
                    ShowCallout = true,
                    DefaultPinColor = Color.Red
                };
                Pins.Add(_toPin);
                Pins.Add(_driverPin);
            });
        }
        private void TimerTick(object s, EventArgs e)
        {
            if (_driverPin != null)
                _driverPin.Position = CurrentPosition;
            if (_route != null)
                _route.Source = _driverPin.Position;
        }

    }
}
