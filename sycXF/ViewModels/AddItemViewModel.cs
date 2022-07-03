using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public class AddItemViewModel : ViewModelBase
    {
        #region Services
        private IClosetService _myClosetService;
        private IUserService _userService;
        private IDialogService _dialogService;

        #endregion

        #region Properties
        // selected items for saving to db
        private string _selectedApparelType;
        public string SelectedApparelType
        {
            get
            {
                return _selectedApparelType;
            }
            set
            {
                if (_selectedApparelType != value)
                {
                    _selectedApparelType = value;
                }
            }
        }

        private string _selectedSeason;
        public string SelectedSeason
        {
            get
            {
                return _selectedSeason;
            }
            set
            {
                if (_selectedSeason != value)
                {
                    _selectedSeason = value;
                }
            }
        }

        private string _selectedSize;
        public string SelectedSize
        {
            get
            {
                return _selectedSize;
            }
            set
            {
                if (_selectedSize != value)
                {
                    _selectedSize = value;
                }
            }
        }

        //// ApparelCategory
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

        private bool _isVisibleNameDesc;
        public bool IsVisibleNameDesc
        {
            get => _isVisibleNameDesc;
            set
            {
                if (value == _isVisibleNameDesc) return;
                _isVisibleNameDesc = value;
                _headerTextLabel = "Add Name and Description";
                RaisePropertyChanged(() => IsVisibleNameDesc);
            }
        }

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

                IsVisibleCVApparelTypes = true;
                IsVisibleCVSeasons = false;
                RaisePropertyChanged(() => ApparelCategoryCollection);
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


        public ICommand ApparelTypeSelectedCommand
        {
            get
            {
                return new Command(async () =>
                {
                    if (SelectedApparelType == null)
                        return;

                    IsVisibleCVApparelTypes = false;
                    IsVisibleCVSeasons = true;


                    SelectedApparelType = null;
                });
            }
        }

        public ICommand SeasonSelectedCommand
        {
            get
            {
                return new Command(async () =>
                {
                    if (SelectedSeason == null)
                        return;

                    IsVisibleCVApparelTypes = false;
                    IsVisibleCVSeasons = true;


                    SelectedSeason = null;
                });
            }
        }

        #endregion


        public AddItemViewModel()
        {
            this.MultipleInitialization = true;

            _myClosetService = DependencyService.Get<IClosetService>();
            _userService = DependencyService.Get<IUserService>();
            _dialogService = DependencyService.Get<IDialogService>();
            
            //IsVisibleCVApparelTypes = false;

        }


        public override async Task InitializeAsync(IDictionary<string, string> query)
        {
            IsBusy = true;

            ApparelCategoryCollection = await _myClosetService.GetCategoriesAsync("Apparel");
            SeasonCategoryCollection = await _myClosetService.GetCategoriesAsync("Season");
            IsBusy = false;
        }

    }
}
