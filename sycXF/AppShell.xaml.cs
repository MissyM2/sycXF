using System;
using System.Collections.Generic;
using Autofac;
using sycXF.ViewModels.Base;
using sycXF.Views;
using Xamarin.Forms;

namespace sycXF
{
    public partial class AppShell : Shell
    {
        public Dictionary<string, Type> Routes { get; private set; } = new Dictionary<string, Type>();

        public AppShell ()
        {
            InitializeComponent ();
            
            BindingContext = App.Container.Resolve<AppShellViewModel>();
            RegisterRoutes();
        }

        private void RegisterRoutes()
        {
            Routes.Add("ClosetItemsViewModel", typeof(ClosetItemsView));
            Routes.Add("TestViewModel", typeof(TestView));
            Routes.Add("AddItemViewModel", typeof(AddItemView));
            Routes.Add("AddPhotoViewModel", typeof(AddPhotoView));

            foreach (var item in Routes)
            {
                Routing.RegisterRoute(item.Key, item.Value);
            }
        }


    }
}
