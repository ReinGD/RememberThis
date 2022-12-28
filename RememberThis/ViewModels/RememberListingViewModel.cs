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
    public class RememberListingViewModel : ViewModelBase
    {
        private ObservableCollection<CalendarEventViewModel> _calendarEvents;
        private ObservableCollection<ToDoEventViewModel> _toDoEvents;

        private Registrator _registrator;

        public IEnumerable<CalendarEventViewModel> CalendarEvents => _calendarEvents;
        public IEnumerable<ToDoEventViewModel> ToDoEvents => _toDoEvents;

        public ICommand AddEventCommand { get; }

        public RememberListingViewModel(Registrator registrator, NavigationService rememberListingViewNavigationService)
        {
            _registrator = registrator;

            AddEventCommand = new NavigateCommand(rememberListingViewNavigationService);

            _calendarEvents = new ObservableCollection<CalendarEventViewModel>();
            _toDoEvents = new ObservableCollection<ToDoEventViewModel>();

            UpdateEvents();
        }

        private void UpdateEvents()
        {
            _calendarEvents.Clear();

            foreach (CalendarEvent calendarEvent in _registrator.GetCalendarEvents())
            {
                CalendarEventViewModel calendarEventViewModel = new CalendarEventViewModel(calendarEvent);
                if (calendarEvent.startDate.Date >= DateTime.Now.Date )
                   _calendarEvents.Add(calendarEventViewModel);
            }

            _toDoEvents.Clear();
            foreach (ToDoEvent toDoEvent in _registrator.GetToDoEvents())
            {
                ToDoEventViewModel todoEventViewModel = new ToDoEventViewModel(toDoEvent, _registrator);
                if (!toDoEvent.completed)
                    _toDoEvents.Add(todoEventViewModel);

                
            }
        }
    }
}
