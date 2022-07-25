using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using SQLite;
using sycXF.Models.Closet;
using sycXF.Models.User;

namespace sycXF.Services.Database
{
    public class MockDataRepository : IMockDataRepository
    {
       
        // Mock Closet Source

        public async Task<List<ClosetItemModel>> GetAllMockClosetItems()
        {
            await Task.Delay(1000);

            var items = new List<ClosetItemModel>();

            items.Add(new ClosetItemModel()
            {
                Id = 1,
                PictureUri = "top_1.png",
                Name = "Floral cap-sleeved blouseM",
                Description = "Small, Spring, Top M",
                Size = "Small",
                Season = "Spring",
                Type = "Top"
            });
            items.Add(new ClosetItemModel()
            {
                Id = 2,
                PictureUri = "bottom_blue_corduroy_skirt_1.png",
                Name = "Corduroy skirt",
                Description = "Small, Summer, Bottom M",
                Size = "Small",
                Season = "Summer",
                Type = "Bottom"
            });
            items.Add(new ClosetItemModel()
            {
                Id = 3,
                PictureUri = "dress_red_1.png",
                Name = "Red long dress",
                Description = "Medium, Winter, Dress M",
                Size = "Medium",
                Season = "Winter",
                Type = "Dress"
            });
            items.Add(new ClosetItemModel()
            {
                Id = 4,
                PictureUri = "outerwear_1.png",
                Name = "London Fog rain coat",
                Description = "Large, Always, Outerwear M",
                Size = "Large",
                Season = "Always",
                Type = "Outerwear"
            });
            items.Add(new ClosetItemModel()
            {
                Id = 5,
                PictureUri = "footwear_1.png",
                Name = "Black leather boots",
                Description = "Small, Winter, Footwear M",
                Size = "Small",
                Season = "Winter",
                Type = "Footwear"
            });
            items.Add(new ClosetItemModel()
            {
                Id = 6,
                PictureUri = "top_white_blouse_1.png",
                Name = "White dressy blouse",
                Description = "Medium, Spring, Top M",
                Size = "Medium",
                Season = "Spring",
                Type = "Top"
            });
            items.Add(new ClosetItemModel()
            {
                Id = 7,
                PictureUri = "bottoms_1.png",
                Name = "Blue Corduroy Skirt",
                Description = "Large, Summer, Bottom M",
                Size = "Large",
                Season = "Summer",
                Type = "Bottom"
            });
            items.Add(new ClosetItemModel()
            {
                Id = 8,
                PictureUri = "dress_1.png",
                Name = "Long Green dress",
                Description = "Small, Fall, Dress M",
                Size = "Small",
                Season = "Fall",
                Type = "Dress"
            });
            items.Add(new ClosetItemModel()
            {
                Id = 9,
                PictureUri = "top_white_sweater_1.png",
                Name = "White Sweater",
                Description = "Medium, Always, Outerwear M",
                Size = "Medium",
                Season = "Always",
                Type = "Outerwear"
            });
            items.Add(new ClosetItemModel()
            {
                Id = 10,
                PictureUri = "top_white_blouse_1.png",
                Name = "White Blouse",
                Description = "Medium, Always, Top M",
                Size = "Medium",
                Season = "Always",
                Type = "Top"
            });
            items.Add(new ClosetItemModel()
            {
                Id = 10,
                PictureUri = "accessories_pearl_necklace_1.png",
                Name = "Pearl Necklace",
                Description = "Medium, Winter, Accessory M",
                Size = "Medium",
                Season = "Winter",
                Type = "Accessory"
            });
            items.Add(new ClosetItemModel()
            {
                Id = 11,
                PictureUri = "purse_1.png",
                Name = "Purse",
                Description = "Large, Spring, Accessory M",
                Size = "Large",
                Season = "Spring",
                Type = "Accessory"
            });
            items.Add(new ClosetItemModel()
            {
                Id = 12,
                PictureUri = "bottoms_1.png",
                Name = "Jeans",
                Description = "Small, Winter, Bottom M",
                Size = "Small",
                Season = "Winter",
                Type = "Bottom"
            });

            return items;

            }



