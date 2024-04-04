using EStoreBackend.Application.Constants;
using EStoreBackend.Application.Interfaces.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Queries.Slider.GetAllSlider
{
    public class GetAllSliderQueryHandler : IRequestHandler<GetAllSliderQueryRequest, GetAllSliderQueryResponse>
    {
        private readonly ISliderReadRepository _sliderReadRepository;
        private readonly IHttpContextAccessor _contextAccessor;

        public GetAllSliderQueryHandler(ISliderReadRepository sliderReadRepository, IHttpContextAccessor contextAccessor)
        {
            _sliderReadRepository = sliderReadRepository;
            _contextAccessor = contextAccessor;
        }

        public async Task<GetAllSliderQueryResponse> Handle(GetAllSliderQueryRequest request, CancellationToken cancellationToken)
        {
            string baseUrl = $"{_contextAccessor.HttpContext.Request.Scheme}://{_contextAccessor.HttpContext.Request.Host}";
            var sliders = _sliderReadRepository.GetAll().ToList();
            foreach (var slider in sliders)
            {
                if (!string.IsNullOrEmpty(slider.SliderImagePath))
                {
                    slider.SliderImagePath = $"{baseUrl}/{PathConstants.ImagesSliderPath}{slider.SliderImagePath}";
                }
            }
            return new()
            {
                Sliders = sliders,
            };
        }
    }
}
