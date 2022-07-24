using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using sycXF.Controllers;
using sycXF.Models.Closet;
using sycXF.Services;
using sycXF.Services.Navigation;
using sycXF.ViewModels.Base;
using Xamarin.Forms;

namespace sycXF.ViewModels
{
    [QueryProperty("QueryType", "QueryType")]
    [QueryProperty("CategoryType", "CategoryType")]
    [QueryProperty("CategoryName", "CategoryName")]
    [QueryProperty("CategoryTitle", "SelectedCategory.CategoryTitle")]
    public class ClosetItemsViewModel: BaseViewModel
    {

        #region Services
        private IClosetController _closetController;
        private INavigationService _navigationService;
        private IDialogService _dialogService;

        #endregion

        #region Properties

        const int RefreshDuration = 2;
        int itemNumber = 1;

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

        private bool _isRefreshing;
        public bool IsRefreshing
        {
            get => _isRefreshing;
            set { SetProperty(ref _isRefreshing, value); }
        }

        #endregion

        public ICommand RefreshCommand => new Command(async () => await RefreshItemsAsync());

        public ClosetItemsViewModel(INavigationService navigationService,
            IClosetController closetController)
        {
            _navigationService = navigationService;
            _closetController = closetController;

        }

        public override async Task InitializeAsync(IDictionary<string, string> query)
        {
            //IsRefreshing = true;

            //ClosetItemCollection = await _closetController.GetClosetItems(QueryType, CategoryName);
            //ItemCount = ClosetItemCollection.Count;

            //IsRefreshing = false;

            //RefreshClosetItemCollection(query);
        }

        async Task RefreshItemsAsync()
        {
            IsRefreshing = true;
            await Task.Delay(TimeSpan.FromSeconds(RefreshDuration));
            //RefreshClosetItemCollection();
            IsRefreshing = false;
        }

        //private void RefreshClosetItemCollection()
        //{
        //    IsRefreshing = true;

        //    ClosetItemCollection = await _closetController.GetClosetItems(QueryType, CategoryName);
        //    ItemCount = ClosetItemCollection.Count;

        //    IsRefreshing = false;
        //}
    }
}

