using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using sycXF.Models;
using sycXF.Services.Navigation;
using sycXF.ViewModels.Base;
using Xamarin.Forms;

namespace sycXF.ViewModels
{
    public class OnboardingViewModel : BaseViewModel
    {
        private INavigationService _navigationService;

        public OnboardingViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public ObservableCollection<OnboardingItemModel> OnboardingSteps { get; set; } = new ObservableCollection<OnboardingItemModel>
        {
            new OnboardingItemModel("welcome.png",
                "Welcome to Shop Your Closet",
                "Manage all your wardrobe items! It's simple and easy!"),
            new OnboardingItemModel("nice.png",
                "Nice and Tidy Closet",
                "Keep Tops, Bottoms, Outerwear, and many other wardrobe types."),
            new OnboardingItemModel("security.png",
                "Your Safety is Our Top Priority",
                "Our top-notch security features will keep you completely safe."),
            new OnboardingItemModel("","","")
        };

        public ICommand SkipCommand { get => new Command(async () => await FinishOnboarding()); }

        private async Task FinishOnboarding()
        {
            await _navigationService.InsertAsRoot<LoginViewModel>();
        }
    }
}

