using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
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
    public class ClosetViewModel : BaseViewModel
    {
        #region Services
        private IClosetController _closetController;
        private INavigationService _navigationService;
        private IDialogService _dialogService;

        #endregion

        private ObservableCollection<ClosetItemModel> _allItemsCollection;
        public ObservableCollection<ClosetItemModel> AllItemsCollection
        {
            get => _allItemsCollection;
            set { SetProperty(ref _allItemsCollection, value); }
        }

        private ObservableCollection<MainFilterCategoryModel> _mainFilterCategoryCollection;
        public ObservableCollection<MainFilterCategoryModel> MainFilterCategoryCollection
        {
            get => _mainFilterCategoryCollection;
            set { SetProperty(ref _mainFilterCategoryCollection, value); }
        }

        private ObservableCollection<ItemCategoryModel> _seasonCategoryCollection;
        public ObservableCollection<ItemCategoryModel> SeasonCategoryCollection
        {
            get => _seasonCategoryCollection;
            set { SetProperty(ref _seasonCategoryCollection, value); }
        }

        private ObservableCollection<ItemCategoryModel> _categoryCollection;
        public ObservableCollection<ItemCategoryModel> CategoryCollection
        {
            get => _categoryCollection;
            set { SetProperty(ref _categoryCollection, value); }
        }

        private ObservableCollection<ItemCategoryModel> _typeCategoryCollection;
        public ObservableCollection<ItemCategoryModel> TypeCategoryCollection
        {
            get => _typeCategoryCollection;
            set { SetProperty(ref _typeCategoryCollection, value); }
        }

        public ClosetViewModel(INavigationService navigationService,
            IClosetController closetController)
        {

            _navigationService = navigationService;
            _closetController = closetController;
            _dialogService = DependencyService.Get<IDialogService>();

            AllItemsCollection = new ObservableCollection<ClosetItemModel>();
            SeasonCategoryCollection = new ObservableCollection<ItemCategoryModel>();
            MainFilterCategoryCollection = new ObservableCollection<MainFilterCategoryModel>();
            TypeCategoryCollection = new ObservableCollection<ItemCategoryModel>();


        }

        public override async Task InitializeAsync(IDictionary<string, string> query)
        {
            //_queryType = parameter.ToString();
            await GetAllClosetItems();

            ItemCount = AllItemsCollection.Count;

        }


        private async Task GetAllClosetItems()
        {
            IsRefreshing = true;

            AllItemsCollection = await _closetController.GetClosetItems("", "");

            CategoryCollection = await _closetController.GetAllItemCategories();

            var mainFilterCategories = await _closetController.GetAllMainFilterCategories();
            MainFilterCategoryCollection = new ObservableCollection<MainFilterCategoryModel>(mainFilterCategories);

            Console.WriteLine("MainFilterCategoryCollection.Count is " + MainFilterCategoryCollection.Count);
            //SelectedMainFilterCategory = MainFilterCategoryCollection.Skip(SelectedMenu).FirstOrDefault();

            IsRefreshing = false;
        }

        public void FilterClosetCategories(string filter)
        {
            if (string.IsNullOrWhiteSpace(filter))
            {
                if (filter == "Type") TypeCategoryCollection = _typeCategoryCollection;
                if (filter == "Season") SeasonCategoryCollection = _seasonCategoryCollection;
            }
            else
            {
                if (filter == "Type")
                {
                    TypeCategoryCollection = new ObservableCollection<ItemCategoryModel>(_categoryCollection.Where(item => item.CategoryType.Contains(filter)));
                    ItemCount = TypeCategoryCollection.Count;
                }

                if (filter == "Season")
                {
                    SeasonCategoryCollection = new ObservableCollection<ItemCategoryModel>(_categoryCollection.Where(item => item.CategoryType.Contains(filter)));
                    ItemCount = SeasonCategoryCollection.Count;
                }
            }
        }

        #region Commands
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

        public ICommand CategorySelectedCommand
        {
            get
            {
                return new Command(async () =>
                {
                    if (SelectedCategory == null)
                        return;

                    var routeParameters = new Dictionary<string, string>();
                    routeParameters.Add("QueryType", QueryType);
                    routeParameters.Add("CategoryType", SelectedCategory.CategoryType);
                    routeParameters.Add("CategoryName", SelectedCategory.CategoryName);
                    routeParameters.Add("CategoryTitle", SelectedCategory.CategoryTitle);

                    var route = new StringBuilder();

                    if (routeParameters != null)
                    {
                        foreach (var routeParameter in routeParameters)
                        {
                            route.Append($"{routeParameter.Key}={routeParameter.Value}&");
                            Console.WriteLine("What is route after adding new key? " + route);
                        }
                        route.Remove(route.Length - 1, 1);
                    }

                    Console.WriteLine("What is final route? " + route.ToString());

                    await _navigationService.PushAsync<ClosetItemsViewModel>(route.ToString());
                    //await _navigationService.PushAsync<ClosetItemsViewModel>();

                    SelectedCategory = null;
                });
            }
        }

        public ICommand AddItemTapCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await _navigationService.PushAsync<AddItemViewModel>();
                });
            }
        }

        #endregion

        #region Properties

        private bool _isRefreshing;
        public bool IsRefreshing
        {
            get => _isRefreshing;
            set { SetProperty(ref _isRefreshing, value); }
        }

        



        private string _queryType;
        public string QueryType
        {
            get => _queryType;
            set { SetProperty(ref _queryType, value); }
        }

        private int _itemCount;
        public int ItemCount
        {
            get => _itemCount;
            set { SetProperty(ref _itemCount, value); }
        }

        private string _headerTextLabel;
        public string HeaderTextLabel
        {
            get => _headerTextLabel;
            set { SetProperty(ref _headerTextLabel, value); }
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
                    IsVisibleCVTypes = true;
                    if (SelectedMainFilterCategory.PropertyName == "Types")
                    {
                        FilterClosetCategories("Type");
                        QueryType = "ApparelType";
                        IsVisibleCVTypes = true;
                        IsVisibleCVSeasons = false;
                        IsVisibleCVFavorites = false;

                        HeaderTextLabel = "Browse By Apparel Types";
                    }
                    else if (SelectedMainFilterCategory.PropertyName == "Seasons")
                    {
                        QueryType = "Season";

                        FilterClosetCategories("Season");
                        IsVisibleCVTypes = false;
                        IsVisibleCVSeasons = true;
                        IsVisibleCVFavorites = false;

                        HeaderTextLabel = "Browse By Seasons";
                    }
                    else if (SelectedMainFilterCategory.PropertyName == "Favorites")
                    {
                        QueryType = "Favorites";
                        IsVisibleCVTypes = false;
                        IsVisibleCVSeasons = false;
                        IsVisibleCVFavorites = true;

                        HeaderTextLabel = "Browse By Favorites";
                    }
                    else
                    {
                        Console.WriteLine("asdfasdf");
                    }
                }
            }
        }

        private bool _isVisibleCVSeasons;
        public bool IsVisibleCVSeasons
        {
            get => _isVisibleCVSeasons;
            set
            {
                _headerTextLabel = "Browse By Season";
                SetProperty(ref _isVisibleCVSeasons, value); 
            }
        }

        private bool _isVisibleCVTypes;
        public bool IsVisibleCVTypes
        {
            get => _isVisibleCVTypes;
            set { SetProperty(ref _isVisibleCVTypes, value); }
        }

        private bool _isVisibleCVFavorites;
        public bool IsVisibleCVFavorites
        {
            get => _isVisibleCVFavorites;
            set { SetProperty(ref _isVisibleCVFavorites, value); }
        }

        private ItemCategoryModel _selectedCategory;
        public ItemCategoryModel SelectedCategory
        {
            get => _selectedCategory;
            set { SetProperty(ref _selectedCategory, value); }
        }

        #endregion
    }
}