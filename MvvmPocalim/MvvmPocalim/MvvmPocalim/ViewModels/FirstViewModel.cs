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
            _marker = new Markers(48.831165, 2.254237, "Sogeti");
            base.Start();
        }


    }
}


