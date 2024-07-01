using MediatR;

namespace EStoreBackend.Application.Features.Commands.User.CreateUserAdmin
{
    public class CreateUserAdminCommandRequest : IRequest<CreateUserAdminCommandResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public string UserRole { get; set; } = "User";
    }
}