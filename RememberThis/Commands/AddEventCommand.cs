using RememberThis.Exceptions;
using RememberThis.Models;
using RememberThis.Services;
using RememberThis.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RememberThis.Commands
{
    public class AddEventCommand : CommandBase
    {
        private readonly AddEventViewModel _addEventViewModel;
        private readonly Registrator _registrator;
        private readonly NavigationService _eventViewNavigationService;

        public AddEventCommand(AddEventViewModel addEventViewModel, 
            Registrator registrator,
            NavigationService eventViewNavigationService)
        {
            _addEventViewModel = addEventViewModel;
            _registrator = registrator;
            _eventViewNavigationService = eventViewNavigationService;

            _addEventViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }
        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(AddEventViewModel.EventAction))
            {
                OnCanExecuteChanged();
            }
        }
        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_addEventViewModel.EventAction) && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            if (_addEventViewModel.Repeats)
            {
                try
                {
                    //this is a todo event
                    ToDoEvent toDoEvent = new ToDoEvent(_addEventViewModel.EventAction, _addEventViewModel.StartDate, _addEventViewModel.Priority);
                    _registrator.AddEvent(toDoEvent);
                }
                catch (AddEventConflictException ex)
                {
                    //fix this later
                    MessageBox.Show("Same event exists.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else 
            {
                //this is a calendar event
                CalendarEvent calendarEvent = new CalendarEvent(_addEventViewModel.EventAction, _addEventViewModel.StartDate, _addEventViewModel.Priority);
                _registrator.AddEvent(calendarEvent);

            }
            _eventViewNavigationService.Navigate();

        }
    }
}
