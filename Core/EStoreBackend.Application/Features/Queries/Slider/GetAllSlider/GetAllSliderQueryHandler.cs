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

        public GetAllSliderQueryHandler(ISliderReadRepository sliderReadRepository)
        {
            _sliderReadRepository = sliderReadRepository;
        }

        public async Task<GetAllSliderQueryResponse> Handle(GetAllSliderQueryRequest request, CancellationToken cancellationToken)
        {
            var sliders = _sliderReadRepository.GetAll().ToList();
            return new()
            {
                Sliders = sliders,
            };
        }
    }
}
