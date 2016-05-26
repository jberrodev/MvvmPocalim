using Java.Util;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins.Location;
using MvvmPocalim.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace MvvmPocalim.ViewModels
{
    public class FirstViewModel : MvxViewModel
    {
        private Markers _marker;
        private Markers _marker2;

        private List<Markers> _list;

        public Markers Marker
        {
            get { return _marker; }
            set { _marker = value; RaisePropertyChanged(() => Marker); }
        }
        public Markers Marker2
        {
            get { return _marker2; }
            set { _marker2 = value; RaisePropertyChanged(() => Marker2); }
        }

        public List<Markers> MarkerList
        {
            get { return _list; }
            set { _list = value; RaisePropertyChanged(() => MarkerList); }
        }

        public override void Start()
        {
            _list= new List<Markers>();
            
            _marker = new Markers()
            {
                Coord = new GPSCoord() { Lat = 48.826577, Lng = 2.270949 },
                Nom = "Sogeti"
            };
            _marker2 = new Markers()
            {
                Coord = new GPSCoord() { Lat = 48.831165, Lng = 2.254237 },
                Nom = "Boulogne"
            };

            _list.Add(_marker);
            _list.Add(_marker2);
            /*
            string jsonString = @"{""movies"":[{""id"":""1"",""title"":""Sherlock""},{""id"":""2"",""title"":""The Matrix""}]}";
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            MovieCollection collection = serializer.Deserialize<MovieCollection>(jsonString);*/
        }

           
            base.Start();
        }

        public IMvxCommand MoveCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    Marker.Coord = new GPSCoord()
                    {
                        Lat = Marker.Coord.Lat + 0.1,
                        Lng = Marker.Coord.Lng
                    };
                });
            }
        }


    }
}


