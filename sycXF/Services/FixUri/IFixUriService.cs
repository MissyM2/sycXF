using System.Collections.Generic;using sycXF.Models.Closet;

namespace sycXF.Services.FixUri
{
    public interface IFixUriService
    {
        void FixClosetItemPictureUri(IEnumerable<ClosetItemModel> catalogItems);
    }
}
