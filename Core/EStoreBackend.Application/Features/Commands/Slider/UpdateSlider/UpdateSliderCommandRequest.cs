using MediatR;
using Microsoft.AspNetCore.Http;

namespace EStoreBackend.Application.Features.Commands.Slider.UpdateSlider
{
    public class UpdateSliderCommandRequest : IRequest<UpdateSliderCommandResponse>
    {
        public string Id { get; set; }
        public string SliderTitle { get; set; }
        public string SliderSubtitle { get; set; }
        public string? SliderImagePath { get; set; }
        public string SliderTargetUrl { get; set; }
        public bool SliderActive { get; set; }
    }
}