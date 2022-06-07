using sycXF.Extensions;
using sycXF.Models.MyCloset;
using sycXF.Services;
using sycXF.Services.MyCloset;
using sycXF.Services.Settings;
using sycXF.Services.User;
using sycXF.ViewModels.Base;
using System;
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
        

        private ObservableCollection<Season> _seasonsCollection;
        public ObservableCollection<Season> SeasonsCollection
        {
            get => _seasonsCollection;
            set
            {
                if (value == _seasonsCollection) return;
                _seasonsCollection = value;
                RaisePropertyChanged(() => SeasonsCollection);
            }
        }
        private Season _selectedSeason;
        public Season SelectedSeason
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

        private ObservableCollection<MyClosetItem> _closetItems;
        public ObservableCollection<MyClosetItem> ClosetItems
        {
            get => _closetItems;
            set
            {
                if (value == _closetItems) return;
                _closetItems = value;
                RaisePropertyChanged(() => ClosetItems);
            }
        }

        private MyClosetItem _selectedClosetItem;
        public MyClosetItem SelectedClosetItem
        { 

            get => _selectedClosetItem;
            set
            {
                if (value == _selectedClosetItem) return;
                _selectedClosetItem = value;
                RaisePropertyChanged(() => _selectedClosetItem);
            }
        }


        private ObservableCollection<Object> _selectedClosetItems;
        public ObservableCollection<Object> SelectedClosetItems
        {
            get
            {
                return _selectedClosetItems;
            }
            set
            {
                if (value == _selectedClosetItems) return;
                _selectedClosetItems = value;
                RaisePropertyChanged(() => _selectedClosetItems);
            }
        }

        private string _selectedClosetItemMessage; 
        public string SelectedClosetItemMessage
        {
            get => _selectedClosetItemMessage;
            set
            {
                _selectedClosetItemMessage = value;
                RaisePropertyChanged(() => _selectedClosetItemMessage);
            }
        }

        public IList<MyClosetItem> source;

        int selectionCount = 1;

        public IList<MyClosetItem> EmptyClosetItems { get; private set; }


        #endregion

        public ICommand FilterCommand => new Command<Season>(FilterItems);
        //public ICommand ClosetItemSelectionChangedCommand => new Command(ClosetItemSelectionChanged);

        public MyClosetViewModel()
        {

            this.MultipleInitialization = true;

            _myClosetService = DependencyService.Get<IMyClosetService>();
            _settingsService = DependencyService.Get<ISettingsService>();
            _userService = DependencyService.Get<IUserService>();
            _dialogService = DependencyService.Get<IDialogService>();

            source = new List<MyClosetItem>();
            CreateClosetItemCollection();

            _selectedClosetItem = ClosetItems.FirstOrDefault();
            ClosetItemSelectionChanged();

            SelectedClosetItems = new ObservableCollection<object>()
            {
                ClosetItems[1], ClosetItems[2], ClosetItems[3]
            };
        }

        public override async Task InitializeAsync(IDictionary<string, string> query)
        {
            IsBusy = true;

            SeasonsCollection = await _myClosetService.GetSeasonAsync();
            

            //ClosetItems = await _myClosetService.GetMyClosetAsync();

            foreach (var item in ClosetItems)
                Console.WriteLine("closetitem" + item.Name + " " + item.Season);

            //source = await _myClosetService.GetMyClosetAsync();
            //ClosetItems = new ObservableCollection<MyClosetItem>(source);

            //SelectedClosetItems = new ObservableCollection<MyClosetItem>(source);
            IsBusy = false;
        }

        void CreateClosetItemCollection()
        {
            source.Add(new MyClosetItem
            {
                Id = 1,
                PictureUri = "fake_product_01.png",
                Name = "Floral cap-sleeved blouse",
                Description = "a;lsdkfj;alskdfj;alskdjf;alskdjf;aslkdjf",
                MyClosetSizeId = 2,
                MyClosetSize = "Small",
                SeasonId = 2,
                Season = "Spring Basics",
                MyClosetTypeId = 3,
                MyClosetType = "Top"
            });

            source.Add(new MyClosetItem
            {
                Id = 2,
                PictureUri = "fake_product_02.png",
                Name = "Floral skirt",
                Description = "a;lsdkfj;alskdfj;alskdjf;alskdjf;aslkdjf",
                MyClosetSizeId = 2,
                MyClosetSize = "Small",
                SeasonId = 3,
                Season = "Summer Basics",
                MyClosetTypeId = 4,
                MyClosetType = "Bottom"
            });

            source.Add(new MyClosetItem
            {
                Id = 3,
                PictureUri = "fake_product_03.png",
                Name = "Black tea-length dress",
                Description = "a;lsdkfj;alskdfj;alskdjf;alskdjf;aslkdjf",
                MyClosetSizeId = 3,
                MyClosetSize = "Medium",
                SeasonId = 1,
                Season = "Winter Basics",
                MyClosetTypeId = 5,
                MyClosetType = "Dress"
            });

            source.Add(new MyClosetItem
            {
                Id = 4,
                PictureUri = "fake_product_04.png",
                Name = "London Fog rain coat",
                Description = "a;lsdkfj;alskdfj;alskdjf;alskdjf;aslkdjf",
                MyClosetSizeId = 4,
                MyClosetSize = "Large",
                SeasonId = 5,
                Season = "Always in Season",
                MyClosetTypeId = 6,
                MyClosetType = "Outerwear"
            });

            source.Add(new MyClosetItem
            {
                Id = 5,
                PictureUri = "fake_product_05.png",
                Name = "Black leather boots",
                Description = "a;lsdkfj;alskdfj;alskdjf;alskdjf;aslkdjf",
                MyClosetSizeId = 2,
                MyClosetSize = "Small",
                Season = "Winter Basics",
                MyClosetTypeId = 7,
                MyClosetType = "Footwear"
            });

            source.Add(new MyClosetItem
            {
                Id = 6,
                PictureUri = "fake_product_01.png",
                Name = "White button-down blouse",
                Description = "a;lsdkfj;alskdfj;alskdjf;alskdjf;aslkdjf",
                MyClosetSizeId = 3,
                MyClosetSize = "Medium",
                Season = "Spring Basics",
                MyClosetTypeId = 3,
                MyClosetType = "Top"
            });

            source.Add(new MyClosetItem
            {
                Id = 7,
                PictureUri = "fake_product_02.png",
                Name = "White jean skirt",
                Description = "a;lsdkfj;alskdfj;alskdjf;alskdjf;aslkdjf",
                MyClosetSizeId = 4,
                MyClosetSize = "Large",
                SeasonId = 3,
                Season = "Summer Basics",
                MyClosetTypeId = 4,
                MyClosetType = "Bottom"
            });

            source.Add(new MyClosetItem
            {
                Id = 8,
                PictureUri = "fake_product_03.png",
                Name = "Flannel long-sleeved dress",
                Description = "a;lsdkfj;alskdfj;alskdjf;alskdjf;aslkdjf",
                MyClosetSizeId = 2,
                MyClosetSize = "Small",
                SeasonId = 4,
                Season = "Fall Basics",
                MyClosetTypeId = 5,
                MyClosetType = "Dress"
            });

            source.Add(new MyClosetItem
            {
                Id = 9,
                PictureUri = "fake_product_04.png",
                Name = "White Sweater",
                Description = "a;lsdkfj;alskdfj;alskdjf;alskdjf;aslkdjf",
                MyClosetSizeId = 3,
                MyClosetSize = "Medium",
                SeasonId = 5,
                Season = "Always in Season",
                MyClosetTypeId = 6,
                MyClosetType = "Outerwear"
            });

            source.Add(new MyClosetItem
            {
                Id = 10,
                PictureUri = "fake_product_05.png",
                Name = "Pearl Necklace",
                Description = "a;lsdkfj;alskdfj;alskdjf;alskdjf;aslkdjf",
                MyClosetSizeId = 3,
                MyClosetSize = "Medium",
                SeasonId = 1,
                Season = "Winter Basics",
                MyClosetTypeId = 8,
                MyClosetType = "Accessory"
            });

            source.Add(new MyClosetItem
            {
                Id = 11,
                PictureUri = "fake_product_05.png",
                Name = "Purse",
                Description = "a;lsdkfj;alskdfj;alskdjf;alskdjf;aslkdjf",
                MyClosetSizeId = 4,
                MyClosetSize = "Large",
                SeasonId = 2,
                Season = "Spring Basics",
                MyClosetTypeId = 8,
                MyClosetType = "Accessory"
            });

            source.Add(new MyClosetItem
            {
                Id = 12,
                PictureUri = "fake_product_05.png",
                Name = "Jeans",
                Description = "a;lsdkfj;alskdfj;alskdjf;alskdjf;aslkdjf",
                MyClosetSizeId = 2,
                MyClosetSize = "Small",
                SeasonId = 1,
                Season = "Winter Basics",
                MyClosetTypeId = 4,
                MyClosetType = "Bottom"
            });

            ClosetItems = new ObservableCollection<MyClosetItem>(source);
        }

        




        void FilterItems(Season filter)
        {

            foreach (var item in ClosetItems)
                Console.WriteLine("before filtering" + item.Name + " " + item.Season);

            SelectedSeason = filter;
            var filteredItems = source.Where(closetitem => closetitem.Season == SelectedSeason.Name).ToList();
            foreach (var closetitem in source)
            {
                if (!filteredItems.Contains(closetitem))
                {
                    ClosetItems.Remove(closetitem);
                }
                else
                {
                    if (!ClosetItems.Contains(closetitem))
                    {
                        ClosetItems.Add(closetitem);
                    }
                }
            }

            foreach (var item in ClosetItems)
                Console.WriteLine("filtered item" + item.Name + " " + item.Season);
        }

        void ClosetItemSelectionChanged()
        {
            _selectedClosetItemMessage = $"Selection {selectionCount}: {SelectedClosetItem.Name}";
            Console.WriteLine("message is " + _selectedClosetItemMessage);
            //OnPropertyChanged("SelectedClosetItemMessage");
            selectionCount++;
        }






    }
}