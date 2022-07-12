using sycXF.Models.User;
using sycXF.Services.Settings;
using sycXF.ViewModels.Base;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using sycXF.Services.Dependency;
using Xamarin.Essentials;
using System.Runtime.CompilerServices;

namespace sycXF.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        private bool _useAzureServices;
        private string _identityEndpoint;
        private string _gatewayShoppingEndpoint;
        private string _gatewayMarketingEndpoint;

        private readonly ISettingsService _settingsService;

        public SettingsViewModel()
        {
            _settingsService = Xamarin.Forms.DependencyService.Get<ISettingsService> ();

            _useAzureServices = !_settingsService.UseMocks;

        }

        public string TitleUseAzureServices
        {
            get => "Use Microservices/Containers from sycXF";
        }

        public string DescriptionUseAzureServices
        {
            get
            {
                return !UseAzureServices
                    ? "Currently using mock services that are simulated objects that mimic the behavior of real services using a controlled approach. Toggle on to configure the use of microserivces/containers."
                        : "When enabling the use of microservices/containers, the app will attempt to use real services deployed as Docker/Kubernetes containers at the specified base endpoint, which will must be reachable through the network.";
            }
        }

        public bool UseAzureServices
        {
            get => _useAzureServices;
            set
            {
                _useAzureServices = value;
                UpdateUseAzureServices();
                RaisePropertyChanged(() => UseAzureServices);
            }
        }


        

        
        public ICommand ToggleMockServicesCommand => new Command(async () => await ToggleMockServicesAsync());

        private async Task ToggleMockServicesAsync()
        {
            ViewModelLocator.UpdateDependencies(!UseAzureServices);
            RaisePropertyChanged(() => TitleUseAzureServices);
            RaisePropertyChanged(() => DescriptionUseAzureServices);

            //TODO: We should re-evaluate this workflow
            if (UseAzureServices)
            {
                //_settingsService.AuthAccessToken = string.Empty;
                //_settingsService.AuthIdToken = string.Empty;
            }
        }

        private void UpdateUseAzureServices()
        {
            // Save use mocks services to local storage
            _settingsService.UseMocks = !_useAzureServices;
        }

       
    }
}