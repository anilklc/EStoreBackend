using EStoreBackend.Application.Constants;
using EStoreBackend.Application.Interfaces.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Queries.Slider.GetAllActiveSlider
{
    public class GetAllActiveSliderQueryHandler : IRequestHandler<GetAllActiveSliderQueryRequest, GetAllActiveSliderQueryResponse>
    {
        private readonly ISliderReadRepository _sliderReadRepository;
        private readonly IHttpContextAccessor _contextAccessor;

        public GetAllActiveSliderQueryHandler(ISliderReadRepository sliderReadRepository, IHttpContextAccessor contextAccessor)
        {
            _sliderReadRepository = sliderReadRepository;
            _contextAccessor = contextAccessor;
        }

        public async Task<GetAllActiveSliderQueryResponse> Handle(GetAllActiveSliderQueryRequest request, CancellationToken cancellationToken)
        {
            string baseUrl = $"{_contextAccessor.HttpContext.Request.Scheme}://{_contextAccessor.HttpContext.Request.Host}";
            var sliders = await _sliderReadRepository.GetWhere(s=>s.SliderActive == true).ToListAsync();
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
