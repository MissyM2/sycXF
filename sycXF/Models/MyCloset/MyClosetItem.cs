namespace sycXF.Models.MyCloset
{
    public class MyClosetItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureUri { get; set; }
        public int SizeCategoryId { get; set; }
        public string SizeCategoryName { get; set; }
        public int SeasonCategoryId { get; set; }
        public string SeasonCategoryName { get; set; }
        public int ApparelCategoryId { get; set; }
        public string ApparelCategoryName { get; set; }
    }
}