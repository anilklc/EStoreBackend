using MediatR;
using Microsoft.AspNetCore.Http;

namespace EStoreBackend.Application.Features.Commands.Slider.CreateSlider
{
    public class CreateSliderCommandRequest : IRequest<CreateSliderCommandResponse>
    {
        public string SliderTitle { get; set; }
        public string SliderSubtitle { get; set; }
        public string SliderTargetUrl { get; set; }
        public bool SliderActive { get; set; }
    }
}