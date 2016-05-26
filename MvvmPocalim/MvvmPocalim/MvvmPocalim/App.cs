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
            Mvx.RegisterType<ICalculation, Calculation>();
            Mvx.RegisterSingleton<IMvxAppStart>(new MvxAppStart<FirstViewModel>());
        }
    }

}
