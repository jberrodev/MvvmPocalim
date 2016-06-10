using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmPocalim.Services;
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
            Mvx.RegisterType<IMyFilter, MyFilter>();
            Mvx.RegisterSingleton<IMvxAppStart>(new MvxAppStart<FillingListOfMyPOIViewModel>());
        }
    }

}
