using MediatR;

namespace EStoreBackend.Application.Features.Queries.SliderImage.GetSliderImageById
{
    public class GetSliderImageByIdQueryRequest : IRequest<GetSliderImageByIdQueryResponse>
    {
        public string Id { get; set; }
    }
}