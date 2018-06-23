using CountdownTimer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;

namespace CountdownTimer.ViewModels
{
    public class CountdownViewModel : BaseViewModel
    {
        private DispatcherTimer _countdownTimer;

        private bool _isRunning;
        
        private ApplicationViewModel _applicationViewModel;
        public ApplicationViewModel ApplicationViewModel { get; private set; }


        public CountdownModel CountdownModel { get; set; }
        private bool _isStartButtonEnabled;
        public bool isStartButtonEnabled
        {
            get { return _isStartButtonEnabled; }
            set { OnPropertyChanged(ref _isStartButtonEnabled, value); }
        }
        private bool _isStopButtonEnabled;
        public bool isStopButtonEnabled
        {
            get { return _isStopButtonEnabled; }
            set { OnPropertyChanged(ref _isStopButtonEnabled, value); }
        }


        public ICommand StartCountdownCommand { get; private set; }
        public ICommand StopCountdownCommand { get; private set; }
        public ICommand SettingsCommand { get; private set; }


        public CountdownViewModel(ApplicationViewModel applicationViewModel)
        {
            CountdownModel = new CountdownModel();
            CountdownModel.SecondsRemaining = 10;
            StartCountdownCommand = new RelayCommand(StartCountdown);
            StopCountdownCommand = new RelayCommand(StopCountdown);
            SettingsCommand = new RelayCommand(GoToSettings);
            _isRunning = false;
            isStartButtonEnabled = true;
            isStopButtonEnabled = true;
            _applicationViewModel = applicationViewModel;
        }


        public void StartCountdown(object obj)
        {
            if (_isRunning == false)
            {
                _countdownTimer = new DispatcherTimer();
                _countdownTimer.Tick += OnTimer_Tick;
                _countdownTimer.Interval = new TimeSpan(0, 0, 1);
                _countdownTimer.Start();
                _isRunning = true;
                isStartButtonEnabled = false;
                isStopButtonEnabled = true;
            }
        }

        public void OnTimer_Tick(object sender, EventArgs e)
        {
            if (CountdownModel.SecondsRemaining > 0)
                CountdownModel.SecondsRemaining--;
            else
                StopCountdown(null);
        }



        public void StopCountdown(object obj)
        {
            _countdownTimer.Stop();
            _isRunning = false;

            if (CountdownModel.SecondsRemaining > 0)
            {
                isStartButtonEnabled = true;
                isStopButtonEnabled = false;
            }
            else
            {
                isStartButtonEnabled = true;
            }

        }

        public void GoToSettings(object obj)
        {
            _applicationViewModel.CurrentView = new CountdownSettingsViewModel();
        }
    
    }
}
