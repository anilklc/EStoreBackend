using EStoreBackend.Application.Constants;
using EStoreBackend.Application.DTOs.ProductImage;
using EStoreBackend.Application.Interfaces.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Queries.ProductImage.GetProductImageByProductId
{
    public class GetProductImageByProductIdQueryHandler : IRequestHandler<GetProductImageByProductIdQueryRequest, GetProductImageByProductIdQueryResponse>
    {
        private readonly IProductImageReadRepository _productImageReadRepository;
        private readonly IHttpContextAccessor _contextAccessor;

        public GetProductImageByProductIdQueryHandler(IProductImageReadRepository productImageReadRepository, IHttpContextAccessor contextAccessor)
        {
            _productImageReadRepository = productImageReadRepository;
            _contextAccessor = contextAccessor;
        }

        public async Task<GetProductImageByProductIdQueryResponse> Handle(GetProductImageByProductIdQueryRequest request, CancellationToken cancellationToken)
        {
            string baseUrl = $"{_contextAccessor.HttpContext.Request.Scheme}://{_contextAccessor.HttpContext.Request.Host}";
            var files = await _productImageReadRepository.GetWhere(p => p.ProductId == Guid.Parse(request.ProductId)).Include(pr => pr.Product).ToListAsync();
            var productImages = files.Select(p => new ListProductImage
            {
                Id = p.Id.ToString(),
                ImagePath = $"{baseUrl}/{PathConstants.ImagesProductPath}{p.ImagePath}",
                ProductName = p.Product.ProductName,
                ProductId = p.ProductId.ToString(),
            }).ToList();
            return new GetProductImageByProductIdQueryResponse()
            {
                ProductImages = productImages,

            };
        }
    }
}
