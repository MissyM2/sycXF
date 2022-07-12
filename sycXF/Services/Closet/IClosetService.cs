using sycXF.Models.Closet;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace sycXF.Services.Closet
{
    public interface IClosetService
    {
        // closet items
        Task AddClosetItem(string name,
            string description,
            string pictureUri,
            string size,
            string season,
            string apparelType
            );
        Task RemoveClosetItem(int id);
        Task<ObservableCollection<ClosetItemModel>> GetClosetAsync();
        Task<ObservableCollection<ClosetItemModel>> GetClosetItemsAsync(string queryType, string categoryName);

        // main filter categories
        Task AddMainFilterCategory(string propertyName);
        Task RemoveMainFilterCategory(int id);
        Task<ObservableCollection<MainFilterCategoryModel>> GetMainFilterCategoriesAsync();

        // item categories
        Task AddItemCategory(
            string categoryType,
            string categoryName,
            string iconGlyph,
            string iconFamily,
            string pictureUri,
            byte[] imgContent
            );
        Task RemoveItemCategory(int id);
        Task<ObservableCollection<ItemCategoryModel>> GetCategoriesAsync(string categoryType);

    }
}
