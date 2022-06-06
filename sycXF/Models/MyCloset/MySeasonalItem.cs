using System;
namespace sycXF.Models.MyCloset
{
	public class MySeasonalItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureUri { get; set; }
        public int MyClosetSizeId { get; set; }
        public string MyClosetSize { get; set; }
        public int SeasonId { get; set; }
        public string Season { get; set; }
        public int MyClosetTypeId { get; set; }
        public string MyClosetType { get; set; }
    }
}

