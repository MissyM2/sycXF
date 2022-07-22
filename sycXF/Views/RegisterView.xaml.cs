using System;
using System.Collections.Generic;
using Autofac;
using sycXF.ViewModels;
using Xamarin.Forms;

namespace sycXF.Views
{
    public partial class RegisterView : ContentPage
    {
        public RegisterView()
        {
            InitializeComponent();
            BindingContext = App.Container.Resolve<RegisterViewModel>();
        }
    }
}

