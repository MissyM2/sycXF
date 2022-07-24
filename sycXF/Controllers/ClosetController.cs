using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using sycXF.Services.Database;
using sycXF.Models.Closet;
using sycXF.Controllers;
using System.Collections.Generic;
using System.Linq;

namespace sycXF.Controllers
{
    public class ClosetController : IClosetController
    {

        private IDataRepository<ClosetItemModel> _closetItemRepository;
        private IDataRepository<ItemCategoryModel> _itemCategoryRepository;
        private IDataRepository<MainFilterCategoryModel> _mainFilterCategoryRepository;
        public IMockDataRepository Api { get; set; }

        private List<MainFilterCategoryModel> _mainFilterCategories = new List<MainFilterCategoryModel>
        {
            new MainFilterCategoryModel
            { Id = 1, PropertyName = "Categories" },
            new MainFilterCategoryModel
            { Id = 2, PropertyName = "Seasons" },
            new MainFilterCategoryModel
            { Id = 4, PropertyName = "Favorites"},
        };

        public ClosetController(IDataRepository<ClosetItemModel> closetItemRepository,
            IDataRepository<ItemCategoryModel> itemCategoryRepository,
            IDataRepository<MainFilterCategoryModel> mainFilterCategoryRepository)
        {
            _closetItemRepository = closetItemRepository;
            _itemCategoryRepository = itemCategoryRepository;
            _mainFilterCategoryRepository = mainFilterCategoryRepository;

            Api = new MockDataRepository();
            Console.WriteLine("ClosetController: Constants.USE_MOCKS " + Constants.USE_MOCKS);
        }

        public async Task<ObservableCollection<ClosetItemModel>> GetAllClosetItems()
        {

            if (Constants.USE_MOCKS == "useMocks")
            {

                var myClosetItemsList = await Api.GetAllMockClosetItems();
                ObservableCollection<ClosetItemModel> myClosetItems = new ObservableCollection<ClosetItemModel>(myClosetItemsList);
                return myClosetItems;
            }
            else
            {
                var myClosetItemsList = await _closetItemRepository.GetAllAsync();
                ObservableCollection<ClosetItemModel> myClosetItems = new ObservableCollection<ClosetItemModel>();
                return myClosetItems;
            }
        }


        public async Task<ObservableCollection<ClosetItemModel>> GetClosetItems(string queryType, string categoryName)
        {

            if (Constants.USE_MOCKS == "useMocks")
            {

                var myClosetItemsList = await Api.GetAllMockClosetItems();

                if (queryType == "Season")
                {
                    var result = myClosetItemsList.Where(w => w.Season.Equals(categoryName));
                    ObservableCollection<ClosetItemModel> myClosetItems = new ObservableCollection<ClosetItemModel>(result);
                    return myClosetItems;
                }
                else if (queryType == "Type")
                {
                    var result = myClosetItemsList.Where(w => w.Type.Equals(categoryName));
                    ObservableCollection<ClosetItemModel> myClosetItems = new ObservableCollection<ClosetItemModel>(result);
                    return myClosetItems;
                }
                else
                {
                    ObservableCollection<ClosetItemModel> myClosetItems = new ObservableCollection<ClosetItemModel>();
                    return myClosetItems;
                }
            }
            else
            {
                var myClosetItemsList = await _closetItemRepository.GetAllAsync();

                if (queryType == "Season")
                {
                    var result = myClosetItemsList.Where(w => w.Season.Equals(categoryName));
                    ObservableCollection<ClosetItemModel> myClosetItems = new ObservableCollection<ClosetItemModel>(result);
                    return myClosetItems;
                }
                else if (queryType == "Type")
                {
                    var result = myClosetItemsList.Where(w => w.Season.Equals(categoryName));
                    ObservableCollection<ClosetItemModel> myClosetItems = new ObservableCollection<ClosetItemModel>(result);
                    return myClosetItems;
                }
                else
                {
                    ObservableCollection<ClosetItemModel> myClosetItems = new ObservableCollection<ClosetItemModel>();
                    return myClosetItems;
                }
            }
        }

        public async Task<ObservableCollection<ItemCategoryModel>> GetAllItemCategories()
        {

            if (Constants.USE_MOCKS == "useMocks")
            {
                var itemCategoriesListMock = await Api.GetMockItemCategories();
                ObservableCollection<ItemCategoryModel> itemCategories = new ObservableCollection<ItemCategoryModel>(itemCategoriesListMock);

                return itemCategories;
            }
            else
            {
                var itemCategoriesList = await _itemCategoryRepository.GetAllAsync();
                ObservableCollection<ItemCategoryModel> itemCategories = new ObservableCollection<ItemCategoryModel>(itemCategoriesList);

                return itemCategories;

            }
        }

        public async Task<ObservableCollection<MainFilterCategoryModel>> GetAllMainFilterCategories()
        {

            if (Constants.USE_MOCKS == "useMocks")
            {
                var mainFilterCategoriesMock = await Api.GetMockMainFilterCategories();

                ObservableCollection<MainFilterCategoryModel> itemCategories = new ObservableCollection<MainFilterCategoryModel>(mainFilterCategoriesMock);

                return itemCategories;
            }
            else
            {
                var mainFilterCategories = await _mainFilterCategoryRepository.GetAllAsync();

                ObservableCollection<MainFilterCategoryModel> itemCategories = new ObservableCollection<MainFilterCategoryModel>(mainFilterCategories);

                return itemCategories;

            }
        }


    }
}

