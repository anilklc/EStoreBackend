using EStoreBackend.Application.Constants;
using EStoreBackend.Application.DTOs.Product;
using EStoreBackend.Application.DTOs.SliderImage;
using EStoreBackend.Application.Interfaces.Repositories;
using EStoreBackend.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Queries.Product.GetAllProductAdmin
{
    public class GetAllProductAdminQueryHandler : IRequestHandler<GetAllProductAdminQueryRequest, GetAllProductAdminQueryResponse>
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IHttpContextAccessor _contextAccessor;

        public GetAllProductAdminQueryHandler(IProductReadRepository productReadRepository, IHttpContextAccessor contextAccessor)
        {
            _productReadRepository = productReadRepository;
            _contextAccessor = contextAccessor;
        }

        public async Task<GetAllProductAdminQueryResponse> Handle(GetAllProductAdminQueryRequest request, CancellationToken cancellationToken)
        {
            string baseUrl = $"{_contextAccessor.HttpContext.Request.Scheme}://{_contextAccessor.HttpContext.Request.Host}";
            var products = await _productReadRepository.GetAll(false).Include(b=>b.Brand).Include(c=>c.Category).ToListAsync();
            var allProduts = products.Select(p => new GetAllProductAdminDto
            {
                Id = p.Id.ToString(),
                ProductName = p.ProductName,
                ProductDescription = p.ProductDescription,
                Price = p.Price,
                ProductCoverImagePath = $"{baseUrl}/{PathConstants.ImagesProductCoverPath}{p.ProductCoverImagePath}",
                CategoryId = p.CategoryId,
                CategoryName = p.Category.CategoryName,
                BrandId = p.Brand.Id,
                BrandName = p.Brand.BrandName,
            }).ToList();
            return new()
            {
                Products = allProduts
            };
        }
    }
}
