using Foundation;
using Microsoft.Maui;
using UIKit;

namespace sycXF.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : MauiUIApplicationDele
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
        }
    }
}
