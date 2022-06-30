using sycXF.Extensions;
using sycXF.Models.Closet;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace sycXF.Services.Closet
{
    public class ClosetMockService : IClosetService
    {

        private Random RandomGenerator = new Random();
        private int newItemId = 0;


        private ObservableCollection<ItemCategoryModel> MockItemCategories = new ObservableCollection<ItemCategoryModel>
        {
            new ItemCategoryModel
            {
                Id = 1,
                CategoryType="Season",
                CategoryName = "Winter",
                CategoryTitle ="Winter",
                IconGlyph = "noun-snowflake-2098252.png",
                IconFamily = "FontAwesome-Regular",
                PictureUri = "noun-shirt-3013538.png"

            },
            new ItemCategoryModel
            {
                Id = 2,
                CategoryType="Season",
                CategoryName = "Spring",
                CategoryTitle ="Spring",
                IconGlyph = "noun-sunny-2494509.png",
                IconFamily = "FontAwesome-Regular",
                PictureUri = "noun-shirt-3013538.png"

            },
            new ItemCategoryModel
            {
                Id = 3,
                CategoryType="Season",
                CategoryName = "Summer",
                CategoryTitle ="Summer",
                IconGlyph = "noun-sun-2494511.png",
                IconFamily = "FontAwesome-Regular",
                PictureUri = "noun-shirt-3013538.png"

            },
            new ItemCategoryModel
            {
                Id = 4,
                CategoryType="Season",
                CategoryName = "Fall",
                CategoryTitle ="Fall",
                IconGlyph = "noun-autumn-3789702.png",
                IconFamily = "FontAwesome-Regular",
                PictureUri = "noun-shirt-3013538.png"

            },
            new ItemCategoryModel
            {
                Id = 5,
                CategoryType="Season",
                CategoryName = "Always",
                CategoryTitle ="Always",
                IconGlyph = "noun-dress-3013536.png",
                IconFamily = "FontAwesome-Regular",
                PictureUri = "noun-shirt-3013538.png"

            },
            new ItemCategoryModel
            {
                Id = 6,
                CategoryType="Apparel",
                CategoryName = "Top",
                CategoryTitle ="Tops",
                IconGlyph = "noun-shirt-3013538.png",
                IconFamily = "FontAwesome-Regular",
                PictureUri = "noun-shirt-3013538.png"
            },
            new ItemCategoryModel
            {
                Id = 7,
                CategoryType="Apparel",
                CategoryName = "Bottom",
                CategoryTitle ="Bottoms",
                IconGlyph = "noun-jeans-3049748.png",
                IconFamily = "FontAwesome-Regular",
                PictureUri = "noun-jeans-3049748.png"
            },
            new ItemCategoryModel
            {
                Id = 8,
                CategoryType="Apparel",
                CategoryName = "Dress",
                CategoryTitle ="Dresses",
                IconGlyph = "noun-dress-3013536.png",
                IconFamily = "FontAwesome-Regular",
                PictureUri = "noun-dress-3013536.png"
            },
            new ItemCategoryModel
            {
                Id = 9,
                CategoryType="Apparel",
                CategoryName = "Outerwear",
                CategoryTitle ="Outerwear",
                IconGlyph = "noun-puffer-vest-2200104.png",
                IconFamily = "FontAwesome-Regular",
                PictureUri = "noun-puffer-vest-2200104.png"
            },
            new ItemCategoryModel
            {
                Id = 10,
                CategoryType="Apparel",
                CategoryName = "Footwear",
                CategoryTitle ="Footwear",
                IconGlyph = "noun-shoe-1202591.png",
                IconFamily = "FontAwesome-Regular",
                PictureUri = "noun-shoe-1202591.png"
            },
            new ItemCategoryModel
            {
                Id = 11,
                CategoryType="Apparel",
                CategoryName = "Accessory",
                CategoryTitle ="Accessories",
                IconGlyph = "noun-scarf-3790978.png",
                IconFamily = "FontAwesome-Regular",
                PictureUri = "noun-scarf-3790978.png"
            },
            new ItemCategoryModel
            {
                Id = 12,
                CategoryType="Size",
                CategoryName = "XSmall",
                CategoryTitle ="",
                IconGlyph = "noun-scarf-3790978.png",
                IconFamily = "FontAwesome-Regular",
                PictureUri = "noun-scarf-3790978.png"
            },
            new ItemCategoryModel
            {
               Id = 13,
                CategoryType="Size",
                CategoryName = "Small",
                CategoryTitle ="",
                IconGlyph = "noun-scarf-3790978.png",
                IconFamily = "FontAwesome-Regular",
                PictureUri = "noun-scarf-3790978.png"
            },
            new ItemCategoryModel
            {
                Id = 14,
                CategoryType="Size",
                CategoryName = "Medium",
                CategoryTitle ="",
                IconGlyph = "noun-scarf-3790978.png",
                IconFamily = "FontAwesome-Regular",
                PictureUri = "noun-scarf-3790978.png"
            },
            new ItemCategoryModel
            {
                Id = 15,
                CategoryType="Size",
                CategoryName = "Large",
                CategoryTitle ="",
                IconGlyph = "noun-scarf-3790978.png",
                IconFamily = "FontAwesome-Regular",
                PictureUri = "noun-scarf-3790978.png"
            },
            new ItemCategoryModel
            {
                Id = 16,
                 CategoryType="Size",
                CategoryName = "XLarge",
                CategoryTitle ="",
                IconGlyph = "noun-scarf-3790978.png",
                IconFamily = "FontAwesome-Regular",
                PictureUri = "noun-scarf-3790978.png"
            },
            new ItemCategoryModel
            {
                Id = 17,
                 CategoryType="Size",
                CategoryName = "XSmall",
                CategoryTitle ="",
                IconGlyph = "noun-scarf-3790978.png",
                IconFamily = "FontAwesome-Regular",
                PictureUri = "noun-scarf-3790978.png"
            }
        };

        private ObservableCollection<MainFilterCategoryModel> MockMainFilterCategories = new ObservableCollection<MainFilterCategoryModel>
        {
            new MainFilterCategoryModel { Id = 1, PropertyName = "Categories" },
            new MainFilterCategoryModel { Id = 2, PropertyName = "Seasons" },
            new MainFilterCategoryModel { Id = 4, PropertyName = "Favorites" }
        };

        private ObservableCollection<ClosetItemModel> MockClosetSource = new ObservableCollection<ClosetItemModel>
        {
            new ClosetItemModel
            {
                Id = 1,
                PictureUri = "top_1.png",
                Name = "Floral cap-sleeved blouse",
                Description="a;lsdkfj;alskdfj;alskdjf;alskdjf;aslkdjf",
                Size = "Small",
                Season = "Spring",
                ApparelType = "Top"
            },
            new ClosetItemModel
            {
                Id = 2,
                PictureUri = "bottom_blue_corduroy_skirt_1.png",
                Name = "Corduroy skirt",
                Description="a;lsdkfj;alskdfj;alskdjf;alskdjf;aslkdjf",
                Size = "Small",
                Season  = "Summer",
                ApparelType = "Bottom"
            },
            new ClosetItemModel
            {
                Id = 3,
                PictureUri = "dress_red_1.png",
                Name = "Red long dress",
                Description="a;lsdkfj;alskdfj;alskdjf;alskdjf;aslkdjf",
                Size = "Medium",
                Season  = "Winter",
                ApparelType = "Dress"
            },
            new ClosetItemModel
            {
                Id = 4,
                PictureUri = "outerwear_1.png",
                Name = "London Fog rain coat",
                Description="a;lsdkfj;alskdfj;alskdjf;alskdjf;aslkdjf",
                Size = "Large",
                Season  = "Always",
                ApparelType = "Outerwear"
            },
            new ClosetItemModel
            {
                Id = 5,
                PictureUri = "footwear_1.png",
                Name = "Black leather boots",
                Description="a;lsdkfj;alskdfj;alskdjf;alskdjf;aslkdjf",
                Size = "Small",
                Season  = "Winter",
                ApparelType = "Footwear"
            },
            new ClosetItemModel
            {
                Id = 6,
                PictureUri = "top_white_blouse_1.png",
                Name = "White dressy blouse",
                Description="a;lsdkfj;alskdfj;alskdjf;alskdjf;aslkdjf",
                Size = "Medium",
                Season  = "Spring",
                ApparelType = "Top"
            },
            new ClosetItemModel
            {
                Id = 7,
                PictureUri = "bottoms_1.png",
                Name = "Blue Corduroy Skirt",
                Description="a;lsdkfj;alskdfj;alskdjf;alskdjf;aslkdjf",
                Size = "Large",
                Season  = "Summer",
                ApparelType = "Bottom"
            },
            new ClosetItemModel
            {
                Id = 8,
                PictureUri = "dress_1.png",
                Name = "Long Green dress",
                Description="a;lsdkfj;alskdfj;alskdjf;alskdjf;aslkdjf",
                Size = "Small",
                Season  = "Fall",
                ApparelType = "Dress"
            },
            new ClosetItemModel
            {
                Id = 9,
                PictureUri = "top_white_sweater_1.png",
                Name = "White Sweater",
                Description="a;lsdkfj;alskdfj;alskdjf;alskdjf;aslkdjf",
                Size = "Medium",
                Season  = "Always",
                ApparelType = "Outerwear"
            },
            new ClosetItemModel
            {
                Id = 10,
                PictureUri = "top_white_blouse_1.png",
                Name = "White Blouse",
                Description="a;lsdkfj;alskdfj;alskdjf;alskdjf;aslkdjf",
                Size = "Medium",
                Season  = "Always",
                ApparelType = "Top"
            },
            new ClosetItemModel
            {
                Id = 10,
                PictureUri = "accessories_pearl_necklace_1.png",
                Name = "Pearl Necklace",
                Description="a;lsdkfj;alskdfj;alskdjf;alskdjf;aslkdjf",
                Size = "Medium",
                Season  = "Winter",
                ApparelType = "Accessory"
            },
            new ClosetItemModel
            {
                Id = 11,
                PictureUri = "purse_1.png",
                Name = "Purse",
                Description="a;lsdkfj;alskdfj;alskdjf;alskdjf;aslkdjf",
                Size = "Large",
                Season  = "Spring",
                ApparelType = "Accessory"
            },
            new ClosetItemModel
            {
                Id = 12,
                PictureUri = "bottoms_1.png",
                Name = "Jeans",
                Description="a;lsdkfj;alskdfj;alskdjf;alskdjf;aslkdjf",
                Size = "Small",
                Season = "Winter",
                ApparelType = "Bottom"
            }

        };

        public async Task<ObservableCollection<ClosetItemModel>> GetClosetAsync()
        {
            await Task.Delay(10);

            return MockClosetSource;
        }

        public async Task<ObservableCollection<MainFilterCategoryModel>> GetMainFilterCategoriesAsync()
        {
            await Task.Delay(10);

            return MockMainFilterCategories;
        }

        public async Task<ObservableCollection<ItemCategoryModel>> GetCategoriesAsync(string categoryType)
        {
            await Task.Delay(10);

            return MockItemCategories
                .Where(c => c.CategoryType == categoryType)
                .ToObservableCollection();
        }

        public async Task<ObservableCollection<ClosetItemModel>> GetClosetItemsAsync(string queryType, string categoryName)
        {
            await Task.Delay(10);
            var catName = categoryName.ToString();

            if (queryType == "ApparelType")
            {
                return MockClosetSource
                    .Where(c => c.ApparelType == catName)
                    .ToObservableCollection();
            }
            else if (queryType == "Season")
            {

                return MockClosetSource
                    .Where(c => c.Season == catName)
                    .ToObservableCollection();

            } else
            {
                return null;
            }
        }

      
    }
}