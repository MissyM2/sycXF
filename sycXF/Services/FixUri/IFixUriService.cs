using System.Collections.Generic;
using sycXF.Models.Basket;
using sycXF.Models.MyCloset;

namespace sycXF.Services.FixUri
{
    public interface IFixUriService
    {
        void FixMyClosetItemPictureUri(IEnumerable<MyClosetItem> catalogItems);
        void FixBasketItemPictureUri(IEnumerable<BasketItem> basketItems);
    }
}
