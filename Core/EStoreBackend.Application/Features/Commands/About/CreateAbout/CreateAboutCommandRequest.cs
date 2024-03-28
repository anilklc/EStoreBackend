using MediatR;

namespace EStoreBackend.Application.Features.Commands.About.CreateAbout
{
    public class CreateAboutCommandRequest :  IRequest<CreateAboutCommandResponse>
    {
        public string AboutTitle { get; set; }
        public string AboutDescription { get; set; }
        public string AboutIcon { get; set; }
    }
}