using sycXF.Extensions;
using sycXF.Models.MyCloset;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Maui
using Microsoft.Maui.Controls;

namespace sycXF.Services.MyCloset
{
    public class MyClosetMockService : IMyClosetService
    {

        private Random RandomGenerator = new Random();
        private int newItemId = 0;


        private ObservableCollection<SeasonCategory> MockSeasonCategories = new ObservableCollection<SeasonCategory>
        {
            new SeasonCategory { Id = 1, IconGlyph = "noun-snowflake-2098252.png", SeasonCategoryName = "Winter" },
            new SeasonCategory { Id = 2, IconGlyph = "noun-sunny-2494509.png", SeasonCategoryName = "Spring" },
            new SeasonCategory { Id = 3, IconGlyph = "noun-sun-2494511.png", SeasonCategoryName = "Summer" },
            new SeasonCategory { Id = 4, IconGlyph = "noun-autumn-3789702.png", SeasonCategoryName = "Fall" },
            new SeasonCategory { Id = 5, IconGlyph = "noun-dress-3013536.png", SeasonCategoryName = "Always in Season" }
        };

        private ObservableCollection<ApparelCategory> MockApparelCategories = new ObservableCollection<ApparelCategory>
        {
            new ApparelCategory
            {
                Id = 3,
                ApparelCategoryName = "Top",
                ApparelCategoryTitle ="Tops",
                IconFamily = "FontAwesome-Regular",
                IconGlyph = "noun-shirt-3013538.png",
                PictureUri = "noun-shirt-3013538.png"
            },
            new ApparelCategory
            {
                Id = 4,
                ApparelCategoryName = "Bottom",
                ApparelCategoryTitle ="Bottoms",
                IconFamily = "FontAwesome-Regular",
                IconGlyph = "noun-jeans-3049748.png",
                PictureUri = "noun-jeans-3049748.png"
            },
            new ApparelCategory
            {
                Id = 5,
                ApparelCategoryName = "Dress",
                ApparelCategoryTitle ="Dresses",
                IconFamily = "FontAwesome-Regular",
                IconGlyph = "noun-dress-3013536.png",
                PictureUri = "noun-dress-3013536.png"
            },
            new ApparelCategory
            {
                Id = 6,
                ApparelCategoryName = "Outerwear",
                ApparelCategoryTitle ="Outerwear",
                IconFamily = "FontAwesome-Regular",
                IconGlyph = "noun-puffer-vest-2200104.png",
                PictureUri = "noun-puffer-vest-2200104.png"
            },
            new ApparelCategory
            {
                Id = 7,
                ApparelCategoryName = "Footwear",
                ApparelCategoryTitle ="Footwear",
                IconFamily = "FontAwesome-Regular",
                IconGlyph = "noun-shoe-1202591.png",
                PictureUri = "noun-shoe-1202591.png"
            },
            new ApparelCategory
            {
                Id = 8,
                ApparelCategoryName = "Accessory",
                ApparelCategoryTitle ="Accessories",
                IconFamily = "FontAwesome-Regular",
                IconGlyph = "noun-scarf-3790978.png",
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
            new MainFilterCategoryModel { Id = 3, PropertyName = "Sizes" },
            new MainFilterCategoryModel { Id = 4, PropertyName = "Favorites" }
        };

        private List<MyClosetItem> MockMyClosetSource = new List<MyClosetItem>
        //private ObservableCollection<MyClosetItem> MockMyCloset = new ObservableCollection<MyClosetItem>
        {
            new MyClosetItem
            {
                Id = 1,
                PictureUri = "fake_product_01.png",
                Name = "Floral cap-sleeved blouse",
                Description="a;lsdkfj;alskdfj;alskdjf;alskdjf;aslkdjf",
                SizeCategoryId = 2,
                SizeCategoryName = "Small",
                SeasonCategoryId = 2,
                SeasonCategoryName = "Spring",
                ApparelCategoryId = 3,
                ApparelCategoryName = "Top"
            },
            new MyClosetItem
            {
                Id = 2,
                PictureUri = "fake_product_02.png",
                Name = "Floral skirt",
                Description="a;lsdkfj;alskdfj;alskdjf;alskdjf;aslkdjf",
                SizeCategoryId = 2,
                SizeCategoryName = "Small",
                SeasonCategoryId = 3,
                SeasonCategoryName  = "Summer",
                ApparelCategoryId = 4,
                ApparelCategoryName = "Bottom"
            },
            new MyClosetItem
            {
                Id = 3,
                PictureUri = "fake_product_03.png",
                Name = "Black tea-length dress",
                Description="a;lsdkfj;alskdfj;alskdjf;alskdjf;aslkdjf",
                SizeCategoryId = 3,
                SizeCategoryName = "Medium",
                SeasonCategoryId = 1,
                SeasonCategoryName  = "Winter",
                ApparelCategoryId = 5,
                ApparelCategoryName = "Dress"
            },
            new MyClosetItem
            {
                Id = 4,
                PictureUri = "fake_product_04.png",
                Name = "London Fog rain coat",
                Description="a;lsdkfj;alskdfj;alskdjf;alskdjf;aslkdjf",
                SizeCategoryId = 4,
                SizeCategoryName = "Large",
                SeasonCategoryId = 5,
                SeasonCategoryName  = "Always in Season",
                ApparelCategoryId = 6,
                ApparelCategoryName = "Outerwear"
            },
            new MyClosetItem
            {
                Id = 5,
                PictureUri = "fake_product_05.png",
                Name = "Black leather boots",
                Description="a;lsdkfj;alskdfj;alskdjf;alskdjf;aslkdjf",
                SizeCategoryId = 2,
                SizeCategoryName = "Small",
                SeasonCategoryName  = "Winter",
                ApparelCategoryId = 7,
                ApparelCategoryName = "Footwear"
            },
            new MyClosetItem
            {
                Id = 6,
                PictureUri = "fake_product_01.png",
                Name = "White button-down blouse",
                Description="a;lsdkfj;alskdfj;alskdjf;alskdjf;aslkdjf",
                SizeCategoryId = 3,
                SizeCategoryName = "Medium",
                SeasonCategoryName  = "Spring",
                ApparelCategoryId = 3,
                ApparelCategoryName = "Top"
            },
            new MyClosetItem
            {
                Id = 7,
                PictureUri = "fake_product_02.png",
                Name = "White jean skirt",
                Description="a;lsdkfj;alskdfj;alskdjf;alskdjf;aslkdjf",
                SizeCategoryId = 4,
                SizeCategoryName = "Large",
                SeasonCategoryId = 3,
                SeasonCategoryName  = "Summer",
                ApparelCategoryId = 4,
                ApparelCategoryName = "Bottom"
            },
            new MyClosetItem
            {
                Id = 8,
                PictureUri = "fake_product_03.png",
                Name = "Flannel long-sleeved dress",
                Description="a;lsdkfj;alskdfj;alskdjf;alskdjf;aslkdjf",
                SizeCategoryId = 2,
                SizeCategoryName = "Small",
                SeasonCategoryId = 4,
                SeasonCategoryName  = "Fall",
                ApparelCategoryId = 5,
                ApparelCategoryName = "Dress"
            },
            new MyClosetItem
            {
                Id = 9,
                PictureUri = "fake_product_04.png",
                Name = "White Sweater",
                Description="a;lsdkfj;alskdfj;alskdjf;alskdjf;aslkdjf",
                SizeCategoryId = 3,
                SizeCategoryName = "Medium",
                SeasonCategoryId = 5,
                SeasonCategoryName  = "Always in Season",
                ApparelCategoryId = 6,
                ApparelCategoryName = "Outerwear"
            },
            new MyClosetItem
            {
                Id = 10,
                PictureUri = "fake_product_05.png",
                Name = "Pearl Necklace",
                Description="a;lsdkfj;alskdfj;alskdjf;alskdjf;aslkdjf",
                SizeCategoryId = 3,
                SizeCategoryName = "Medium",
                SeasonCategoryId = 1,
                SeasonCategoryName  = "Winter",
                ApparelCategoryId = 8,
                ApparelCategoryName = "Accessory"
            },
            new MyClosetItem
            {
                Id = 11,
                PictureUri = "fake_product_05.png",
                Name = "Purse",
                Description="a;lsdkfj;alskdfj;alskdjf;alskdjf;aslkdjf",
                SizeCategoryId = 4,
                SizeCategoryName = "Large",
                SeasonCategoryId = 2,
                SeasonCategoryName  = "Spring",
                ApparelCategoryId = 8,
                ApparelCategoryName = "Accessory"
            },
            new MyClosetItem
            {
                Id = 12,
                PictureUri = "fake_product_05.png",
                Name = "Jeans",
                Description="a;lsdkfj;alskdfj;alskdjf;alskdjf;aslkdjf",
                SizeCategoryId = 2,
                SizeCategoryName = "Small",
                SeasonCategoryId = 1,
                SeasonCategoryName = "Winter",
                ApparelCategoryId = 4,
                ApparelCategoryName = "Bottom"
            }

        };

        
       

        public async Task<List<MyClosetItem>> GetMyClosetAsyncSource()
        {
            await Task.Delay(10);

            return MockMyClosetSource;
        }

        public async Task<ObservableCollection<MainFilterCategoryModel>> GetMainFilterCategoriesAsync()
        {
            await Task.Delay(10);

            return MockMainFilterCategories;
        }


        public async Task<ObservableCollection<SeasonCategory>> GetSeasonCategoriesAsync()
        {
            await Task.Delay(10);

            return MockSeasonCategories;
        }

        public async Task<ObservableCollection<ApparelCategory>> GetApparelCategoriesAsync()
        {
            await Task.Delay(10);

            return MockApparelCategories;
        }

        public async Task<ObservableCollection<SizeCategory>> GetSizeCategoriesAsync()
        {
            await Task.Delay(10);

            return MockSizeCategories;
        }
    }
}