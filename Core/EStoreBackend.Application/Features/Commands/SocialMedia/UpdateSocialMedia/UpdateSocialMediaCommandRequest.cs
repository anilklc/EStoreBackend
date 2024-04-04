using MediatR;

namespace EStoreBackend.Application.Features.Commands.SocialMedia.UpdateSocialMedia
{
    public class UpdateSocialMediaCommandRequest : IRequest<UpdateSocialMediaCommandResponse>
    {
        public string Id { get; set; }
        public string SocialMediaName { get; set; }
        public string SocialMediaUrl { get; set; }
        public string SocialMediaIcon { get; set; }
    }
}