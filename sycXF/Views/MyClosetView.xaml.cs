using sycXF.ViewModels;
using sycXF.ViewModels.Base;
using System;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.CommunityToolkit.UI.Views;
using Microsoft.Maui
using Microsoft.Maui.Controls;

namespace sycXF.Views
{
    public partial class MyClosetView : ContentPageBase
    {
        //private FiltersView _filterView = new FiltersView();

        public MyClosetView()
        {
            InitializeComponent();

            //VisualStateManager.GoToState(CVMainFilterCategories, "Selected");
        }

        //protected override void OnBindingContextChanged()
        //{
        //    base.OnBindingContextChanged();

        //    _filterView.BindingContext = BindingContext;
        //}

        //private void OnFilterChanged(object sender, EventArgs e)
        //{
        //    Navigation.ShowPopup (_filterView);
        //}
    }
}