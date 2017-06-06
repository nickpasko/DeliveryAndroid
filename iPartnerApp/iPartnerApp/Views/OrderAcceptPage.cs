using iPartnerApp.Enums;
using iPartnerApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace iPartnerApp.Views
{
    public class OrderAcceptPage : ContentPage, IDisposable
    {
        private ITimer _timer;
        public OrderAcceptPage(OrderInfo order)
        {
            _timer = DependencyService.Get<ITimer>(DependencyFetchTarget.NewInstance);
            _timer.Tick += TimerTick;
            _timer.Interval = 10000;
            if (order == null)
                return;
            var acceptButton = new Button
            {
                Text = "I Accept!"
            };
            var rejectButton = new Button
            {
                Text = "Reject"
            };
            acceptButton.Clicked += (s, e) =>
            {
                //send status 
				order.OrderStatus = OrderStatus.DriverAccepted;
                SendOrderStatus(order.OrderId, OrderStatus.DriverAccepted);
                order.OrderStatus = OrderStatus.DriverAccepted;
                Close();
            };
            rejectButton.Clicked += (s, e) =>
            {
                //send status 
                SendOrderStatus(order.OrderId, OrderStatus.NewOrder);
                Close();
            };
            Content = new StackLayout
            {
                Children = {
                    new Label
                    {
                        Text = "Incoming order",
                        HorizontalOptions = LayoutOptions.Center,
                    },
                    new Label
                    {
                        Text = order.UserName,
                        HorizontalOptions = LayoutOptions.Center,
                    },
                    new Label
                    {
                        Text = new Converters.OrderAdressTextConverter().Convert(order,order.GetType(), null,null).ToString(),
                        HorizontalOptions = LayoutOptions.Center,
                    },
                    acceptButton,
                    rejectButton
                }
            };
        }

        ~OrderAcceptPage()
        {
            Dispose();
        }


        private void Close()
        {
            try
            {
                Navigation.PopModalAsync();
            }
            catch
            {
            }
            Dispose();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                Close();
            });
        }

        public void Dispose()
        {
			if (_timer == null)
				return;
            _timer.StopTimer();
            _timer = null;
        }
        private async void SendOrderStatus(int orderId, OrderStatus orderStatus)
        {
            var result = await new DataService().SetOrderStatus(orderId, orderStatus);
            if (result != null)
            {
                DataBaseService.SqlLiteDataBaseService.SaveOrderStatus(orderId, orderStatus);
            }
        }
    }
}
