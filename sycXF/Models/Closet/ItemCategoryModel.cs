using System;
using Newtonsoft.Json;
using SQLite;

namespace sycXF.Models.Closet
{
    public class ItemCategoryModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [JsonProperty("CategoryType")]
        public string CategoryType { get; set; }

        [JsonProperty("CategoryName")]
        public string CategoryName { get; set; }

        [JsonProperty("CategoryTitle")]
        public string CategoryTitle { get; set; }

        [JsonProperty("IconGlyph")]
        public string IconGlyph { get; set; }

        [JsonProperty("IconFamily")]
        public string IconFamily { get; set; }

        [JsonProperty("PictureUri")]
        public string PictureUri { get; set; }

        [JsonProperty("Img")]
        public string Img { get; set; }

        [JsonProperty("ImgContent")]
        public byte[] ImgContent { get; set; }

        public override string ToString()
        {
            return CategoryName;
        }
    }
}

