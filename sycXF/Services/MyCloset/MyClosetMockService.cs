using sycXF.Extensions;
using sycXF.Models.MyCloset;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace sycXF.Services.MyCloset
{
    public class MyClosetMockService : IMyClosetService
    {

        private Random RandomGenerator = new Random();
        private int newItemId = 0;


        private ObservableCollection<ItemCategory> MockItemCategories = new ObservableCollection<ItemCategory>
        {
            new ItemCategory
            {
                Id = 1,
                CategoryType="Season",
                CategoryName = "Winter",
                CategoryTitle ="Winter",
                IconGlyph = "noun-snowflake-2098252.png",
                IconFamily = "FontAwesome-Regular",
                PictureUri = "noun-shirt-3013538.png"

            },
            new ItemCategory
            {
                Id = 2,
                CategoryType="Season",
                CategoryName = "Spring",
                CategoryTitle ="Spring",
                IconGlyph = "noun-sunny-2494509.png",
                IconFamily = "FontAwesome-Regular",
                PictureUri = "noun-shirt-3013538.png"

            },
            new ItemCategory
            {
                Id = 3,
                CategoryType="Season",
                CategoryName = "Summer",
                CategoryTitle ="Summer",
                IconGlyph = "noun-sun-2494511.png",
                IconFamily = "FontAwesome-Regular",
                PictureUri = "noun-shirt-3013538.png"

            },
            new ItemCategory
            {
                Id = 4,
                CategoryType="Season",
                CategoryName = "Fall",
                CategoryTitle ="Fall",
                IconGlyph = "noun-autumn-3789702.png",
                IconFamily = "FontAwesome-Regular",
                PictureUri = "noun-shirt-3013538.png"

            },
            new ItemCategory
            {
                Id = 5,
                CategoryType="Season",
                CategoryName = "Always",
                CategoryTitle ="Always",
                IconGlyph = "noun-dress-3013536.png",
                IconFamily = "FontAwesome-Regular",
                PictureUri = "noun-shirt-3013538.png"

            },
            new ItemCategory
            {
                Id = 3,
                CategoryType="Apparel",
                CategoryName = "Top",
                CategoryTitle ="Tops",
                IconGlyph = "noun-shirt-3013538.png",
                IconFamily = "FontAwesome-Regular",
                PictureUri = "noun-shirt-3013538.png"
            },
            new ItemCategory
            {
                Id = 4,
                CategoryType="Apparel",
                CategoryName = "Bottom",
                CategoryTitle ="Bottoms",
                IconGlyph = "noun-jeans-3049748.png",
                IconFamily = "FontAwesome-Regular",
                PictureUri = "noun-jeans-3049748.png"
            },
            new ItemCategory
            {
                Id = 5,
                CategoryType="Apparel",
                CategoryName = "Dress",
                CategoryTitle ="Dresses",
                IconGlyph = "noun-dress-3013536.png",
                IconFamily = "FontAwesome-Regular",
                PictureUri = "noun-dress-3013536.png"
            },
            new ItemCategory
            {
                Id = 6,
                CategoryType="Apparel",
                CategoryName = "Outerwear",
                CategoryTitle ="Outerwear",
                IconGlyph = "noun-puffer-vest-2200104.png",
                IconFamily = "FontAwesome-Regular",
                PictureUri = "noun-puffer-vest-2200104.png"
            },
            new ItemCategory
            {
                Id = 7,
                CategoryType="Apparel",
                CategoryName = "Footwear",
                CategoryTitle ="Footwear",
                IconGlyph = "noun-shoe-1202591.png",
                IconFamily = "FontAwesome-Regular",
                PictureUri = "noun-shoe-1202591.png"
            },
            new ItemCategory
            {
                Id = 8,
                CategoryType="Apparel",
                CategoryName = "Accessory",
                CategoryTitle ="Accessories",
                IconGlyph = "noun-scarf-3790978.png",
                IconFamily = "FontAwesome-Regular",
                PictureUri = "noun-scarf-3790978.png"
            }
        };

        private ObservableCollection<SizeCategory> MockSizeCategories = new ObservableCollection<SizeCategory>
        {
            new SizeCategory { Id = 1, SizeCategoryName = "XSmall" },
            new SizeCategory { Id = 2, SizeCategoryName = "Small" },
            new SizeCategory { Id = 3, SizeCategoryName = "Medium" },
            new SizeCategory { Id = 4, SizeCategoryName = "Large" },
            new SizeCategory { Id = 5, SizeCategoryName = "XLarge" },
            new SizeCategory { Id = 6, SizeCategoryName = "XSmall" }
        };

        private ObservableCollection<MainFilterCategoryModel> MockMainFilterCategories = new ObservableCollection<MainFilterCategoryModel>
        {
            new MainFilterCategoryModel { Id = 1, PropertyName = "Categories" },
            new MainFilterCategoryModel { Id = 2, PropertyName = "Seasons" },
            new MainFilterCategoryModel { Id = 4, PropertyName = "Favorites" }
        };

        private ObservableCollection<MyClosetItem> MockMyClosetSource = new ObservableCollection<MyClosetItem>
        {
            new MyClosetItem
            {
                Id = 1,
                PictureUri = "top_1.png",
                Name = "Floral cap-sleeved blouse",
                Description="a;lsdkfj;alskdfj;alskdjf;alskdjf;aslkdjf",
                SizeCategoryId = 2,
                SizeCategoryName = "Small",
                Season = "Spring",
                ApparelType = "Top"
            },
            new MyClosetItem
            {
                Id = 2,
                PictureUri = "bottom_blue_corduroy_skirt_1.png",
                Name = "Corduroy skirt",
                Description="a;lsdkfj;alskdfj;alskdjf;alskdjf;aslkdjf",
                SizeCategoryId = 2,
                SizeCategoryName = "Small",
                Season  = "Summer",
                ApparelType = "Bottom"
            },
            new MyClosetItem
            {
                Id = 3,
                PictureUri = "dress_red_1.png",
                Name = "Red long dress",
                Description="a;lsdkfj;alskdfj;alskdjf;alskdjf;aslkdjf",
                SizeCategoryId = 3,
                SizeCategoryName = "Medium",
                Season  = "Winter",
                ApparelType = "Dress"
            },
            new MyClosetItem
            {
                Id = 4,
                PictureUri = "outerwear_1.png",
                Name = "London Fog rain coat",
                Description="a;lsdkfj;alskdfj;alskdjf;alskdjf;aslkdjf",
                SizeCategoryId = 4,
                SizeCategoryName = "Large",
                Season  = "Always",
                ApparelType = "Outerwear"
            },
            new MyClosetItem
            {
                Id = 5,
                PictureUri = "footwear_1.png",
                Name = "Black leather boots",
                Description="a;lsdkfj;alskdfj;alskdjf;alskdjf;aslkdjf",
                SizeCategoryId = 2,
                SizeCategoryName = "Small",
                Season  = "Winter",
                ApparelType = "Footwear"
            },
            new MyClosetItem
            {
                Id = 6,
                PictureUri = "top_white_blouse_1.png",
                Name = "White dressy blouse",
                Description="a;lsdkfj;alskdfj;alskdjf;alskdjf;aslkdjf",
                SizeCategoryId = 3,
                SizeCategoryName = "Medium",
                Season  = "Spring",
                ApparelType = "Top"
            },
            new MyClosetItem
            {
                Id = 7,
                PictureUri = "bottoms_1.png",
                Name = "Blue Corduroy Skirt",
                Description="a;lsdkfj;alskdfj;alskdjf;alskdjf;aslkdjf",
                SizeCategoryId = 4,
                SizeCategoryName = "Large",
                Season  = "Summer",
                ApparelType = "Bottom"
            },
            new MyClosetItem
            {
                Id = 8,
                PictureUri = "dress_1.png",
                Name = "Long Green dress",
                Description="a;lsdkfj;alskdfj;alskdjf;alskdjf;aslkdjf",
                SizeCategoryId = 2,
                SizeCategoryName = "Small",
                Season  = "Fall",
                ApparelType = "Dress"
            },
            new MyClosetItem
            {
                Id = 9,
                PictureUri = "top_white_sweater_1.png",
                Name = "White Sweater",
                Description="a;lsdkfj;alskdfj;alskdjf;alskdjf;aslkdjf",
                SizeCategoryId = 3,
                SizeCategoryName = "Medium",
                Season  = "Always",
                ApparelType = "Outerwear"
            },
            new MyClosetItem
            {
                Id = 10,
                PictureUri = "top_white_blouse_1.png",
                Name = "White Blouse",
                Description="a;lsdkfj;alskdfj;alskdjf;alskdjf;aslkdjf",
                SizeCategoryId = 3,
                SizeCategoryName = "Medium",
                Season  = "Always",
                ApparelType = "Top"
            },
            new MyClosetItem
            {
                Id = 10,
                PictureUri = "accessories_pearl_necklace_1.png",
                Name = "Pearl Necklace",
                Description="a;lsdkfj;alskdfj;alskdjf;alskdjf;aslkdjf",
                SizeCategoryId = 3,
                SizeCategoryName = "Medium",
                Season  = "Winter",
                ApparelType = "Accessory"
            },
            new MyClosetItem
            {
                Id = 11,
                PictureUri = "purse_1.png",
                Name = "Purse",
                Description="a;lsdkfj;alskdfj;alskdjf;alskdjf;aslkdjf",
                SizeCategoryId = 4,
                SizeCategoryName = "Large",
                Season  = "Spring",
                ApparelType = "Accessory"
            },
            new MyClosetItem
            {
                Id = 12,
                PictureUri = "bottoms_1.png",
                Name = "Jeans",
                Description="a;lsdkfj;alskdfj;alskdjf;alskdjf;aslkdjf",
                SizeCategoryId = 2,
                SizeCategoryName = "Small",
                Season = "Winter",
                ApparelType = "Bottom"
            }

        };

        public async Task<ObservableCollection<MyClosetItem>> GetMyClosetAsync()
        {
            await Task.Delay(10);

            return MockMyClosetSource;
        }

        public async Task<ObservableCollection<MainFilterCategoryModel>> GetMainFilterCategoriesAsync()
        {
            await Task.Delay(10);

            return MockMainFilterCategories;
        }

        public async Task<ObservableCollection<ItemCategory>> GetCategoriesAsync(string categoryType)
        {
            await Task.Delay(10);

            return MockItemCategories
                .Where(c => c.CategoryType == categoryType)
                .ToObservableCollection();
        }

        public async Task<ObservableCollection<MyClosetItem>> GetClosetItemsAsync(string queryType, string categoryName)
        {
            await Task.Delay(10);
            var catName = categoryName.ToString();

            if (queryType == "ApparelType")
            {
                return MockMyClosetSource
                    .Where(c => c.ApparelType == catName)
                    .ToObservableCollection();
            }
            else if (queryType == "Season")
            {

                return MockMyClosetSource
                    .Where(c => c.Season == catName)
                    .ToObservableCollection();

            } else
            {
                return null;
            }
           

            //get all items in closet
            // pull only those with the category type (apparel or season
        }

        //public async Task<ObservableCollection<MyClosetItem>> GetItemsBySeasonAsync(string season)
        //{
        //    await Task.Delay(10);
        //    var seasType = season.ToString();

        //    return MockMyClosetSource
        //        .Where(c => c.Season == seasType)
        //        .ToObservableCollection();
        //}
    }
}