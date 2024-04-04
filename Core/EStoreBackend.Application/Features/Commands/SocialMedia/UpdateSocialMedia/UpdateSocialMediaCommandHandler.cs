using EStoreBackend.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Commands.SocialMedia.UpdateSocialMedia
{
    public class UpdateSocialMediaCommandHandler : IRequestHandler<UpdateSocialMediaCommandRequest, UpdateSocialMediaCommandResponse>
    {
        private readonly ISocialMediaReadRepository _socialMediaReadRepository;
        private readonly ISocialMediaWriteRepository _socialMediaWriteRepository;

        public UpdateSocialMediaCommandHandler(ISocialMediaReadRepository socialMediaReadRepository, ISocialMediaWriteRepository socialMediaWriteRepository)
        {
            _socialMediaReadRepository = socialMediaReadRepository;
            _socialMediaWriteRepository = socialMediaWriteRepository;
        }

        public async Task<UpdateSocialMediaCommandResponse> Handle(UpdateSocialMediaCommandRequest request, CancellationToken cancellationToken)
        {
            var socialMedia = await _socialMediaReadRepository.GetByIdAsync(request.Id);
            socialMedia.SocialMediaName = request.SocialMediaName;
            socialMedia.SocialMediaUrl = request.SocialMediaUrl;
            socialMedia.SocialMediaIcon = request.SocialMediaIcon;
            await _socialMediaWriteRepository.SaveAsync();
            return new();
        }
    }
}