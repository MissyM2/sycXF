using System;
using System.Threading.Tasks;
using System.Windows.Input;
using sycXF.Services.Navigation;
using sycXF.ViewModels;
using sycXF.ViewModels.Base;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace sycXF
{
    public class AppShellViewModel : BaseViewModel
    {
        private INavigationService _navigationService;

        public AppShellViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public ICommand SignOutCommand { get => new Command(async () => await SignOut()); }

        private async Task SignOut()
        {
            Preferences.Remove(Constants.IS_USER_LOGGED_IN);
            _navigationService.GoToLoginFlow();
            await _navigationService.InsertAsRoot<LoginViewModel>();
        }

    }
}

