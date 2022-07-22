using System;
using System.Threading.Tasks;
using sycXF.ViewModels.Base;
using Xamarin.Forms;

namespace sycXF.Services.Navigation
{
    public class ShellRoutingService : INavigationService
    {
        public Task PushAsync<TViewModel>(string parameters = null) where TViewModel : BaseViewModel
        {
            return GoToAsync<TViewModel>("", parameters);
        }

        public Task PopAsync()
        {
            return Shell.Current.Navigation.PopAsync();
        }

        public Task InsertAsRoot<TViewModel>(string parameters = null) where TViewModel : BaseViewModel
        {
            return GoToAsync<TViewModel>("//", parameters);
        }

        public Task GoBackAsync()
        {
            return Shell.Current.GoToAsync("..");
        }


        public void GoToMainFlow()
        {
            Application.Current.MainPage = new AppShell();
        }

        public void GoToLoginFlow()
        {
            Application.Current.MainPage = new LoginShell();
        }









        private Task GoToAsync<TViewModel>(string routePrefix, string parameters) where TViewModel : BaseViewModel
        {
            var route = routePrefix + typeof(TViewModel).Name;
            if (!string.IsNullOrWhiteSpace(parameters))
            {
                route += $"?{parameters}";
            }
            return Shell.Current.GoToAsync(route);
        }
    }
}

