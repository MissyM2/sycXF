using sycXF.Models.Navigation;
using sycXF.Services.Navigation;
using sycXF.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace sycXF.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private INavigationService _navigationService;

        public ICommand SettingsCommand => new Command(async () => await SettingsAsync());

        public MainViewModel(INavigationService navigationService)
        {

            _navigationService = navigationService;

        }

        private async Task SettingsAsync()
        {
            //await _navigationService.PushAsync<SettingsViewModel>();
            Console.WriteLine("settings async");
        }
    }
}