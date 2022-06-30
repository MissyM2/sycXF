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
    public class ClosetViewModel : ViewModelBase
    {
        #region Services
        private IClosetService _myClosetService;
        private ISettingsService _settingsService;
        private IUserService _userService;
        private IDialogService _dialogService;

        #endregion

        #region Properties

        private ObservableCollection<ClosetItemModel> _allItemsCollection;
        public ObservableCollection<ClosetItemModel> AllItemsCollection
        {
            get => _allItemsCollection;
            set
            {
                if (value == _allItemsCollection) return;
                _allItemsCollection = value;
                RaisePropertyChanged(() => AllItemsCollection);
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

        // FilterCategory CV
        private ObservableCollection<MainFilterCategoryModel> _mainFilterCategoryCollection;
        public ObservableCollection<MainFilterCategoryModel> MainFilterCategoryCollection
        {
            get => _mainFilterCategoryCollection;
            set
            {
                if (value == _mainFilterCategoryCollection) return;
                _mainFilterCategoryCollection = value;
                RaisePropertyChanged(() => MainFilterCategoryCollection);
            }
        }
        private MainFilterCategoryModel _selectedMainFilterCategory;
        public MainFilterCategoryModel SelectedMainFilterCategory
        {
            get
            {
                return _selectedMainFilterCategory;
            }
            set
            {
                if (_selectedMainFilterCategory != value)
                {
                    _selectedMainFilterCategory = value;
                    IsVisibleCVApparelTypes = true;
                    if (SelectedMainFilterCategory.PropertyName == "Categories")
                    {
                        QueryType = "ApparelType";
                        IsVisibleCVApparelTypes = true;
                        IsVisibleCVSeasons = false;
                        IsVisibleCVFavorites = false;
                    }
                    else if (SelectedMainFilterCategory.PropertyName == "Seasons")
                    {
                        QueryType = "Season";
                        IsVisibleCVApparelTypes = false;
                        IsVisibleCVSeasons = true;
                        IsVisibleCVFavorites = false;
                    }
                    else if (SelectedMainFilterCategory.PropertyName == "Favorites")
                    {
                        QueryType = "Favorites";
                        IsVisibleCVApparelTypes = false;
                        IsVisibleCVSeasons = false;
                        IsVisibleCVFavorites = true;
                    }
                    else
                    {
                        Console.WriteLine("asdfasdf");
                    }
                }
            }
        }

        public ICommand MainFilterCategorySelectedCommand
        {
            get
            {
                return new Command(() =>
                {
                    if (SelectedMainFilterCategory == null)
                        return;

                });
            }
        }

        // SeasonCategory filter
        private bool _isVisibleCVSeasons;
        public bool IsVisibleCVSeasons
        {
            get => _isVisibleCVSeasons;
            set
            {
                if (value == _isVisibleCVSeasons) return;
                _isVisibleCVSeasons = value;
                RaisePropertyChanged(() => IsVisibleCVSeasons);
            }
        }

        
        private ObservableCollection<ItemCategoryModel> _seasonCategoryCollection;
        public ObservableCollection<ItemCategoryModel> SeasonCategoryCollection
        {
            get => _seasonCategoryCollection;
            set
            {
                if (value == _seasonCategoryCollection) return;
                _seasonCategoryCollection = value;
                RaisePropertyChanged(() => SeasonCategoryCollection);
            }
        }

        

        // ApparelCategory filter
        private bool _isVisibleCVApparelTypes;
        public bool IsVisibleCVApparelTypes
        {
            get => _isVisibleCVApparelTypes;
            set
            {
                if (_isVisibleCVApparelTypes != value)
                {
                    _isVisibleCVApparelTypes = value;
                    RaisePropertyChanged(() => IsVisibleCVApparelTypes);
                }
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


        public ICommand CategorySelectedCommand
        {
            get
            {
                return new Command(async () =>
                {
                    if (SelectedCategory == null)
                        return;

                    var dictionary = new Dictionary<string, string>();
                    dictionary.Add("QueryType", QueryType);
                    dictionary.Add("CategoryType", SelectedCategory.CategoryType);
                    dictionary.Add("CategoryName", SelectedCategory.CategoryName);
                    dictionary.Add("CategoryTitle", SelectedCategory.CategoryTitle);

                    await NavigationService.NavigateToAsync("ClosetItems", dictionary);

                    SelectedCategory = null;
                });
        }
    }

    // Favorites filter

    private bool _isVisibleCVFavorites;
    public bool IsVisibleCVFavorites
    {
        get => _isVisibleCVFavorites;
        set
        {
            if (value == _isVisibleCVFavorites) return;
            _isVisibleCVFavorites = value;
            RaisePropertyChanged(() => IsVisibleCVFavorites);
        }
    }

   
        #endregion


        public ClosetViewModel()
        {

            this.MultipleInitialization = true;

            _myClosetService = DependencyService.Get<IClosetService>();
            _settingsService = DependencyService.Get<ISettingsService>();
            _userService = DependencyService.Get<IUserService>();
            _dialogService = DependencyService.Get<IDialogService>();

        }


        public override async Task InitializeAsync(IDictionary<string, string> query)
        {
            IsBusy = true;

            AllItemsCollection = await _myClosetService.GetClosetAsync();

            ItemCount = AllItemsCollection.Count;

            ApparelCategoryCollection = await _myClosetService.GetCategoriesAsync("Apparel");
            
            MainFilterCategoryCollection = await _myClosetService.GetMainFilterCategoriesAsync();
            
            SeasonCategoryCollection = await _myClosetService.GetCategoriesAsync("Season");

            //SelectedMainFilterCategory = MainFilterCategoryCollection.Skip(SelectedMenu).FirstOrDefault();



            IsBusy = false;
        }

    }
}