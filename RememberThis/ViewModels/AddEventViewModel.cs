using RememberThis.Commands;
using RememberThis.Models;
using RememberThis.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RememberThis.ViewModels
{
    public class AddEventViewModel : ViewModelBase
    {
        private string _eventAction;
        private bool _repeats;
        private DateTime _startDate = DateTime.Now;
        private bool[] _priorityArray = new bool[] { true, false, false };
        private int _priority;

        public string EventAction
        {
            get
            {
                return _eventAction;
            }
            set
            {
                _eventAction = value;
                OnPropertyChanged(nameof(EventAction));
            }

        }
        public bool Repeats
        {
            get
            {
                return _repeats;
            }
            set
            {
                _repeats = value;
                OnPropertyChanged(nameof(Repeats));
            }

        }
       
        public DateTime StartDate
        {
            get
            {
                return _startDate;
            }
            set
            {
                _startDate = value;
                OnPropertyChanged(nameof(StartDate));
            }

        }
  
        public bool[] PriorityArray 
        {
            get 
            { 
                return _priorityArray; 
            }
            set 
            {
                _priorityArray = value;
                _priority = Array.IndexOf(_priorityArray, true);
                OnPropertyChanged(nameof(PriorityArray));
            }
        }

        public int Priority 
        {
            get
            {
                return Array.IndexOf(_priorityArray, true);
            }

        }

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public AddEventViewModel(Registrator registrator, NavigationService eventViewNavigationService)
        {
            SubmitCommand = new AddEventCommand(this, registrator, eventViewNavigationService);
            CancelCommand = new NavigateCommand(eventViewNavigationService);
        }
    }
}
