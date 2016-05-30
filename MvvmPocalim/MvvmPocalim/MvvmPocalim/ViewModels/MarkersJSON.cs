using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmPocalim.ViewModels
{
    //Classe qui sert à désérialiser le fichier JSON
    public class MarkersJSON : MvxViewModel
    {
        public List<MarkerJSON> data { get; set; }
    }

    public class MarkerJSON
    {
        public string nom { get; set; }
        public string lattitude { get; set; }
        public string longitude { get; set; }
        public string type { get; set; }
        public string adresse { get; set; }
        public string note { get; set; }
        public string inspection { get; set; }
    }
}
