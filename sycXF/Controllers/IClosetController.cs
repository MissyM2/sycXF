using sycXF.Models.Closet;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace sycXF.Controllers
{
    public interface IClosetController
    {
        //Task AddClosetItem(string name,
        //    string description,
        //    string pictureUri,
        //    string size,
        //    string season,
        //    string apparelType
        //    );
        //Task RemoveClosetItem(int id);
        Task<ObservableCollection<ClosetItemModel>> GetClosetItems(string queryType, string categoryName);
        Task<ObservableCollection<ItemCategoryModel>> GetAllItemCategories();
        Task<ObservableCollection<MainFilterCategoryModel>> GetAllMainFilterCategories();

    }
}

