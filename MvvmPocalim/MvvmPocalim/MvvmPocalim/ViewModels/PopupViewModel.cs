using Java.IO;
using Java.Util;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins.Location;
using MvvmPocalim.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace MvvmPocalim.ViewModels
{
    public class PopupViewModel : MvxViewModel
    {
    
        private MyPOI _marker;
        public MyPOI Marker
        {
            get { return _marker; }
            set { _marker = value; RaisePropertyChanged(() => Marker); }
        }

        public override void Start()
        {
            var marker = new MyPOI()
            {
                Coord = new GPSCoord() { Lat = 0, Lng = 0},
                Nom = "Marker de TEST",
                Type = "MyType",
                Adresse = "MyAdress",
                Note = 4,
                Inspection = "01/06/2016"
            };
            base.Start();
        }
    }
}


