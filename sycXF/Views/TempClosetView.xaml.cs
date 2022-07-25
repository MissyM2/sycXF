using Autofac;
using sycXF.ViewModels;
using Xamarin.Forms;

namespace sycXF.Views
{
    public partial class TempClosetView : ContentPage
    {
        public TempClosetView()
        {
            InitializeComponent();
            BindingContext = App.Container.Resolve<TempClosetViewModel>();
        }
    }
}


