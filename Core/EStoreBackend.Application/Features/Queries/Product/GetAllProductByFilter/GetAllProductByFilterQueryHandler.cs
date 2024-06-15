using EStoreBackend.Application.Constants;
using EStoreBackend.Application.DTOs.Product;
using EStoreBackend.Application.Features.Queries.Product.GetAllProduct;
using EStoreBackend.Application.Interfaces.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Queries.Product.GetAllProductByFilter
{
    public class GetAllProductByFilterQueryHandler : IRequestHandler<GetAllProductByFilterQueryRequest, GetAllProductByFilterQueryResponse>
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IHttpContextAccessor _contextAccessor;

        public GetAllProductByFilterQueryHandler(IProductReadRepository productReadRepository, IHttpContextAccessor contextAccessor)
        {
            _productReadRepository = productReadRepository;
            _contextAccessor = contextAccessor;
        }

        public async Task<GetAllProductByFilterQueryResponse> Handle(GetAllProductByFilterQueryRequest request, CancellationToken cancellationToken)
        {
            string baseUrl = $"{_contextAccessor.HttpContext.Request.Scheme}://{_contextAccessor.HttpContext.Request.Host}";

            var query = _productReadRepository.GetAll(false).AsQueryable();

            if (!string.IsNullOrEmpty(request.CategoryName))
            {
                query = query.Where(p => p.Category.CategoryName == request.CategoryName);
            }

            if (!string.IsNullOrEmpty(request.BrandName))
            {
                query = query.Where(p => p.Brand.BrandName == request.BrandName);
            }

            if (request.MinPrice.HasValue)
            {
                query = query.Where(p => p.Price >= request.MinPrice.Value);
            }

            if (request.MaxPrice.HasValue)
            {
                query = query.Where(p => p.Price <= request.MaxPrice.Value);
            }

            var totalCount = await query.CountAsync();
            var totalPages = (int)Math.Ceiling(totalCount / (double)request.Size);

            var products = await query
                .Skip(request.Page * request.Size)
                .Take(request.Size)
                .ToListAsync();

            var productList = products.Select(p => new GetAllProductDto()
            {
                Id = p.Id.ToString(),
                ProductName = p.ProductName,
                CoverImagePath = $"{baseUrl}/{PathConstants.ImagesProductCoverPath}{p.ProductCoverImagePath}",
                Price = p.Price,
            }).ToList();

            return new ()
            {
                Products = productList,
                CurrentPage = request.Page,
                TotalPages = totalPages
            };
        }
    }
}
