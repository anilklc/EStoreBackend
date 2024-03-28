using MediatR;

namespace EStoreBackend.Application.Features.Commands.About.RemoveAbout
{
    public class RemoveAboutCommandRequest : IRequest<RemoveAboutCommandResponse>
    {
        public string Id { get; set; }
    }
}