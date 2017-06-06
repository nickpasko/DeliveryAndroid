using Acr.UserDialogs;
using DeviceOrientation.Forms.Plugin.Abstractions;
using iPartnerApp.Enums;
using iPartnerApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace iPartnerApp.Views
{
    public partial class OrderListPage : BasePage
    {


        private Command<OrderInfo> _startCommand;
        private Command<OrderInfo> _displayActionCommand;
        private Command<OrderInfo> _navigateCommand;
        private Command<OrderInfo> _bellCommand;
        private Command<OrderInfo> _collectCommand;

        public Command<OrderInfo> StartCommand {
			get {
				return _startCommand ?? (_startCommand = new Command<OrderInfo> (order => {
                    if (order == null)
                    {
                        UserDialogs.Instance.Alert("Not exist order", "Fail change status");
                        return;
                    }
                    if (_orders.FirstOrDefault(x=>x.ExpressPrice == 2 && x.OrderStatus<OrderStatus.DeliveryStarted) !=null)
                    {
                        UserDialogs.Instance.Alert("Any orders with express delivery", "Fail change status");
                        return;
                    }
                    if ( order.OrderStatus > OrderStatus.DriverAccepted){
						UserDialogs.Instance.Alert("Order is started", "Fail change status");
						return;
					}
					if(_orders.FirstOrDefault(x=>x.OrderStatus == OrderStatus.DeliveryStarted || x.OrderStatus == OrderStatus.CallBellCustomer)!=null){
						UserDialogs.Instance.Alert("Order not completed", "Fail change status");
						return;
					}
					order.OrderStatus = OrderStatus.DeliveryStarted;
					order.OnPropertyChanged ("OrderStatus");
					SendStatusOrder (order.OrderId, OrderStatus.DeliveryStarted);
				}));
			}
		}
        public Command<OrderInfo> BellCommand {
			get {
				return _bellCommand ?? (_bellCommand = new Command<OrderInfo> (order => {
                    if (order == null)
                    {
                        UserDialogs.Instance.Alert("Not exist order", "Fail change status");
                        return;
                    }
                    if (order.OrderStatus > OrderStatus.CallBellCustomer) {
						UserDialogs.Instance.Alert("Order is call bell", "Fail change status");
						return;
					}
					order.OrderStatus = OrderStatus.CallBellCustomer;
					order.OnPropertyChanged ("OrderStatus");
					SendStatusOrder (order.OrderId, OrderStatus.CallBellCustomer);
				}));
			}
		}

        public Command<OrderInfo> CollectCommand {
			get {
				return _collectCommand ?? (_collectCommand = new Command<OrderInfo> (order => {
                    if (order == null)
                    {
                        UserDialogs.Instance.Alert("Not exist order", "Fail change status");
                        return;
                    }
                    if (order.OrderStatus > OrderStatus.PaymentProcess){
						UserDialogs.Instance.Alert("Order is Collect payment", "Fail change status");
						return;
					}	
					order.OrderStatus = OrderStatus.PaymentProcess;
					order.OnPropertyChanged ("OrderStatus");
					SendStatusOrder (order.OrderId, OrderStatus.PaymentProcess);
				}));
			}
		}

        public Command<OrderInfo> NavigateCommand {
            get
            {
                return _navigateCommand ?? (_navigateCommand = new Command<OrderInfo>(order => {
                    if (order == null || order.OrderStatus > OrderStatus.DeliveryStarted)
                        return;
                    var sendNavigation = DependencyService.Get<IShowNavigate>();
                    if (sendNavigation != null)
                        sendNavigation.StartNavigate(order.UnitNo + " " + order.FloorNo + " " + order.BlockNo + " " + order.StreetName + " " + order.PostalCode);
                }));
            }
        }

        public Command<OrderInfo> DisplayActionsCommand
        {
            get
            {
                return _displayActionCommand ?? (_displayActionCommand = new Command<OrderInfo>(async order =>
                { 
                    var action = await DisplayActionSheet("Select action:", "cancel", null, "Start","Navigate", "Bell open door", "Collect payment");
                    switch (action)
                    {
                        case "Navigate":
                            NavigateCommand.Execute(order);
                            break;
                        case "Start":
                            StartCommand.Execute(order);
                            break;
                        case "Bell open door":
                            BellCommand.Execute(order);
                            break;
                        case "Collect payment":
                            CollectCommand.Execute(order);
                            break;
                    }
                }));
            }
        }
        
        private IDeviceOrientation _deviceOrientation;
        private ObservableCollection<OrderInfo> _orders = new ObservableCollection<OrderInfo>();
        /// <summary>
        /// List of orders
        /// </summary>
        public ObservableCollection<OrderInfo> Orders
        {
            set { _orders = value; }
            get { return new ObservableCollection<OrderInfo>(_orders.OrderByDescending(x => x.ExpressPrice)); }
        }

        public OrderListPage()
        {

            InitializeComponent();
            BindingContext = this;
            Title = "FOOD DELIVERY";
            Title = "Orders";
            Icon = "hometab.png";
            _deviceOrientation = DependencyService.Get<IDeviceOrientation>();
        }

        private async void SendStatusOrder(int orderId, OrderStatus orderStatus)
        {
            UserDialogs.Instance.Loading("Sending");
            var result = await DataSercvice.SetOrderStatus(orderId, orderStatus);
            if (result != null)
            {
                DataBaseService.SqlLiteDataBaseService.SaveOrderStatus(orderId, orderStatus);
                Orders.First(x => x.OrderId == orderId).OnPropertyChanged("OrderStatusText");
            }
            UserDialogs.Instance.Loading().Hide();
        }

        public void UpdataOrders(List<OrderInfo> orders)
        {
            bool isChangeOrder = false;
            foreach (var order in orders.Where(x => x.OrderStatus >= OrderStatus.DriverAccepted))
            {
                var existOrder = _orders.FirstOrDefault(x => x.OrderId == order.OrderId);
                if (existOrder == null)
                {
                    _orders.Add(order);
                    if (!isChangeOrder)
                        isChangeOrder = true;
                }
                else if (!order.Equals(existOrder))
                {
                    _orders.Remove(existOrder);
                    _orders.Add(existOrder);
                    if (!isChangeOrder)
                        isChangeOrder = true;
                }
            }
			for (int i=0;i<_orders.Count;i++) 
			{
				var or = orders.FirstOrDefault (x => x.OrderId == _orders[i].OrderId);
				if (or == null) 
				{
					_orders.Remove ( _orders[i]);
					i--;
				}
			}
            if (isChangeOrder)
            {
                CreateGrid(_deviceOrientation.GetOrientation());
            }
        }

        public void CreateGrid(DeviceOrientations orientation)
        {
            ListPortrait.IsVisible = true;
            ListPortrait.ItemsSource = _orders;
            /*if (orientation == DeviceOrientations.Portrait)
                CreatePortraitOrientation();
            else
                CreateLandscapeOrientation();*/
        }

       /* private void CreatePortraitOrientation()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                ListLandscape.IsVisible = false;
                ListLandscape.ItemsSource = null;
                ListPortrait.IsVisible = true;
                ListPortrait.ItemsSource = _orders;
            });
        }

        private void CreateLandscapeOrientation()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                ListPortrait.IsVisible = false;
                ListPortrait.ItemsSource = null;
                ListLandscape.IsVisible = true;
                ListLandscape.ItemsSource = _orders;
            });
            
        }*/
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
