using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using sycXF.Controllers;
using sycXF.Models.Closet;
using sycXF.Services;
using sycXF.Services.Navigation;
using sycXF.Validations;
using sycXF.ViewModels.Base;
using Xamarin.Forms;

namespace sycXF.ViewModels
{
    public class AddItemViewModel : BaseViewModel
    {

        #region Services
        private INavigationService _navigationService;
        private IClosetController _closetController;
        private IDialogService _dialogService;

        #endregion

        public AddItemViewModel(IClosetController closetController,
            INavigationService navigationService)
        {
            _navigationService = navigationService;
            _closetController = closetController;
            //this.MultipleInitialization = true;

            //_settingsService = DependencyService.Get<ISettingsService>();
            //_closetItemService = DependencyService.Get<IClosetItemService>();
            //_mainFilterService = DependencyService.Get<IMainFilterCategoryService>();
            //_itemCategoryService = DependencyService.Get<IItemCategoryService>();
            //_userService = DependencyService.Get<IUserService>();
            //_dialogService = DependencyService.Get<IDialogService>();

            //InvalidateMock();
            //AddValidations();
        }


        public override async Task InitializeAsync(IDictionary<string, string> query)
        {

            await GetApparelCollection();
            await GetSeasonCollection();
            //await GetSizeCollection();
        }

        #region Properties

        private bool _isMock;
        public bool IsMock
        {
            get => _isMock;
            set {SetProperty(ref _isMock, value); }

        }

        private bool _isValid;
        public bool IsValid
        {
            get => _isValid;
            set { SetProperty(ref _isValid, value); }
        }

        private string _itemName;
        public string ItemName
        {
            get => _itemName;
            set { SetProperty(ref _itemName, value); } 
        }

        private string _itemDesc;
        public string ItemDesc
        {
            get => _itemDesc;
            set { SetProperty(ref _itemDesc, value); }
        }


        // IsVisible properties
        private bool _isVisibleCVSeasons;
        public bool IsVisibleCVSeasons
        {
            get => _isVisibleCVSeasons;
            set { SetProperty(ref _isVisibleCVSeasons, value); }
        }

        private bool _isVisibleCVApparelTypes;
        public bool IsVisibleCVApparelTypes
        {
            get => _isVisibleCVApparelTypes;
            set { SetProperty(ref _isVisibleCVApparelTypes, value); }
        }

        private bool _isVisibleCVSizes;
        public bool IsVisibleCVSizes
        {
            get => _isVisibleCVSizes;
            set { SetProperty(ref _isVisibleCVSizes, value); }
        }

        private bool _isVisibleNameDesc;
        public bool IsVisibleNameDesc
        {
            get => _isVisibleNameDesc;
            set
            {
                SetProperty(ref _isVisibleNameDesc, value);
                _headerTextLabel = "Add Name and Description";
            }
        }

        private string _headerTextLabel;
        public string HeaderTextLabel
        {
            get => _headerTextLabel;
            set { SetProperty(ref _headerTextLabel, value); }
        }

        // Collections
        private ObservableCollection<ItemCategoryModel> _apparelCategoryCollection;
        public ObservableCollection<ItemCategoryModel> ApparelCategoryCollection
        {
            get => _apparelCategoryCollection;
            set
            {
                SetProperty(ref _apparelCategoryCollection, value);

                IsVisibleCVApparelTypes = true;
                IsVisibleCVSeasons = false;
                IsVisibleCVSizes = false;
            }
        }

        private ObservableCollection<ItemCategoryModel> _seasonCategoryCollection;
        public ObservableCollection<ItemCategoryModel> SeasonCategoryCollection
        {
            get => _seasonCategoryCollection;
            set { SetProperty(ref _seasonCategoryCollection, value); }
        }

        private ObservableCollection<ItemCategoryModel> _sizeCategoryCollection;
        public ObservableCollection<ItemCategoryModel> SizeCategoryCollection
        {
            get => _sizeCategoryCollection;
            set { SetProperty(ref _sizeCategoryCollection, value); }
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

        #region Commands
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
                    await _navigationService.PushAsync<AddItemViewModel>();
                });
            }
        }

        #endregion

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

        




        #endregion


        

        //private Task GetSizeCollection()
        //{
        //    IsBusy = true;
        //    var items = await _itemCategoryService.GetItemCategoriesAsync("Apparel");
        //    IsBusy = false;
        //}

        private Task GetSeasonCollection()
        {
            throw new NotImplementedException();
        }

        private Task GetApparelCollection()
        {
            throw new NotImplementedException();
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
