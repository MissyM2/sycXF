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


        private ObservableCollection<MyClosetItem> _selectedClosetItems;
        public ObservableCollection<MyClosetItem> SelectedClosetItems
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

        //public ICommand FilterCommand => new Command<Season>(FilterItems);
        //public ICommand ClosetItemSelectionChangedCommand => new Command(ClosetItemSelectionChanged);

        public MyClosetViewModel()
        {

            this.MultipleInitialization = true;

            _myClosetService = DependencyService.Get<IMyClosetService>();
            _settingsService = DependencyService.Get<ISettingsService>();
            _userService = DependencyService.Get<IUserService>();
            _dialogService = DependencyService.Get<IDialogService>();

            

            //source = new List<MyClosetItem>();
        }

       

        public override async Task InitializeAsync(IDictionary<string, string> query)
        {
            IsBusy = true;
            
            SeasonsCollection = await _myClosetService.GetSeasonAsync();
            //ClosetItemSelectionChanged();

            ClosetItems = await _myClosetService.GetMyClosetAsync();

            foreach (var item in ClosetItems)
                Console.WriteLine("closetitem" + item.Name + " " + item.Season);

            //source = await _myClosetService.GetMyClosetAsync();
            //ClosetItems = new ObservableCollection<MyClosetItem>(source);

            //SelectedClosetItems = new ObservableCollection<MyClosetItem>(source);
            IsBusy = false;
        }


        

        //void FilterItems(Season filter)
        //{

            //foreach (var item in SelectedClosetItems)
            //    Console.WriteLine("before filtering" + item.Name + " " + item.Season);

            //SelectedSeason = filter;
            //var filteredItems = source.Where(closetitem => closetitem.Season == SelectedSeason.Name).ToList();
            //foreach (var closetitem in source)
            //{
            //    if (!filteredItems.Contains(closetitem))
            //    {
            //        ClosetItems.Remove(closetitem);
            //    }
            //    else
            //    {
            //        if (!ClosetItems.Contains(closetitem))
            //        {
            //            ClosetItems.Add(closetitem);
            //        }
            //    }
            //}

            //foreach (var item in ClosetItems)
            //    Console.WriteLine("filtered item" + item.Name + " " + item.Season);
        //}

        //void ClosetItemSelectionChanged()
        //{
        //    _selectedClosetItemMessage = $"Selection {selectionCount}: {SelectedClosetItem.Name}";
        //    Console.WriteLine("message is " + _selectedClosetItemMessage);
        //    //OnPropertyChanged("SelectedClosetItemMessage");
        //    selectionCount++;
        //}






    }
}