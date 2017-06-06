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
using Plugin.Geolocator.Abstractions;

namespace iPartnerApp.Views
{
    public abstract class BaseMapPage<M,P>:BasePage where M : TKCustomMap where P : TKCustomMapPin
    {
        protected AbsoluteLayout MainContent { set; get; }
        protected DataService DataService = new DataService();
        protected Xamarin.Forms.Maps.Position CurrentPosition;
        private ObservableCollection<P> _pins = new ObservableCollection<P>();
        private MapSpan _mapRegion;
        private Xamarin.Forms.Maps.Position _mapCenter;
        public Xamarin.Forms.Maps.Position MapCenter 
		{
			set 
			{
				_mapCenter = value;
				try 
				{
					OnPropertyChanged ("MapCenter");
				}
				catch 
				{
					
				}
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
        protected M Map { set; get; }
        #endregion

        public BaseMapPage(bool useUpdateGeo = false)
        {
            Map = Activator.CreateInstance<M>();
            Map.MapType = MapType.Street;
            Map.IsShowingUser = true;
            Map.BindingContext = this;
            Map.SetBinding(TKCustomMap.CustomPinsProperty, "Pins");
            Map.SetBinding(TKCustomMap.MapCenterProperty, "MapCenter");
            Map.SetBinding(TKCustomMap.MapRegionProperty, "MapRegion");
            AbsoluteLayout.SetLayoutFlags(Map, AbsoluteLayoutFlags.SizeProportional);
            AbsoluteLayout.SetLayoutBounds(Map, new Rectangle(0, 0, 1, 1));
            if (useUpdateGeo)
            {
                CrossGeolocator.Current.DesiredAccuracy = 1;
                CrossGeolocator.Current.AllowsBackgroundUpdates = true;
                CrossGeolocator.Current.PositionChanged += Current_PositionChanged;
                GetPosition();
            }
            MainContent = new AbsoluteLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children = {
                    Map
                }
            };
            Content = MainContent;
        }

        private void Current_PositionChanged(object sender, PositionEventArgs e)
        {
            UpdateMapRegion(e.Position);
        }

        protected async void GetPosition()
        {
            var position = await CrossGeolocator.Current.GetPositionAsync(3000);
            if (position != null)
                UpdateMapRegion(position);
        }

        /// <summary>
        /// update map region for display
        /// </summary>
        public void UpdateMapRegion(Plugin.Geolocator.Abstractions.Position position)
        {
            CurrentPosition = new Xamarin.Forms.Maps.Position(position.Latitude, position.Longitude);
            MapCenter = CurrentPosition;
            Distance distance = MapRegion != null ? MapRegion.Radius : Distance.FromKilometers(30);
            MapRegion = MapSpan.FromCenterAndRadius(CurrentPosition, distance);
        }
    }
}
