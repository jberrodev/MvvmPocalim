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
         
            List<bool> list = new List<bool>();
            if (filtreRestaurantIsChecked)
                list.Add(filtreRestaurantIsChecked);
            if (filtreProximiteIsChecked)
                list.Add(filtreProximiteIsChecked);
            if (filtreTransformationIsChecked)
                list.Add(filtreTransformationIsChecked);
            if (filtreSupermarcheIsChecked)
                list.Add(filtreSupermarcheIsChecked);

            return list.Count.ToString();

        }
    }
}
