using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.OS;
using Plugin.CurrentActivity;
using Xamarin.Forms.Platform.Android;

namespace sycXF.Droid.Activities
{
    [Activity(
        Label = "sycXF",
        Icon = "@drawable/icon",
        Theme = "@style/MainTheme",
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            FormsAppCompatActivity.ToolbarResource = Resource.Layout.Toolbar;
            

            base.OnCreate(bundle);
            CrossCurrentActivity.Current.Init(this, bundle);

            Xamarin.Essentials.Platform.Init (this, bundle);

            

            SupportActionBar.SetDisplayShowHomeEnabled(true); // Show or hide the default home button
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetDisplayShowCustomEnabled(true); // Enable overriding the default toolbar layout
            SupportActionBar.SetDisplayShowTitleEnabled(false);

            global::Xamarin.Forms.Forms.Init(this, bundle);


            LoadApplication(new App());

            Window window = this.Window;
            window.ClearFlags(WindowManagerFlags.TranslucentStatus);
            window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);
            //window.SetStatusBarColor(Droid.Graphics.Color.Rgb(0, 166, 156));
        }

        /// <summary>
        /// FFImageLoading image service preserves in heap memory of the device every image newly downloaded 
        /// from url. In order to avoid application crash, you should reclaim memory in low memory situations.
        /// </summary>
        public override void OnTrimMemory([GeneratedEnum] TrimMemory level)
        {
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
            base.OnTrimMemory(level);
        }

        public override void OnRequestPermissionsResult (int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult (requestCode, permissions, grantResults);

            //Plugin.Permissions.PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult (requestCode, permissions, grantResults);
        }
    }
}

