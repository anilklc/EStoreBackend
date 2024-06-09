using EStoreBackend.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Queries.ProductImage.GetProductImageById
{
    public class GetProductImageByIdQueryHandler : IRequestHandler<GetProductImageByIdQueryRequest, GetProductImageByIdQueryResponse>
    {
        private readonly IProductImageReadRepository _productImageReadRepository;

        public GetProductImageByIdQueryHandler(IProductImageReadRepository productImageReadRepository)
        {
            _productImageReadRepository = productImageReadRepository;
        }

        public async Task<GetProductImageByIdQueryResponse> Handle(GetProductImageByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var productImage = await _productImageReadRepository.GetByIdAsync(request.Id);
            return new()
            {
                Id = request.Id,
                ProductId = productImage.ProductId.ToString(),
                ImagePath = productImage.ImagePath,
            };
        }
    }
}
