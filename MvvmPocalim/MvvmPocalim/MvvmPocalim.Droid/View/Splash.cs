using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V7.App;
using System.Threading.Tasks;
using MvvmPocalim.Droid.View;
using MvvmCross.Droid.Views;

namespace MvvmPocalim.Droid
{
    [Activity(Theme = "@style/MyTheme.Splash", MainLauncher = true, NoHistory = true, Icon = "@drawable/splash_logo")]
    public class Splash : MvxSplashScreenActivity
    {
      
    }

}
