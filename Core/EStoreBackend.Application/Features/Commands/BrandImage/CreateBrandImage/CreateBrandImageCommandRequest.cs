using MediatR;
using Microsoft.AspNetCore.Http;

namespace EStoreBackend.Application.Features.Commands.BrandImage.CreateBrandImage
{
    public class CreateBrandImageCommandRequest : IRequest<CreateBrandImageCommandResponse>
    {
        public IFormFile FormFile { get; set; }
        public string BrandId { get; set; }
    }
}