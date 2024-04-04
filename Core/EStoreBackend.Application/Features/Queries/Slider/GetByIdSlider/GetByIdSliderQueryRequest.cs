using MediatR;

namespace EStoreBackend.Application.Features.Queries.Slider.GetByIdSlider
{
    public class GetByIdSliderQueryRequest  :IRequest<GetByIdSliderQueryResponse>
    {
        public string Id { get; set; }
    }
}