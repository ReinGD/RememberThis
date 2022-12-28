using RememberThis.Commands;
using RememberThis.Models;
using RememberThis.Services;
using RememberThis.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RememberThis.ViewModels
{
    public class ToDoEventViewModel : ViewModelBase
    {
        private ToDoEvent _toDoEvent;
        private Registrator _registrator;
        public string EventAction => _toDoEvent.eventAction;
        public bool Completed
        {
            get
            {
                return _toDoEvent.completed;
            }
            set
            {
                _toDoEvent.completed = value;
                OnPropertyChanged(nameof(Completed));
            }

        }

        public ICommand CheckCommand { get; }
        public ToDoEventViewModel(ToDoEvent toDoEvent, Registrator registrator)
        {
            CheckCommand = new RemoveEventCommand(this, registrator, new Services.NavigationService(App._navigationStore, App.CreateRememberListingViewModel));
            _toDoEvent = toDoEvent;
        }

    }
}
