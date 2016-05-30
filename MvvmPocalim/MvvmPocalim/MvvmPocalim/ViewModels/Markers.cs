﻿using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmPocalim.ViewModels
{
    //Objet Markers qui sera lu par les couches natives
   public class Markers : MvxViewModel
    {
        private GPSCoord _coord;
        private String _nom;
        private String _adresse;
        private Decimal _note;
        private String _inspection;

        public Markers()
        {
            _coord = Coord;
            _nom = Nom;
            _adresse = Adresse;
            _note = Note;
            _inspection = Inspection;
        }

        public GPSCoord Coord
        {
            get { return _coord; }
            set { _coord = value; RaisePropertyChanged(() => Coord); }
        }
        public String Nom
        {
            get { return _nom; }
            set { _nom = value; RaisePropertyChanged(() => Nom); }
        }
        public String Adresse
        {
            get { return _adresse; }
            set { _adresse = value; RaisePropertyChanged(() => Adresse); }
        }
        public Decimal Note
        {
            get { return _note; }
            set { _note = value; RaisePropertyChanged(() => Note); }
        }
        public String Inspection
        {
            get { return _inspection; }
            set { _inspection = value; RaisePropertyChanged(() => Inspection); }
        }
    }
}
