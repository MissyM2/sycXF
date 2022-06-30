using sycXF.Models.MyCloset;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace sycXF.Services.MyCloset
{
    public interface IMyClosetService
    {
        Task<ObservableCollection<SeasonCategory>> GetSeasonCategoriesAsync();
        //Task<ObservableCollection<MyClosetItem>> FilterAsync(int catalogSeasonId, int catalogTypeId);
        Task<ObservableCollection<ApparelCategory>> GetApparelCategoriesAsync();
        Task<ObservableCollection<SizeCategory>> GetSizeCategoriesAsync();
        Task<ObservableCollection<MainFilterCategoryModel>> GetMainFilterCategoriesAsync();
        //Task<List<MyClosetItem>> GetMyClosetAsyncSource();
        Task<ObservableCollection<MyClosetItem>> GetMyClosetAsync();
        Task<ObservableCollection<MyClosetItem>> GetItemsByApparelAsync(string apparelType);
        Task<ObservableCollection<MyClosetItem>> GetItemsBySeasonAsync(string seasonType);
    }
}
