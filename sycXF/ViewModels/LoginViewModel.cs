using sycXF.Validations;
using sycXF.ViewModels.Base;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using sycXF.Services.Navigation;
using System.Collections.Generic;

namespace sycXF.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private ValidatableObject<string> _userName;
        private ValidatableObject<string> _password;
        private bool _isMock;
        private bool _isValid;
        private bool _isLogin;
        private string _authUrl;

        private INavigationService _navigationService;

        public LoginViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            _userName = new ValidatableObject<string>();
            _password = new ValidatableObject<string>();

            AddValidations();
        }

        public ValidatableObject<string> UserName
        {
            get => _userName;
            set { SetProperty(ref _userName, value); }
        }

        public ValidatableObject<string> Password
        {
            get => _password;
            set { SetProperty(ref _password, value); }
        }

        public bool IsMock
        {
            get => _isMock;
            set { SetProperty(ref _isMock, value); }
        }

        public bool IsValid
        {
            get => _isValid;
            set { SetProperty(ref _isValid, value); }
        }

        public bool IsLogin
        {
            get => _isLogin;
            set { SetProperty(ref _isLogin, value); }
        }

        public string LoginUrl
        {
            get => _authUrl;
            set { SetProperty(ref _authUrl, value); }
        }

        public ICommand MockSignInCommand => new Command(async () => await MockSignInAsync());

        public ICommand SignInCommand => new Command(async () => await SignInAsync());

        public ICommand RegisterCommand => new Command(async () => await RegisterAsync());

        public ICommand NavigateCommand => new Command<string>(async (url) => await NavigateAsync(url));

       // public ICommand SettingsCommand => new Command(async () => await SettingsAsync());

        public ICommand ValidateUserNameCommand => new Command(() => ValidateUserName());

        public ICommand ValidatePasswordCommand => new Command(() => ValidatePassword());

        public override Task InitializeAsync (IDictionary<string, string> query)
        {
            //var logout = query.GetValueAsBool ("Logout");

            //if(logout.ContainsKeyAndValue && logout.Value == true)
            //{
            //    Logout ();
            //}

            return Task.CompletedTask;
        }

        private Task MockSignInAsync()
        {
            IsBusy = true;
            //IsValid = true;
            //bool isValid = Validate();
            //bool isAuthenticated = false;

            //if (isValid)
            //{
            //    try
            //    {
            //        await Task.Delay(10);

            //        isAuthenticated = true;
            //    }
            //    catch (Exception ex)
            //    {
            //        Debug.WriteLine($"[SignIn] Error signing in: {ex}");
            //    }
            //}
            //else
            //{
            //    IsValid = false;
            //}

            //if (isAuthenticated)
            //{
            //    _settingsService.AuthAccessToken = GlobalSetting.Instance.AuthToken;

                 _navigationService.GoToMainFlow();
                 _navigationService.InsertAsRoot<ClosetViewModel>();
            return Task.CompletedTask;
            
            //}

            //IsBusy = false;
        }

        private async Task SignInAsync()
        {
            IsBusy = true;

            await Task.Delay(10);

            //LoginUrl = _identityService.CreateAuthorizationRequest();

            IsValid = true;
            IsLogin = true;
            IsBusy = false;
        }

        private Task RegisterAsync()
        {
            //return _openUrlService.OpenUrl(GlobalSetting.Instance.RegisterWebsite);
            throw new NotImplementedException();
        }

        private void Logout()
        {
            //var authIdToken = _settingsService.AuthIdToken;
            //var logoutRequest = _identityService.CreateLogoutRequest(authIdToken);

            //if (!string.IsNullOrEmpty(logoutRequest))
            //{
                // Logout
                //LoginUrl = logoutRequest;
            //}

            //if (_settingsService.UseMocks)
            //{
                //_settingsService.AuthAccessToken = string.Empty;
                //_settingsService.AuthIdToken = string.Empty;
            //}

        }

        private async Task NavigateAsync(string url)
        {
            throw new NotImplementedException();

            //var unescapedUrl = System.Net.WebUtility.UrlDecode(url);

            //if (unescapedUrl.Equals(GlobalSetting.Instance.LogoutCallback))
            //{
            //_settingsService.AuthAccessToken = string.Empty;
            //_settingsService.AuthIdToken = string.Empty;
            //IsLogin = false;
            //LoginUrl = _identityService.CreateAuthorizationRequest();
            //}
            //else if (unescapedUrl.Contains(GlobalSetting.Instance.Callback))
            //{
            // var authResponse = new AuthorizeResponse(url);
            //if (!string.IsNullOrWhiteSpace(authResponse.Code))
            //{
            //var userToken = await _identityService.GetTokenAsync(authResponse.Code);
            //string accessToken = userToken.AccessToken;

            //if (!string.IsNullOrWhiteSpace(accessToken))
            //{
            //_settingsService.AuthAccessToken = accessToken;
            //_settingsService.AuthIdToken = authResponse.IdentityToken;
            // await NavigationService.NavigateToAsync ("//Main/Closet");
            //}
            //}
            //}
        }

        //private Task SettingsAsync()
        //{
        //    return NavigationService.NavigateToAsync(
        //        "Settings",
        //        new Dictionary<string, string>
        //        {
        //            { "reset", "true" },
        //        });
        //}

        private bool Validate()
        {
            bool isValidUser = ValidateUserName();
            bool isValidPassword = ValidatePassword();

            return isValidUser && isValidPassword;
        }

        private bool ValidateUserName()
        {
            return _userName.Validate();
        }

        private bool ValidatePassword()
        {
            return _password.Validate();
        }

        private void AddValidations()
        {
            _userName.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "A username is required." });
            _password.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "A password is required." });
        }

    }
}