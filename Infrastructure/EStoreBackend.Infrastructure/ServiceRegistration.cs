using EStoreBackend.Application.Interfaces;
using EStoreBackend.Application.Interfaces.Repositories;
using EStoreBackend.Infrastructure.Helpers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {      
            services.AddScoped<IFileHelper, FileHelper>();
        }
    }
}
