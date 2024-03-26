using MediatR;
using Microsoft.AspNetCore.Http;

namespace EStoreBackend.Application.Features.Commands.BrandImage.UpdateBrandImage
{
    public class UpdateBrandImageCommandRequest : IRequest<UpdateBrandImageCommandResponse>
    {
        public string Id { get; set; }
        public IFormFile formFile { get; set; }
    }
}