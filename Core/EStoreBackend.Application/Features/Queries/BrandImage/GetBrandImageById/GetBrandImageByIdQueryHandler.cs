using EStoreBackend.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Queries.BrandImage.GetBrandImageById
{
    public class GetBrandImageByIdQueryHandler : IRequestHandler<GetBrandImageByIdQueryRequest, GetBrandImageByIdQueryResponse>
    {
        private readonly IBrandImageReadRepository _brandImageReadRepository;

        public GetBrandImageByIdQueryHandler(IBrandImageReadRepository brandImageReadRepository)
        {
            _brandImageReadRepository = brandImageReadRepository;
        }

        public async Task<GetBrandImageByIdQueryResponse> Handle(GetBrandImageByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var brandImage = await _brandImageReadRepository.GetByIdAsync(request.Id);
            return new()
            {
                Id = request.Id,
                BrandId = brandImage.BrandId.ToString(),
                ImagePath = brandImage.ImagePath,
            };    
        }
    }
}
