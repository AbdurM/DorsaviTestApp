using DorsaviTestApp.Constants;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;

namespace DorsaviTestApp.ViewModels
{
    public class SettingsPageViewModel : ViewModelBase
    {
        #region Commands
        public ICommand AboutUsCommand { get; }
        #endregion

        #region Constructors
        public SettingsPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            AboutUsCommand = new DelegateCommand(async () => await NavigateToAboutUsWebPage());
        }
        #endregion

        #region Methods

        private async Task NavigateToAboutUsWebPage()
        {
            try
            {
                await Browser.OpenAsync(AppConstants.AboutUsUri, BrowserLaunchMode.SystemPreferred);
            }
            catch (Exception ex)
            {
                //Would use logging to relevant platform(ex raygun) in prod
                Debug.WriteLine(ex.Message);
            }
        }
        #endregion
    }
}
