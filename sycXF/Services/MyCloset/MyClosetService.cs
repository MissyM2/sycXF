using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using sycXF.Models.MyCloset;
using sycXF.Services.RequestProvider;
using sycXF.Extensions;
using System.Collections.Generic;
using sycXF.Services.FixUri;
using sycXF.Helpers;

namespace sycXF.Services.MyCloset
{
    public class MyClosetService : IMyClosetService
    {
        private readonly IRequestProvider _requestProvider;
        private readonly IFixUriService _fixUriService;
		
        private const string ApiUrlBase = "c/api/v1/catalog";

        public MyClosetService(IRequestProvider requestProvider, IFixUriService fixUriService)
        {
            _requestProvider = requestProvider;
            _fixUriService = fixUriService;
        }

       
        public async Task<ObservableCollection<MyClosetItem>> GetMyClosetAsync()
        {
            var uri = UriHelper.CombineUri(GlobalSetting.Instance.GatewayShoppingEndpoint, $"{ApiUrlBase}/items");

            IEnumerable<MyClosetItem> myclosetitems = await _requestProvider.GetAsync<IEnumerable<MyClosetItem>>(uri);

            if (myclosetitems != null)
                return myclosetitems?.ToObservableCollection();
            else
                return new ObservableCollection<MyClosetItem>();
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


        public async Task<ObservableCollection<ItemCategory>> GetCategoriesAsync(string categoryType)
        {
            var uri = UriHelper.CombineUri(GlobalSetting.Instance.GatewayShoppingEndpoint, $"{ApiUrlBase}/catalogbrands");

            IEnumerable<ItemCategory> categories = await _requestProvider.GetAsync<IEnumerable<ItemCategory>>(uri);

            if (categories != null)
                return categories?.ToObservableCollection();
            else
                return new ObservableCollection<ItemCategory>();
        }

        

        public async Task<ObservableCollection<MyClosetItem>> GetItemsByApparelAsync(string apparelType)
        {
            var uri = UriHelper.CombineUri(GlobalSetting.Instance.GatewayShoppingEndpoint, $"{ApiUrlBase}/items");

            IEnumerable<MyClosetItem> myclosetitems = await _requestProvider.GetAsync<IEnumerable<MyClosetItem>>(uri);

            if (myclosetitems != null)
                return myclosetitems?.ToObservableCollection();
            else
                return new ObservableCollection<MyClosetItem>();
        }

        public async Task<ObservableCollection<MyClosetItem>> GetItemsBySeasonAsync(string season)
        {
            var uri = UriHelper.CombineUri(GlobalSetting.Instance.GatewayShoppingEndpoint, $"{ApiUrlBase}/items");

            IEnumerable<MyClosetItem> myclosetitems = await _requestProvider.GetAsync<IEnumerable<MyClosetItem>>(uri);

            if (myclosetitems != null)
                return myclosetitems?.ToObservableCollection();
            else
                return new ObservableCollection<MyClosetItem>();

        }
    }
}
