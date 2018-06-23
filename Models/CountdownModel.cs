using CountdownTimer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountdownTimer.Models
{
    public class CountdownModel : ObservableObject
    {
        private double _secondsRemaining;
        public double SecondsRemaining
        {
            get { return _secondsRemaining; }
            set { OnPropertyChanged(ref _secondsRemaining, value); }
        }

        private  double _maxSeconds;
        public  double MaxSeconds { get { return _maxSeconds; }  set { _maxSeconds = value; } }

        public CountdownModel()
        {
            MaxSeconds = 10;
        }
    }
}
