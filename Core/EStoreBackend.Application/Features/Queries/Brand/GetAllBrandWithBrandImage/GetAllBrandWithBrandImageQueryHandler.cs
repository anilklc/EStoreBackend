using EStoreBackend.Application.Constants;
using EStoreBackend.Application.DTOs.BrandImage;
using EStoreBackend.Application.Features.Queries.BrandImage.GetBrandImageByBrandId;
using EStoreBackend.Application.Interfaces.Repositories;
using EStoreBackend.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Queries.Brand.GetAllBrandWithBrandImage
{
    public class GetAllBrandWithBrandImageQueryHandler : IRequestHandler<GetAllBrandWithBrandImageQueryRequest, GetAllBrandWithBrandImageQueryResponse>
    {
        private readonly IBrandReadRepository _brandReadRepository;
        private readonly IHttpContextAccessor _contextAccessor;

        public GetAllBrandWithBrandImageQueryHandler(IBrandReadRepository brandReadRepository, IHttpContextAccessor contextAccessor)
        {
            _brandReadRepository = brandReadRepository;
            _contextAccessor = contextAccessor;
        }

        public async Task<GetAllBrandWithBrandImageQueryResponse> Handle(GetAllBrandWithBrandImageQueryRequest request, CancellationToken cancellationToken)
        {
            string baseUrl = $"{_contextAccessor.HttpContext.Request.Scheme}://{_contextAccessor.HttpContext.Request.Host}";
            var files = await _brandReadRepository.GetAll().Include(br => br.BrandImages).ToListAsync();
            var brandWithImages = files.SelectMany(brand => brand.BrandImages.Select(brandImage => new ListBrandWithBrandImage
            {
                Id = brandImage.Id.ToString(),
                ImagePath = $"{baseUrl}/{PathConstants.ImagesBrandPath}{brandImage.ImagePath}",
                BrandName = brand.BrandName,
                BrandImageId = brandImage.Id.ToString()
            })).ToList();
            return new ()
            {
                BrandWithImages = brandWithImages,

            };
        }
    }
}
