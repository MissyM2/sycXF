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
using sycXF.Validations;
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
        private ISettingsService _settingsService;

        #endregion

        #region Properties

        private bool _isMock;
        public bool IsMock
        {
            get => _isMock;
            set
            {
                _isMock = value;
                RaisePropertyChanged(() => IsMock);
            }
        }

        private bool _isValid;
        public bool IsValid
        {
            get => _isValid;
            set
            {
                _isValid = value;
                RaisePropertyChanged(() => IsValid);
            }
        }

        private string _itemName;
        public string ItemName
        {
            get => _itemName;
            set
            {
                _itemName = value;
                RaisePropertyChanged(() => ItemName);
            }
        }

        private string _itemDesc;
        public string ItemDesc
        {
            get => _itemDesc;
            set
            {
                _itemDesc = value;
                RaisePropertyChanged(() => ItemDesc);
            }
        }


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

                    //SelectedSize = null;
                });
            }
        }

        public ICommand NavToAddPictureCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var dictionary = new Dictionary<string, string>();
                    dictionary.Add("ApparelType", SelectedApparelType.CategoryName);
                    dictionary.Add("Season", SelectedSeason.CategoryName);
                    dictionary.Add("Size", SelectedSize.CategoryName);
                    dictionary.Add("Name", ItemName);
                    dictionary.Add("Description", ItemDesc);

                    foreach (KeyValuePair<string, string> kvp in dictionary)
                    {
                        Console.WriteLine("Key={0}, Value = {1}", kvp.Key, kvp.Value);
                    }
                    await NavigationService.NavigateToAsync("AddPhotoRoute", dictionary);
                });
            }
        }




        #endregion


        public AddItemViewModel()
        {
            this.MultipleInitialization = true;

            _settingsService = DependencyService.Get<ISettingsService>();
            _myClosetService = DependencyService.Get<IClosetService>();
            _userService = DependencyService.Get<IUserService>();
            _dialogService = DependencyService.Get<IDialogService>();

            //InvalidateMock();
            //AddValidations();
        }


        public override async Task InitializeAsync(IDictionary<string, string> query)
        {
            IsBusy = true;

            ApparelCategoryCollection = await _myClosetService.GetCategoriesAsync("Apparel");
            SeasonCategoryCollection = await _myClosetService.GetCategoriesAsync("Season");
            SizeCategoryCollection = await _myClosetService.GetCategoriesAsync("Size");

            IsBusy = false;
        }

        //private bool Validate()
        //{
        //    //bool isValidItemName = ValidateItemName();
        //    //bool isValidItemDesc= ValidateItemDesc();
        //    bool isValidItemName = true;
        //    bool isValidItemDesc= true;


        //    return isValidItemName && isValidItemDesc;
        //}

        //private bool ValidateItemName()
        //{
        //    return _itemName.Validate();
        //}

        //private bool ValidateItemDesc()
        //{
        //    return _itemDesc.Validate();
        //}

        //private void AddValidations()
        //{
        //    _itemName.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "An item name is required." });
        //    _itemDesc.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "A description is required." });
        //}

        //public void InvalidateMock()
        //{
        //    IsMock = _settingsService.UseMocks;
        //}

    }
}
