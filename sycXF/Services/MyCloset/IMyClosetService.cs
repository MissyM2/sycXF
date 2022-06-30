using sycXF.Models.MyCloset;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace sycXF.Services.MyCloset
{
    public interface IMyClosetService
    {
        Task<ObservableCollection<MyClosetItem>> GetMyClosetAsync();
        Task<ObservableCollection<MainFilterCategoryModel>> GetMainFilterCategoriesAsync();
        Task<ObservableCollection<ItemCategory>> GetCategoriesAsync(string categoryType);
        Task<ObservableCollection<MyClosetItem>> GetItemsByApparelAsync(string apparelType);
        Task<ObservableCollection<MyClosetItem>> GetItemsBySeasonAsync(string season);
    }
}
