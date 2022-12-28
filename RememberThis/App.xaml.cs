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
            //_registrator = new Registrator("Remember ReinGD");
            //_navigationStore = new NavigationStore();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            _navigationStore.CurrentViewModel = CreateRememberListingViewModel();

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
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
