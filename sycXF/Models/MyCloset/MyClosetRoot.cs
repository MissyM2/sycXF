using System.Collections.Generic;

namespace sycXF.Models.MyCloset
{
    public class MyClosetRoot
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; }
        public List<MyClosetItem> Data { get; set; }
    }
}
