using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace sycXF.Services.Settings
{
    public class SettingsService : ISettingsService
    {
        #region Setting Constants

        private const string IdUseMocks = "use_mocks";

        private readonly bool UseMocksDefault = true;

        #endregion

        #region Settings Properties


        public bool UseMocks
        {
            get => Preferences.Get(IdUseMocks, UseMocksDefault);
            set => Preferences.Set(IdUseMocks, value);
        }

        
        #endregion
    }
}