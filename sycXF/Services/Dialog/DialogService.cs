using System.Threading.Tasks;
using Microsoft.Maui
using Microsoft.Maui.Controls;

namespace sycXF.Services
{
    public class DialogService : IDialogService
    {
        public Task ShowAlertAsync(string message, string title, string buttonLabel)
        {
            return App.Current.MainPage.DisplayAlert (title, message, buttonLabel);
        }
    }
}
