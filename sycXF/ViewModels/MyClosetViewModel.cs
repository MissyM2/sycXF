using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using sycXF.Models.MyCloset;
using sycXF.Services;
using sycXF.Services.MyCloset;
using sycXF.Services.Settings;
using sycXF.Services.User;
using sycXF.ViewModels.Base;
using Xamarin.Forms;

namespace sycXF.ViewModels
{
    public class MyClosetViewModel : ViewModelBase
    {
        #region Services
        private IMyClosetService _myClosetService;
        private ISettingsService _settingsService;
        private IUserService _userService;
        private IDialogService _dialogService;

        #endregion

        #region Properties

        private ObservableCollection<MyClosetItem> _allItemsCollection;
        public ObservableCollection<MyClosetItem> AllItemsCollection
        {
            get => _allItemsCollection;
            set
            {
                if (value == _allItemsCollection) return;
                _allItemsCollection = value;
                RaisePropertyChanged(() => AllItemsCollection);
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
                        IsVisibleCVApparelTypes = true;
                        IsVisibleCVSeasons = false;
                        IsVisibleCVFavorites = false;
                    }
                    else if (SelectedMainFilterCategory.PropertyName == "Seasons")
                    {
                        IsVisibleCVApparelTypes = false;
                        IsVisibleCVSeasons = true;
                        IsVisibleCVFavorites = false;
                    }
                    else if (SelectedMainFilterCategory.PropertyName == "Favorites")
                    {
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

        
        private ObservableCollection<ItemCategory> _seasonCategoryCollection;
        public ObservableCollection<ItemCategory> SeasonCategoryCollection
        {
            get => _seasonCategoryCollection;
            set
            {
                if (value == _seasonCategoryCollection) return;
                _seasonCategoryCollection = value;
                RaisePropertyChanged(() => SeasonCategoryCollection);
            }
        }

        private ItemCategory _selectedSeasonCategory;
        public ItemCategory SelectedSeasonCategory
        {
            get
            {
                return _selectedSeasonCategory;
            }
            set
            {
                if (_selectedSeasonCategory != value)
                {
                    _selectedSeasonCategory = value;
                }
            }
        }

        public ICommand SeasonCategorySelectedCommand
        {
            get
            {
                return new Command(async () =>
                {
                    if (SelectedSeasonCategory == null)
                        return;

                    var dictionary = new Dictionary<string, string>();
                    dictionary.Add("SeasonCategoryName", SelectedSeasonCategory.CategoryName);
                    await NavigationService.NavigateToAsync("ClosetItemsSeasons", dictionary);
                    SelectedSeasonCategory = null;

                });
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

        private ObservableCollection<ItemCategory> _apparelCategoryCollection;
        public ObservableCollection<ItemCategory> ApparelCategoryCollection
        {
            get => _apparelCategoryCollection;
            set
            {
                if (value == _apparelCategoryCollection) return;
                _apparelCategoryCollection = value;
                RaisePropertyChanged(() => ApparelCategoryCollection);
            }
        }

        private ItemCategory _selectedApparelCategory;
        public ItemCategory SelectedApparelCategory
        {
            get
            {
                return _selectedApparelCategory;
            }
            set
            {
                if (_selectedApparelCategory != value)
                {
                    _selectedApparelCategory = value;
                }
            }
        }


        public ICommand ApparelCategorySelectedCommand
        {
            get
            {
                return new Command(async () =>
                {
                    if (SelectedApparelCategory == null)
                        return;

                    var dictionary = new Dictionary<string, string>();
                    dictionary.Add("ApparelCategoryName", SelectedApparelCategory.CategoryName);
                    dictionary.Add("ApparelCategoryTitle", SelectedApparelCategory.CategoryTitle);

                    await NavigationService.NavigateToAsync("ClosetItems", dictionary);

                    SelectedApparelCategory = null;
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


        public MyClosetViewModel()
        {

            this.MultipleInitialization = true;

            _myClosetService = DependencyService.Get<IMyClosetService>();
            _settingsService = DependencyService.Get<ISettingsService>();
            _userService = DependencyService.Get<IUserService>();
            _dialogService = DependencyService.Get<IDialogService>();

        }


        public override async Task InitializeAsync(IDictionary<string, string> query)
        {
            IsBusy = true;

            AllItemsCollection = await _myClosetService.GetMyClosetAsync();

            ItemCount = AllItemsCollection.Count;

            ApparelCategoryCollection = await _myClosetService.GetCategoriesAsync("Apparel");
            
            MainFilterCategoryCollection = await _myClosetService.GetMainFilterCategoriesAsync();
            
            SeasonCategoryCollection = await _myClosetService.GetCategoriesAsync("Season");

            //SelectedMainFilterCategory = MainFilterCategoryCollection.Skip(SelectedMenu).FirstOrDefault();



            IsBusy = false;
        }

    }
}