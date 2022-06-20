using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Microsoft.Maui
using Microsoft.Maui.Controls;

namespace sycXF.Services.Settings
{
    public class SettingsService : ISettingsService
    {
        #region Setting Constants

        private const string AccessToken = "access_token";
        private const string IdToken = "id_token";
        private const string IdUseMocks = "use_mocks";
        private const string IdIdentityBase = "url_base";
        private const string IdGatewayMarketingBase = "url_marketing";
        private const string IdGatewayShoppingBase = "url_shopping";
        private readonly string AccessTokenDefault = string.Empty;
        private readonly string IdTokenDefault = string.Empty;
        private readonly bool UseMocksDefault = true;
        private readonly string UrlIdentityDefault = GlobalSetting.Instance.BaseIdentityEndpoint;
        private readonly string UrlGatewayMarketingDefault = GlobalSetting.Instance.BaseGatewayMarketingEndpoint;
        private readonly string UrlGatewayShoppingDefault = GlobalSetting.Instance.BaseGatewayShoppingEndpoint;
        #endregion

        #region Settings Properties

        public string AuthAccessToken
        {
            get => Preferences.Get(AccessToken, AccessTokenDefault);
            set => Preferences.Set(AccessToken, value);
        }

        public string AuthIdToken
        {
            get => Preferences.Get(IdToken, IdTokenDefault);
            set => Preferences.Set(IdToken, value);
        }

        public bool UseMocks
        {
            get => Preferences.Get(IdUseMocks, UseMocksDefault);
            set => Preferences.Set(IdUseMocks, value);
        }

        public string IdentityEndpointBase
        {
            get => Preferences.Get(IdIdentityBase, UrlIdentityDefault);
            set => Preferences.Set(IdIdentityBase, value);
        }

        public string GatewayShoppingEndpointBase
        {
            get => Preferences.Get(IdGatewayShoppingBase, UrlGatewayShoppingDefault);
            set => Preferences.Set(IdGatewayShoppingBase, value);
        }

        public string GatewayMarketingEndpointBase
        {
            get => Preferences.Get(IdGatewayMarketingBase, UrlGatewayMarketingDefault);
            set => Preferences.Set(IdGatewayMarketingBase, value);
        }

        #endregion
    }
}