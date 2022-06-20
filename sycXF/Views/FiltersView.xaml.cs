using System.Threading.Tasks;
using sycXF.ViewModels;
using Xamarin.CommunityToolkit.UI.Views;
using Microsoft.Maui
using Microsoft.Maui.Controls;

namespace sycXF.Views
{
    public partial class FiltersView : Popup
    {
        public FiltersView()
        {
            InitializeComponent();
        }

        //protected override object GetLightDismissResult ()
        //{
        //    return false;
        //}

        //void OnFilterClicked (System.Object sender, System.EventArgs e)
        //{
        //    if(BindingContext is MyClosetViewModel viewModel)
        //    {
        //        viewModel.FilterCommand.Execute (null);
        //        this.Dismiss (true);
        //    }
        //}
    }
}
