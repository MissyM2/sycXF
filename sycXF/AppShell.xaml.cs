﻿using System;
using System.Collections.Generic;
using sycXF.Services.Settings;
using sycXF.ViewModels.Base;
using sycXF.Views;
using Microsoft.Maui
using Microsoft.Maui.Controls;

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
            Routing.RegisterRoute("ClosetItemsRoute", typeof(ClosetItemsView));
        }


    }
}
