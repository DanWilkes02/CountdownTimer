using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountdownTimer.ViewModels
{
    public class ApplicationViewModel : ObservableObject
    {


      
        private BaseViewModel _currentView;
        public BaseViewModel CurrentView
        {
            get { return _currentView; }
            set { OnPropertyChanged(ref _currentView, value); }
        }


        public ApplicationViewModel()
        {
            CurrentView = new CountdownViewModel(this);
        }
        
    }
}
