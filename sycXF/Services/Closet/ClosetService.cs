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
    public class ClosetService : IClosetService
    {
        private readonly IRequestProvider _requestProvider;
        private readonly IFixUriService _fixUriService;
		
        private const string ApiUrlBase = "c/api/v1/catalog";

        public ClosetService(IRequestProvider requestProvider, IFixUriService fixUriService)
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

        public async Task<ObservableCollection<MainFilterCategoryModel>> GetMainFilterCategoriesAsync()
        {
            var uri = UriHelper.CombineUri(GlobalSetting.Instance.GatewayShoppingEndpoint, $"{ApiUrlBase}/catalogbrands");

            IEnumerable<MainFilterCategoryModel> mainfiltercategories = await _requestProvider.GetAsync<IEnumerable<MainFilterCategoryModel>>(uri);

            if (mainfiltercategories != null)
                return mainfiltercategories?.ToObservableCollection();
            else
                return new ObservableCollection<MainFilterCategoryModel>();
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

        

        public async Task<ObservableCollection<ClosetItemModel>> GetClosetItemsAsync(string queryType, string categoryName)
        {
            var uri = UriHelper.CombineUri(GlobalSetting.Instance.GatewayShoppingEndpoint, $"{ApiUrlBase}/items");

            IEnumerable<ClosetItemModel> myclosetitems = await _requestProvider.GetAsync<IEnumerable<ClosetItemModel>>(uri);

            if (myclosetitems != null)
                return myclosetitems?.ToObservableCollection();
            else
                return new ObservableCollection<ClosetItemModel>();
        }
    }
}
