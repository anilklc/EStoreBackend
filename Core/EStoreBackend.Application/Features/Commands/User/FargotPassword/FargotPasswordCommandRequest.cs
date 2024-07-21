using MediatR;

namespace EStoreBackend.Application.Features.Commands.User.FargotPassword
{
    public class FargotPasswordCommandRequest : IRequest<FargotPasswordCommandResponse>
    {
        public string Id { get; set; }
        public string ResetToken { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
    }
}