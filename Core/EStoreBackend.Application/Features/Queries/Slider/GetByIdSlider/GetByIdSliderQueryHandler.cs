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
        private readonly IHttpContextAccessor _contextAccessor;

        public GetByIdSliderQueryHandler(ISliderReadRepository sliderReadRepository, IHttpContextAccessor contextAccessor)
        {
            _sliderReadRepository = sliderReadRepository;
            _contextAccessor = contextAccessor;
        }

        public async Task<GetByIdSliderQueryResponse> Handle(GetByIdSliderQueryRequest request, CancellationToken cancellationToken)
        {
            string baseUrl = $"{_contextAccessor.HttpContext.Request.Scheme}://{_contextAccessor.HttpContext.Request.Host}";
            var slider = await _sliderReadRepository.GetByIdAsync(request.Id);
            
            return new()
            {
                Id = request.Id,
                SliderSubtitle = slider.SliderSubtitle,
                SliderTitle = slider.SliderTitle,
                SliderImagePath = $"{baseUrl}/{PathConstants.ImagesSliderPath}{slider.SliderImagePath}",
                SliderTargetUrl = slider.SliderTargetUrl,
                SliderActive = slider.SliderActive,
            };
        }
    }
}
