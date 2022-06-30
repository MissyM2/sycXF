using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using sycXF.Models.MyCloset;
using sycXF.Services;
using sycXF.Services.MyCloset;
using sycXF.Services.Settings;
using sycXF.Services.User;
using sycXF.ViewModels.Base;
using Xamarin.Forms;

namespace sycXF.ViewModels
{
	public class ClosetItemsSeasonsViewModel: ViewModelBase
    {

        #region Services
        private IMyClosetService _myClosetService;
        private IUserService _userService;
        private IDialogService _dialogService;
        private INavigationService _navigationService;

        #endregion

        // Closet Items
        private ObservableCollection<MyClosetItem> _myClosetItemCollection;
        public ObservableCollection<MyClosetItem> MyClosetItemCollection
        {
            get => _myClosetItemCollection;
            set
            {
                if (value == _myClosetItemCollection) return;
                _myClosetItemCollection = value;
                RaisePropertyChanged(() => MyClosetItemCollection);
            }
        }
        private string _seasonName;
        public string SeasonName
        {
            get => _seasonName;
            set
            {
                if (value == _seasonName) return;
                _seasonName = value;
                RaisePropertyChanged(() => SeasonName);


            }
        }

        

        private int _itemCount;
        public int ItemCount
        {
            get => _itemCount;
            set
            {
                if (value == _itemCount) return;
                _itemCount = value;
                RaisePropertyChanged(() => ItemCount);


            }
        }

        public ClosetItemsSeasonsViewModel()
        {
            _myClosetService = DependencyService.Get<IMyClosetService>();

        }

        public override async Task InitializeAsync(IDictionary<string, string> query)
        {
            IsBusy = true;

            foreach (KeyValuePair<string, string> kvp in query)
            {
                if (kvp.Key == "SeasonCategoryName")
                    _seasonName = kvp.Value; 
            }

            MyClosetItemCollection = await _myClosetService.GetItemsBySeasonAsync(SeasonName);
            ItemCount = MyClosetItemCollection.Count;

            IsBusy = false;
        }
    }
}

 