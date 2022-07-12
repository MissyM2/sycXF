using Newtonsoft.Json;
using SQLite;

namespace sycXF.Models.Closet
{
    public class ClosetItemModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("PictureUri")]
        public string PictureUri { get; set; }

        [JsonProperty("Size")]
        public string Size { get; set; }

        [JsonProperty("Season")]
        public string Season { get; set; }

        [JsonProperty("ApparelType")]
        public string ApparelType { get; set; }
    }
}