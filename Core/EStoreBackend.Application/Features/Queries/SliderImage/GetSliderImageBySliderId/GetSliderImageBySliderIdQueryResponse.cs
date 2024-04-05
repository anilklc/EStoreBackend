using EStoreBackend.Application.DTOs.SliderImage;

namespace EStoreBackend.Application.Features.Queries.SliderImage.GetSliderImageBySliderId
{
    public class GetSliderImageBySliderIdQueryResponse
    {
        public List<ListSliderWithSliderImage> SliderImages { get; set; }
    }
}