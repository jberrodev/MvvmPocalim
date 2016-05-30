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
        private Marker _marker;

        //Specification du ViewModel
        public new FirstViewModel ViewModel
        {
            get { return (FirstViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }
        //Une fois le ViewModel chargé on genere la vue
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
          
            //Position de départ de la camera
            moveCameraStart();
            
            //parcours de la liste de markers du ViewModel
            //et ajout des markers à la map
            addMarkers();
                         
            /*
            //binding du marker au ModelView
            var set = this.CreateBindingSet<Map, FirstViewModel>();
            set.Bind(_marker)
                .For(m => m.Position)
                .To(vm => vm.Marker.Coord).WithConversion(new CoordToLatLngValueConverter(), null);
            set.Apply();
            */
        }

        public void moveCameraStart()
        {
                LatLng location = new LatLng(48.828808,2.261146);
                CameraPosition.Builder builder = CameraPosition.InvokeBuilder();
                builder.Target(location);
                builder.Zoom(14);
                CameraPosition cameraPosition = builder.Build();
                CameraUpdate cameraUpdate = CameraUpdateFactory.NewCameraPosition(cameraPosition);

            if (_gMap != null)
            {
                _gMap.MoveCamera(cameraUpdate);
            }
           
        }
        //parcours de la liste de markers du ViewModel
        //et ajout des markers à la map
        public void addMarkers()
        {
                foreach (Markers marker in ViewModel.MarkerList)
                {
                    var option = new MarkerOptions();
                    option.SetPosition(new LatLng(marker.Coord.Lat, marker.Coord.Lng));
                    option.SetTitle(marker.Nom);
                    if (marker.Type.Contains("Restaurant"))
                        option.SetIcon(BitmapDescriptorFactory.DefaultMarker(BitmapDescriptorFactory.HueRose));
                    if (marker.Type.Contains("Proximité"))
                        option.SetIcon(BitmapDescriptorFactory.DefaultMarker(BitmapDescriptorFactory.HueYellow));
                    if (marker.Type.Contains("Supermarché"))
                        option.SetIcon(BitmapDescriptorFactory.DefaultMarker(BitmapDescriptorFactory.HueOrange));
                    if (marker.Type.Contains("Transformation"))
                        option.SetIcon(BitmapDescriptorFactory.DefaultMarker(BitmapDescriptorFactory.HueCyan));

                    if (_gMap != null)
                        _marker = _gMap.AddMarker(option);
                }
        }
       
    }

}