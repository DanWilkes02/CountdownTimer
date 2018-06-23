using CountdownTimer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountdownTimer.ViewModels
{
    public class ApplicationViewModel : ObservableObject
    {


        //The view shown by the main window 
        private BaseViewModel _currentView;
        public BaseViewModel CurrentView
        {
            get { return _currentView; }
            set { OnPropertyChanged(ref _currentView, value); }
        }

        private CountdownModel _countdownModel; 

        public ApplicationViewModel()
        {

            _countdownModel = new CountdownModel();

            //Sets up new CVM keeping this class, so only
            //one instance of this is ever created. 
            CurrentView = new CountdownViewModel(this, _countdownModel);
        }


        
    }
}
