using MediatR;

namespace EStoreBackend.Application.Features.Queries.SocialMedia.GetByIdSocialMedia
{
    public class GetByIdSocialMediaQueryRequest :  IRequest<GetByIdSocialMediaQueryResponse>
    {
        public string Id { get; set; }
    }
}