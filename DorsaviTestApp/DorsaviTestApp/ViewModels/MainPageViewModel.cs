using DorsaviTestApp.Services.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DorsaviTestApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        #region fields
        private readonly IPersonService _personService;
        #endregion

        #region properties
        public string DeveloperName { get; set; }
        #endregion


        #region Commands
        public ICommand BeginCommand { get; }
        #endregion

        #region constructors
        public MainPageViewModel(INavigationService navigationService, 
            IPersonService personService)
            : base(navigationService)
        {
            Title = "Main Page";

            _personService = personService;
            BeginCommand = new DelegateCommand(async()=> await NavigateToHomePageAsync());

            PreparePageBindings();
             
        }

        private async Task NavigateToHomePageAsync()
        {
            await NavigationService.NavigateAsync("HomePage");
        }


        #endregion

        #region private methods
        private async void PreparePageBindings()
        {
            DeveloperName = "Abdur Mohammed";
            var result = await _personService.GetPeople();
        }
        #endregion
    }
}
