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
	public class ClosetItemsViewModel: ViewModelBase
    {

        #region Services
        private IMyClosetService _myClosetService;
        private IUserService _userService;
        private IDialogService _dialogService;

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
        private string _apparelName;
        public string ApparelName
        {
            get => _apparelName;
            set
            {
                if (value == _apparelName) return;
                _apparelName = value;
                RaisePropertyChanged(() => ApparelName);


            }
        }

        private string _apparelTitle;
        public string ApparelTitle
        {
            get => _apparelTitle;
            set
            {
                if (value == _apparelTitle) return;
                _apparelName = value;
                RaisePropertyChanged(() => ApparelTitle);


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

        public ClosetItemsViewModel()
        {
            _myClosetService = DependencyService.Get<IMyClosetService>();

        }

        public override async Task InitializeAsync(IDictionary<string, string> query)
        {
            IsBusy = true;

            foreach (KeyValuePair<string, string> kvp in query)
            {
                if(kvp.Key == "ApparelCategoryName")
                    _apparelName = kvp.Value;
                if (kvp.Key == "ApparelCategoryTitle")
                    _apparelTitle = kvp.Value;
            }


            MyClosetItemCollection = await _myClosetService.GetItemsByApparelAsync(ApparelName);
            ItemCount = MyClosetItemCollection.Count;

            IsBusy = false;
        }
    }
}

