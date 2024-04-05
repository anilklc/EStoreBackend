using EStoreBackend.Application.Constants;
using EStoreBackend.Application.DTOs.BrandImage;
using EStoreBackend.Application.DTOs.SliderImage;
using EStoreBackend.Application.Features.Queries.BrandImage.GetBrandImageByBrandId;
using EStoreBackend.Application.Interfaces.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Queries.SliderImage.GetSliderImageBySliderId
{
    public class GetSliderImageBySliderIdQueryHandler : IRequestHandler<GetSliderImageBySliderIdQueryRequest, GetSliderImageBySliderIdQueryResponse>
    {
        private readonly ISliderImageReadRepository _sliderImageReadRepository;
        private readonly IHttpContextAccessor _contextAccessor;

        public GetSliderImageBySliderIdQueryHandler(ISliderImageReadRepository sliderImageReadRepository, IHttpContextAccessor contextAccessor)
        {
            _sliderImageReadRepository = sliderImageReadRepository;
            _contextAccessor = contextAccessor;
        }

        public async Task<GetSliderImageBySliderIdQueryResponse> Handle(GetSliderImageBySliderIdQueryRequest request, CancellationToken cancellationToken)
        {
            string baseUrl = $"{_contextAccessor.HttpContext.Request.Scheme}://{_contextAccessor.HttpContext.Request.Host}";
            var files = await _sliderImageReadRepository.GetWhere(s => s.SliderId == Guid.Parse(request.SliderId)).Include(sl => sl.Slider).ToListAsync();
            var sliderImages = files.Select(s => new ListSliderWithSliderImage
            {
                Id = s.Id.ToString(),
                ImagePath = $"{baseUrl}/{PathConstants.ImagesSliderPath}{s.ImagePath}",
                SliderId = s.SliderId.ToString(),
                SliderTitle = s.Slider.SliderTitle,
                SliderActive = s.Slider.SliderActive,
                SliderSubtitle = s.Slider.SliderSubtitle,
                SliderTargetUrl = s.Slider.SliderTargetUrl,
            }).ToList();
            return new ()
            {
                SliderImages = sliderImages,

            };
        }
    }
}
