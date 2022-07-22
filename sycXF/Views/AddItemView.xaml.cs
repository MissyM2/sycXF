using System;
using System.Collections.Generic;
using Autofac;
using sycXF.ViewModels;
using Xamarin.Forms;

namespace sycXF.Views
{
    public partial class AddItemView : ContentPage
    {
        public AddItemView()
        {
            InitializeComponent();
            BindingContext = App.Container.Resolve<AddItemViewModel>();
        }

        //protected override async void OnAppearing()
        //{
        //    base.OnAppearing();
        //    await (BindingContext as AddItemViewModel).InitializeAsync(string.Empty);
        //}
    }
}

