
using Android.App;
using MvvmCross.Droid.Views;
using MvvmPocalim.ViewModels;

namespace MvvmPocalim.Droid.View
{
    /**Classe de cr�ation de la map
     * et ajout des markers**/
    [Activity(Theme = "@style/MyTheme.Popup")]
    public class FilterView : MvxActivity
    {
        //Specification du ViewModel
        public new FilterViewModel ViewModel
        {
            get { return (FilterViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }
        //Une fois le ViewModel charg� on genere la vue
        protected override void OnViewModelSet()
        {
            base.OnViewModelSet();
            SetContentView(Resource.Layout.View_Filtre);


        }
    }
}