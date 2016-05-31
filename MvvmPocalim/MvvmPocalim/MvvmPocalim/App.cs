﻿using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmPocalim.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmPocalim
{
    public class App : MvxApplication
    {
        public App()
        {
            Mvx.RegisterSingleton<IMvxAppStart>(new MvxAppStart<MarkerListViewModel>());
        }
    }

}
