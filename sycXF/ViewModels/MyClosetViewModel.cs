using sycXF.Models.Basket;
using sycXF.Models.MyCloset;
using sycXF.Services.Basket;
using sycXF.Services.MyCloset;
using sycXF.Services.Settings;
using sycXF.Services.User;
using sycXF.ViewModels.Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace sycXF.ViewModels
{
    public class MyClosetViewModel : ViewModelBase
    {
        private ObservableCollection<MyClosetItem> _products;
        private MyClosetItem _selectedProduct;
        private ObservableCollection<MyClosetSeason> _seasons;
        private MyClosetSeason _season;
        private ObservableCollection<MyClosetType> _types;
        private MyClosetType _type;
        private int _badgeCount;
        private IMyClosetService _catalogService;
        private IBasketService _basketService;
        private ISettingsService _settingsService;
        private IUserService _userService;

        public MyClosetViewModel()
        {
            this.MultipleInitialization = true;

            _catalogService = DependencyService.Get<IMyClosetService> ();
            _basketService = DependencyService.Get<IBasketService> ();
            _settingsService = DependencyService.Get<ISettingsService> ();
            _userService = DependencyService.Get<IUserService> ();
        }

        public ObservableCollection<MyClosetItem> Products
        {
            get => _products;
            set
            {
                _products = value;
                RaisePropertyChanged(() => Products);
            }
        }

        public MyClosetItem SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                if (value == null)
                    return;
                _selectedProduct = null;
                RaisePropertyChanged(() => SelectedProduct);
            }
        }

        public ObservableCollection<MyClosetSeason> Seasons
        {
            get => _seasons;
            set
            {
                _seasons = value;
                RaisePropertyChanged(() => Seasons);
            }
        }

        public MyClosetSeason Season
        {
            get => _season;
            set
            {
                _season = value;
                RaisePropertyChanged(() => Season);
                RaisePropertyChanged(() => IsFilter);
            }
        }

        public ObservableCollection<MyClosetType> Types
        {
            get => _types;
            set
            {
                _types = value;
                RaisePropertyChanged(() => Types);
            }
        }

        public MyClosetType Type
        {
            get => _type;
            set
            {
                _type = value;
                RaisePropertyChanged(() => Type);
                RaisePropertyChanged(() => IsFilter);
            }
        }

        public bool IsFilter { get { return Season != null || Type != null; } }

        public int BadgeCount
        {
            get => _badgeCount;
            set
            {
                _badgeCount = value;
                RaisePropertyChanged(() => BadgeCount);
            }
        }

        public ICommand AddMyClosetItemCommand => new Command<MyClosetItem>(AddMyClosetItem);

        public ICommand FilterCommand => new Command(async () => await FilterAsync());

		public ICommand ClearFilterCommand => new Command(async () => await ClearFilterAsync());

        public ICommand ViewBasketCommand => new Command (async () => await ViewBasket ());

        public override async Task InitializeAsync (IDictionary<string, string> query)
        {
            IsBusy = true;

            // Get MyCloset, Seasons and Types
            Products = await _catalogService.GetMyClosetAsync ();
            Seasons = await _catalogService.GetMyClosetSeasonAsync ();
            Types = await _catalogService.GetMyClosetTypeAsync ();

            var authToken = _settingsService.AuthAccessToken;
            var userInfo = await _userService.GetUserInfoAsync (authToken);

            var basket = await _basketService.GetBasketAsync (userInfo.UserId, authToken);

            BadgeCount = basket?.Items?.Count () ?? 0;

            IsBusy = false;
        }

        private async void AddMyClosetItem(MyClosetItem catalogItem)
        {
            var authToken = _settingsService.AuthAccessToken;
            var userInfo = await _userService.GetUserInfoAsync (authToken);
            var basket = await _basketService.GetBasketAsync (userInfo.UserId, authToken);
            if(basket != null)
            {
                basket.Items.Add (
                    new BasketItem
                    {
                        ProductId = catalogItem.Id,
                        ProductName = catalogItem.Name,
                        PictureUrl = catalogItem.PictureUri,
                        UnitPrice = catalogItem.Price,
                        Quantity = 1
                    });

                await _basketService.UpdateBasketAsync (basket, authToken);
                BadgeCount = basket.Items.Count ();
            }
        }

        private async Task FilterAsync()
        {
            try
            {    
                IsBusy = true;

                if (Season != null && Type != null)
                {
                    Products = await _catalogService.FilterAsync(Season.Id, Type.Id);
                }
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task ClearFilterAsync()
        {
            IsBusy = true;

            Season = null;
            Type = null;
            Products = await _catalogService.GetMyClosetAsync();

            IsBusy = false;
        }

        private Task ViewBasket()
        {
            return NavigationService.NavigateToAsync ("Basket");
        }
    }
}