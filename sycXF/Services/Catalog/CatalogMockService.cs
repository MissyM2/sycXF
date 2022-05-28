using sycXF.Extensions;
using sycXF.Models.MyCloset;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace sycXF.Services.MyCloset
{
    public class MyClosetMockService : IMyClosetService
    {
        private ObservableCollection<MyClosetSeason> MockMyClosetSeason = new ObservableCollection<MyClosetSeason>
        {
            new MyClosetSeason { Id = 1, Season = "Winter Basics" },
            new MyClosetSeason { Id = 2, Season = "Spring Basics" },
            new MyClosetSeason { Id = 3, Season = "Summer Basics" },
            new MyClosetSeason { Id = 4, Season = "Fall Basics" },
            new MyClosetSeason { Id = 5, Season = "Always in Season" }
        };

        private ObservableCollection<MyClosetType> MockMyClosetType = new ObservableCollection<MyClosetType>
        {
            new MyClosetType { Id = 1, Type = "Mug" },
            new MyClosetType { Id = 2, Type = "T-Shirt" },
            new MyClosetType { Id = 3, Type = "Top" },
            new MyClosetType { Id = 4, Type = "Bottom" },
            new MyClosetType { Id = 5, Type = "Dress" },
            new MyClosetType { Id = 6, Type = "Outerwear" },
            new MyClosetType { Id = 7, Type = "Footwear" },
            new MyClosetType { Id = 8, Type = "Accessory" }
        };

        private ObservableCollection<MyClosetItem> MockMyCloset = new ObservableCollection<MyClosetItem>
        {
            new MyClosetItem
            {
                Id = Common.Common.MockMyClosetItemId01,
                PictureUri = "fake_product_01.png",
                Name = "Floral cap-sleeved blouse",
                Price = 19.50M,
                MyClosetSeasonId = 2,
                MyClosetSeason = "Spring Basics",
                MyClosetTypeId = 3,
                MyClosetType = "Top"
            },
            new MyClosetItem
            {
                Id = Common.Common.MockMyClosetItemId02,
                PictureUri = "fake_product_02.png",
                Name = "Floral skirt",
                Price = 19.50M,
                MyClosetSeasonId = 3,
                MyClosetSeason = "Summer Basics",
                MyClosetTypeId = 4,
                MyClosetType = "Bottom"
            },
            new MyClosetItem
            {
                Id = Common.Common.MockMyClosetItemId03,
                PictureUri = "fake_product_03.png",
                Name = "Black velvet tea-length dress",
                Price = 19.95M,
                MyClosetSeasonId = 1,
                MyClosetSeason = "Winter Basics",
                MyClosetTypeId = 5,
                MyClosetType = "Dress"
            },
            new MyClosetItem
            {
                Id = Common.Common.MockMyClosetItemId04,
                PictureUri = "fake_product_04.png",
                Name = "London Fog rain coat",
                Price = 17.00M,
                MyClosetSeasonId = 5,
                MyClosetSeason = "Always in Season",
                MyClosetTypeId = 6,
                MyClosetType = "Outerwear"
            },
            new MyClosetItem
            {
                Id = Common.Common.MockMyClosetItemId05,
                PictureUri = "fake_product_05.png",
                Name = "Black leather boots",
                Price = 19.50M,
                MyClosetSeasonId = 1,
                MyClosetSeason = "Winter Basics",
                MyClosetTypeId = 7,
                MyClosetType = "Footwear"
            },
            new MyClosetItem
            {
                Id = Common.Common.MockMyClosetItemId01,
                PictureUri = "fake_product_01.png",
                Name = "White button-down blouse",
                Price = 19.50M,
                MyClosetSeasonId = 2,
                MyClosetSeason = "Spring Basics",
                MyClosetTypeId = 3,
                MyClosetType = "Top"
            },
            new MyClosetItem
            {
                Id = Common.Common.MockMyClosetItemId02,
                PictureUri = "fake_product_02.png",
                Name = "White jean skirt",
                Price = 19.50M,
                MyClosetSeasonId = 3,
                MyClosetSeason = "Summer Basics",
                MyClosetTypeId = 4,
                MyClosetType = "Bottom"
            },
            new MyClosetItem
            {
                Id = Common.Common.MockMyClosetItemId03,
                PictureUri = "fake_product_03.png",
                Name = "Flannel long-sleeved dress",
                Price = 19.95M,
                MyClosetSeasonId = 4,
                MyClosetSeason = "Fall Basics",
                MyClosetTypeId = 5,
                MyClosetType = "Dress"
            },
            new MyClosetItem
            {
                Id = Common.Common.MockMyClosetItemId04,
                PictureUri = "fake_product_04.png",
                Name = "White Sweater",
                Price = 17.00M,
                MyClosetSeasonId = 5,
                MyClosetSeason = "Always in Season",
                MyClosetTypeId = 6,
                MyClosetType = "Outerwear"
            },
            new MyClosetItem
            {
                Id = Common.Common.MockMyClosetItemId05,
                PictureUri = "fake_product_05.png",
                Name = "Pearl Necklace",
                Price = 19.50M,
                MyClosetSeasonId = 1,
                MyClosetSeason = "Winter Basics",
                MyClosetTypeId = 8,
                MyClosetType = "Accessory"
            },
            new MyClosetItem
            {
                Id = Common.Common.MockMyClosetItemId05,
                PictureUri = "fake_product_05.png",
                Name = "Purse",
                Price = 19.50M,
                MyClosetSeasonId = 2,
                MyClosetSeason = "Spring Basics",
                MyClosetTypeId = 8,
                MyClosetType = "Accessory"
            },
            new MyClosetItem
            {
                Id = Common.Common.MockMyClosetItemId05,
                PictureUri = "fake_product_05.png",
                Name = "Jeans",
                Price = 19.50M,
                MyClosetSeasonId = 1,
                MyClosetSeason = "Winter Basics",
                MyClosetTypeId = 4,
                MyClosetType = "Bottom"
            }

        };

        public async Task<ObservableCollection<MyClosetItem>> GetMyClosetAsync()
        {
            await Task.Delay(10);

            return MockMyCloset;
        }

        public async Task<ObservableCollection<MyClosetItem>> FilterAsync(int catalogSeasonId, int catalogTypeId)
        {
            await Task.Delay(10);

            return MockMyCloset
                .Where(c => c.MyClosetSeasonId == catalogSeasonId &&
                c.MyClosetTypeId == catalogTypeId)
                .ToObservableCollection();
        }

        public async Task<ObservableCollection<MyClosetSeason>> GetMyClosetSeasonAsync()
        {
            await Task.Delay(10);

            return MockMyClosetSeason;
        }

        public async Task<ObservableCollection<MyClosetType>> GetMyClosetTypeAsync()
        {
            await Task.Delay(10);

            return MockMyClosetType;
        }
    }
}