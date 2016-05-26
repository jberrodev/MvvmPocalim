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
        private GPSCoord _coord;
        private String _nom;

        public Markers()
        {
            _coord = Coord;
            _nom = Nom;
        }

        public GPSCoord Coord
        {
            get { return _coord; }
            set { _coord = value; RaisePropertyChanged(() => Coord); }
        }
        public String Nom
        {
            get { return _nom; }
            set { _nom = value; RaisePropertyChanged(() => Nom); }
        }
    }
}
