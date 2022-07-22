using System;
using System.Collections.Generic;
using sycXF.ViewModels;
using Xamarin.Forms;
using Autofac;

namespace sycXF.Views
{
    public partial class LoadingView : ContentPage
    {
        public LoadingView()
        {
            InitializeComponent();
            BindingContext = App.Container.Resolve<LoadingViewModel>();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await (BindingContext as LoadingViewModel).InitializeAsync(null);
        }
    }
}

