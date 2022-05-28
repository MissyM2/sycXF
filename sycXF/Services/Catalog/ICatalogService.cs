using sycXF.Models.MyCloset;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace sycXF.Services.MyCloset
{
    public interface IMyClosetService
    {
        Task<ObservableCollection<MyClosetSeason>> GetMyClosetSeasonAsync();
        Task<ObservableCollection<MyClosetItem>> FilterAsync(int catalogSeasonId, int catalogTypeId);
        Task<ObservableCollection<MyClosetType>> GetMyClosetTypeAsync();
        Task<ObservableCollection<MyClosetItem>> GetMyClosetAsync();
    }
}
