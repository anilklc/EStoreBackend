﻿using EStoreBackend.Application.DTOs.Token;

namespace EStoreBackend.Application.Features.Commands.User.LoginUser
{
    public class LoginUserCommandResponse
    {
    }
    public class LoginUserSuccessCommandResponse : LoginUserCommandResponse
    {
            public Token Token { get; set; }
    }
    public class LoginUserErrorCommandResponse : LoginUserCommandResponse
    {
            public string Message { get; set; }
    }
    
}