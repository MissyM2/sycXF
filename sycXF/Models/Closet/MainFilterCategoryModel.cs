using System;
using Newtonsoft.Json;
using SQLite;

namespace sycXF.Models.Closet
{
    public class MainFilterCategoryModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [JsonProperty("PropertyName")]
        public string PropertyName { get; set; }
    }
}