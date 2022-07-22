using sycXF.Views.Templates;
using sycXF.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace sycXF.ViewModels.Base
{
    public abstract class BaseViewModel : ExtendedBindableObject
    {
        public virtual Task InitializeAsync(IDictionary<string, string> query)
        {
            //return Task.CompletedTask;
            return Task.FromResult(false);
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                if (SetProperty(ref _isBusy, value))
                {
                    IsNotBusy = !_isBusy;
                }
            }
        }

        private bool _isNotBusy = true;
        public bool IsNotBusy
        {
            get => _isNotBusy;
            set
            {
                if (SetProperty(ref _isNotBusy, value))
                {
                    IsBusy = !_isNotBusy;
                }
            }
        }
    }
}