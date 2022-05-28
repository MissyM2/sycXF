using sycXF.Models.MyCloset;
using sycXF.Services;
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
        private MyClosetItem _selectedMyClosetItem;
        private ObservableCollection<MyClosetSeason> _seasons;
        private MyClosetSeason _season;
        private ObservableCollection<MyClosetType> _types;
        private MyClosetType _type;
        private int _badgeCount;
        private IMyClosetService _myClosetService;
        private ISettingsService _settingsService;
        private IUserService _userService;
        private IDialogService _dialogService;

        public MyClosetViewModel()
        {
            this.MultipleInitialization = true;

            _myClosetService = DependencyService.Get<IMyClosetService> ();
            _settingsService = DependencyService.Get<ISettingsService> ();
            _userService = DependencyService.Get<IUserService> ();
            _dialogService = DependencyService.Get<IDialogService>();
        }

        public ObservableCollection<MyClosetItem> MyClosetItems
        {
            get => _products;
            set
            {
                _products = value;
                RaisePropertyChanged(() => MyClosetItems);
            }
        }

        public MyClosetItem SelectedMyClosetItem
        {
            get => _selectedMyClosetItem;
            set
            {
                if (value == null)
                    return;
                _selectedMyClosetItem = null;
                RaisePropertyChanged(() => SelectedMyClosetItem);
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

        public ICommand DeleteCommand => new Command<MyClosetItem>(async (item) => await DeleteMyClosetItemAsync(item));

        private async Task DeleteMyClosetItemAsync(MyClosetItem item)
        {
            await _dialogService.ShowAlertAsync("Delete", "Delete this closet item function", "OK");


            //BasketItems.Remove(item);

            //var authToken = _settingsService.AuthAccessToken;
            //var userInfo = await _userService.GetUserInfoAsync(authToken);
            //var basket = await _basketService.GetBasketAsync(userInfo.UserId, authToken);
            //if (basket != null)
            //{
            //    basket.Items.Remove(item);
            //    await _basketService.UpdateBasketAsync(basket, authToken);
            //    BadgeCount = basket.Items.Count();
            //}

            //await ReCalculateTotalAsync();
        }

        public ICommand FilterCommand => new Command(async () => await FilterAsync());

		public ICommand ClearFilterCommand => new Command(async () => await ClearFilterAsync());

        //public ICommand ViewBasketCommand => new Command (async () => await ViewBasket ());

        public override async Task InitializeAsync (IDictionary<string, string> query)
        {
            IsBusy = true;

            // Get MyCloset, Seasons and Types
            MyClosetItems = await _myClosetService.GetMyClosetAsync ();
            Seasons = await _myClosetService.GetMyClosetSeasonAsync ();
            Types = await _myClosetService.GetMyClosetTypeAsync ();

            var authToken = _settingsService.AuthAccessToken;
            var userInfo = await _userService.GetUserInfoAsync (authToken);

            //BadgeCount = basket?.Items?.Count () ?? 0;

            IsBusy = false;
        }

        private async void AddMyClosetItem(MyClosetItem myClosetItem)
        {
            var authToken = _settingsService.AuthAccessToken;
            var userInfo = await _userService.GetUserInfoAsync (authToken);

            await _dialogService.ShowAlertAsync("Add", "Add a closet item function", "OK");

            //var basket = await _basketService.GetBasketAsync (userInfo.UserId, authToken);
            //if(basket != null)
            //{
            //    basket.Items.Add (
            //        new BasketItem
            //        {
            //            MyClosetItemId = myClosetItem.Id,
            //            MyClosetItemName = myClosetItem.Name,
            //            PictureUrl = myClosetItem.PictureUri,
            //            UnitPrice = myClosetItem.Price,
            //            Quantity = 1
            //        });

            //    await _basketService.UpdateBasketAsync (basket, authToken);
            //BadgeCount = basket.Items.Count ();
            //}
        }

        private async Task FilterAsync()
        {
            try
            {    
                IsBusy = true;

                if (Season != null && Type != null)
                {
                    MyClosetItems = await _myClosetService.FilterAsync(Season.Id, Type.Id);
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
            MyClosetItems = await _myClosetService.GetMyClosetAsync();

            IsBusy = false;
        }

       
    }
}