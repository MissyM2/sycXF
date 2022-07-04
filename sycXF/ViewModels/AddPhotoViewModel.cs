using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using sycXF.ViewModels.Base;
using sycXF.Services;
using sycXF.Services.User;
using sycXF.Validations;
using Xamarin.Forms;

using System.IO;

using Xamarin.Essentials;
using System.Collections.Generic;
using System.Linq;

namespace sycXF.ViewModels
{
    public class AddPhotoViewModel : ViewModelBase
    {

        private IDialogService _dialogService;
        private IUserService _userService;

        #region Properties

        private ValidatableObject<string> _itemName;
        public ValidatableObject<string> ItemName
        {
            get => _itemName;
            set
            {
                _itemName = value;
                RaisePropertyChanged();
            }
        }

        private ImageSource _imgSource;
        public ImageSource ImgSource
        {
            get { return _imgSource; }
            set
            {
                _imgSource = value;
                RaisePropertyChanged();
            }
        }

        string photoPath;
        public string PhotoPath
        {
            get => photoPath;
            set
            {
                if (photoPath == value)
                    return;
                photoPath = value;
                RaisePropertyChanged();
            }
        }

        byte[] photoArray;
        public byte[] PhotoArray
        {
            get => photoArray;
            set
            {
                if (photoArray == value)
                    return;
                photoArray = value;
                RaisePropertyChanged();
            }
        }

        //private ImageSource selectedImage = ImageSource.FromResource(ImageManager.SelectedImage, typeof(AddAssetPageModel).GetTypeInfo().Assembly);

        #endregion

        #region Commands

        //public ICommand TakePhotoCommand { get => new Command(async () => await TakePhoto(), () => IsNotBusy); }
        public ICommand PickPhotoCommand { get => new Command(async () => await PickPhoto(), () => IsNotBusy); }
        #endregion

        public AddPhotoViewModel()
        {

            _userService = DependencyService.Get<IUserService>();
            _dialogService = DependencyService.Get<IDialogService>();

            

        }

        public override async Task InitializeAsync(IDictionary<string, string> query)
        {
            IsBusy = true;
            foreach (KeyValuePair<string, string> kvp in query)
            {
                Console.WriteLine("Key={0}, Value = {1}", kvp.Key, kvp.Value);
            }
        }





            //  ***  Photos Methods ***

            private byte[] ConvertStreamtoByte(Stream stream)
        {
            byte[] ImageBytes;
            using (var memoryStream = new System.IO.MemoryStream())
            {
                stream.CopyTo(memoryStream);
                ImageBytes = memoryStream.ToArray();
            }
            return ImageBytes;
        }



        private async Task TakePhoto()
        {
            //await CrossMedia.Current.Initialize();
            Console.WriteLine("AddAssetPageModel:TakePhoto");
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await _dialogService.ShowAlertAsync("No Camera", ":( No camera available.", "OK");
                return;
            }
            //var isPermissionGranted = await RequestCameraAndGalleryPermissions();
            //if (!isPermissionGranted)
            //    return null;
            var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "Test",
                SaveToAlbum = true,
                CompressionQuality = 75,
                CustomPhotoSize = 50,
                PhotoSize = PhotoSize.MaxWidthHeight,
                MaxWidthHeight = 2000,
                DefaultCamera = CameraDevice.Front
            });
            await _dialogService.ShowAlertAsync("File Location", photo.Path, "OK");
            if (photo == null)
                return;
            byte[] imageArray = null;
            using (MemoryStream memory = new MemoryStream())
            {
                Stream stream = photo.GetStream();
                stream.CopyTo(memory);
                imageArray = memory.ToArray();
            }
            PhotoArray = imageArray;


            //await LoadPhotoAsync(file);

            //var imgSource = ImageSource.FromStream(() =>
            //{
            //    var stream = file.GetStream();
            //    file.Dispose();
            //    return stream;
            //});

            //PhotoPath = photo.Path;

        }

        //private async Task LoadPhotoAsync(MediaFile photo)
        //{
        //    // canceled
        //    if (photo == null)
        //    {
        //        PhotoPath = null;
        //        return;
        //    }

        //    var newFile = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
        //    using (var stream = photo.GetStream())
        //    {
        //        using (var newStream = File.OpenWrite(newFile))
        //        {
        //            await stream.CopyToAsync(newStream);
        //        }
        //    }
        //    PhotoPath = newFile;
        //}

        // private async Task<bool> RequestCameraAndGalleryPermissions()
        //{
        //var cameraStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera);
        //var storageStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);
        //var photosStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Photos);
        //if (cameraStatus != PermissionStatus.Granted || storageStatus != PermissionStatus.Granted)
        //{
        //    var permissionRequestResult = await CrossPermissions.Current.RequestPermissionsAsync(
        //        new Permission[] { Permission.Camera, Permission.Storage, Permission.Photos });
        //    var cameraResult = permissionRequestResult[Plugin.Permissions.Abstractions.Permission.Camera];
        //    var storageResult = permissionRequestResult[Plugin.Permissions.Abstractions.Permission.Storage];
        //    var photosResult = permissionRequestResult[Plugin.Permissions.Abstractions.Permission.Photos];
        //    return (
        //        cameraResult != PermissionStatus.Denied &&
        //        storageResult != PermissionStatus.Denied &&
        //        photosResult != PermissionStatus.Denied);
        //}
        //return true;
        //}
        //private async Task<bool> RequestPermissions(List<Permission> permissionList)
        //{
        //List<PermissionStatus> permissionStatuses = new List<PermissionStatus>();
        //foreach (var permission in permissionList)
        //{
        //var status = await CrossPermissions.Current.CheckPermissionStatusAsync(permission);
        //permissionStatuses.Add(status);
        //}
        //var requiresRequesst = permissionStatuses.Any(x => x != PermissionStatus.Granted);
        //if (requiresRequesst)
        //{
        //var permissionRequestResult = await CrossPermissions.Current.RequestPermissionsAsync(permissionList.ToArray());
        //return permissionRequestResult.All(x => x.Value != PermissionStatus.Denied);
        //}
        //return true;
        //}



        private async Task PickPhoto()
        {
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await _dialogService.ShowAlertAsync("Photos Not Supported", ":( Permission not granted to photos.", "OK");
                return;
            }
            var file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
            });
            if (file == null)
            return;
            var imgSource = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                    return stream;
            });
        }
        

        //private void AddValidations()
        //{
        //    _itemName = new ValidatableObject<string>();

        //    _itemName.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Choose a name for your item." });
        //}

        //private bool EntriesCorrectlyPopulated()
        //{

        //    Console.WriteLine("Inside Entries Correctly Populated");
        //    _itemName.Validate();


        //    return _itemName.IsValid;
        //}
    }
}
