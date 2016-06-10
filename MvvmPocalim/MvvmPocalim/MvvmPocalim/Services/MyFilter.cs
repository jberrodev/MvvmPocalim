using MvvmPocalim.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmPocalim.Services
{
    public class MyFilter : IMyFilter
    {
        public string Reload(bool filtreRestaurantIsChecked, bool filtreProximiteIsChecked, bool filtreTransformationIsChecked, bool filtreSupermarcheIsChecked)
        {
            List<MyPOI> listRestaurant, listProximite, listTransformation, listSupermarche;

            FillingListOfMyPOIViewModel _viewModel = new FillingListOfMyPOIViewModel();
            /*
            if (filtreRestaurantIsChecked)
            {
                listRestaurant = new List<MyPOI>();
                foreach(MyPOI poi in _viewModel.MarkerList)
                {
                    if (poi.Type.Contains("Restaurant"))
                        listRestaurant.Add(poi);
                }
            }
            if (filtreProximiteIsChecked)
            {
                listProximite = new List<MyPOI>();
                foreach (MyPOI poi in _viewModel.MarkerList)
                {
                    if (poi.Type.Contains("Proximité"))
                        listProximite.Add(poi);
                }
            }
            if (filtreProximiteIsChecked)
            {
                listTransformation = new List<MyPOI>();
                foreach (MyPOI poi in _viewModel.MarkerList)
                {
                    if (poi.Type.Contains("Transformation"))
                        listTransformation.Add(poi);
                }
            }
            if (filtreProximiteIsChecked)
            {
                listSupermarche = new List<MyPOI>();
                foreach (MyPOI poi in _viewModel.MarkerList)
                {
                    if (poi.Type.Contains("Supermarché"))
                        listSupermarche.Add(poi);
                }
            }
            */
            List<bool> list = new List<bool>();
            if (filtreRestaurantIsChecked)
                list.Add(filtreRestaurantIsChecked);
            if (filtreProximiteIsChecked)
                list.Add(filtreProximiteIsChecked);
            if (filtreTransformationIsChecked)
                list.Add(filtreTransformationIsChecked);
            if (filtreSupermarcheIsChecked)
                list.Add(filtreSupermarcheIsChecked);

            //    return list.Count.ToString();
            return _viewModel.MarkerList.ToString();

        }
    }
}
