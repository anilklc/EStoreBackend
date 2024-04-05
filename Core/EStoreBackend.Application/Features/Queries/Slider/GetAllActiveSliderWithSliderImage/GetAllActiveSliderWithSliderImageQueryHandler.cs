using EStoreBackend.Application.Constants;
using EStoreBackend.Application.DTOs.BrandImage;
using EStoreBackend.Application.DTOs.SliderImage;
using EStoreBackend.Application.Interfaces.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Queries.Slider.GetAllActiveSliderWithSliderImage
{
    public class GetAllActiveSliderWithSliderImageQueryHandler : IRequestHandler<GetAllActiveSliderWithSliderImageQueryRequest, GetAllActiveSliderWithSliderImageQueryResponse>
    {
        private readonly ISliderReadRepository _sliderReadRepository;
        private readonly IHttpContextAccessor _contextAccessor;

        public GetAllActiveSliderWithSliderImageQueryHandler(ISliderReadRepository sliderReadRepository, IHttpContextAccessor contextAccessor)
        {
            _sliderReadRepository = sliderReadRepository;
            _contextAccessor = contextAccessor;
        }

        public async Task<GetAllActiveSliderWithSliderImageQueryResponse> Handle(GetAllActiveSliderWithSliderImageQueryRequest request, CancellationToken cancellationToken)
        {
            string baseUrl = $"{_contextAccessor.HttpContext.Request.Scheme}://{_contextAccessor.HttpContext.Request.Host}";
            var files = await _sliderReadRepository.GetWhere(s=>s.SliderActive==true).Include(s => s.SliderImages).ToListAsync();
            var sliderWithImages = files.SelectMany(slider => slider.SliderImages.Select(slideImage => new ListSliderWithSliderImage
            {
                Id = slideImage.Id.ToString(),
                ImagePath = $"{baseUrl}/{PathConstants.ImagesSliderPath}{slideImage.ImagePath}",
                SliderId = slideImage.SliderId.ToString(),
                SliderTitle = slider.SliderTitle,
                SliderActive = slider.SliderActive,
                SliderSubtitle = slider.SliderSubtitle,
                SliderTargetUrl = slider.SliderTargetUrl,
            })).ToList();
            return new()
            {
                SliderWithSliderImages = sliderWithImages,

            };
        }
    }
}
