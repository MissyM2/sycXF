using sycXF.Services.Theme;
using sycXF.ViewModels.Base;
using sycXF.Services;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using sycXF.Models.Closet;
using Autofac;
using System.Reflection;
using sycXF.Services.Database;
using sycXF.Models.User;
using sycXF.Views;

namespace sycXF
{
    public partial class App : Application
    {
        public static Autofac.IContainer Container;

        public App()
        {
            InitializeComponent();

            InitApp();

            MainPage = Container.Resolve<LoadingView>();
            //MainPage = new AppShell ();
        }

        private void InitApp()
        {
            
                //class used for registration
                var builder = new ContainerBuilder();
                //scan and register all classes in the assembly
                var dataAccess = Assembly.GetExecutingAssembly();
                builder.RegisterAssemblyTypes(dataAccess)
                       .AsImplementedInterfaces()
                       .AsSelf();
                // Keeping the line below so I can remember that I an use this User instead of transaction
                builder.RegisterType<DataRepository<ClosetItemModel>>().As<IDataRepository<ClosetItemModel>>();
                builder.RegisterType<DataRepository<ItemCategoryModel>>().As<IDataRepository<ItemCategoryModel>>();
                builder.RegisterType<DataRepository<MainFilterCategoryModel>>().As<IDataRepository<MainFilterCategoryModel>>();
                builder.RegisterType<DataRepository<UserInfoModel>>().As<IDataRepository<UserInfoModel>>();
                builder.RegisterType<DataRepository<UserAddressModel>>().As<IDataRepository<UserAddressModel>>();
                
            //get container
            Container = builder.Build();

            Plugin.Media.CrossMedia.Current.Initialize();

        }

       

        //protected override async void OnStart()
        //{
        //    base.OnStart();

        //    OnResume();
        //}

        //protected override void OnSleep()
        //{
        //    SetStatusBar();
        //    RequestedThemeChanged -= App_RequestedThemeChanged;
        //}

        //protected override void OnResume()
        //{
        //    Console.WriteLine("alsdkfj inside onResume");
        //    SetStatusBar();
        //    RequestedThemeChanged += App_RequestedThemeChanged;
        //}

        //private void App_RequestedThemeChanged(object sender, AppThemeChangedEventArgs e)
        //{
        //    MainThread.BeginInvokeOnMainThread(() =>
        //    {
        //        SetStatusBar();
        //    });
        //}

        //void SetStatusBar()
        //{
        //    var nav = Current.MainPage as NavigationPage;

        //    var e = DependencyService.Get<ITheme>();
        //    if (Current.RequestedTheme == OSAppTheme.Dark)
        //    {
        //        e?.SetStatusBarColor(Color.Black, false);
        //        if (nav != null)
        //        {
        //            nav.BarBackgroundColor = Color.Black;
        //            nav.BarTextColor = Color.White;
        //        }
        //    }
        //    else
        //    {
        //        e?.SetStatusBarColor(Color.White, true);
        //        if (nav != null)
        //        {
        //            nav.BarBackgroundColor = Color.White;
        //            nav.BarTextColor = Color.Black;
        //        }
        //    }
        //}

    }
}