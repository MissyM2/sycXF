using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using sycXF.Models.Closet;
using sycXF.Services.RequestProvider;
using sycXF.Extensions;
using System.Collections.Generic;
using sycXF.Services.FixUri;
using sycXF.Helpers;

namespace sycXF.Services.Closet
{
    public class InternetClosetService : IClosetService
    {
        private readonly IRequestProvider _requestProvider;
        private readonly IFixUriService _fixUriService;

        private const string ApiUrlBase = "c/api/v1/catalog";


        // closet item services
        public Task AddClosetItem(string name, string description, string pictureUri, string size, string season, string apparelType)
        {
            throw new NotImplementedException();
        }

        public Task RemoveClosetItem(int id)
        {
            throw new NotImplementedException();
        }

        public InternetClosetService(IRequestProvider requestProvider, IFixUriService fixUriService)
        {
            _requestProvider = requestProvider;
            _fixUriService = fixUriService;
        }

        public async Task<ObservableCollection<ClosetItemModel>> GetClosetAsync()
        {
            var uri = UriHelper.CombineUri(GlobalSetting.Instance.GatewayShoppingEndpoint, $"{ApiUrlBase}/items");

            IEnumerable<ClosetItemModel> myclosetitems = await _requestProvider.GetAsync<IEnumerable<ClosetItemModel>>(uri);

            if (myclosetitems != null)
                return myclosetitems?.ToObservableCollection();
            else
                return new ObservableCollection<ClosetItemModel>();
        }

        public async Task<ObservableCollection<ClosetItemModel>> GetClosetItemsAsync(string queryType, string categoryName)
        {
            var uri = UriHelper.CombineUri(GlobalSetting.Instance.GatewayShoppingEndpoint, $"{ApiUrlBase}/items");

            IEnumerable<ClosetItemModel> myclosetitems = await _requestProvider.GetAsync<IEnumerable<ClosetItemModel>>(uri);

            if (myclosetitems != null)
                return myclosetitems?.ToObservableCollection();
            else
                return new ObservableCollection<ClosetItemModel>();
        }


        // main filter category services
        public Task AddMainFilterCategory(string propertyName)
        {
            throw new NotImplementedException();
        }

        public Task RemoveMainFilterCategory(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ObservableCollection<MainFilterCategoryModel>> GetMainFilterCategoriesAsync()
        {
            var uri = UriHelper.CombineUri(GlobalSetting.Instance.GatewayShoppingEndpoint, $"{ApiUrlBase}/catalogbrands");

            IEnumerable<MainFilterCategoryModel> mainfiltercategories = await _requestProvider.GetAsync<IEnumerable<MainFilterCategoryModel>>(uri);

            if (mainfiltercategories != null)
                return mainfiltercategories?.ToObservableCollection();
            else
                return new ObservableCollection<MainFilterCategoryModel>();
        }


        // item category services
        public Task AddItemCategory(string categoryType, string categoryName, string iconGlyph, string iconFamily, string pictureUri, byte[] imgContent)
        {
            throw new NotImplementedException();
        }

        public Task RemoveItemCategory(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ObservableCollection<ItemCategoryModel>> GetCategoriesAsync(string categoryType)
        {
            var uri = UriHelper.CombineUri(GlobalSetting.Instance.GatewayShoppingEndpoint, $"{ApiUrlBase}/catalogbrands");

            IEnumerable<ItemCategoryModel> categories = await _requestProvider.GetAsync<IEnumerable<ItemCategoryModel>>(uri);

            if (categories != null)
                return categories?.ToObservableCollection();
            else
                return new ObservableCollection<ItemCategoryModel>();
        }
    }

        
}
