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
    internal class RemoveEventCommand : CommandBase
    {
        private readonly ToDoEventViewModel _toDoEventViewModel;
        private readonly Registrator _registrator;
        private readonly NavigationService _eventViewNavigationService;


        public RemoveEventCommand(ToDoEventViewModel toDoEventViewModel,
            Registrator registrator,
            NavigationService eventViewNavigationService)
        {
            _toDoEventViewModel = toDoEventViewModel;
            _registrator = registrator;
            _eventViewNavigationService = eventViewNavigationService;


        }


        public override void Execute(object? parameter)
        {
            ToDoEvent toDoEvent = new ToDoEvent(_toDoEventViewModel.EventAction, DateTime.Now.Date, 0);
            _registrator.RemoveEvent(toDoEvent);
            _eventViewNavigationService.Navigate();

        }
    }
}
