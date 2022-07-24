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
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace sycXF.ViewModels
{
    public class ClosetViewModel : BaseViewModel
    {
        //#region Services
        //private IClosetController _closetController;
        //private INavigationService _navigationService;
        //private IDialogService _dialogService;

        //#endregion

        //private ObservableCollection<ClosetItemModel> _allItemsCollection;
        //public ObservableCollection<ClosetItemModel> AllItemsCollection
        //{
        //    get => _allItemsCollection;
        //    set { SetProperty(ref _allItemsCollection, value); }
        //}

        //private ObservableCollection<Grouping<string,ClosetItemModel>> _allItemsCollectionGrouped;
        //public ObservableCollection<Grouping<string, ClosetItemModel>> AllItemsCollectionGrouped
        //{
        //    get => _allItemsCollectionGrouped;
        //    set { SetProperty(ref _allItemsCollectionGrouped, value); }
        //}

        //private ObservableCollection<MainFilterCategoryModel> _mainFilterCategoryCollection;
        //public ObservableCollection<MainFilterCategoryModel> MainFilterCategoryCollection
        //{
        //    get => _mainFilterCategoryCollection;
        //    set { SetProperty(ref _mainFilterCategoryCollection, value); }
        //}

        //private ObservableCollection<ItemCategoryModel> _categoryCollection;
        //public ObservableCollection<ItemCategoryModel> CategoryCollection
        //{
        //    get => _categoryCollection;
        //    set { SetProperty(ref _categoryCollection, value); }
        //}

        //private ObservableCollection<ItemCategoryModel> _categoryFilteredCollection;
        //public ObservableCollection<ItemCategoryModel> CategoryFilteredCollection
        //{
        //    get => _categoryFilteredCollection;
        //    set { SetProperty(ref _categoryFilteredCollection, value); }
        //}

        //private ItemCategoryModel _selectedCategory;
        //public ItemCategoryModel SelectedCategory
        //{
        //    get => _selectedCategory;
        //    set { SetProperty(ref _selectedCategory, value); }
        //}


        //private MainFilterCategoryModel _selectedMainFilterCategory;
        //public MainFilterCategoryModel SelectedMainFilterCategory
        //{
        //    get
        //    {
        //        return _selectedMainFilterCategory;
        //    }
        //    set
        //    {
        //        if (_selectedMainFilterCategory != value)
        //        {
        //            _selectedMainFilterCategory = value;
        //            if (SelectedMainFilterCategory.PropertyName == "Types")
        //            {
        //                //CategoryFilteredCollection = new ObservableCollection<ItemCategoryModel>(_categoryCollection.Where(item => item.CategoryType.Contains("Type")));


        //                var sorted = from closetitem in AllItemsCollection
        //                             orderby closetitem.Name
        //                             group closetitem by closetitem.Type into closetitemGroup
        //                             select new Grouping<string, ClosetItemModel>(closetitemGroup.Key, closetitemGroup);

        //                AllItemsCollectionGrouped = new ObservableCollection<Grouping<string, ClosetItemModel>>(sorted);
        //                QueryType = "Type";
        //                HeaderTextLabel = "Browse By Type";
        //            }
        //            else if (SelectedMainFilterCategory.PropertyName == "Seasons")
        //            {
        //                //CategoryFilteredCollection = new ObservableCollection<ItemCategoryModel>(_categoryCollection.Where(item => item.CategoryType.Contains("Season")));
        //                var sorted = from closetitem in AllItemsCollection
        //                             orderby closetitem.Name
        //                             group closetitem by closetitem.Season into closetitemGroup
        //                             select new Grouping<string, ClosetItemModel>(closetitemGroup.Key, closetitemGroup);

        //                AllItemsCollectionGrouped = new ObservableCollection<Grouping<string, ClosetItemModel>>(sorted);

        //                QueryType = "Season";
        //                HeaderTextLabel = "Browse By Seasons";
        //            }
        //            else
        //            {
        //                Console.WriteLine("asdfasdf");
        //            }
        //        }
        //        ItemCount = CategoryFilteredCollection.Count;
        //    }
        //}

        public ClosetViewModel(INavigationService navigationService,
            IClosetController closetController)
        {

            //_navigationService = navigationService;
            //_closetController = closetController;
            //_dialogService = DependencyService.Get<IDialogService>();

            //AllItemsCollection = new ObservableCollection<ClosetItemModel>();
            //AllItemsCollectionGrouped = new ObservableCollection<Grouping<string, ClosetItemModel>>();
            //MainFilterCategoryCollection = new ObservableCollection<MainFilterCategoryModel>();


        }

        //public override async Task InitializeAsync(IDictionary<string, string> query)
        //{
        //    await GetAllClosetItems();
        //}


        //private async Task GetAllClosetItems()
        //{
        //    IsRefreshing = true;

        //    AllItemsCollection = await _closetController.GetAllClosetItems();

           
        //    ItemCount = AllItemsCollection.Count;
        //    CategoryCollection = await _closetController.GetAllItemCategories();
        //    var mainFilterCategories = await _closetController.GetAllMainFilterCategories();
        //    MainFilterCategoryCollection = new ObservableCollection<MainFilterCategoryModel>(mainFilterCategories);

        //    IsRefreshing = false;
        //}

        //async Task Refresh()
        //{
        //    IsBusy = true;
        //    await Task.Delay(2000);
        //    IsBusy = false;
        //}

        //public int ClosetItemCount => AllItemsCollection?.Count ?? 0;

        //void Clear()
        //{
        //    AllItemsCollection.Clear();
        //    AllItemsCollectionGrouped.Clear();
        //}

        //#region Commands
        //public ICommand MainFilterCategorySelectedCommand
        //{
        //    get
        //    {
        //        return new Command(() =>
        //        {
        //            if (SelectedMainFilterCategory == null)
        //                return;

        //        });
        //    }
        //}

        //public ICommand CategorySelectedCommand
        //{
        //    get
        //    {
        //        return new Command(async () =>
        //        {
        //            if (SelectedCategory == null)
        //                return;

        //            Console.WriteLine("SelectedCategory " + SelectedCategory);

        //            var routeParameters = new Dictionary<string, string>();
        //            routeParameters.Add("QueryType", QueryType);
        //            routeParameters.Add("CategoryType", SelectedCategory.CategoryType);
        //            routeParameters.Add("CategoryName", SelectedCategory.CategoryName);
        //            //routeParameters.Add("CategoryTitle", SelectedCategory.CategoryTitle);

        //            var route = new StringBuilder();

        //            if (routeParameters != null)
        //            {
        //                foreach (var routeParameter in routeParameters)
        //                {
        //                    route.Append($"{routeParameter.Key}={routeParameter.Value}&");
        //                    Console.WriteLine("What is route after adding new key? " + route);
        //                }
        //                route.Remove(route.Length - 1, 1);
        //            }

        //            Console.WriteLine("What is final route? " + route.ToString());

        //            await _navigationService.PushAsync<ClosetItemsViewModel>(route.ToString());


        //            //SelectedCategory = null;
        //        });
        //    }
        //}

        //public ICommand AddItemTapCommand
        //{
        //    get
        //    {
        //        return new Command(async () =>
        //        {
        //            await _navigationService.PushAsync<AddItemViewModel>();
        //        });
        //    }
    //    }

    //    #endregion

    //    #region Properties

    //    private bool _isRefreshing;
    //    public bool IsRefreshing
    //    {
    //        get => _isRefreshing;
    //        set { SetProperty(ref _isRefreshing, value); }
    //    }

    //    private string _queryType;
    //    public string QueryType
    //    {
    //        get => _queryType;
    //        set { SetProperty(ref _queryType, value); }
    //    }

    //    private int _itemCount = 10;
    //    public int ItemCount
    //    {
    //        get => _itemCount;
    //        set { SetProperty(ref _itemCount, value); }
    //    }

    //    private string _headerTextLabel;
    //    public string HeaderTextLabel
    //    {
    //        get => _headerTextLabel;
    //        set { SetProperty(ref _headerTextLabel, value); }
    //    }

        

    //    #endregion
    }
}