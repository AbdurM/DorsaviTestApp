using DorsaviTestApp.Gateway.Interfaces;
using DorsaviTestApp.Services.Implementations;
using DorsaviTestApp.Services.Interfaces;
using DorsaviTestApp.ViewModels;
using DorsaviTestApp.Views;
using Prism;
using Prism.Ioc;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace DorsaviTestApp
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync(ViewNames.WelcomePage);
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            //Register services here
            containerRegistry.RegisterSingleton<IPersonService, PersonService>();

            //Register gateways here
            containerRegistry.RegisterSingleton<IPersonGateway, PersonGateway>();

            //Register Views Here
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
            containerRegistry.RegisterForNavigation<SettingsPage, SettingsPageViewModel>();
        }
    }
}
