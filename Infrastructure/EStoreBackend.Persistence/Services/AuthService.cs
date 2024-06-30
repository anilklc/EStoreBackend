using EStoreBackend.Application.DTOs.Token;
using EStoreBackend.Application.Interfaces.Mail;
using EStoreBackend.Application.Interfaces;
using EStoreBackend.Application.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EStoreBackend.Domain.Entities.Identity;
using EStoreBackend.Application.Exceptions;

namespace EStoreBackend.Persistence.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;
        private readonly IMailService _mailService;

        public AuthService(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signInManager, IUserService userService = null, IMailService mailService = null)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signInManager = signInManager;
            _userService = userService;
            _mailService = mailService;
        }

        public async Task<Token> LoginAsync(string email, string password)
        {
            AppUser? user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                throw new NotFoundUserException();
            }
            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
            if (result.Succeeded)
            {
                var roles = await _userManager.GetRolesAsync(user);
                Token token = _tokenService.CreateToken(user , roles);
                await _userService.UpdateRefreshTokenAsync(token.RefreshToken, user, token.Expiration, 15);
                return token;

            }

            throw new AuthenticationErrorException();
        }

        public async Task<IList<string>> RoleControl(string email)
        {
            AppUser? user = await _userManager.FindByEmailAsync(email);
            var roleControl = await _userManager.GetRolesAsync(user);
            return roleControl;
        }

        public async Task<Token> RefreshTokenLoginAsync(string refreshToken)
        {
            AppUser? user = _userManager.Users.FirstOrDefault(u => u.RefreshToken == refreshToken);
            if (user != null && user.RefreshTokenEndDate > DateTime.UtcNow)
            {
                var roles = await _userManager.GetRolesAsync(user);
                Token token = _tokenService.CreateToken(user, roles);
                await _userService.UpdateRefreshTokenAsync(token.RefreshToken, user, token.Expiration, 15);
                return token;
            }
            else
            {
                throw new NotFoundUserException();
            }
        }

        public async Task PasswordResetAsync(string email)
        {
            AppUser? user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                string resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
                byte[] tokenBytes = Encoding.UTF8.GetBytes(resetToken);
                resetToken = WebEncoders.Base64UrlEncode(tokenBytes);
                await _mailService.SendPasswordResetMailAsync(email, user.Id.ToString(), resetToken);
            }
        }
        public async Task<bool> VerifyResetTokenAsync(string resetToken, string userId)
        {
            AppUser user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                byte[] tokenBytes = WebEncoders.Base64UrlDecode(resetToken);
                resetToken = Encoding.UTF8.GetString(tokenBytes);
                return await _userManager.VerifyUserTokenAsync(user,
                    _userManager.Options.Tokens.PasswordResetTokenProvider, "ResetToken", resetToken);
            }
            return false;
        }
    }
}
