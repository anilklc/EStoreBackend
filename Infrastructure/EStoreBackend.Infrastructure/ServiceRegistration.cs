using EStoreBackend.Application.Interfaces;
using EStoreBackend.Application.Interfaces.Mail;
using EStoreBackend.Application.Interfaces.Repositories;
using EStoreBackend.Infrastructure.Helpers;
using EStoreBackend.Infrastructure.Services.Mail;
using EStoreBackend.Infrastructure.Services.Token;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IFileHelper, FileHelper>();
            services.AddScoped<IMailService, MailService>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).
              AddJwtBearer("Admin", options =>
              {
                 options.TokenValidationParameters = new()
                 {
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     ValidateLifetime = true,
                     ValidateIssuerSigningKey = true,

                     ValidAudience = configuration["Token:Audience"],
                     ValidIssuer = configuration["Token:Issuer"],
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Token:Secret"])),
                     LifetimeValidator = (notBefore, expires, securityToken, validationParameters) => expires != null ? expires > DateTime.UtcNow : false,
                     NameClaimType = ClaimTypes.Name,
                     RoleClaimType = ClaimTypes.Role,

                 };
              });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy =>
                {
                    policy.AuthenticationSchemes.Add("Admin");
                    policy.RequireRole("Admin");
                });
                options.AddPolicy("EditorOrAdmin", policy =>
                {
                    policy.AuthenticationSchemes.Add("Admin");
                    policy.RequireRole("Editor", "Admin");
                });
                options.AddPolicy("User", policy =>
                {
                    policy.AuthenticationSchemes.Add("Admin");
                    policy.RequireRole("User");
                });

            });
        }
    }
}
