using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using sycXF.Services.Navigation;
using sycXF.Settings;
using sycXF.ViewModels.Base;

namespace sycXF.ViewModels
{
    public class LoadingViewModel : BaseViewModel
    {
        private INavigationService _navigationService;
        private IUserPreferences _userPreferences;

        public LoadingViewModel(INavigationService navigationService, IUserPreferences userPreferences)
        {
            _navigationService = navigationService;
            _userPreferences = userPreferences;
        }

        public override Task InitializeAsync(IDictionary<string, string> query)
        {
            if (!_userPreferences.ContainsKey(Constants.SHOWN_ONBOARDING))
            {
                //_userPreferences.Set(Constants.SHOWN_ONBOARDING, true);
                _userPreferences.Set(Constants.SHOWN_ONBOARDING, false);
                _navigationService.GoToLoginFlow();
                _navigationService.InsertAsRoot<OnboardingViewModel>();
                return Task.CompletedTask;
            }

            if (_userPreferences.ContainsKey(Constants.IS_USER_LOGGED_IN) && _userPreferences.Get(Constants.IS_USER_LOGGED_IN, false))
            {
                //_navigationService.GoToMainFlow();
                _navigationService.GoToLoginFlow();
                _navigationService.InsertAsRoot<OnboardingViewModel>();
                return Task.CompletedTask;
            }

            _navigationService.GoToLoginFlow();
            return _navigationService.InsertAsRoot<OnboardingViewModel>();
        }
    }
}

