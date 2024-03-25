using MediatR;

namespace EStoreBackend.Application.Features.Commands.BrandImage.RemoveBrandImage
{
    public class RemoveBrandImageCommandRequest : IRequest<RemoveBrandImageCommandResponse>
    {
        public string Id { get; set; }
        public string ImagePath { get; set; }
    }
}