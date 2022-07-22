using System;
using System.Collections.Generic;
using Autofac;
using sycXF.ViewModels;
using Xamarin.Forms;

namespace sycXF.Views
{
    public partial class OnboardingView : ContentPage
    {
        public OnboardingView()
        {
            InitializeComponent();
            BindingContext = App.Container.Resolve<OnboardingViewModel>();
        }
    }
}

