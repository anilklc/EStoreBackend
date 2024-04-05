using EStoreBackend.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Queries.SliderImage.GetSliderImageById
{
    public class GetSliderImageByIdQueryHandler : IRequestHandler<GetSliderImageByIdQueryRequest, GetSliderImageByIdQueryResponse>
    {
        private readonly ISliderImageReadRepository _sliderImageReadRepository;

        public GetSliderImageByIdQueryHandler(ISliderImageReadRepository sliderImageReadRepository)
        {
            _sliderImageReadRepository = sliderImageReadRepository;
        }

        public async Task<GetSliderImageByIdQueryResponse> Handle(GetSliderImageByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var sliderImage = await _sliderImageReadRepository.GetByIdAsync(request.Id);
            return new()
            {
                Id = request.Id,
                ImagePath = sliderImage.ImagePath,
                SliderId = sliderImage.SliderId,
            };
        }
    }
}
