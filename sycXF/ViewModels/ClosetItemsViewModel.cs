using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using sycXF.Models.Closet;
using sycXF.Services;
using sycXF.Services.Closet;
using sycXF.Services.Settings;
using sycXF.Services.User;
using sycXF.ViewModels.Base;
using Xamarin.Forms;

namespace sycXF.ViewModels
{
	public class ClosetItemsViewModel: ViewModelBase
    {

        #region Services
        private IClosetService _myClosetService;
        private IUserService _userService;
        private IDialogService _dialogService;

        #endregion

        // Closet Items
        private ObservableCollection<ClosetItemModel> _myClosetItemCollection;
        public ObservableCollection<ClosetItemModel> ClosetItemCollection
        {
            get => _myClosetItemCollection;
            set
            {
                if (value == _myClosetItemCollection) return;
                _myClosetItemCollection = value;
                RaisePropertyChanged(() => ClosetItemCollection);
            }
        }

        private string _queryType;
        public string QueryType
        {
            get => _queryType;
            set
            {
                if (value == _queryType) return;
                _queryType = value;
                RaisePropertyChanged(() => QueryType);


            }
        }

        private string _categoryType;
        public string CategoryType
        {
            get => _categoryType;
            set
            {
                if (value == _categoryType) return;
                _categoryType = value;
                RaisePropertyChanged(() => CategoryType);


            }
        }
        private string _categoryName;
        public string CategoryName
        {
            get => _categoryName;
            set
            {
                if (value == _categoryName) return;
                _categoryName = value;
                RaisePropertyChanged(() => CategoryName);


            }
        }

        private string _categoryTitle;
        public string CategoryTitle
        {
            get => _categoryTitle;
            set
            {
                if (value == _categoryTitle) return;
                _categoryTitle = value;
                RaisePropertyChanged(() => CategoryTitle);


            }
        }

        private int _itemCount;
        public int ItemCount
        {
            get => _itemCount;
            set
            {
                if (value == _itemCount) return;
                _itemCount = value;
                RaisePropertyChanged(() => ItemCount);


            }
        }

        public ClosetItemsViewModel()
        {
            _myClosetService = DependencyService.Get<IClosetService>();

        }

        public override async Task InitializeAsync(IDictionary<string, string> query)
        {
            IsBusy = true;

            foreach (KeyValuePair<string, string> kvp in query)
            {
                if (kvp.Key == "QueryType")
                    _queryType = kvp.Value;
                else if (kvp.Key == "CategoryType")
                    _categoryType = kvp.Value;
                else if (kvp.Key == "CategoryName")
                    _categoryName = kvp.Value;
                else if (kvp.Key == "CategoryTitle")
                    _categoryTitle = kvp.Value;
            }


            ClosetItemCollection = await _myClosetService.GetClosetItemsAsync(QueryType, CategoryName);
            ItemCount = ClosetItemCollection.Count;

            IsBusy = false;
        }
    }
}

