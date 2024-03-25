using EStoreBackend.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Commands.Brand.UpdateBrand
{
    public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommandRequest, UpdateBrandCommandResponse>
    {
        private readonly IBrandWriteRepository _brandWriteRepository;
        private readonly IBrandReadRepository _brandReadRepository;
        public UpdateBrandCommandHandler(IBrandWriteRepository brandWriteRepository, IBrandReadRepository brandReadRepository)
        {
            _brandWriteRepository = brandWriteRepository;
            _brandReadRepository = brandReadRepository;
        }

        public async Task<UpdateBrandCommandResponse> Handle(UpdateBrandCommandRequest request, CancellationToken cancellationToken)
        {
            var brand = await _brandReadRepository.GetByIdAsync(request.Id);
            brand.BrandName = request.BrandName;
            await _brandWriteRepository.SaveAsync();
            return new();
        }
    }
}
