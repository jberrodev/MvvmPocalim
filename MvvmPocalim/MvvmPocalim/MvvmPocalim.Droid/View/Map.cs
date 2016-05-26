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
using MvvmCross.Droid.Views;
using MvvmPocalim.ViewModels;
using MvvmCross.Droid.Support.V7.Fragging;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using MvvmCross.Droid.Support.V7.Fragging.Fragments;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platform.Converters;
using System.Globalization;

namespace MvvmPocalim.Droid.View
{
    [Activity(Label = "Map", MainLauncher = true, Theme ="@style/MyTheme.NoTitle")]
    public class Map : MvxActivity,IOnMapReadyCallback
    {
        private GoogleMap _gMap;
        private Marker _marker1;


        public new FirstViewModel ViewModel
        {
            get { return (FirstViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }

        protected override void OnViewModelSet()
        {
            base.OnViewModelSet();
            SetContentView(Resource.Layout.View_Map);

            if (_gMap == null)
                FragmentManager.FindFragmentById<MapFragment>(Resource.Id.map).GetMapAsync(this);

        }

        public void OnMapReady(GoogleMap googleMap)
        {
            _gMap = googleMap;

            var option1 = new MarkerOptions();
            option1.SetPosition(new LatLng(ViewModel.Marker.Coord.Lat, ViewModel.Marker.Coord.Lng));
            option1.SetTitle(ViewModel.Marker.Nom);

            _marker1 = _gMap.AddMarker(option1);
            
            var set = this.CreateBindingSet<Map, FirstViewModel>();
            set.Bind(_marker1)
                .For(m => m.Position)
                .To(vm => vm.Marker.Coord).WithConversion(new CoordToLatLngValueConverter(),null);
            set.Apply();
        }

        public class CoordToLatLngValueConverter : MvxValueConverter<GPSCoord, LatLng>
        {
            protected override LatLng Convert(GPSCoord value, Type targetType, object parameter, CultureInfo culture)
            {
                return new LatLng(value.Lat, value.Lng);
            }
            protected override GPSCoord ConvertBack(LatLng value, Type targetType, object parameter, CultureInfo culture)
            {
                return new GPSCoord() { Lat = value.Latitude, Lng = value.Longitude };
            }
        }
    }

}