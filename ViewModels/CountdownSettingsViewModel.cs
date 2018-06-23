using CountdownTimer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CountdownTimer.ViewModels
{
    public class CountdownSettingsViewModel : BaseViewModel
    {

        private double _maxSeconds;
        public double MaxSeconds
        {
            get { return _maxSeconds;}
            set { OnPropertyChanged(ref _maxSeconds, value); }
        }

        private ApplicationViewModel _applicationViewModel;

        public ICommand BackCommand { get; private set; }
        public ICommand ApplyCommand { get; private set; }

        private CountdownModel _countdownModel;

        public CountdownSettingsViewModel(CountdownModel countdownModel, ApplicationViewModel applicationViewModel)
        {
            _countdownModel = countdownModel;
            _applicationViewModel = applicationViewModel;
            MaxSeconds = _countdownModel.MaxSeconds;
            BackCommand = new RelayCommand(GoBack);
            ApplyCommand = new RelayCommand(ApplySettings);
        }

        private void GoBack(object obj) => _applicationViewModel.CurrentView = new CountdownViewModel(_applicationViewModel, _countdownModel);

        private void ApplySettings(object obj) => _countdownModel.MaxSeconds = MaxSeconds;
    }
}
