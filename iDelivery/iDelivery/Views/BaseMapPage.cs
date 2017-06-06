using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TK.CustomMap;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace iDelivery
{
    public abstract class BaseMapPage<T, P>:ContentPage where T : TKCustomMap where P: TKCustomMapPin
    {
        protected AbsoluteLayout MainContent { set; get; }
        protected DataService DataService = new DataService();
        protected Position ClientPosition;
        private ObservableCollection<P> _pins = new ObservableCollection<P>();
        private MapSpan _mapRegion;
        private Position _mapCenter;
        public Position MapCenter
        {
            set
            {
                _mapCenter = value;
                OnPropertyChanged("MapCenter");
            }
            get { return _mapCenter; }
        }
        public MapSpan MapRegion
        {
            set
            {
                _mapRegion = value;
                OnPropertyChanged("MapRegion");
            }
            get
            {
                return _mapRegion;
            }
        }
        public ObservableCollection<P> Pins
        {
            get { return _pins; }
            set
            {
                _pins = value;
                OnPropertyChanged("Pins");
            }
        }

        #region Controls
        protected T Map {set; get; }
        
        #endregion

        public BaseMapPage()
        {
            Map = Activator.CreateInstance<T>();
            Map.MapType = MapType.Street;
            Map.IsShowingUser = true;
            CrossGeolocator.Current.PositionChanged += Current_PositionChanged;
            CrossGeolocator.Current.DesiredAccuracy = 1;
			if(!CrossGeolocator.Current.IsListening)
            	CrossGeolocator.Current.StartListeningAsync(2000, 1);
            Map.BindingContext = this;
            Map.SetBinding(TKCustomMap.CustomPinsProperty, "Pins");
            Map.SetBinding(TKCustomMap.MapCenterProperty, "MapCenter");
            Map.SetBinding(TKCustomMap.MapRegionProperty, "MapRegion");
            AbsoluteLayout.SetLayoutFlags(Map, AbsoluteLayoutFlags.SizeProportional);
            AbsoluteLayout.SetLayoutBounds(Map, new Rectangle(0, 0, 1, 1));

            MainContent = new AbsoluteLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children = {
                    Map
                }
            };
            Content = MainContent;
        }

        private void Current_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            ClientPosition = new Position( e.Position.Latitude,e.Position.Longitude);
            MapCenter = ClientPosition;
            Distance distance = MapRegion != null ? MapRegion.Radius : Distance.FromKilometers(30);
            MapRegion = MapSpan.FromCenterAndRadius(ClientPosition, distance);
        }
    }
}