        // Mock Item Categories

        public async Task<List<ItemCategoryModel>> GetMockItemCategories()
        {
            await Task.Delay(1000);

            var items = new List<ItemCategoryModel>();
            items.Add(new ItemCategoryModel()
            {
                Id = 1,
                Color = "#B96CBD",
                CategoryType = "Season",
                CategoryName = "Winter",
                CategoryTitle = "Winter",
                IconGlyph = "noun-snowflake-2098252.png",
                IconFamily = "FontAwesome-Regular",
                PictureUri = "noun-shirt-3013538.png"

            });
            items.Add(new ItemCategoryModel()
            {
                Id = 2,
                Color = "#B96CBD",
                CategoryType = "Season",
                CategoryName = "Spring",
                CategoryTitle = "Spring",
                IconGlyph = "noun-sunny-2494509.png",
                IconFamily = "FontAwesome-Regular",
                PictureUri = "noun-shirt-3013538.png"

            });
            items.Add(new ItemCategoryModel()
            {
                Id = 3,
                Color = "#B96CBD",
                CategoryType = "Season",
                CategoryName = "Summer",
                CategoryTitle = "Summer",
                IconGlyph = "noun-sun-2494511.png",
                IconFamily = "FontAwesome-Regular",
                PictureUri = "noun-shirt-3013538.png"

            });
            items.Add(new ItemCategoryModel()
            {
                Id = 4,
                Color = "#B96CBD",
                CategoryType = "Season",
                CategoryName = "Fall",
                CategoryTitle = "Fall",
                IconGlyph = "noun-autumn-3789702.png",
                IconFamily = "FontAwesome-Regular",
                PictureUri = "noun-shirt-3013538.png"

            });
            items.Add(new ItemCategoryModel()
            {
                Id = 5,
                Color = "#B96CBD",
                CategoryType = "Season",
                CategoryName = "Always",
                CategoryTitle = "Always",
                IconGlyph = "noun-dress-3013536.png",
                IconFamily = "FontAwesome-Regular",
                PictureUri = "noun-shirt-3013538.png"

            });
            items.Add(new ItemCategoryModel()
            {
                Id = 6,
                Color = "#B96CBD",
                CategoryType = "Type",
                CategoryName = "Top",
                CategoryTitle = "Tops",
                IconGlyph = "noun-shirt-3013538.png",
                IconFamily = "FontAwesome-Regular",
                PictureUri = "noun-shirt-3013538.png"
            });
            items.Add(new ItemCategoryModel()
            {
                Id = 7,
                Color = "#B96CBD",
                CategoryType = "Type",
                CategoryName = "Bottom",
                CategoryTitle = "Bottoms",
                IconGlyph = "noun-jeans-3049748.png",
                IconFamily = "FontAwesome-Regular",
                PictureUri = "noun-jeans-3049748.png"
            });
            items.Add(new ItemCategoryModel()
            {
                Id = 8,
                Color = "#B96CBD",
                CategoryType = "Type",
                CategoryName = "Dress",
                CategoryTitle = "Dresses",
                IconGlyph = "noun-dress-3013536.png",
                IconFamily = "FontAwesome-Regular",
                PictureUri = "noun-dress-3013536.png"
            });
            items.Add(new ItemCategoryModel()
            {
                Id = 9,
                Color = "#B96CBD",
                CategoryType = "Type",
                CategoryName = "Outerwear",
                CategoryTitle = "Outerwear",
                IconGlyph = "noun-puffer-vest-2200104.png",
                IconFamily = "FontAwesome-Regular",
                PictureUri = "noun-puffer-vest-2200104.png"
            });
            items.Add(new ItemCategoryModel()
            {
                Id = 10,
                Color = "#B96CBD",
                CategoryType = "Type",
                CategoryName = "Footwear",
                CategoryTitle = "Footwear",
                IconGlyph = "noun-shoe-1202591.png",
                IconFamily = "FontAwesome-Regular",
                PictureUri = "noun-shoe-1202591.png"
            });
            items.Add(new ItemCategoryModel()
            {
                Id = 11,
                Color = "#B96CBD",
                CategoryType = "Type",
                CategoryName = "Accessory",
                CategoryTitle = "Accessories",
                IconGlyph = "noun-scarf-3790978.png",
                IconFamily = "FontAwesome-Regular",
                PictureUri = "noun-scarf-3790978.png"
            });
            items.Add(new ItemCategoryModel()
            {
                Id = 12,
                Color = "#B96CBD",
                CategoryType = "Size",
                CategoryName = "XSmall",
                CategoryTitle = "XSmall",
                IconGlyph = "noun-scarf-3790978.png",
                IconFamily = "FontAwesome-Regular",
                PictureUri = "noun-scarf-3790978.png"
            });
            items.Add(new ItemCategoryModel()
            {
                Id = 13,
                Color = "#B96CBD",
                CategoryType = "Size",
                CategoryName = "Small",
                CategoryTitle = "Small",
                IconGlyph = "noun-scarf-3790978.png",
                IconFamily = "FontAwesome-Regular",
                PictureUri = "noun-scarf-3790978.png"
            });
            items.Add(new ItemCategoryModel()
            {
                Id = 14,
                Color = "#B96CBD",
                CategoryType = "Size",
                CategoryName = "Medium",
                CategoryTitle = "Medium",
                IconGlyph = "noun-scarf-3790978.png",
                IconFamily = "FontAwesome-Regular",
                PictureUri = "noun-scarf-3790978.png"
            });
            items.Add(new ItemCategoryModel()
            {
                Id = 15,
                Color = "#B96CBD",
                CategoryType = "Size",
                CategoryName = "Large",
                CategoryTitle = "Large",
                IconGlyph = "noun-scarf-3790978.png",
                IconFamily = "FontAwesome-Regular",
                PictureUri = "noun-scarf-3790978.png"
            });
            items.Add(new ItemCategoryModel()
            {
                Id = 16,
                Color = "#B96CBD",
                CategoryType = "Size",
                CategoryName = "XLarge",
                CategoryTitle = "XLarge",
                IconGlyph = "noun-scarf-3790978.png",
                IconFamily = "FontAwesome-Regular",
                PictureUri = "noun-scarf-3790978.png"
            });
            items.Add(new ItemCategoryModel()
            {
                Id = 17,
                Color = "#B96CBD",
                CategoryType = "Size",
                CategoryName = "XSmall",
                CategoryTitle = "XSmall",
                IconGlyph = "noun-scarf-3790978.png",
                IconFamily = "FontAwesome-Regular",
                PictureUri = "noun-scarf-3790978.png"
            });

            //var filteredItems = new List<ItemCategoryModel>();

            //foreach (var item in items)
            //    if (item.CategoryType == cat)
            //    { 
            //        filteredItems.Add(item);
            //    }
            return items;
        }

