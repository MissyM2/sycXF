﻿using System;
using System.Threading.Tasks;
using sycXF.Helpers;
using sycXF.Services.RequestProvider;

namespace sycXF.Services.Location
{
    public class LocationService : ILocationService
    {
        private readonly IRequestProvider _requestProvider;

        private const string ApiUrlBase = "l/api/v1/locations";

        public LocationService(IRequestProvider requestProvider)
        {
            _requestProvider = requestProvider;
        }

        public async Task UpdateUserLocation(sycXF.Models.Location.Location newLocReq, string token)
        {
            var uri = UriHelper.CombineUri(GlobalSetting.Instance.GatewayMarketingEndpoint, ApiUrlBase);

            await _requestProvider.PostAsync(uri, newLocReq, token);
        }
    }
}