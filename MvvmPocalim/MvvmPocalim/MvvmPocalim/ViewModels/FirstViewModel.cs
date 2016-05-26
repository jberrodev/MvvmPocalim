using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins.Location;
using MvvmPocalim.Services;
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

        public Markers Marker
        {
            get { return _marker; }
            set { _marker = value; RaisePropertyChanged(() => Marker); }
        }

        public override void Start()
        {
            _marker = new Markers()
            {
                Coord = new GPSCoord() { Lat = 48.831165, Lng = 2.254237 },
                Nom = "Sogeti"
            };
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


