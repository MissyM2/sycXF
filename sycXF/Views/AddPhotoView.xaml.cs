using System;
using System.Collections.Generic;
using Autofac;
using sycXF.ViewModels;
using Xamarin.Forms;

namespace sycXF.Views
{
    public partial class AddPhotoView : ContentPage
    {
        public AddPhotoView()
        {
            InitializeComponent();
            BindingContext = App.Container.Resolve<AddPhotoViewModel>();
        }
    }
}

