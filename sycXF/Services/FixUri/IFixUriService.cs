using System.Collections.Generic;using sycXF.Models.MyCloset;

namespace sycXF.Services.FixUri
{
    public interface IFixUriService
    {
        void FixMyClosetItemPictureUri(IEnumerable<MyClosetItem> catalogItems);
    }
}
