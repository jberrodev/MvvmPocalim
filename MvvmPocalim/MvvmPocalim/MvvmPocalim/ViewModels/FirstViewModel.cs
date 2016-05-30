using Java.Util;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins.Location;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace MvvmPocalim.ViewModels
{
    public class FirstViewModel : MvxViewModel
    {
        private List<Markers> _list;

        public List<Markers> MarkerList
        {
            get { return _list; }
            set { _list = value; RaisePropertyChanged(() => MarkerList); }
        }
        string jsonString2 = @"
    {
        ""data"": [
            {
                ""nom"": ""Sogeti France"",
                ""lattitude"": ""48.826870"",
                ""longitude"": ""2.271165"",
                ""adresse"": ""22 rue Gouverneur General Eboue, 92130 Issy Les Moulineaux"",
                ""note"": ""5"",
                ""inspection"": ""01/01/2015""
            },
            {
                 ""nom"": ""Quelque part"",
                ""lattitude"": ""48.831165"",
                ""longitude"": ""2.254237"",
                ""adresse"": ""18, Rue du Test, 92100 Boulogne-Billancourt"",
                ""note"": ""4"",
                ""inspection"": ""01/01/2016""
            }
        ]
    }";

        public override void Start()
        {
            _list= new List<Markers>();
        
            //désérialisation du Json dans une liste de MarkerJSON
            var des = (MarkersJSON)Newtonsoft.Json.JsonConvert.DeserializeObject(jsonString2, typeof(MarkersJSON));

            //On parcours le résultat en remplissant la liste
            //de Markers qui sera utilisée par les couches natives
            foreach (MarkerJSON markerJson in des.data)
            {
                try
                {
                    var marker = new Markers()
                    {
                        Coord = new GPSCoord() { Lat = Convert.ToDouble(markerJson.lattitude), Lng = Convert.ToDouble(markerJson.longitude) },
                        Nom = markerJson.nom,
                        Adresse = markerJson.adresse,
                        Note = Convert.ToDecimal(markerJson.note),
                        Inspection = markerJson.inspection

                    };
                    _list.Add(marker);
                }
                catch (FormatException)
                {
                }
                catch (OverflowException)
                {
                }

            }


            base.Start();
        }

        /*
        public IMvxCommand MoveCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    Marker.Coord = new GPSCoord()
                    {
                        Lat = Marker.Coord.Lat + 0.1,
                        Lng = Marker.Coord.Lng
                    };
                });
            }
        }    */

    }
}


