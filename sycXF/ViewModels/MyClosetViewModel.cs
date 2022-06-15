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

        // FilterCategory CV
        private ObservableCollection<MainFilterCategoryModel> _mainFilterCategoryCollection;
        public ObservableCollection<MainFilterCategoryModel> MainFilterCategoryCollection
        {
            get => _mainFilterCategoryCollection;
            set
            {
                if (value == _mainFilterCategoryCollection) return;
                _mainFilterCategoryCollection = value;
                RaisePropertyChanged(() => MainFilterCategoryCollection);
            }
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
                }
            }
        }

        public ICommand MainFilterCategorySelectedCommand
        {
            get
            {
                return new Command(() =>
                {
                    if (SelectedMainFilterCategory == null)
                        return;
                    if (SelectedMainFilterCategory.PropertyName == "Categories")
                   // {
                        _isVisibleCVApparelTypes = !_isVisibleCVApparelTypes;
                       // _isVisibleCVSeasons = false;
                    //}
                    //else if (SelectedMainFilterCategory.PropertyName == "Seasons")
                    //{
                    //    _isVisibleCVApparelTypes = false;
                    //    _isVisibleCVSeasons = true;

                    //}
                        

                    //var filteredItems = _source.Where(closetitem => closetitem.SeasonCategoryName == SelectedMainFilterCategory.PropertyName).ToList();
                    //foreach (var closetitem in _source)
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

                    SelectedMainFilterCategory = null;
                   // }
                });
            }
        }



        // SeasonCategory filter

        private bool _isVisibleCVSeasons;
        public bool IsVisibleCVSeasons
        {
            get => _isVisibleCVSeasons;
            set
            {
                if (value == _isVisibleCVSeasons) return;
                _isVisibleCVSeasons = value;
                RaisePropertyChanged(() => IsVisibleCVSeasons);
            }
        }

        private ObservableCollection<SeasonCategory> _seasonCategoryCollection;
        public ObservableCollection<SeasonCategory> SeasonCategoryCollection
        {
            get => _seasonCategoryCollection;
            set
            {
                if (value == _seasonCategoryCollection) return;
                _seasonCategoryCollection = value;
                RaisePropertyChanged(() => SeasonCategoryCollection);
            }
        }
        private SeasonCategory _selectedSeasonCategory;
        public SeasonCategory SelectedSeasonCategory
        {
            get
            {
                return _selectedSeasonCategory;
            }
            set
            {
                if (_selectedSeasonCategory != value)
                {
                    _selectedSeasonCategory = value;
                }
            }
        }

        public ICommand SeasonCategorySelectedCommand
        {
            get
            {
                return new Command(() =>
                {
                    if (SelectedSeasonCategory == null)
                        return;

                   

                    //var filteredItems = _source.Where(closetitem => closetitem.ApparelCategoryName == SelectedApparelCategory.ApparelCategoryName).ToList();
                    //foreach (var closetitem in _source)
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

                    SelectedSeasonCategory = null;
                    //}
                });
            }
        }

        // ApparelCategory filter

        private bool _isVisibleCVApparelTypes;
        public bool IsVisibleCVApparelTypes
        {
            get => _isVisibleCVApparelTypes;
            set
            {
                if (_isVisibleCVApparelTypes != value)
                {
                    _isVisibleCVApparelTypes = value;
                }
            }
        }

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

                  //var filteredItems = _source.Where(closetitem => closetitem.ApparelCategoryName == SelectedApparelCategory.ApparelCategoryName).ToList();
                  //foreach (var closetitem in _source)
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

                  SelectedApparelCategory = null;
                    //}
                });
            }
        }






        #endregion


        public MyClosetViewModel()
        {

            this.MultipleInitialization = true;

            _myClosetService = DependencyService.Get<IMyClosetService>();
            _settingsService = DependencyService.Get<ISettingsService>();
            _userService = DependencyService.Get<IUserService>();
            _dialogService = DependencyService.Get<IDialogService>();

        }

        public override async Task InitializeAsync(IDictionary<string, string> query)
        {
            IsBusy = true;
            
            ApparelCategoryCollection = await _myClosetService.GetApparelCategoriesAsync();
            MainFilterCategoryCollection = await _myClosetService.GetMainFilterCategoriesAsync();
           // _selectedMainFilterCategory = MainFilterCategoryCollection.FirstOrDefault();
            
            

            IsBusy = false;
        }

    }
}