﻿using sycXF.Extensions;
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
        
        // SeasonsCategory filter
        private ObservableCollection<SeasonCategory> _seasonsCategoryCollection;
        public ObservableCollection<SeasonCategory> SeasonsCategoryCollection
        {
            get => _seasonsCategoryCollection;
            set
            {
                if (value == _seasonsCategoryCollection) return;
                _seasonsCategoryCollection = value;
                RaisePropertyChanged(() => SeasonsCategoryCollection);
            }
        }
        private SeasonCategory _selectedSeason;
        public SeasonCategory SelectedSeason
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

        public ICommand SeasonsCategorySelectedCommand
        {
            get
            {
                return new Command( () =>
                {
                    if (SelectedSeason == null)
                        return;

                    var filteredItems = source.Where(closetitem => closetitem.SeasonCategoryName == SelectedSeason.SeasonCategoryName).ToList();
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

                        SelectedSeason = null;
                    }
                });
            }
        }

        // ApparelCategory filter

        private ObservableCollection<ApparelCategory> _apparelCategoryCollection;
        public ObservableCollection<ApparelCategory> ApparelCategoryCollection
        {
            get => _apparelCategoryCollection;
            set
            {
                if (value == _apparelCategoryCollection) return;
                _apparelCategoryCollection = value;
                RaisePropertyChanged(() => ApparelCategoryCollection);
            }
        }
        private ApparelCategory _selectedApparelCategory;
        public ApparelCategory SelectedApparelCategory
        {
            get
            {
                return _selectedApparelCategory;
            }
            set
            {
                if (_selectedApparelCategory != value)
                {
                    _selectedApparelCategory = value;
                }
            }
        }

        public ICommand ApparelCategorySelectedCommand
        {
            get
            {
                return new Command(() =>
                {
                    if (SelectedApparelCategory == null)
                        return;

                    var filteredItems = source.Where(closetitem => closetitem.ApparelCategoryName == SelectedApparelCategory.ApparelCategoryName).ToList();
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

                        SelectedApparelCategory = null;
                    }
                });
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

        public ICommand FilterCommand => new Command<SeasonCategory>(FilterItems);
        public ICommand FilterTypeCommand => new Command<Type>(FilterTypeItems);
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

            SeasonsCategoryCollection = await _myClosetService.GetSeasonCategoriesAsync();
            ApparelCategoryCollection = await _myClosetService.GetApparelCategoriesAsync();


            //ClosetItems = await _myClosetService.GetMyClosetAsync();

            //foreach (var item in ClosetItems)
            //    Console.WriteLine("closetitem" + item.Name + " " + item.SeasonCategoryName);

            foreach (var item in SeasonsCategoryCollection)
                Console.WriteLine("season " + item.SeasonCategoryName);

            foreach (var item in ApparelCategoryCollection)
                Console.WriteLine("closetitem" + item.ApparelCategoryName);

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
                SizeCategoryId = 2,
                SizeCategoryName = "Small",
                SeasonCategoryId = 2,
                SeasonCategoryName = "Spring",
                ApparelCategoryId = 3,
                ApparelCategoryName = "Top"
            });

            source.Add(new MyClosetItem
            {
                Id = 2,
                PictureUri = "fake_product_02.png",
                Name = "Floral skirt",
                Description = "a;lsdkfj;alskdfj;alskdjf;alskdjf;aslkdjf",
                SizeCategoryId = 2,
                SizeCategoryName = "Small",
                SeasonCategoryId = 3,
                SeasonCategoryName = "Summer",
                ApparelCategoryId = 4,
                ApparelCategoryName = "Bottom"
            });

            source.Add(new MyClosetItem
            {
                Id = 3,
                PictureUri = "fake_product_03.png",
                Name = "Black tea-length dress",
                Description = "a;lsdkfj;alskdfj;alskdjf;alskdjf;aslkdjf",
                SizeCategoryId = 3,
                SizeCategoryName = "Medium",
                SeasonCategoryId = 1,
                SeasonCategoryName = "Winter",
                ApparelCategoryId = 5,
                ApparelCategoryName = "Dress"
            });

            source.Add(new MyClosetItem
            {
                Id = 4,
                PictureUri = "fake_product_04.png",
                Name = "London Fog rain coat",
                Description = "a;lsdkfj;alskdfj;alskdjf;alskdjf;aslkdjf",
                SizeCategoryId = 4,
                SizeCategoryName = "Large",
                SeasonCategoryId = 5,
                SeasonCategoryName = "Always in Season",
                ApparelCategoryId = 6,
                ApparelCategoryName = "Outerwear"
            });

            source.Add(new MyClosetItem
            {
                Id = 5,
                PictureUri = "fake_product_05.png",
                Name = "Black leather boots",
                Description = "a;lsdkfj;alskdfj;alskdjf;alskdjf;aslkdjf",
                SizeCategoryId = 2,
                SizeCategoryName = "Small",
                SeasonCategoryName = "Winter",
                ApparelCategoryId = 7,
                ApparelCategoryName = "Footwear"
            });

            source.Add(new MyClosetItem
            {
                Id = 6,
                PictureUri = "fake_product_01.png",
                Name = "White button-down blouse",
                Description = "a;lsdkfj;alskdfj;alskdjf;alskdjf;aslkdjf",
                SizeCategoryId = 3,
                SizeCategoryName = "Medium",
                SeasonCategoryName = "Spring",
                ApparelCategoryId = 3,
                ApparelCategoryName = "Top"
            });

            source.Add(new MyClosetItem
            {
                Id = 7,
                PictureUri = "fake_product_02.png",
                Name = "White jean skirt",
                Description = "a;lsdkfj;alskdfj;alskdjf;alskdjf;aslkdjf",
                SizeCategoryId = 4,
                SizeCategoryName = "Large",
                SeasonCategoryId = 3,
                SeasonCategoryName = "Summer",
                ApparelCategoryId = 4,
                ApparelCategoryName = "Bottom"
            });

            source.Add(new MyClosetItem
            {
                Id = 8,
                PictureUri = "fake_product_03.png",
                Name = "Flannel long-sleeved dress",
                Description = "a;lsdkfj;alskdfj;alskdjf;alskdjf;aslkdjf",
                SizeCategoryId = 2,
                SizeCategoryName = "Small",
                SeasonCategoryId = 4,
                SeasonCategoryName = "Fall",
                ApparelCategoryId = 5,
                ApparelCategoryName = "Dress"
            });

            source.Add(new MyClosetItem
            {
                Id = 9,
                PictureUri = "fake_product_04.png",
                Name = "White Sweater",
                Description = "a;lsdkfj;alskdfj;alskdjf;alskdjf;aslkdjf",
                SizeCategoryId = 3,
                SizeCategoryName = "Medium",
                SeasonCategoryId = 5,
                SeasonCategoryName = "Always in Season",
                ApparelCategoryId = 6,
                ApparelCategoryName = "Outerwear"
            });

            source.Add(new MyClosetItem
            {
                Id = 10,
                PictureUri = "fake_product_05.png",
                Name = "Pearl Necklace",
                Description = "a;lsdkfj;alskdfj;alskdjf;alskdjf;aslkdjf",
                SizeCategoryId = 3,
                SizeCategoryName = "Medium",
                SeasonCategoryId = 1,
                SeasonCategoryName = "Winter",
                ApparelCategoryId = 8,
                ApparelCategoryName = "Accessory"
            });

            source.Add(new MyClosetItem
            {
                Id = 11,
                PictureUri = "fake_product_05.png",
                Name = "Purse",
                Description = "a;lsdkfj;alskdfj;alskdjf;alskdjf;aslkdjf",
                SizeCategoryId = 4,
                SizeCategoryName = "Large",
                SeasonCategoryId = 2,
                SeasonCategoryName = "Spring",
                ApparelCategoryId = 8,
                ApparelCategoryName = "Accessory"
            });

            source.Add(new MyClosetItem
            {
                Id = 12,
                PictureUri = "fake_product_05.png",
                Name = "Jeans",
                Description = "a;lsdkfj;alskdfj;alskdjf;alskdjf;aslkdjf",
                SizeCategoryId = 2,
                SizeCategoryName = "Small",
                SeasonCategoryId = 1,
                SeasonCategoryName = "Winter",
                ApparelCategoryId = 4,
                ApparelCategoryName = "Bottom"
            });

            ClosetItems = new ObservableCollection<MyClosetItem>(source);
        }

        




        //void FilterItems(Season filter)
        void FilterItems(SeasonCategory filter)
        {

            //foreach (var item in ClosetItems)
            //    Console.WriteLine("before filtering" + item.Name + " " + item.Season);

            //SelectedSeason = filter;
            var filteredItems = source.Where(closetitem => closetitem.SeasonCategoryName == SelectedSeason.SeasonCategoryName).ToList();
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
                Console.WriteLine("filtered item by season" + item.Name + " " + item.SeasonCategoryName);
        }

        
        void FilterTypeItems(Type filter)
        {

            //foreach (var item in ClosetItems)
            //    Console.WriteLine("before filtering" + item.Name + " " + item.Season);

            //SelectedSeason = filter;
            var filteredItems = source.Where(closetitem => closetitem.ApparelCategoryName == SelectedApparelCategory.ApparelCategoryName).ToList();
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
                Console.WriteLine("filtered item by type" + item.Name + " " + item.ApparelCategoryName);
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