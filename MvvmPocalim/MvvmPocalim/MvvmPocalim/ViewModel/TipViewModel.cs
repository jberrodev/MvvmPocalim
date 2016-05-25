using MvvmCross.Core.ViewModels;
using MvvmPocalim.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmPocalim.ViewModel
{
    public class TipViewModel : MvxViewModel
    {
        private readonly ICalculation _calculation;
        public TipViewModel(ICalculation calculation)
        {
            _calculation = calculation;
        }

        public override void Start()
        {
            _subTotal = 100;
            _generosity = 10;
            Recalculate();
            base.Start();
        }

        private double _subTotal;

        public double SubTotal
        {
            get { return _subTotal; }
            set { _subTotal = value; RaisePropertyChanged(() => SubTotal); Recalculate(); }
        }

        private int _generosity;

        public int Generosity
        {
            get { return _generosity; }
            set { _generosity = value; RaisePropertyChanged(() => Generosity); Recalculate(); }
        }

        private double _tip;

        public double Tip
        {
            get { return _tip; }
            private set { _tip = value; RaisePropertyChanged(() => Tip); }
        }

        private void Recalculate()
        {
            Tip = _calculation.TipAmount(SubTotal, Generosity);
        }
    }
}


