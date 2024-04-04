using MediatR;

namespace EStoreBackend.Application.Features.Commands.SocialMedia.RemoveSocialMedia
{
    public class RemoveSocialMediaCommandRequest : IRequest<RemoveSocialMediaCommandResponse>
    {
        public string Id { get; set; }
    }
}