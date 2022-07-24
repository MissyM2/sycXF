using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using sycXF.ViewModels.Base;

namespace sycXF.Services.Navigation
{
     public interface INavigationService
    {
        Task GoToAsync<TViewModel>(string routePrefix, string parameters) where TViewModel : BaseViewModel;
        Task PushAsync<TViewModel>(string parameters = null) where TViewModel : BaseViewModel;
        Task PopAsync();
        Task InsertAsRoot<TViewModel>(string parameters = null) where TViewModel : BaseViewModel;
        Task GoBackAsync();
        void GoToMainFlow();
        void GoToLoginFlow();
    }
}

