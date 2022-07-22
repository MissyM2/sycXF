using Newtonsoft.Json;
using sycXF.Services.Database;

namespace sycXF.Models.Closet
{
    public class MainFilterCategoryModel : BaseDatabaseItem
    {
        [JsonProperty("PropertyName")]
        public string PropertyName { get; set; }
    }
}