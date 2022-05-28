namespace sycXF.Models.MyCloset
{
    public class MyClosetItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUri { get; set; }
        public int MyClosetSeasonId { get; set; }
        public string MyClosetSeason { get; set; }
        public int MyClosetTypeId { get; set; }
        public string MyClosetType { get; set; }
    }
}