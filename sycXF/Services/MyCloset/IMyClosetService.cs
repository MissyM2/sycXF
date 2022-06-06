using sycXF.Models.MyCloset;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace sycXF.Services.MyCloset
{
    public interface IMyClosetService
    {
        Task<ObservableCollection<Season>> GetSeasonAsync();
        Task<ObservableCollection<MyClosetItem>> FilterAsync(int catalogSeasonId, int catalogTypeId);
        Task<ObservableCollection<MyClosetType>> GetMyClosetTypeAsync();
        Task<ObservableCollection<MyClosetItem>> GetMyClosetAsync();
    }
}
