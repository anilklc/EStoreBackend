using EStoreBackend.Application.Constants;
using EStoreBackend.Application.Interfaces;
using EStoreBackend.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Commands.BrandImage.CreateBrandImage
{
    public class CreateBrandImageCommandHandler : IRequestHandler<CreateBrandImageCommandRequest, CreateBrandImageCommandResponse>
    {
        private readonly IBrandImageWriteRepository _brandImageWriteRepository;
        private readonly IFileHelper _fileHelper;

        public CreateBrandImageCommandHandler(IBrandImageWriteRepository brandImageWriteRepository, IFileHelper fileHelper)
        {
            _brandImageWriteRepository = brandImageWriteRepository;
            _fileHelper = fileHelper;
        }

        public async Task<CreateBrandImageCommandResponse> Handle(CreateBrandImageCommandRequest request, CancellationToken cancellationToken)
        {
            
            await _brandImageWriteRepository.AddAsync(new()
            {
                ImagePath = _fileHelper.Upload(request.FormFile, PathConstants.ImagesBrandAddPath),
                BrandId = Guid.Parse(request.BrandId),
            });
            await _brandImageWriteRepository.SaveAsync();
            return new();
        }
    }
}
