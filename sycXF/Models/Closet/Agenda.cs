using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using sycXF.Services.Database;

namespace sycXF.Models.Closet
{
    public class Agenda : BaseDatabaseItem
    {
        [JsonProperty("Color")]
        public string Color { get; set; }

        [JsonProperty("CategoryType")]
        public string CategoryType { get; set; }

        [JsonProperty("CategoryName")]
        public string CategoryName { get; set; }

        [JsonProperty("CategoryTitle")]
        public string CategoryTitle { get; set; }

        [JsonProperty("CategoryCount")]
        public int CategoryCount { get; set; }

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

        [JsonProperty("ClosetItems")]
        public ObservableCollection<ClosetItemModel> ClosetItems { get; set; }
    }
}

