using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using iDelivery;
using iDelivery.Droid;
using TK.CustomMap.Droid;
using Android.Graphics;
using System.IO;
using System.Net;
using TK.CustomMap.Api.Google;
using Android.Gms.Maps;
using iDelivery.Pins;

[assembly: ExportRenderer(typeof(TrackMap), typeof(TrakMapRender))]
namespace iDelivery.Droid
{
    public class TrakMapRender:TKCustomMapRenderer, Android.Gms.Maps.GoogleMap.IInfoWindowAdapter
    {
        public TrackMap TrackMap { get { return Element as TrackMap; } }

        public override void OnMapReady(GoogleMap googleMap)
        {
            base.OnMapReady(googleMap);
            googleMap.SetInfoWindowAdapter(this);
        }

        private Dictionary<string, Bitmap> _cacheBitmaps = new Dictionary<string, Bitmap>();

        Android.Views.View Android.Gms.Maps.GoogleMap.IInfoWindowAdapter.GetInfoContents(Android.Gms.Maps.Model.Marker marker)
        {
            var pin = this.GetPinByMarker(marker) as DriverPin;
            if (pin == null || pin.DriverInfo == null) return null;
            var layout = new LinearLayout(Context);
            layout.Orientation = Orientation.Horizontal;
            var image = new ImageView(Context);
            layout.AddView(image);
            if (!_cacheBitmaps.ContainsKey(pin.DriverInfo.DriverPhoto))
            {
                var bitmap = GetImageBitmapFromUrl("http://jaimayakali.com/"+pin.DriverInfo.DriverPhoto);
                _cacheBitmaps.Add(pin.DriverInfo.DriverPhoto, bitmap);
            }
            image.SetImageBitmap(_cacheBitmaps[pin.DriverInfo.DriverPhoto]);
            var textLayout = new LinearLayout(Context);
            textLayout.Orientation = Orientation.Vertical;
            var lp = new LayoutParams(LayoutParams.WrapContent, LayoutParams.WrapContent);
            var textName = new TextView(Context)
            {
                Text = "Driver Name:" + pin.DriverInfo.DriverName,
                LayoutParameters = lp
            };
            textName.SetTextColor(Android.Graphics.Color.Black);
            textLayout.AddView(textName);
            var textNumber = new TextView(Context)
            {
                Text = "Vehicle No:" + pin.DriverInfo.VehicleNo,
                LayoutParameters = lp
            };
            textNumber.SetTextColor(Android.Graphics.Color.Black);
            textLayout.AddView(textNumber);
            layout.AddView(textLayout);
            return layout;
        }
        private Bitmap GetImageBitmapFromUrl(string url)
        {
            Bitmap imageBitmap = null;

            using (var webClient = new WebClient())
            {
                try
                {
                    var imageBytes = webClient.DownloadData(url);
                    if (imageBytes != null && imageBytes.Length > 0)
                    {
                        imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                    }
                }
                catch(Exception ex) {
                    return null;
                }
            }

            return imageBitmap;
        }
        Android.Views.View Android.Gms.Maps.GoogleMap.IInfoWindowAdapter.GetInfoWindow(Android.Gms.Maps.Model.Marker marker)
        {
            return null;
        }
    }

}