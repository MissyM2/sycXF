using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using SQLite;
using sycXF.Models.Closet;
using Xamarin.Essentials;

namespace sycXF.Services.Closet
{
    public class ClosetService : IClosetService
    {
        SQLiteAsyncConnection sycXFdb;

        async Task Init()
        {
            if (sycXFdb != null)
                return;

            // Get an absolute path to the database file
            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "sycXF.db");
            Console.WriteLine("What is databasePath? " + databasePath);

            sycXFdb = new SQLiteAsyncConnection(databasePath);

            await sycXFdb.CreateTableAsync<ClosetItemModel>();
            await sycXFdb.CreateTableAsync<ClosetRootModel>();
            await sycXFdb.CreateTableAsync<ItemCategoryModel>();
            await sycXFdb.CreateTableAsync<MainFilterCategoryModel>();
        }

        // closet services
        public async Task AddClosetItem(string name,
            string description,
            string pictureUri,
            string size,
            string season,
            string apparelType
            )
        {
            await Init();

            var closetItem = new ClosetItemModel
            {
                Name = name,
                Description = description,
                PictureUri = pictureUri,
                Size = size,
                Season = season,
                ApparelType = apparelType
            };

            var id = await sycXFdb.InsertAsync(closetItem);
        }


        public async Task RemoveClosetItem(int id)
        {

            await Init();

            await sycXFdb.DeleteAsync<ClosetItemModel>(id);
        }

        public async Task<ObservableCollection<ClosetItemModel>> GetClosetAsync()
        {
            await Init();

            var myClosetItemsList = await sycXFdb.Table<ClosetItemModel>().ToListAsync();

            ObservableCollection<ClosetItemModel> myClosetItems = new ObservableCollection<ClosetItemModel>(myClosetItemsList);

            return myClosetItems;
        }

        public async Task<ObservableCollection<ClosetItemModel>> GetClosetItemsAsync(string queryType, string categoryName)
        {
            await Init();

            var myClosetItemsList = await sycXFdb.Table<ClosetItemModel>().ToListAsync();
            ObservableCollection<ClosetItemModel> myClosetItems = new ObservableCollection<ClosetItemModel>(myClosetItemsList);

            return myClosetItems;
        }

        public async Task<ClosetItemModel> GetClosetItem(int id)
        {
            await Init();

            var closetItem = await sycXFdb.Table<ClosetItemModel>()
                .FirstOrDefaultAsync(c => c.Id == id);

            return closetItem;
        }

        // main filter categories services
        public async Task AddMainFilterCategory(string propertyName)
        {
            await Init();

            var mainFilterCategory = new MainFilterCategoryModel
            {
                PropertyName = propertyName
            };

            var id = await sycXFdb.InsertAsync(mainFilterCategory);
        }

        public async Task RemoveMainFilterCategory(int id)
        {

            await Init();

            await sycXFdb.DeleteAsync<MainFilterCategoryModel>(id);
        }

        public async Task<ObservableCollection<MainFilterCategoryModel>> GetMainFilterCategoriesAsync()
        {
            await Init();

            var mainFilterCategoriesList = await sycXFdb.Table<MainFilterCategoryModel>().ToListAsync();

            ObservableCollection<MainFilterCategoryModel> mainFilterCategories = new ObservableCollection<MainFilterCategoryModel>(mainFilterCategoriesList);

            return mainFilterCategories;
        }

        // item category services
        public async Task AddItemCategory(
            string categoryType,
            string categoryName,
            string iconGlyph,
            string iconFamily,
            string pictureUri,
            byte[] imgContent
            )
        {
            await Init();

            var itemCategory = new ItemCategoryModel
            {
                CategoryType = categoryType,
                CategoryName = categoryName,
                IconGlyph = iconGlyph,
                IconFamily = iconFamily,
                PictureUri = pictureUri,
                ImgContent = imgContent
            };

            var id = await sycXFdb.InsertAsync(itemCategory);
        }

        public async Task RemoveItemCategory(int id)
        {

            await Init();

            await sycXFdb.DeleteAsync<ItemCategoryModel>(id);
        }

        public async Task<ObservableCollection<ItemCategoryModel>> GetCategoriesAsync(string categoryType)
        {
            await Init();

            var itemCategoriesList = await sycXFdb.Table<ItemCategoryModel>().ToListAsync();

            ObservableCollection<ItemCategoryModel> itemCategories = new ObservableCollection<ItemCategoryModel>(itemCategoriesList);

            return itemCategories;
        }


    }
}
