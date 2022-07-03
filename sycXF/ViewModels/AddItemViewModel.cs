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
        

        // IsVisible properties
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

        private bool _isVisibleCVSizes;
        public bool IsVisibleCVSizes
        {
            get => _isVisibleCVSizes;
            set
            {
                if (_isVisibleCVSizes != value)
                {
                    _isVisibleCVSizes = value;
                    RaisePropertyChanged(() => IsVisibleCVSizes);
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

        // Collections
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
                IsVisibleCVSizes = false;
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

        private ObservableCollection<ItemCategoryModel> _sizeCategoryCollection;
        public ObservableCollection<ItemCategoryModel> SizeCategoryCollection
        {
            get => _sizeCategoryCollection;
            set
            {
                if (value == _sizeCategoryCollection) return;
                _sizeCategoryCollection = value;

                RaisePropertyChanged(() => SizeCategoryCollection);
            }
        }


        // selections and associated commands
        private ItemCategoryModel _selectedApparelType;
        public ItemCategoryModel SelectedApparelType
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
                    IsVisibleCVSizes = false;
                    IsVisibleNameDesc = false;

                    SelectedApparelType = null;
                });
            }
        }

        private ItemCategoryModel _selectedSeason;
        public ItemCategoryModel SelectedSeason
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

        public ICommand SeasonSelectedCommand
        {
            get
            {
                return new Command(async () =>
                {
                    if (SelectedSeason == null)
                        return;
                    IsVisibleCVApparelTypes = false;
                    IsVisibleCVSeasons = false;
                    IsVisibleCVSizes = true;
                    IsVisibleNameDesc = false;

                    SelectedSeason = null;
                });
            }
        }


        private ItemCategoryModel _selectedSize;
        public ItemCategoryModel SelectedSize
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

        public ICommand SizeSelectedCommand
        {
            get
            {
                return new Command(async () =>
                {
                    if (SelectedSize == null)
                        return;
                    IsVisibleCVApparelTypes = false;
                    IsVisibleCVSeasons = false;
                    IsVisibleCVSizes = false;
                    IsVisibleNameDesc = true;


                    SelectedSize = null;
                });
            }
        }

        public ICommand NavToAddPictureCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await NavigationService.NavigateToAsync("AddPhotoRoute");
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
            SizeCategoryCollection = await _myClosetService.GetCategoriesAsync("Size");

            IsBusy = false;
        }

    }
}
