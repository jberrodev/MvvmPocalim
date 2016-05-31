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
    /**Classe de création de la map
     * et ajout des markers**/
    [Activity(Label = "Map", Theme ="@style/MyTheme.NoTitle")]
    public class MapView : MvxActivity,IOnMapReadyCallback
    {
        private GoogleMap _gMap;
        private Marker _marker;

        //Specification du ViewModel
        public new MarkerListViewModel ViewModel
        {
            get { return (MarkerListViewModel)base.ViewModel; }
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
            
            //Listener sur click d'un marker
            _gMap.MarkerClick += MapOnMarkerClick;

            //Listener sur click de la map
            _gMap.MapClick += MapOnMapClick;

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

        private void MapOnMapClick(object sender, GoogleMap.MapClickEventArgs mapClickEventArgs)
        {
            Toast.MakeText(this, String.Format("You clicked on the MAP"), ToastLength.Short).Show();

        }

        private void MapOnMarkerClick(object sender, GoogleMap.MarkerClickEventArgs markerClickEventArgs)
        {
            markerClickEventArgs.Handled = true;
            Marker marker = markerClickEventArgs.Marker;

            Toast.MakeText(this, String.Format("You clicked on {0}", marker.Title), ToastLength.Short).Show();

            //Creation et affichage d'une fenetre
            //avec les infos du marker
            createPopup();


        }

       
        //Intent vers PopupView
        public void createPopup()
        {
            var popup = new Intent(this, typeof(PopupView));
            popup.PutExtra("FirstPage", "Data from First Page");
            StartActivity(popup);
        }

        //Position de départ de la camera
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
                        option.SetIcon(BitmapDescriptorFactory.FromResource(Resource.Drawable.pin_restaurant));
                    if (marker.Type.Contains("Proximité"))
                        option.SetIcon(BitmapDescriptorFactory.FromResource(Resource.Drawable.pin_proximite));
                    if (marker.Type.Contains("Supermarché"))
                        option.SetIcon(BitmapDescriptorFactory.FromResource(Resource.Drawable.pin_supermarche));
                    if (marker.Type.Contains("Transformation"))
                        option.SetIcon(BitmapDescriptorFactory.FromResource(Resource.Drawable.pin_transformation));

                    if (_gMap != null)
                        _marker = _gMap.AddMarker(option);
                }
        }
       
    }

}