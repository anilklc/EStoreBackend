using MediatR;

namespace EStoreBackend.Application.Features.Commands.About.UpdateAbout
{
    public class UpdateAboutCommandRequest : IRequest<UpdateAboutCommandResponse>
    {
        public string Id { get; set; }
        public string AboutTitle { get; set; }
        public string AboutDescription { get; set; }
        public string AboutIcon { get; set; }
    }
}