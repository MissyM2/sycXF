using sycXF.Services.Closet;
using sycXF.Services.Dependency;
using sycXF.Services.Settings;
using sycXF.Services.User;
using sycXF.Services;
using System;
using System.Globalization;
using System.Reflection;
using Xamarin.Forms;

namespace sycXF.ViewModels.Base
{
    public static class ViewModelLocator
    {
        public static readonly BindableProperty AutoWireViewModelProperty =
            BindableProperty.CreateAttached("AutoWireViewModel", typeof(bool), typeof(ViewModelLocator), default(bool), propertyChanged: OnAutoWireViewModelChanged);

        public static bool GetAutoWireViewModel(BindableObject bindable)
        {
            return (bool)bindable.GetValue(ViewModelLocator.AutoWireViewModelProperty);
        }

        public static void SetAutoWireViewModel(BindableObject bindable, bool value)
        {
            bindable.SetValue(ViewModelLocator.AutoWireViewModelProperty, value);
        }

        public static bool UseMockService { get; set; }

        static ViewModelLocator()
        {
            // Services - by default, TinyIoC will register interface registrations as singletons.
            var settingsService = new SettingsService();
            Xamarin.Forms.DependencyService.RegisterSingleton<ISettingsService>(settingsService);
            Xamarin.Forms.DependencyService.RegisterSingleton<INavigationService>(new NavigationService(settingsService));
            Xamarin.Forms.DependencyService.RegisterSingleton<IDialogService>(new DialogService());
            Xamarin.Forms.DependencyService.RegisterSingleton<IDependencyService>(new Services.Dependency.DependencyService());
            Xamarin.Forms.DependencyService.RegisterSingleton<IClosetService>(new ClosetMockService());
            Xamarin.Forms.DependencyService.RegisterSingleton<IUserService>(new UserMockService());

            // View models - by default, TinyIoC will register concrete classes as multi-instance.
            Xamarin.Forms.DependencyService.Register<ClosetViewModel>();
            Xamarin.Forms.DependencyService.Register<ClosetItemsViewModel>();
            Xamarin.Forms.DependencyService.Register<LoginViewModel>();
            Xamarin.Forms.DependencyService.Register<MainViewModel>();
            Xamarin.Forms.DependencyService.Register<SettingsViewModel>();
            Xamarin.Forms.DependencyService.Register<AddItemViewModel>();
            Xamarin.Forms.DependencyService.Register<AddPhotoViewModel>();
        }

        public static void UpdateDependencies(bool useMockServices)
        {
            // Change injected dependencies
            if (useMockServices)
            {
                Xamarin.Forms.DependencyService.RegisterSingleton<IClosetService>(new ClosetMockService());
                Xamarin.Forms.DependencyService.RegisterSingleton<IUserService>(new UserMockService());

                UseMockService = true;
            }
            else
            {
                Xamarin.Forms.DependencyService.RegisterSingleton<IClosetService>(new ClosetService());

                // use the user mock service until i figure out how to use something else
                Xamarin.Forms.DependencyService.RegisterSingleton<IUserService>(new UserMockService());

                UseMockService = false;
            }
        }

        public static T Resolve<T>() where T : class
        {
            return Xamarin.Forms.DependencyService.Get<T>();
        }

        private static void OnAutoWireViewModelChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as Element;
            if (view == null)
            {
                return;
            }

            var viewType = view.GetType();
            var viewName = viewType.FullName.Replace(".Views.", ".ViewModels.");
            var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
            var viewModelName = string.Format(CultureInfo.InvariantCulture, "{0}Model, {1}", viewName, viewAssemblyName);

            var viewModelType = Type.GetType(viewModelName);
            if (viewModelType == null)
            {
                return;
            }

            var viewModel = Activator.CreateInstance(viewModelType);

            view.BindingContext = viewModel;
        }
    }
}
