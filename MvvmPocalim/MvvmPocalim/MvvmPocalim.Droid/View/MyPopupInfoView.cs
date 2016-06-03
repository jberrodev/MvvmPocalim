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
using MvvmCross.Droid.Views;
using MvvmPocalim.ViewModels;

namespace MvvmPocalim.Droid.View
{
    [Activity(Theme = "@style/MyTheme.Popup")]
    public class PopupView : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.View_Popup);
        }
    }
}