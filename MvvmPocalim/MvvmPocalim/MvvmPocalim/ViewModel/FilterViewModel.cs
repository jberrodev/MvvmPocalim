﻿using MvvmCross.Core.ViewModels;
using MvvmPocalim.Services;
using System;

namespace MvvmPocalim.ViewModels
{
    public class FilterViewModel : MvxViewModel
    {
        private readonly IMyFilter _myFilter;
        public FilterViewModel (IMyFilter filter)
        {
            _myFilter = filter;
        }

        public override void Start()
        {
            base.Start();
        }

        private string _test;

        public String Test
        {
            get { return _test; }
            set { _test = value; RaisePropertyChanged(() => Test); }
        }

        private bool _filterRestaurantIsChecked;

        public Boolean FilterRestaurantIsChecked
        {
            get { return _filterRestaurantIsChecked; }
            set { _filterRestaurantIsChecked = value; RaisePropertyChanged(() => FilterRestaurantIsChecked); Recalculate(); }
        }
        private bool _filterProximiteIsChecked;

        public Boolean FilterProximiteIsChecked
        {
            get { return _filterProximiteIsChecked; }
            set { _filterProximiteIsChecked = value; RaisePropertyChanged(() => FilterProximiteIsChecked); Recalculate(); }
        }
        private bool _filterTransformationIsChecked;

        public Boolean FilterTransformationIsChecked
        {
            get { return _filterTransformationIsChecked; }
            set { _filterTransformationIsChecked = value; RaisePropertyChanged(() => FilterTransformationIsChecked); Recalculate(); }
        }
        private bool _filterSupermarcheIsChecked;

        public Boolean FilterSupermarcheIsChecked
        {
            get { return _filterSupermarcheIsChecked; }
            set { _filterSupermarcheIsChecked = value; RaisePropertyChanged(() => FilterSupermarcheIsChecked); Recalculate(); }
        }

        //On recharge les POI
        //en fonction des checkboxes
        private void Recalculate()
        {
            Test = _myFilter.Reload(FilterRestaurantIsChecked, FilterProximiteIsChecked, FilterTransformationIsChecked, FilterSupermarcheIsChecked);
        }
        
    }
}


