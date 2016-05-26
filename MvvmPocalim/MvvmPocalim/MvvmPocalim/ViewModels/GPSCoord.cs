using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmPocalim.ViewModels
{
    public class GPSCoord
    {
        private double _lat;
        private double _lng;

        public GPSCoord()
        {
            _lat = Lat;
            _lng = Lng;
        }

        public double Lat
        {
            get { return _lat; }
            set { _lat = value; }
        }

        public double Lng
        {
            get { return _lng; }
            set { _lng = value; }
        }
    }
}
