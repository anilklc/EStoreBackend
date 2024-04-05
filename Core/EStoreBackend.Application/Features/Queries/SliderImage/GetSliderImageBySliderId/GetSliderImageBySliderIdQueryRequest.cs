using EStoreBackend.Application.DTOs.BrandImage;
using EStoreBackend.Application.DTOs.SliderImage;
using MediatR;

namespace EStoreBackend.Application.Features.Queries.SliderImage.GetSliderImageBySliderId
{
    public class GetSliderImageBySliderIdQueryRequest : IRequest<GetSliderImageBySliderIdQueryResponse>
    {
        public string SliderId { get; set; }
    }
}