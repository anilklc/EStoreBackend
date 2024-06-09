using EStoreBackend.Application.Constants;
using EStoreBackend.Application.DTOs.Product;
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

namespace EStoreBackend.Application.Features.Queries.Product.GetAllProduct
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, GetAllProductQueryResponse>
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IHttpContextAccessor _contextAccessor;

        public GetAllProductQueryHandler(IProductReadRepository productReadRepository, IHttpContextAccessor contextAccessor)
        {
            _productReadRepository = productReadRepository;
            _contextAccessor = contextAccessor;
        }

        public async Task<GetAllProductQueryResponse> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            string baseUrl = $"{_contextAccessor.HttpContext.Request.Scheme}://{_contextAccessor.HttpContext.Request.Host}";
            var totalCount = await _productReadRepository.GetAll(false).CountAsync();
            var totalPages = (int)Math.Ceiling(totalCount / (double)request.Size);
            var products = await _productReadRepository.GetAll(false).Skip(request.Page * request.Size).Take(request.Size).ToListAsync();
            var productList = products.Select(p => new GetAllProductDto()
            {
                Id = p.Id.ToString(),
                ProductName = p.ProductName,
                CoverImagePath = $"{baseUrl}/{PathConstants.ImagesProductCoverPath}{p.ProductCoverImagePath}",       
                Price = p.Price,
            }).ToList();

            return new()
            {
                Products = productList,
                CurrentPage = request.Page,
                TotalPages = totalPages
            };
        }
    }
}
