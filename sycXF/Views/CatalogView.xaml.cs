using sycXF.ViewModels;
using sycXF.ViewModels.Base;
using System;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;

namespace sycXF.Views
{
    public partial class CatalogView : ContentPageBase
    {
        private FiltersView _filterView = new FiltersView();

        public CatalogView()
        {
            InitializeComponent();
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            _filterView.BindingContext = BindingContext;
        }

        private void OnFilterChanged(object sender, EventArgs e)
        {
            Navigation.ShowPopup (_filterView);
        }
    }
}