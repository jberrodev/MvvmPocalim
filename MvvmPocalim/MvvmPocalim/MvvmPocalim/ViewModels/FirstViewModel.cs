using Java.IO;
using Java.Util;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins.Location;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace MvvmPocalim.ViewModels
{
    public class FirstViewModel : MvxViewModel
    {
        private List<Markers> _markerslist;

        public List<Markers> MarkerList
        {
            get { return _markerslist; }
            set { _markerslist = value; RaisePropertyChanged(() => MarkerList); }
        }
        string jsonString2 = @"
    {
        ""data"": [
            {
                ""nom"": ""Sogeti France"",
                ""lattitude"": ""48.826870"",
                ""longitude"": ""2.271165"",
                ""type"": ""Restaurant"",
                ""adresse"": ""22 rue Gouverneur General Eboue, 92130 Issy Les Moulineaux"",
                ""note"": ""5"",
                ""inspection"": ""01/01/2015""
            },
            {
                 ""nom"": ""Quelque part"",
                ""lattitude"": ""48.831772"",
                ""longitude"": ""2.262446"",
                ""type"": ""Proximité"",
                ""adresse"": ""18, Rue du Test, 92100 Boulogne-Billancourt"",
                ""note"": ""2"",
                ""inspection"": ""01/01/2016""
            },
            {
                 ""nom"": ""Quelque part ailleurs"",
                ""lattitude"": ""48.831165"",
                ""longitude"": ""2.254237"",
                ""type"": ""Supermarché"",
                ""adresse"": ""18,rue d'ailleurs, 92100 Boulogne-Billancourt"",
                ""note"": ""1"",
                ""inspection"": ""01/01/2016""
            },
            {
                 ""nom"": ""Quelque part d'autre"",
                ""lattitude"": ""48.828851"",
                ""longitude"": ""2.266948"",
                ""type"": ""Transformation"",
                ""adresse"": ""123 Avenue d'autre part, 92130 Issy Les Moulineaux"",
                ""note"": ""3"",
                ""inspection"": ""01/01/2016""
            }

        ]
    }";

        public override void Start()
        {
            _markerslist= new List<Markers>();
        
            //On parcours le résultat en remplissant la liste
            //de Markers qui sera utilisée par les couches natives
            loadJson();

            base.Start();
        }

        //On parcours le résultat en remplissant la liste
        //de Markers qui sera utilisée par les couches natives
        public void loadJson()
        {
          
                var des = (MarkersJSON)Newtonsoft.Json.JsonConvert.DeserializeObject(jsonString2, typeof(MarkersJSON));

                foreach (MarkerJSON markerJson in des.data)
                {
                    try
                    {
                    var marker = new Markers()
                    {
                        Coord = new GPSCoord() { Lat = Convert.ToDouble(markerJson.lattitude), Lng = Convert.ToDouble(markerJson.longitude) },
                        Nom = markerJson.nom,
                        Type = markerJson.type,
                        Adresse = markerJson.adresse,
                        Note = Convert.ToDecimal(markerJson.note),
                        Inspection = markerJson.inspection

                        };
                        _markerslist.Add(marker);
                    }
                    catch (FormatException)
                    {
                    }
                    catch (OverflowException)
                    {
                    }

                }
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


