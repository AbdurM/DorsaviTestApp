using DorsaviTestApp.Services.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DorsaviTestApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        #region fields
        private readonly IPersonService _personService;
        #endregion

        #region constructors
        public MainPageViewModel(INavigationService navigationService, 
            IPersonService personService)
            : base(navigationService)
        {
            Title = "Main Page";
            _personService = personService;

            PreparePageBindings();
             
        }


        #endregion

        #region private methods
        private async void PreparePageBindings()
        {
            var result = await _personService.GetPeople();
        }
        #endregion
    }
}
