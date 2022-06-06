using System;
using sycXF.ViewModels.Base;

namespace sycXF.ViewModels
{
	public class MyClosetItemViewModel: ViewModelBase
    {
        public int Id { get; }

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                RaisePropertyChanged(() => Name);
            }
        }

        private string _description;
        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                RaisePropertyChanged(() => Description);
            }
        }

        private string _pictureUri;
        public string PictureUri
        {
            get => _pictureUri;
            set
            {
                _pictureUri = value;
                RaisePropertyChanged(() => PictureUri);
            }
        }

        private int _myClosetSizeId;
        public int MyClosetSizeId
        {
            get => _myClosetSizeId;
            set
            {
                _myClosetSizeId = value;
                RaisePropertyChanged(() => MyClosetSizeId);
            }
        }

        private string _myClosetSize;
        public string MyClosetSize
        {
            get => _myClosetSize;
            set
            {
                _myClosetSize = value;
                RaisePropertyChanged(() => MyClosetSize);
            }
        }

        private int _seasonId;
        public int SeasonId
        {
            get => _seasonId;
            set
            {
                _seasonId = value;
                RaisePropertyChanged(() => SeasonId);
            }
        }

        private string _season;
        public string Season
        {
            get => _season;
            set
            {
                _season = value;
                RaisePropertyChanged(() => Season);
            }
        }

        private int _myClosetTypeId;
        public int MyClosetTypeId
        {
            get => _myClosetTypeId;
            set
            {
                _myClosetTypeId = value;
                RaisePropertyChanged(() => MyClosetTypeId);
            }
        }

        private string _myClosetType;
        public string MyClosetType
        {
            get => _myClosetType;
            set
            {
                _myClosetType = value;
                RaisePropertyChanged(() => MyClosetType);
            }
        }

        private bool _justAdded = true;
        public bool JustAdded
        {
            get => _justAdded;
            set 
            {
                _justAdded = value;
                RaisePropertyChanged(() => JustAdded);
            }
        }


        public MyClosetItemViewModel(int id)
        {
            Id = id;
        }
    }
}

