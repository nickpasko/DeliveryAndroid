using System;

using iPartnerApp;
using Xamarin.Forms;
using DeviceOrientation.Forms.Plugin.Abstractions;
using Newtonsoft.Json.Linq;
using Acr.UserDialogs;
using System.Collections.Generic;
using iPartnerApp.Model;
using System.Linq;
//using Zumero;

namespace iPartnerApp.Views
{
	public class OrdersListPageOld : BasePage
	{
        private IDeviceOrientation _deviceOrientation;
        private List<OrderInfo> _orders = new List<OrderInfo>();
        //private DataGrid _mainContent;
        ITimer _timer;
		public OrdersListPageOld ()
		{
			this.Title = "FOOD DELIVERY";
			Title = "Orders";
			Icon = "hometab.png";
            _deviceOrientation = DependencyService.Get<IDeviceOrientation>();
            _timer = DependencyService.Get<ITimer>(DependencyFetchTarget.NewInstance);
            _timer.Interval = 5000;
            _timer.Tick += UpdataOrders;
		}

        private async void UpdataOrders(object s, EventArgs e)
        {
            var result = await DataSercvice.GetOrdersForDriver();
            bool isChangeOrder = false;
            foreach (var order in result)
            {
                var existOrder = _orders.FirstOrDefault(x => x.OrderId == order.OrderId);
                if (existOrder == null)
                {
                    _orders.Add(order);
                    if (!isChangeOrder)
                        isChangeOrder = true;
                }
                else if (order != existOrder)
                {
                    _orders.Remove(existOrder);
                    _orders.Add(existOrder);
                    if (!isChangeOrder)
                        isChangeOrder = true;
                }
            }
            if (isChangeOrder)
            {
                CreateGrid(_deviceOrientation.GetOrientation());
            }
        }
        private void CreateGrid(DeviceOrientations orientation)
        {
            if (orientation == DeviceOrientations.Portrait)
                CreatePortraitOrientation();
            else
                CreateLandscapeOrientation();
        }

        private void CreatePortraitOrientation()
        {
            
        }

        private void CreateLandscapeOrientation()
        {
           /* _mainContent.Columns.Add(new Column
            {
                Template = new DataTemplate() {
                    
                }
            });*/
            /*_mainContent = new Grid()
            {
                ColumnDefinitions = {
                    new ColumnDefinition()
                    {
                        Width = new GridLength(25, GridUnitType.Absolute),
                    },
                    new ColumnDefinition()
                    {
                        Width = new GridLength(50, GridUnitType.Absolute),
                    },
                    new ColumnDefinition()
                    {
                        Width = new GridLength(100, GridUnitType.Star),
                    },
                    new ColumnDefinition()
                    {
                        Width = new GridLength(25, GridUnitType.Absolute),
                    },
                    new ColumnDefinition()
                    {
                        Width = new GridLength(25, GridUnitType.Absolute),
                    },
                    new ColumnDefinition()
                    {
                        Width = new GridLength(25, GridUnitType.Absolute),
                    },
                }
            };
            for (int i = 0; i < _orders.Count + 1; i++)
            {

            }*/
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<DeviceOrientationChangeMessage>(this, DeviceOrientationChangeMessage.MessageId, (m) =>
            {
                CreateGrid(m.Orientation);
            });
        }
        protected override void OnDisappearing()
        {
            MessagingCenter.Unsubscribe<DeviceOrientationChangeMessage>(this, DeviceOrientationChangeMessage.MessageId);
            base.OnDisappearing();
            
        }
    }
}


