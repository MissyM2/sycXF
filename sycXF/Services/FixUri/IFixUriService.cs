using System.Collections.Generic;
using sycXF.Models.Basket;
using sycXF.Models.Catalog;

namespace sycXF.Services.FixUri
{
    public interface IFixUriService
    {
        void FixCatalogItemPictureUri(IEnumerable<CatalogItem> catalogItems);
        void FixBasketItemPictureUri(IEnumerable<BasketItem> basketItems);
    }
}
