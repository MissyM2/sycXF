using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Microsoft.Maui
using Microsoft.Maui.Controls;

namespace sycXF.Services.OpenUrl
{
    public class OpenUrlService : IOpenUrlService
    {
        public async Task OpenUrl(string url)
        {
            if (await Launcher.CanOpenAsync(url))
            {
                await Launcher.OpenAsync (url);
            }
        }
    }
}
