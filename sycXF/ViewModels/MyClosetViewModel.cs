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
using Xamarin.CommunityToolkit.ObjectModel;
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

        private ObservableCollection<MyClosetItem> _myClosetItems;
        public ObservableCollection<MyClosetItem> MyClosetItems
        {
            get => _myClosetItems;
            set
            {
                _myClosetItems = value;
                RaisePropertyChanged(() => MyClosetItems);
            }
        }

        private ObservableCollection<Grouping<string, MyClosetItem>> _myClosetItemsGrouped;
        public ObservableCollection<Grouping<string, MyClosetItem>> MyClosetItemsGrouped
        {
            get => _myClosetItemsGrouped;
            set
            {
                _myClosetItemsGrouped = value;
                RaisePropertyChanged(() => MyClosetItemsGrouped);
            }
        }

        private MyClosetItem _selectedMyClosetItem;
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

        private ObservableCollection<MyClosetSeason> _seasons;
        public ObservableCollection<MyClosetSeason> Seasons
        {
            get => _seasons;
            set
            {
                _seasons = value;
                RaisePropertyChanged(() => Seasons);
            }
        }

        private MyClosetSeason _season;
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

        private ObservableCollection<MyClosetType> _types;
        public ObservableCollection<MyClosetType> Types
        {
            get => _types;
            set
            {
                _types = value;
                RaisePropertyChanged(() => Types);
            }
        }

        private MyClosetType _type;
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

        private int _badgeCount;
        public int BadgeCount
        {
            get => _badgeCount;
            set
            {
                _badgeCount = value;
                RaisePropertyChanged(() => BadgeCount);
            }
        }

        public bool IsFilter { get { return Season != null || Type != null; } }

        #endregion

        public MyClosetViewModel()
        {
            this.MultipleInitialization = true;

            _myClosetService = DependencyService.Get<IMyClosetService> ();
            _settingsService = DependencyService.Get<ISettingsService> ();
            _userService = DependencyService.Get<IUserService> ();
            _dialogService = DependencyService.Get<IDialogService>();
        }

        public ICommand MyClosetItemSelectedCommand
        {
            get
            {
                return new Command(async () =>
                {
                    if (SelectedMyClosetItem == null)
                        return;

                    
                    await _dialogService.ShowAlertAsync("Selected", "Item is selected", "OK");
                    
                    SelectedMyClosetItem = null;
                });
            }
        }
        public ICommand AddMyClosetItemCommand => new Command<MyClosetItem>(AddMyClosetItem);

        public ICommand DeleteCommand => new Command<MyClosetItem>(async (item) => await DeleteMyClosetItemAsync(item));

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

            // order the list
            // var OrderedList = MyClosetItems.OrderBy(x => x.MyClosetSeason).ToList();
            //MyClosetItemsGrouped = new ObservableCollection<Grouping<string, MyClosetItem>>(OrderedList);

            var sorted = from myclosetitem in MyClosetItems
                         orderby myclosetitem.MyClosetSeason ascending 
                         group myclosetitem by myclosetitem.MyClosetSeason into myclosetitemGroup
                         select new Grouping<string, MyClosetItem>(myclosetitemGroup.Key, myclosetitemGroup);

            MyClosetItemsGrouped = new ObservableCollection<Grouping<string, MyClosetItem>>(sorted);

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
        }

        private async Task DeleteMyClosetItemAsync(MyClosetItem item)
        {
            await _dialogService.ShowAlertAsync("Delete", "Delete this closet item function", "OK");
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