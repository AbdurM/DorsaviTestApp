using DorsaviTestApp.Views;
using Prism.Commands;
using Prism.Navigation;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DorsaviTestApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        #region properties

        public string DeveloperName { get; set; }

        #endregion properties

        #region Commands

        public ICommand BeginCommand { get; }

        #endregion Commands

        #region constructors

        public MainPageViewModel(INavigationService navigationService )
            : base(navigationService)
        {
            BeginCommand = new DelegateCommand(async () => await NavigateToHomePageAsync());

            PreparePageBindings();
        }

        private async Task NavigateToHomePageAsync()
        {
            await NavigationService.NavigateAsync($"{ViewNames.NavigationPage}/{ViewNames.HomePage}");
        }

        #endregion constructors

        #region private methods

        private async void PreparePageBindings()
        {
            DeveloperName = "Abdur Mohammed";
        }

        #endregion private methods
    }
}