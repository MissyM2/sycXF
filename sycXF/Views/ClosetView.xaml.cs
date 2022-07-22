using Autofac;
using sycXF.ViewModels;
using Xamarin.Forms;

namespace sycXF.Views
{
    public partial class ClosetView : ContentPage
    {
        public ClosetView()
        {
            InitializeComponent();
            BindingContext = App.Container.Resolve<ClosetViewModel>();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await (BindingContext as ClosetViewModel).InitializeAsync(null);
        }

        void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
        }
    }
}