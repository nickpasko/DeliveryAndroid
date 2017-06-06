using Acr.UserDialogs;
using iPartnerApp.Enums;
using iPartnerApp.Model;
using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;
using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Linq;

namespace iPartnerApp.Views
{
	public class MainTabPage : TabbedPage
	{
        private Plugin.Geolocator.Abstractions.Position _currentPosition;
        private List<OrderInfo> _newOrders = new List<OrderInfo>();
        private bool _listnerStart = false;
        private DriverMapPage _mapPage;
        private OrderListPage _orderListPage;
        private bool _showError = false;
        private ITimer _timer;
        public static void ShowLocationError()
        {
            UserDialogs.Instance.Alert("To work correctly, the application must enable GPS tracking");
        }
		public static void ShowNoNetwork(INavigation navigation) 
        {
			navigation.PushModalAsync(new AlertWindow("Network error","Turn On in Setting for data connection or Wi-Fi","nonetwork",null,null),true);
            //UserDialogs.Instance.Alert("Turn On in Setting for data connection or Wi-Fi");
		}

        ~MainTabPage()
        {
            _timer.StopTimer();
            _timer.Tick -= TimerTick;
            _timer = null;
        }

        public MainTabPage()
        {
            CrossGeolocator.Current.DesiredAccuracy = 1;
            CrossGeolocator.Current.AllowsBackgroundUpdates = true;
            CrossGeolocator.Current.PositionChanged += Current_PositionChanged;
            CrossConnectivity.Current.ConnectivityChanged += ConnectivityChanged;
            _mapPage = new DriverMapPage();
            _orderListPage = new OrderListPage();
            _timer = DependencyService.Get<ITimer>(DependencyFetchTarget.NewInstance);
            _timer.Tick += TimerTick;
            _timer.Interval = 5000;
            if (!CrossGeolocator.Current.IsGeolocationEnabled)
            {
                ShowLocationError();
                _showError = true;
                var position = new Plugin.Geolocator.Abstractions.Position();
                position.Longitude = 103.85;
                position.Latitude = 1.35;
                _mapPage.UpdateMapRegion(position);
            }
            else
            {
                StartListner();
            }
            Title = "FOOD DELIVERY";
            Children.Add (_mapPage);
            Children.Add(_orderListPage);
			Children.Add (new OrdersCompletedPage ());
			Children.Add (new ChatPage ());
		}
        
        private void ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            if (!e.IsConnected)
            {
				ShowNoNetwork(Navigation);
            }
        }

        private async void StartListner()
        {
            if (!CrossGeolocator.Current.IsListening)
            {
                _listnerStart = await CrossGeolocator.Current.StartListeningAsync(2000, 1);
            }
            else
            {
                _listnerStart = true;
            }
            _showError = false;
        }
        private async void TimerTick(object sender, EventArgs e)
        {
            var dataService = new DataService();
            //update driver position
            GpsStatus gpsStatus = CrossGeolocator.Current.IsGeolocationEnabled ? GpsStatus.NoError : GpsStatus.GpsTurnOff;
            if (gpsStatus == GpsStatus.GpsTurnOff && !_showError)
            {
                ShowLocationError();
                _showError = true;
                _listnerStart = false;
            }
            if (!_listnerStart && CrossGeolocator.Current.IsGeolocationEnabled)
            {
                StartListner();
            }
            if (Driver.Current != null)
                Driver.Current.GpsStatus = gpsStatus;
            var result = await dataService.UpdatePositionDriver(_currentPosition, gpsStatus);
            //check new orders
			var orders = await dataService.GetOrdersForDriver();
            if (orders != null && orders.Count > 0)
            {
                var newOrder = orders.Where(x => x.OrderStatus == OrderStatus.NewOrder).FirstOrDefault();
                if (newOrder != null)
                {

                    var status =  DataBaseService.SqlLiteDataBaseService.GetLocalOrderStatus(newOrder.OrderId);
                    if (status == null && _newOrders != null && _newOrders.FirstOrDefault(x => x.OrderId == newOrder.OrderId) == null)
                    {
                        var soundPlayer = DependencyService.Get<ISoundPlay>();
                        if (soundPlayer != null)
                        {
                            soundPlayer.PlaySound();
                        }
                        _newOrders.Add(newOrder);
                        if (newOrder.AutoAccept != 1)
                        {
                            Device.BeginInvokeOnMainThread(() =>
                            {
                                var newPage = new OrderAcceptPage(newOrder);
                                Navigation.PushModalAsync(newPage);
                            });
                        }
                        else
                        {
                            var r = await new DataService().SetOrderStatus(newOrder.OrderId, OrderStatus.DriverAccepted);
                            if (r != null)
                            {
                                DataBaseService.SqlLiteDataBaseService.SaveOrderStatus(newOrder.OrderId, OrderStatus.NewOrder);
                                newOrder.OrderStatus = OrderStatus.NewOrder;
                            }
                        }
                    }
                }
            }
            _orderListPage.UpdataOrders(orders);
        }

        private void Current_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            _currentPosition = e.Position;
            if (Driver.Current != null)
                Driver.Current.Position = e.Position;
            _mapPage.UpdateMapRegion(e.Position);
        }
    }
}


