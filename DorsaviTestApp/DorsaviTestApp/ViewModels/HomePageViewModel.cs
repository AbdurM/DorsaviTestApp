using DorsaviTestApp.Constants;
using DorsaviTestApp.Models;
using DorsaviTestApp.Services.Interfaces;
using DorsaviTestApp.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace DorsaviTestApp.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        #region fields
        private readonly IPersonService _personService;
        #endregion

        #region properties
        public ObservableCollection<Person> PeopleCollection { get; set; }
        #endregion

        #region Commands
        public ICommand SettingsCommand { get; }
        #endregion

        #region Constructors
        public HomePageViewModel(INavigationService navigationService, IPersonService personService) 
            : base(navigationService)
        {
            _personService = personService;
            SettingsCommand = new DelegateCommand(async () => await NavigateToSettingsPageAsync());
            LoadPeople();
        }

        
        #endregion

        #region Methods
        private async void LoadPeople()
        {
            var peopleList = await _personService.GetPeople();
            PeopleCollection = new ObservableCollection<Person>(peopleList);
            RaisePropertyChanged(nameof(PeopleCollection));
        }

        private async Task NavigateToSettingsPageAsync()
        {
            await NavigationService.NavigateAsync(ViewNames.SettingsPage);
        }
        #endregion
    }
}
