using EStoreBackend.Application.DTOs.User;
using EStoreBackend.Application.Interfaces.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Commands.User.CreateUserAdmin
{
    public class CreateUserAdminCommandHandler : IRequestHandler<CreateUserAdminCommandRequest, CreateUserAdminCommandResponse>
    {
        private readonly IUserService _userService;

        public CreateUserAdminCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<CreateUserAdminCommandResponse> Handle(CreateUserAdminCommandRequest request, CancellationToken cancellationToken)
        {
            if (IsAuthorizedToCreate(request))
            {
                CreateUserResponse response = await _userService.CreateAsync(new()
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    Phone = request.Phone,
                    Username = request.Username,
                    Password = request.Password,
                    PasswordConfirm = request.PasswordConfirm,
                });
                if (response.Succeeded)
                    await _userService.AddRole(request.Email, request.UserRole);
                return new()
                {
                    Message = response.Message,
                    Succeeded = response.Succeeded,
                };
            }


                throw new Exception("User not created");
        }

        private bool IsAuthorizedToCreate(CreateUserAdminCommandRequest request)
        {
            return (request.AuthorizedRole.Equals("Admin") && request.UserRole.Equals("Editor") || 
                request.Authorized.Equals("admin"));
        }
    }
}
