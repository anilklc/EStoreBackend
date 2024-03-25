using MediatR;
using Microsoft.AspNetCore.Http;

namespace EStoreBackend.Application.Features.Commands.BrandImage.CreateBrandImage
{
    public class CreateBrandImageCommandRequest : IRequest<CreateBrandImageCommandResponse>
    {
        public IFormFile fromFile { get; set; }
        public Guid BrandId { get; set; }
    }
}