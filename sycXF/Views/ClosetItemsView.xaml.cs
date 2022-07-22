using System;
using System.Collections.Generic;
using Autofac;
using sycXF.ViewModels;
using Xamarin.Forms;

namespace sycXF.Views
{	
	public partial class ClosetItemsView : ContentPage
	{	
		public ClosetItemsView ()
		{
			InitializeComponent ();
			BindingContext = App.Container.Resolve<ClosetItemsViewModel>();
		}
	}
}

