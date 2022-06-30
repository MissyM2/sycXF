using System.Collections.Generic;

namespace sycXF.Models.Closet
{
    public class ClosetRootModel
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; }
        public List<ClosetItemModel> Data { get; set; }
    }
}
