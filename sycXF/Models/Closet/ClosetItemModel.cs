using Newtonsoft.Json;
using sycXF.Services.Database;

namespace sycXF.Models.Closet
{
    public class ClosetItemModel : BaseDatabaseItem
    {
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

        [JsonProperty("Type")]
        public string Type { get; set; }
    }
}