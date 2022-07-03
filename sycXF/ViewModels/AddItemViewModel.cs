using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using sycXF.Models.Closet;
using sycXF.Services;
using sycXF.Services.Closet;
using sycXF.Services.Settings;
using sycXF.Services.User;
using sycXF.ViewModels.Base;
using Xamarin.Forms;

namespace sycXF.ViewModels
{
    public class AddItemViewModel :ViewModelBase
    {
        #region Services
        private IClosetService _myClosetService;
        private IUserService _userService;
        private IDialogService _dialogService;

        #endregion

        #region Properties

        //// ApparelCategory
        //private bool _isVisibleCVApparelTypes;
        //public bool IsVisibleCVApparelTypes
        //{
        //    get => _isVisibleCVApparelTypes;
        //    set
        //    {
        //        if (_isVisibleCVApparelTypes != value)
        //        {
        //            _isVisibleCVApparelTypes = value;
        //            RaisePropertyChanged(() => IsVisibleCVApparelTypes);
        //        }
        //    }
        //}

        private string _headerTextLabel;
        public string HeaderTextLabel
        {
            get => _headerTextLabel;
            set
            {
                if (value == _headerTextLabel) return;
                _headerTextLabel = value;
                RaisePropertyChanged(() => HeaderTextLabel);
            }
        }

        private ObservableCollection<ItemCategoryModel> _apparelCategoryCollection;
        public ObservableCollection<ItemCategoryModel> ApparelCategoryCollection
        {
            get => _apparelCategoryCollection;
            set
            {
                if (value == _apparelCategoryCollection) return;
                _apparelCategoryCollection = value;

                HeaderTextLabel = "Which apparel type are you adding?";
                RaisePropertyChanged(() => ApparelCategoryCollection);
            }
        }

        private ItemCategoryModel _selectedCategory;
        public ItemCategoryModel SelectedCategory
        {
            get
            {
                return _selectedCategory;
            }
            set
            {
                if (_selectedCategory != value)
                {
                    _selectedCategory = value;
                }
            }
        }


        //public ICommand CategorySelectedCommand
        //{
        //    get
        //    {
        //        return new Command(async () =>
        //        {
        //            if (SelectedCategory == null)
        //                return;

        //            var dictionary = new Dictionary<string, string>();
        //            dictionary.Add("QueryType", QueryType);
        //            dictionary.Add("CategoryType", SelectedCategory.CategoryType);
        //            dictionary.Add("CategoryName", SelectedCategory.CategoryName);
        //            dictionary.Add("CategoryTitle", SelectedCategory.CategoryTitle);

        //            await NavigationService.NavigateToAsync("ClosetItems", dictionary);

        //            SelectedCategory = null;
        //        });
        //    }
        //}

        #endregion


        public AddItemViewModel()
        {
            this.MultipleInitialization = true;

            _myClosetService = DependencyService.Get<IClosetService>();
            _userService = DependencyService.Get<IUserService>();
            _dialogService = DependencyService.Get<IDialogService>();

        }


        public override async Task InitializeAsync(IDictionary<string, string> query)
        {
            IsBusy = true;

            ApparelCategoryCollection = await _myClosetService.GetCategoriesAsync("Apparel");

            IsBusy = false;
        }

    }
}
