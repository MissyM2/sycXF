﻿using sycXF.Services.Settings;
using sycXF.Views.Templates;
using sycXF.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace sycXF.ViewModels.Base
{
    public abstract class ViewModelBase : ExtendedBindableObject, IQueryAttributable
    {
        protected readonly IDialogService DialogService;
        protected readonly INavigationService NavigationService;

        private bool _isInitialized;

        public bool IsInitialized
        {
            get => _isInitialized;

            set
            {
                _isInitialized = value;
                OnPropertyChanged(nameof(IsInitialized));
            }
        }

        private bool _multipleInitialization;

        public bool MultipleInitialization
        {
            get => _multipleInitialization;

            set
            {
                _multipleInitialization = value;
                OnPropertyChanged(nameof(MultipleInitialization));
            }
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;

            set
            {
                _isBusy = value;
                OnPropertyChanged(nameof(IsBusy));
            }
        }

        private bool _isNotBusy;
        public bool IsNotBusy
        {
            get => _isNotBusy;

            set
            {
                _isNotBusy = value;
                OnPropertyChanged(nameof(IsNotBusy));
            }
        }

        public ViewModelBase()
        {
            DialogService = ViewModelLocator.Resolve<IDialogService>();
            NavigationService = ViewModelLocator.Resolve<INavigationService>();

            var settingsService = ViewModelLocator.Resolve<ISettingsService>();

        }

        public virtual Task InitializeAsync (IDictionary<string, string> query)
        {
            return Task.FromResult (false);
        }

        public async void ApplyQueryAttributes (IDictionary<string, string> query)
        {
            if(!IsInitialized)
            {
                IsInitialized = true;
                await InitializeAsync (query);
            }
        }
    }
}