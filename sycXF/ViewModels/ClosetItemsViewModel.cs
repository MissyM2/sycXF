using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using sycXF.Controllers;
using sycXF.Models.Closet;
using sycXF.Services;
using sycXF.Services.Navigation;
using sycXF.ViewModels.Base;
using Xamarin.Forms;

namespace sycXF.ViewModels
{
	public class ClosetItemsViewModel: BaseViewModel
    {

        #region Services
        private IClosetController _closetController;
        private INavigationService _navigationService;
        private IDialogService _dialogService;

        #endregion

        private string _headerTextLabel;
        public string HeaderTextLabel
        {
            get => _headerTextLabel;
            set
            {
                SetProperty(ref _headerTextLabel, value);
                _headerTextLabel = value;
            }
        }

        // Closet Items
        private ObservableCollection<ClosetItemModel> _myClosetItemCollection;
        public ObservableCollection<ClosetItemModel> ClosetItemCollection
        {
            get => _myClosetItemCollection;
            set { SetProperty(ref _myClosetItemCollection, value); }
        }

        private string _queryType;
        public string QueryType
        {
            get => _queryType;
            set { SetProperty(ref _queryType, value); }
        }

        private string _categoryType;
        public string CategoryType
        {
            get => _categoryType;
            set { SetProperty(ref _categoryType, value); }
        }

        private string _categoryName;
        public string CategoryName
        {
            get => _categoryName;
            set { SetProperty(ref _categoryName, value); }
        }

        private string _categoryTitle;
        public string CategoryTitle
        {
            get => _categoryTitle;
            set { SetProperty(ref _categoryTitle, value); }
        }

        private int _itemCount;
        public int ItemCount
        {
            get => _itemCount;
            set { SetProperty(ref _itemCount, value); }
        }

        public ClosetItemsViewModel(INavigationService navigationService,
            IClosetController closetController)
        {
            _navigationService = navigationService;
            _closetController = closetController;

        }

        public override async Task InitializeAsync(IDictionary<string, string> query)
        {
            IsBusy = true;

            //foreach (KeyValuePair<string, string> kvp in query)
            //{
            //    if (kvp.Key == "QueryType")
            //        _queryType = kvp.Value;
            //    else if (kvp.Key == "CategoryType")
            //        _categoryType = kvp.Value;
            //    else if (kvp.Key == "CategoryName")
            //        _categoryName = kvp.Value;
            //    else if (kvp.Key == "CategoryTitle")
            //        _categoryTitle = kvp.Value;
            //}


            //ClosetItemCollection = await _closetItemService.GetClosetItemsAsync(QueryType, CategoryName);
            //ItemCount = ClosetItemCollection.Count;

            IsBusy = false;
        }
    }
}

