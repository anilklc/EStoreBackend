using EStoreBackend.Application.Constants;
using EStoreBackend.Application.DTOs.BrandImage;
using EStoreBackend.Application.Interfaces.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace EStoreBackend.Application.Features.Queries.BrandImage.GetBrandImageByBrandId
{
    public class GetBrandImageByBrandIdQueryHandler : IRequestHandler<GetBrandImageByBrandIdQueryRequest, GetBrandImageByBrandIdQueryResponse>
    {
        private readonly IBrandImageReadRepository _brandImageReadRepository;
        private readonly IHttpContextAccessor _contextAccessor;

        public GetBrandImageByBrandIdQueryHandler(IBrandImageReadRepository brandImageReadRepository, IHttpContextAccessor contextAccessor)
        {
            _brandImageReadRepository = brandImageReadRepository;
            _contextAccessor = contextAccessor;
        }

        public async Task<GetBrandImageByBrandIdQueryResponse> Handle(GetBrandImageByBrandIdQueryRequest request, CancellationToken cancellationToken)
        {
            string baseUrl = $"{_contextAccessor.HttpContext.Request.Scheme}://{_contextAccessor.HttpContext.Request.Host}";
            var files = await _brandImageReadRepository.GetWhere(b => b.BrandId == Guid.Parse(request.BrandId)).Include(br => br.Brand).ToListAsync();
            var brandImages = files.Select(b => new ListBrandImage
            {
                Id = b.Id.ToString(),
                ImagePath = $"{baseUrl}/{PathConstants.ImagesBrandPath}{b.ImagePath}",
                BrandName = b.Brand.BrandName,
                BrandId = b.BrandId.ToString(),
            }).ToList();
            return new GetBrandImageByBrandIdQueryResponse()
            {
                BrandImages = brandImages,

            };
        }
    }
}
