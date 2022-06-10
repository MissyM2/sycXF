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

        private Random RandomGenerator = new Random();
        private int newItemId = 0;


        private ObservableCollection<Season> MockSeason = new ObservableCollection<Season>
        {
            new Season { Id = 1, Name = "Winter" },
            new Season { Id = 2, Name = "Spring" },
            new Season { Id = 3, Name = "Summer" },
            new Season { Id = 4, Name = "Fall" },
            new Season { Id = 5, Name = "Always in Season" }
        };

        private ObservableCollection<MyClosetType> MockMyClosetType = new ObservableCollection<MyClosetType>
        {
            new MyClosetType { Id = 3, Type = "Top" },
            new MyClosetType { Id = 4, Type = "Bottom" },
            new MyClosetType { Id = 5, Type = "Dress" },
            new MyClosetType { Id = 6, Type = "Outerwear" },
            new MyClosetType { Id = 7, Type = "Footwear" },
            new MyClosetType { Id = 8, Type = "Accessory" }
        };

        private ObservableCollection<MyClosetSize> MockMyClosetSize = new ObservableCollection<MyClosetSize>
        {
            new MyClosetSize { Id = 1, Size = "XSmall" },
            new MyClosetSize { Id = 2, Size = "Small" },
            new MyClosetSize { Id = 3, Size = "Medium" },
            new MyClosetSize { Id = 4, Size = "Large" },
            new MyClosetSize { Id = 5, Size = "XLarge" },
            new MyClosetSize { Id = 6, Size = "XSmall" },

        };

        //public List<MyClosetItem> GetClosetItems()
        //{
        //    return allItems
        //        .Select(b => new MyClosetItem
        //        {
        //            Id = b.Id,
        //            Name = b.Name,
        //            Description = b.Description,
        //            PictureUri = b.PictureUri,
        //            MyClosetSizeId = b.MyClosetSizeId,
        //            MyClosetSize = b.MyClosetSize,
        //            SeasonId = b.SeasonId,
        //            Season = b.CurrentSeason,
        //            MyClosetTypeId = b.MyClosetTypeId,
        //            MyClosetType = b.MyClosetType

        //        }).ToList();
        //}

        private ObservableCollection<MyClosetItem> MockMyCloset = new ObservableCollection<MyClosetItem>
        {
            new MyClosetItem
            {
                Id = 1,
                PictureUri = "fake_product_01.png",
                Name = "Floral cap-sleeved blouse",
                Description="a;lsdkfj;alskdfj;alskdjf;alskdjf;aslkdjf",
                MyClosetSizeId = 2,
                MyClosetSize = "Small",
                SeasonId = 2,
                Season = "Spring Basics",
                MyClosetTypeId = 3,
                MyClosetType = "Top"
            },
            new MyClosetItem
            {
                Id = 2,
                PictureUri = "fake_product_02.png",
                Name = "Floral skirt",
                Description="a;lsdkfj;alskdfj;alskdjf;alskdjf;aslkdjf",
                MyClosetSizeId = 2,
                MyClosetSize = "Small",
                SeasonId = 3,
                Season = "Summer Basics",
                MyClosetTypeId = 4,
                MyClosetType = "Bottom"
            },
            new MyClosetItem
            {
                Id = 3,
                PictureUri = "fake_product_03.png",
                Name = "Black tea-length dress",
                Description="a;lsdkfj;alskdfj;alskdjf;alskdjf;aslkdjf",
                MyClosetSizeId = 3,
                MyClosetSize = "Medium",
                SeasonId = 1,
                Season = "Winter Basics",
                MyClosetTypeId = 5,
                MyClosetType = "Dress"
            },
            new MyClosetItem
            {
                Id = 4,
                PictureUri = "fake_product_04.png",
                Name = "London Fog rain coat",
                Description="a;lsdkfj;alskdfj;alskdjf;alskdjf;aslkdjf",
                MyClosetSizeId = 4,
                MyClosetSize = "Large",
                SeasonId = 5,
                Season = "Always in Season",
                MyClosetTypeId = 6,
                MyClosetType = "Outerwear"
            },
            new MyClosetItem
            {
                Id = 5,
                PictureUri = "fake_product_05.png",
                Name = "Black leather boots",
                Description="a;lsdkfj;alskdfj;alskdjf;alskdjf;aslkdjf",
                MyClosetSizeId = 2,
                MyClosetSize = "Small",
                Season = "Winter Basics",
                MyClosetTypeId = 7,
                MyClosetType = "Footwear"
            },
            new MyClosetItem
            {
                Id = 6,
                PictureUri = "fake_product_01.png",
                Name = "White button-down blouse",
                Description="a;lsdkfj;alskdfj;alskdjf;alskdjf;aslkdjf",
                MyClosetSizeId = 3,
                MyClosetSize = "Medium",
                Season = "Spring Basics",
                MyClosetTypeId = 3,
                MyClosetType = "Top"
            },
            new MyClosetItem
            {
                Id = 7,
                PictureUri = "fake_product_02.png",
                Name = "White jean skirt",
                Description="a;lsdkfj;alskdfj;alskdjf;alskdjf;aslkdjf",
                MyClosetSizeId = 4,
                MyClosetSize = "Large",
                SeasonId = 3,
                Season = "Summer Basics",
                MyClosetTypeId = 4,
                MyClosetType = "Bottom"
            },
            new MyClosetItem
            {
                Id = 8,
                PictureUri = "fake_product_03.png",
                Name = "Flannel long-sleeved dress",
                Description="a;lsdkfj;alskdfj;alskdjf;alskdjf;aslkdjf",
                MyClosetSizeId = 2,
                MyClosetSize = "Small",
                SeasonId = 4,
                Season = "Fall Basics",
                MyClosetTypeId = 5,
                MyClosetType = "Dress"
            },
            new MyClosetItem
            {
                Id = 9,
                PictureUri = "fake_product_04.png",
                Name = "White Sweater",
                Description="a;lsdkfj;alskdfj;alskdjf;alskdjf;aslkdjf",
                MyClosetSizeId = 3,
                MyClosetSize = "Medium",
                SeasonId = 5,
                Season = "Always in Season",
                MyClosetTypeId = 6,
                MyClosetType = "Outerwear"
            },
            new MyClosetItem
            {
                Id = 10,
                PictureUri = "fake_product_05.png",
                Name = "Pearl Necklace",
                Description="a;lsdkfj;alskdfj;alskdjf;alskdjf;aslkdjf",
                MyClosetSizeId = 3,
                MyClosetSize = "Medium",
                SeasonId = 1,
                Season = "Winter Basics",
                MyClosetTypeId = 8,
                MyClosetType = "Accessory"
            },
            new MyClosetItem
            {
                Id = 11,
                PictureUri = "fake_product_05.png",
                Name = "Purse",
                Description="a;lsdkfj;alskdfj;alskdjf;alskdjf;aslkdjf",
                MyClosetSizeId = 4,
                MyClosetSize = "Large",
                SeasonId = 2,
                Season = "Spring Basics",
                MyClosetTypeId = 8,
                MyClosetType = "Accessory"
            },
            new MyClosetItem
            {
                Id = 12,
                PictureUri = "fake_product_05.png",
                Name = "Jeans",
                Description="a;lsdkfj;alskdfj;alskdjf;alskdjf;aslkdjf",
                MyClosetSizeId = 2,
                MyClosetSize = "Small",
                SeasonId = 1,
                Season = "Winter Basics",
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
                .Where(c => c.SeasonId == catalogSeasonId &&
                c.MyClosetTypeId == catalogTypeId)
                .ToObservableCollection();
        }

        public async Task<ObservableCollection<Season>> GetSeasonAsync()
        {
            await Task.Delay(10);

            return MockSeason;
        }

        public async Task<ObservableCollection<MyClosetType>> GetMyClosetTypeAsync()
        {
            await Task.Delay(10);

            return MockMyClosetType;
        }
    }
}