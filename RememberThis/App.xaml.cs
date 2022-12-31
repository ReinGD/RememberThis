using RememberThis.Helpers;
using RememberThis.Models;
using RememberThis.Stores;
using RememberThis.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace RememberThis
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static readonly Registrator _registrator = new Registrator("Remember ReinGD");
        public static readonly NavigationStore _navigationStore = new NavigationStore();
        public App()
        {
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            //load from JSON file
            List<GDEvent> allEvents = GDReadHelper.GetEvents("Resources/RememberThese.json");

            foreach (GDEvent item in allEvents)
            {
                if (item.eventType == GDEvent.EventType.Calendar)
                {
                    CalendarEvent addMe = new CalendarEvent(item.eventAction, item.startDate, (int)item.priority);
                    _registrator.AddEvent(addMe);
                }
                else
                {
                    ToDoEvent addMe = new ToDoEvent(item.eventAction, item.startDate, (int)item.priority);
                    _registrator.AddEvent(addMe);
                }
            }

            _navigationStore.CurrentViewModel = CreateRememberListingViewModel();

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            //write to JSON file
            GDReadHelper.SaveEvents("Resources/RememberThese.json", _registrator.GetCalendarEvents(), _registrator.GetToDoEvents());

            base.OnExit(e);
        }
        public static RememberListingViewModel CreateRememberListingViewModel()
        {
            return new RememberListingViewModel(_registrator, new Services.NavigationService(_navigationStore, CreateAddEventViewModel));
        }

        private static AddEventViewModel CreateAddEventViewModel()
        {
            return new AddEventViewModel(_registrator, new Services.NavigationService(_navigationStore, CreateRememberListingViewModel));
        }
    }
}
