using EStoreBackend.Application.DTOs.BrandImage;

namespace EStoreBackend.Application.Features.Queries.BrandImage.GetBrandImageByBrandId
{
    public class GetBrandImageByBrandIdQueryResponse
    {
        public List<ListBrandImage> BrandImages {  get; set; }
    }
}