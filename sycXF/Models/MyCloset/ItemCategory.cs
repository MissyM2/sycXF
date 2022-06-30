using System;
namespace sycXF.Models.MyCloset
{
    public class ItemCategory
    {
        public int Id { get; set; }
        public string CategoryType { get; set; }
        public string CategoryName { get; set; }
        public string CategoryTitle { get; set; }
        public string IconGlyph { get; set; }
        public string IconFamily { get; set; }
        public string PictureUri { get; set; }
        public string img { get; set; }
        public byte[] ImgContent { get; set; }

        public override string ToString()
        {
            return CategoryName;
        }
    }
}