        // Mock Main Filter Categories
        public async Task<List<MainFilterCategoryModel>> GetMockMainFilterCategories()
        {
            await Task.Delay(1000);

            var items = new List<MainFilterCategoryModel>();

            items.Add(new MainFilterCategoryModel() { Id = 1, PropertyName = "Types" });
            items.Add(new MainFilterCategoryModel() { Id = 2, PropertyName = "Seasons" });
            items.Add(new MainFilterCategoryModel() { Id = 4, PropertyName = "Favorites" });

            return items;
        }

        public async Task<List<UserInfoModel>> GetMockUsers()
        {
            await Task.Delay(1000);

            var items = new List<UserInfoModel>();

            items.Add(new UserInfoModel()
            {
                FirstName = "Jhon",
                LastName = "Doe",
                PreferredUsername = "Jdoe",
                Email = "jdoe@eshop.com",
                EmailVerified = true,
                PhoneNumber = "202-555-0165",
                PhoneNumberVerified = true,
                Address = "Seattle, WA",
                Street = "120 E 87th Street",
                ZipCode = "98101",
                Country = "United States",
                State = "Seattle",
                CardNumber = "378282246310005",
                CardHolder = "American Express",
                CardSecurityNumber = "1234"
            });

            return items;
        }

     
    }
}

