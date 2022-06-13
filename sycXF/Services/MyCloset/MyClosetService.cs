﻿using System;
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

        public async Task<ObservableCollection<MyClosetItem>> FilterAsync(int catalogSeasonId, int catalogTypeId)
        {
            var uri = UriHelper.CombineUri(GlobalSetting.Instance.GatewayShoppingEndpoint, $"{ApiUrlBase}/items/type/{catalogTypeId}/brand/{catalogSeasonId}");

            MyClosetRoot catalog = await _requestProvider.GetAsync<MyClosetRoot>(uri);

            if (catalog?.Data != null)
                return catalog?.Data.ToObservableCollection();
            else
                return new ObservableCollection<MyClosetItem>();
        }

        //public async Task<ObservableCollection<MyClosetItem>> GetMyClosetAsync()
        //{
        //    var uri = UriHelper.CombineUri(GlobalSetting.Instance.GatewayShoppingEndpoint, $"{ApiUrlBase}/items");

        //    MyClosetRoot catalog = await _requestProvider.GetAsync<MyClosetRoot>(uri);

        //    if (catalog?.Data != null)
        //    {
        //        _fixUriService.FixMyClosetItemPictureUri(catalog?.Data);
        //        return catalog?.Data.ToObservableCollection();
        //    }
        //    else
        //        return new ObservableCollection<MyClosetItem>();
        //}


        public async Task<List<MyClosetItem>> GetMyClosetAsyncSource()
        {
            var uri = UriHelper.CombineUri(GlobalSetting.Instance.GatewayShoppingEndpoint, $"{ApiUrlBase}/items");

            List<MyClosetItem> myclosetitems = await _requestProvider.GetAsync<List<MyClosetItem>>(uri);

            if (myclosetitems != null)
                return myclosetitems;
            else
                return new List<MyClosetItem>();
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

        public async Task<ObservableCollection<SeasonCategory>> GetSeasonCategoriesAsync()
        {
            var uri = UriHelper.CombineUri(GlobalSetting.Instance.GatewayShoppingEndpoint, $"{ApiUrlBase}/catalogbrands");

            IEnumerable<SeasonCategory> seasoncategories = await _requestProvider.GetAsync<IEnumerable<SeasonCategory>>(uri);

            if (seasoncategories != null)
                return seasoncategories?.ToObservableCollection();
            else
                return new ObservableCollection<SeasonCategory>();
        }

        public async Task<ObservableCollection<ApparelCategory>> GetApparelCategoriesAsync()
        {
            var uri = UriHelper.CombineUri(GlobalSetting.Instance.GatewayShoppingEndpoint, $"{ApiUrlBase}/catalogtypes");

            IEnumerable<ApparelCategory> apparelcategories = await _requestProvider.GetAsync<IEnumerable<ApparelCategory>>(uri);

            if (apparelcategories != null)
                return apparelcategories.ToObservableCollection();
            else
                return new ObservableCollection<ApparelCategory>();
        }

        public async Task<ObservableCollection<SizeCategory>> GetSizeCategoriesAsync()
        {
            var uri = UriHelper.CombineUri(GlobalSetting.Instance.GatewayShoppingEndpoint, $"{ApiUrlBase}/catalogtypes");

            IEnumerable<SizeCategory> sizecategories = await _requestProvider.GetAsync<IEnumerable<SizeCategory>>(uri);

            if (sizecategories != null)
                return sizecategories.ToObservableCollection();
            else
                return new ObservableCollection<SizeCategory>();
        }
    }
}
