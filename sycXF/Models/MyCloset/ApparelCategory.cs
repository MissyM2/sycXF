namespace sycXF.Models.MyCloset
{
    public class ApparelCategory
    {
        public int Id { get; set; }
        public string ApparelCategoryName { get; set; }
        public string ApparelCategoryTitle { get; set; }
        public string IconFamily { get; set; }
        public string IconGlyph { get; set; }
        public string PictureUri { get; set; }

        public override string ToString()
        {
            return ApparelCategoryName;
        }
    }
}