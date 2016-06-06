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
using System.Windows.Input;

namespace MvvmPocalim.ViewModels
{
    public class SecondViewModel : MvxViewModel
    {

        private string _test;

        public String Test
        {
            get { return _test; }
            set { _test = value; RaisePropertyChanged(() => Test); }
        }

    
        public override void Start()
        {
            _test = "Jadou";
            base.Start();
        }

        
    }
}


