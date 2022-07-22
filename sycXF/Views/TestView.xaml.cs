using System;
using System.Collections.Generic;
using Autofac;
using sycXF.ViewModels;
using Xamarin.Forms;

namespace sycXF.Views
{
    public partial class TestView : ContentPage
    {
        public TestView()
        {
            InitializeComponent();
            BindingContext = App.Container.Resolve<TestViewModel>();
        }
    }
}

