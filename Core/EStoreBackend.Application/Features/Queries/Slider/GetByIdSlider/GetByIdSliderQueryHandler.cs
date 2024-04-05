using EStoreBackend.Application.Constants;
using EStoreBackend.Application.Interfaces.Repositories;
using EStoreBackend.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Queries.Slider.GetByIdSlider
{
    public class GetByIdSliderQueryHandler : IRequestHandler<GetByIdSliderQueryRequest, GetByIdSliderQueryResponse>
    {
        private readonly ISliderReadRepository _sliderReadRepository;

        public GetByIdSliderQueryHandler(ISliderReadRepository sliderReadRepository)
        {
            _sliderReadRepository = sliderReadRepository;
        }

        public async Task<GetByIdSliderQueryResponse> Handle(GetByIdSliderQueryRequest request, CancellationToken cancellationToken)
        {
            var slider = await _sliderReadRepository.GetByIdAsync(request.Id);
            
            return new()
            {
                Id = request.Id,
                SliderSubtitle = slider.SliderSubtitle,
                SliderTitle = slider.SliderTitle,
                SliderTargetUrl = slider.SliderTargetUrl,
                SliderActive = slider.SliderActive,
            };
        }
    }
}
