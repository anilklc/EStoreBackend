using MediatR;
using Microsoft.AspNetCore.Http;

namespace EStoreBackend.Application.Features.Commands.Prdouct.UpdateProductCoverImage
{
    public class UpdateProductCoverImageCommandRequest : IRequest<UpdateProductCoverImageCommandResponse>
    {
        public string Id { get; set; }
        public IFormFile formFile { get; set; }
    }
}