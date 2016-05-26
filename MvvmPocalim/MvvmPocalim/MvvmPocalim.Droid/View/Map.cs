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

namespace MvvmPocalim.Droid.View
{
    [Activity(Label = "Map", MainLauncher = true, Theme ="@style/MyTheme.NoTitle")]
    public class Map : MvxActivity,IOnMapReadyCallback
    {
        private GoogleMap _gMap;


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
            option1.SetPosition(new LatLng(ViewModel.Marker.Lat, ViewModel.Marker.Lng));
            option1.SetTitle(ViewModel.Marker.Nom);

            _gMap.AddMarker(option1);
        }
    }

}