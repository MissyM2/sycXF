namespace sycXF.Models.MyCloset
{
    public class SeasonCategory
    {
        public int Id { get; set; }
        public string SeasonCategoryName { get; set; }
        public string IconGlyph { get; set; }
        public string img { get; set; }
        public byte[] ImgContent { get; set; }

        public override string ToString()
        {
            return SeasonCategoryName;
        }
    }
}