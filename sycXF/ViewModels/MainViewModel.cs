using sycXF.Models.Navigation;
using sycXF.ViewModels.Base;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui
using Microsoft.Maui.Controls;

namespace sycXF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ICommand SettingsCommand => new Command(async () => await SettingsAsync());

        public override Task InitializeAsync(IDictionary<string, string> query)
        {
            IsBusy = true;

            return base.InitializeAsync(query);
        }

        private async Task SettingsAsync()
        {
            await NavigationService.NavigateToAsync("Settings");
        }
    }
}