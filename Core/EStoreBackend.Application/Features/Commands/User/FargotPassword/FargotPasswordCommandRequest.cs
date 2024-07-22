using MediatR;

namespace EStoreBackend.Application.Features.Commands.User.ForgotPassword
{
    public class ForgotPasswordCommandRequest : IRequest<ForgotPasswordCommandResponse>
    {
        public string Id { get; set; }
        public string ResetToken { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
    }
}