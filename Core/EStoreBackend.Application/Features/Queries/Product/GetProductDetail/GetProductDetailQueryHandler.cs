using EStoreBackend.Application.Constants;
using EStoreBackend.Application.DTOs.Product;
using EStoreBackend.Application.DTOs.ProductImage;
using EStoreBackend.Application.DTOs.Stock;
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

namespace EStoreBackend.Application.Features.Queries.Product.GetProductDetail
{
    public class GetProductDetailQueryHandler : IRequestHandler<GetProductDetailQueryRequest, GetProductDetailQueryRespnose>
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IHttpContextAccessor _contextAccessor;

        public GetProductDetailQueryHandler(IProductReadRepository productReadRepository, IHttpContextAccessor contextAccessor)
        {
            _productReadRepository = productReadRepository;
            _contextAccessor = contextAccessor;
        }

        public async Task<GetProductDetailQueryRespnose> Handle(GetProductDetailQueryRequest request, CancellationToken cancellationToken)
        {
            string baseUrl = $"{_contextAccessor.HttpContext.Request.Scheme}://{_contextAccessor.HttpContext.Request.Host}";
            var product = await _productReadRepository.GetWhere(p=>p.Id == Guid.Parse(request.Id)).Include(s=>s.Stocks).Include(pi=>pi.ProductImages).ToListAsync();
            var productDetail = product.Select(p => new ProductDetailDto
            {
                Id = p.Id.ToString(),
                ProductName = p.ProductName,
                ProductDescription = p.ProductDescription,
                Price = p.Price,
                ProductImages = p.ProductImages.Select(pi => new ProductImageDto
                {
                    Id=pi.Id.ToString(),
                    ImagePath = $"{baseUrl}/{PathConstants.ImagesProductPath}{pi.ImagePath}",
                }).ToList(),
                Stock = p.Stocks.Select(s => new StockDto
                {
                    Id = s.Id.ToString(),
                    ProductSize = s.ProductSize,
                    ProductStock = s.ProductStock,
                }).ToList(),
            }).ToList();
            return new()
            {
                ProductDetail = productDetail,
            };
        }
    }
}
