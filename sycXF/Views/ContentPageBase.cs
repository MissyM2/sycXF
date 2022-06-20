using System;
using sycXF.ViewModels.Base;
using Microsoft.Maui
using Microsoft.Maui.Controls;

namespace sycXF.Views
{
    public abstract class ContentPageBase : ContentPage
    {
        public ContentPageBase()
        {
            NavigationPage.SetBackButtonTitle (this, string.Empty);
        }

        protected override async void OnAppearing ()
        {
            base.OnAppearing ();

            if (BindingContext is ViewModelBase vmb)
            {
                if (!vmb.IsInitialized || vmb.MultipleInitialization)
                {
                    await vmb.InitializeAsync (null);
                }
            }
        }
    }
}
