using MediatR;

namespace EStoreBackend.Application.Features.Commands.SocialMedia.CreateSocialMedia
{
    public class CreateSocialMediaCommandRequest : IRequest<CreateSocialMediaCommandResponse>
    {
        public string SocialMediaName { get; set; }
        public string SocialMediaUrl { get; set; }
        public string SocialMediaIcon { get; set; }
    }
}