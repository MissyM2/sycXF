using sycXF.Models.Closet;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace sycXF.Services.Closet
{
    public interface IClosetService
    {
        Task<ObservableCollection<ClosetItemModel>> GetClosetAsync();
        Task<ObservableCollection<MainFilterCategoryModel>> GetMainFilterCategoriesAsync();
        Task<ObservableCollection<ItemCategoryModel>> GetCategoriesAsync(string categoryType);
        Task<ObservableCollection<ClosetItemModel>> GetClosetItemsAsync(string queryType, string categoryName);
    }
}
