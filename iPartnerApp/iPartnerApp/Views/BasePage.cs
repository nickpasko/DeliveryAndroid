using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Acr.UserDialogs;
using Plugin.Connectivity;

namespace iPartnerApp.Views
{
    public abstract class BasePage: ContentPage
    {
        protected DataService DataSercvice = new DataService();
        public BasePage()
        {
            var onlineoffline = new ToolbarItem
            {
                Text = "ONLINE"
            };

            this.ToolbarItems.Add(onlineoffline);

            onlineoffline.Clicked += async (object sender, System.EventArgs e) =>
            {
                if (CrossConnectivity.Current.IsConnected)
                {
                    if (onlineoffline.Text.Equals("ONLINE"))
                    {
                        onlineoffline.Text = "OFFLINE";
                        Model.Driver.Current.DriverStatus = Enums.DriverStatus.Offline;
                        var resposnse = await new DataService().UpdateOnlineOfflineStatus();
                        UserDialogs.Instance.Loading("Go Offline");
                        this.IsBusy = false;
                        UserDialogs.Instance.Loading().Hide();
                    }
                    else
                    {
                        onlineoffline.Text = "ONLINE";
                        UserDialogs.Instance.Loading("Go Online");
                        Model.Driver.Current.DriverStatus = Enums.DriverStatus.Online;
                        var resposnse = await new DataService().UpdateOnlineOfflineStatus();
                        this.IsBusy = false;
                        UserDialogs.Instance.Loading().Hide();
                    }
                }
            };
        }
    }
}
