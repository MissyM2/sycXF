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
        public string Season { get; set; }
        public string ApparelType { get; set; }
    }
}