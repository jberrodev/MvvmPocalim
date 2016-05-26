using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmPocalim.ViewModels
{
   public class Markers : MvxViewModel
    {
        private double _lat;
        private double _lng;
        private String _nom;

        public Markers(double lattitude, double longitude, String nom)
        {
            _lat = lattitude;
            _lng = longitude;
            _nom = nom;
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

        public String Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }
    }
}
