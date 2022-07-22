using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using sycXF.Models.Closet;
using sycXF.Models.User;

namespace sycXF.Services.Database
{
    public interface IMockDataRepository
    {
        Task<List<ClosetItemModel>> GetAllMockClosetItems();
        Task<List<ItemCategoryModel>> GetMockItemCategories();
        Task<List<MainFilterCategoryModel>> GetMockMainFilterCategories();
        Task<List<UserInfoModel>> GetMockUsers();
    }
}

