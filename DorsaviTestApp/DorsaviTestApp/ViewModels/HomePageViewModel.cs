using DorsaviTestApp.Services.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DorsaviTestApp.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        #region fields
        private readonly IPersonService _personService;
        #endregion
        #region properties
        #endregion

        #region Constructors
        public HomePageViewModel(INavigationService navigationService, IPersonService personService) 
            : base(navigationService)
        {

            _personService = personService;
            PreparePageBindings();
        }
        #endregion

        #region Methods
        private async void PreparePageBindings()
        {
            var result = await _personService.GetPeople();
        }
        #endregion
    }
}
