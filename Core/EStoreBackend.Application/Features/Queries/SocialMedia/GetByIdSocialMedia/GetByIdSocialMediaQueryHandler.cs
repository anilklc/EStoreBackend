using EStoreBackend.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Queries.SocialMedia.GetByIdSocialMedia
{
    public class GetByIdSocialMediaQueryHandler : IRequestHandler<GetByIdSocialMediaQueryRequest, GetByIdSocialMediaQueryResponse>
    {
        private readonly ISocialMediaReadRepository _socialMediaReadRepository;

        public GetByIdSocialMediaQueryHandler(ISocialMediaReadRepository socialMediaReadRepository)
        {
            _socialMediaReadRepository = socialMediaReadRepository;
        }

        public async Task<GetByIdSocialMediaQueryResponse> Handle(GetByIdSocialMediaQueryRequest request, CancellationToken cancellationToken)
        {
            var socialMedia = await _socialMediaReadRepository.GetByIdAsync(request.Id);
            return new()
            {
                Id = request.Id,
                SocialMediaName = socialMedia.SocialMediaName,
                SocialMediaUrl = socialMedia.SocialMediaUrl,
                SocialMediaIcon = socialMedia.SocialMediaIcon,
            };
        }
    }
}
