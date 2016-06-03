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
    public class MyPopupInfoView : MvxActivity
    {
        //Specification du ViewModel
        public new PopupViewModel ViewModel
        {
            get { return (PopupViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }
        //Une fois le ViewModel chargé on genere la vue
        protected override void OnViewModelSet()
        {
            base.OnViewModelSet();
            SetContentView(Resource.Layout.View_Popup);

        }
    }
}