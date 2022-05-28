using sycXF.Models.Basket;
using sycXF.Models.MyCloset;
using sycXF.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using sycXF.Services.Settings;

namespace sycXF.Services.FixUri
{
    public class FixUriService : IFixUriService
    {
        private readonly ISettingsService _settingsService;

        private Regex IpRegex = new Regex(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b");

        public FixUriService(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        public void FixMyClosetItemPictureUri(IEnumerable<MyClosetItem> catalogItems)
        {
            if (catalogItems == null)
            {
                return;
            }

            try
            {
                if (!ViewModelLocator.UseMockService
                    && _settingsService.IdentityEndpointBase != GlobalSetting.DefaultEndpoint)
                {
                    foreach (var catalogItem in catalogItems)
                    {
                        MatchCollection serverResult = IpRegex.Matches(catalogItem.PictureUri);
                        MatchCollection localResult = IpRegex.Matches(_settingsService.IdentityEndpointBase);

                        if (serverResult.Count != -1 && localResult.Count != -1)
                        {
                            var serviceIp = serverResult[0].Value;
                            var localIp = localResult[0].Value;

                            catalogItem.PictureUri = catalogItem.PictureUri.Replace(serviceIp, localIp);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public void FixBasketItemPictureUri(IEnumerable<BasketItem> basketItems)
        {
            if (basketItems == null)
            {
                return;
            }

            try
            {
                if (!ViewModelLocator.UseMockService
                    && _settingsService.IdentityEndpointBase != GlobalSetting.DefaultEndpoint)
                {
                    foreach (var basketItem in basketItems)
                    {
                        MatchCollection serverResult = IpRegex.Matches(basketItem.PictureUrl);
                        MatchCollection localResult = IpRegex.Matches(_settingsService.IdentityEndpointBase);

                        if (serverResult.Count != -1 && localResult.Count != -1)
                        {
                            var serviceIp = serverResult[0].Value;
                            var localIp = localResult[0].Value;
                            basketItem.PictureUrl = basketItem.PictureUrl.Replace(serviceIp, localIp);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }

}
