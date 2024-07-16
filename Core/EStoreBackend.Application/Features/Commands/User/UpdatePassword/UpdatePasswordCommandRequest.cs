using MediatR;

namespace EStoreBackend.Application.Features.Commands.User.UpdatePassword
{
    public class UpdatePasswordCommandRequest : IRequest<UpdatePasswordCommandResponse>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PasswordConfrim { get; set; }
    }
}