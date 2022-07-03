using System;
using System.Collections.Generic;
using sycXF.Services.Settings;
using sycXF.ViewModels.Base;
using sycXF.Views;
using Xamarin.Forms;

namespace sycXF
{
    public partial class AppShell : Shell
    {
        public AppShell ()
        {
            InitializeRouting ();
            InitializeComponent ();

            var settingsService = ViewModelLocator.Resolve<ISettingsService> ();

            if (string.IsNullOrEmpty (settingsService.AuthAccessToken))
            {
                this.GoToAsync ("//Login");
            }
        }

        private void InitializeRouting()
        {
            Routing.RegisterRoute ("Settings", typeof (SettingsView));
            Routing.RegisterRoute("ClosetRoute", typeof(ClosetView));
            Routing.RegisterRoute("ClosetItems", typeof(ClosetItemsView));
            Routing.RegisterRoute("AddItemRoute", typeof(AddItemView));
        }


    }
}
